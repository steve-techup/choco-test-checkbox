using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Resources;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Caretag_Class.Exceptions;
using Caretag_Class.Model;
using Caretag_Class.ReactiveUI;
using Caretag_Class.Util;
using ImageMagick;
using Main.ReactiveUI.Interactions;
using Microsoft.VisualBasic.FileIO;
using ReactiveUI;
using Surgical_Admin.Interactions;
using Z.EntityFramework.Plus;
using SearchOption = System.IO.SearchOption;

namespace AdminStation.Services;

public class CSVImportService
{
    private readonly CommonInteractions _commonInteractions;
    private readonly CaretagModel _dbContext;
    private readonly ResourceManager _localRm = new("Surgical_Admin.WinFormStrings", typeof(CSVImportService).Assembly);

    private List<FileInfo>? allImages;

    public CSVImportService(CaretagModel dbContext, CommonInteractionsFactory commonInteractionsFactory,
        IScheduler? scheduler = null)
    {
        _dbContext = dbContext;
        _commonInteractions = commonInteractionsFactory.Create(scheduler ?? RxApp.MainThreadScheduler);
    }

    public DataTable Load(string csv_file_path, string delimiter)
    {
        var csvData = new DataTable();

        try
        {
            using var csvReader = new TextFieldParser(csv_file_path);
            if (string.IsNullOrEmpty(delimiter))
            {
                _commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments
                {
                    Options = CaretagMessageBoxOptions.Ok,
                    Title = _localRm.GetString("Error"),
                    Message = _localRm.GetString("Please choose a delimiter. ")
                }).Subscribe();
                return null;
            }

            csvReader.SetDelimiters(delimiter);
            csvReader.HasFieldsEnclosedInQuotes = true;
            //read column  
            var colFields = csvReader.ReadFields();
            if (colFields.Length <= 1)
            {
                _commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments
                {
                    Options = CaretagMessageBoxOptions.Ok,
                    Title = _localRm.GetString("Error"),
                    Message = _localRm.GetString("Unmatched delimiter! Please choose a different delimiter.")
                }).Subscribe();
                return null;
            }

            foreach (var column in colFields)
            {
                var datecolumn = new DataColumn(column);
                datecolumn.AllowDBNull = true;
                csvData.Columns.Add(datecolumn);
            }

            while (!csvReader.EndOfData)
            {
                string[] fieldData = csvReader.ReadFields();
                for (var i = 0; i < fieldData.Length; i++)
                    if (fieldData[i] == "")
                        fieldData[i] = null;
                csvData.Rows.Add(fieldData);
            }

            return csvData;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    private string getRowStringValue(DataRow dr, string columnName)
    {
        if (columnName == null || string.IsNullOrWhiteSpace(columnName) || dr[columnName] == null ||
            dr[columnName] == DBNull.Value || string.IsNullOrWhiteSpace(dr[columnName].ToString())) return null;

        return dr[columnName].ToString();
    }

    private int? convertToInt(string s)
    {
        return int.TryParse(s, out var result) ? result : null;
    }

    private bool convertToBool(string? s)
    {
        if (s == null) return false;
        switch (s.ToLower())
        {
            case "1":
            case "true":
            case "yes":
                return true;
            default:
                return false;
        }
    }


    private string? SearchForImageWithLongestPrefix(string instrumentDescription, string imageDirectory,
        string searchPattern)
    {
        string[] extensions = {".jpg", ".tiff", ".bmp", ".png", ".tif"};

        allImages ??= Directory.EnumerateFiles(imageDirectory, "*.*", SearchOption.AllDirectories)
            .Where(s => extensions.Any(s.EndsWith)).Select(s => new FileInfo(s)).ToList();

        var candidates = allImages
            .Where(s => s.Name.StartsWith(instrumentDescription)).ToList();

        var file = candidates.FirstOrDefault(f => Regex.IsMatch(f.Name, searchPattern));
        if (file != null)
            return file.FullName;

        return candidates
            .OrderBy(f => f.Length).FirstOrDefault()?.FullName;
    }

    public async Task SaveInDatabase(DataTable fileDataTable, ColumnNames columnNames, Action<int> reportProgress,
        bool imageAutoSearch, string imageSearchPattern, string currentDirectory)
    {
        var processedItemsCount = 0;
        var totalItemsCount = fileDataTable.Rows.Count;

        var trays = new CachingRepository<Tray_Description, string>(_dbContext.Tray_Description);
        var instruments = new CachingRepository<Instrument_Description, string>(_dbContext.Instrument_Description);
        var images = new CachingRepository<Instrument_Image, string>(_dbContext.Instrument_Image);
        var vendors = new CachingRepository<Instrument_Vendor, int?>(_dbContext.Instrument_Vendor);
        var vendorNamesToId = new Dictionary<string, int>();
        var overwriteAllImages = false;
        var overwriteAllInstruments = false;
        var overwriteAllTrays = false;

        // wait for all trays to be loaded
        foreach (var dr in fileDataTable.AsEnumerable())
        {
            var row = new Row
            {
                SetName = getRowStringValue(dr, columnNames.SetName),
                Quantity = convertToInt(getRowStringValue(dr, columnNames.Quantity)),
                Description = getRowStringValue(dr, columnNames.Description),
                ImageUrl = getRowStringValue(dr, columnNames.ImageUrl),
                DescriptionId = getRowStringValue(dr, columnNames.DescriptionId),
                VendorIdOrName = getRowStringValue(dr, columnNames.VendorId),
                Untaggable = convertToBool(getRowStringValue(dr, columnNames.Untaggable))
            };

            if (row.DescriptionId == null)
            {
                await _commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments
                {
                    Options = CaretagMessageBoxOptions.Ok,
                    Title = "Error",
                    Message =
                        "Row without instrument type identifier (description ID). This is required to identify the instrument type. Please check your CSV file."
                });
                throw new CaretagApplicationException(
                    "Row without instrument type identifier (description ID). This is required to identify the instrument type. Please check your CSV file.");
            }

            var instrumentDescription = instruments.Get(m => m.Description_ID == row.DescriptionId, row.DescriptionId);

            var vendorId = convertToInt(row.VendorIdOrName);
            if (vendorId == null) //Try to do a db lookup for the id
            {
                if (vendorNamesToId.ContainsKey(row.VendorIdOrName))
                {
                    vendorId = vendorNamesToId[row.VendorIdOrName];
                }
                else
                {
                    vendorId = _dbContext.Instrument_Vendor.FirstOrDefault(v =>
                        v.Vendor_Name.ToLower().StartsWith(row.VendorIdOrName.ToLower())).Vendor_ID;
                    if (vendorId != null)
                        vendorNamesToId[row.VendorIdOrName] = vendorId.Value;
                }
            }

            var vendor = vendorId != null ? vendors.Get(m => m.Vendor_ID == vendorId, vendorId) : null;

            if (row.Description == null && instrumentDescription == null)
            {
                await _commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments
                {
                    Options = CaretagMessageBoxOptions.Ok,
                    Title = "Error",
                    Message =
                        "Description is required for instruments not existing in database. Please check your CSV file. Instrument id was: " +
                        row.DescriptionId
                });
                throw new CaretagApplicationException(
                    "Description is required for instruments not existing in database. Please check your CSV file. Instrument id was: " +
                    row.DescriptionId);
            }

            if (instrumentDescription == null ||
                instruments.GetState(instrumentDescription.Description_ID) != CacheState.Updated)
            {
                //save description
                if (instrumentDescription == null)
                {
                    instrumentDescription = new Instrument_Description
                    {
                        Description_ID = row.DescriptionId
                    };
                    instruments.Add(instrumentDescription, instrumentDescription.Description_ID);
                }
                else if (!overwriteAllInstruments)
                {
                    // ask user for confirmation of overwriting description id
                    var result = await _commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments
                    {
                        Options = CaretagMessageBoxOptions.YesNoAll,
                        Title = "Warning",
                        Message = "Instrument description with id " + row.DescriptionId +
                                  " already exists. Do you want to overwrite it?"
                    });

                    Console.Write(result);
                    switch (result)
                    {
                        case CaretagMessageBoxResult.Yes:
                            break;
                        case CaretagMessageBoxResult.All:
                            overwriteAllInstruments = true;
                            break;
                        case CaretagMessageBoxResult.No:
                            continue;
                    }
                }

                instrumentDescription.Date_Changed = DateTime.Now;
                instrumentDescription.Description_Name = row.Description;
                instrumentDescription.Vendor_ID = vendorId ?? 678; //Return 678=unknown if no vendor id is provided
                instrumentDescription.Instrument_Company = vendor?.Vendor_Name ?? "Unknown";
                instrumentDescription.D = "";
                instrumentDescription.E = "";
                instrumentDescription.RfidUntaggable = row.Untaggable;
                processedItemsCount++;
                instruments.SetState(instrumentDescription.Description_ID, CacheState.Updated);
            }

            if (imageAutoSearch && !File.Exists(row.ImageUrl))
                row.ImageUrl = SearchForImageWithLongestPrefix(row.DescriptionId, currentDirectory, imageSearchPattern);

            var image = images.Get(i =>
                i.Description_ID == row.DescriptionId, row.DescriptionId);

            if (image == null || images.GetState(image.Description_ID) != CacheState.Updated)
                if (File.Exists(row.ImageUrl))
                {
                    if (image == null)
                    {
                        image = new Instrument_Image
                        {
                            Description_ID = row.DescriptionId
                        };
                        images.Add(image, image.Description_ID);
                    }
                    else if (!overwriteAllImages)
                    {
                        // ask user for confirmation of overwriting image
                        var result = await _commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments
                        {
                            Options = CaretagMessageBoxOptions.YesNoAll,
                            Title = "Warning",
                            Message = "Instrument image with id " + row.DescriptionId +
                                      " already exists. Do you want to overwrite it?"
                        });
                        switch (result)
                        {
                            case CaretagMessageBoxResult.Yes:
                                break;
                            case CaretagMessageBoxResult.All:
                                overwriteAllImages = true;
                                break;
                            case CaretagMessageBoxResult.No:
                                continue;
                        }
                    }

                    image.Date_Changed = DateTime.Now;

                    // Read image from file
                    using (var imageFile = new MagickImage(row.ImageUrl))
                    {
                        // Sets the output format to jpeg
                        imageFile.Format = MagickFormat.Jpeg;
                        imageFile.Resize(0, 300);
                        imageFile.Resize(300, 0);

                        // Create byte array that contains a jpeg file
                        image.TheImage = imageFile.ToByteArray();
                    }

                    images.SetState(image.Description_ID, CacheState.Updated);
                }
            //save image

            var now = DateTime.Now;

            var trayDescription =
                trays.Get(x => x.Tray_Name == row.SetName, row.SetName);

            if (trayDescription == null)
            {
                trayDescription = new Tray_Description
                {
                    Cost_ID = 0,
                    Date_Changed = now,
                    Deleted_Tray = false,
                    Tray_Description1 = "",
                    Hide_Tray = false,
                    Special_Text = "0",
                    Tray_Lock = true,
                    Tray_Name = row.SetName
                };
                trays.Add(trayDescription, trayDescription.Tray_Name);
            }
            else if (!overwriteAllTrays && trays.GetState(trayDescription.Tray_Name) != CacheState.Updated)
            {
                var result = await _commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments
                {
                    Options = CaretagMessageBoxOptions.YesNoAll,
                    Title = "Warning",
                    Message = "Tray with name " + row.SetName +
                              " already exists. Do you want to overwrite it?"
                });
                switch (result)
                {
                    case CaretagMessageBoxResult.Yes:
                        break;
                    case CaretagMessageBoxResult.All:
                        overwriteAllTrays = true;
                        break;
                    case CaretagMessageBoxResult.No:
                        continue;
                }
            }

            if (trays.GetState(trayDescription.Tray_Name) != CacheState.Updated)
                await _dbContext.Tray_PackList.Where(p => p.TrayDescription.Tray_Name == trayDescription.Tray_Name)
                    .DeleteAsync();

            var packlistEntry = new Tray_PackList
            {
                TrayDescription = trayDescription,
                Instrument_Descrip_ID = row.DescriptionId,
                Number = row.Quantity,
                Date_Changed = now
            };
            _dbContext.Tray_PackList.Add(packlistEntry);

            trays.SetState(trayDescription.Tray_Name, CacheState.Updated);

            reportProgress((int) Math.Min(100.0, 100.0 * ++processedItemsCount / totalItemsCount));
        }

        await _dbContext.SaveChangesAsync();
        reportProgress(100);
    }

    private class Row
    {
        public string Description;
        public string DescriptionId;
        public string ImageUrl;
        public int? Quantity;
        public string SetName;
        public bool Untaggable;
        public string VendorIdOrName;
    }

    public class ColumnNames
    {
        public string Description;
        public string DescriptionId;
        public string ImageUrl;
        public string Quantity;
        public string SetName;
        public string Untaggable;
        public string VendorId;
    }
}