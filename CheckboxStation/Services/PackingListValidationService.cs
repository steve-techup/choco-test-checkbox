using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class.Configuration;
using Caretag_Class.Model;
using Caretag_Class.Repositories;
using CheckboxStation.Configuration;
using Main.Model.PackingList.Validation;
using Microsoft.Extensions.DependencyInjection;
using RFIDAbstractionLayer.TagEncoding;

namespace CheckboxStation.Services
{
    public class PackingListValidationService
    {
        private readonly CaretagModel _model;
        private readonly CheckboxService _checkboxService;
        private readonly InstrumentService _instrumentService;
        private readonly AppSettingsBase _appSettingsBase;
        private readonly PackingListRepository _packingListService;
        private readonly CheckboxStationAppSettings _checkboxStationAppSettings;

        public PackingListValidationService(CaretagModel model, CheckboxService checkboxService,
            InstrumentService instrumentService, AppSettingsBase appSettingsBase, PackingListRepository packingListService,
            CheckboxStationAppSettings checkboxStationAppSettings)
        {
            _model = model;
            _checkboxService = checkboxService;
            _instrumentService = instrumentService;
            _appSettingsBase = appSettingsBase;
            _packingListService = packingListService;
            _checkboxStationAppSettings = checkboxStationAppSettings;
        }

        public PackingListValidationService()
        {

        }

        public virtual void Save(ValidatedPackingList validatedPackingList)
        {
            if (validatedPackingList.Id == 0)
                _model.ValidatedPackingList.Add(validatedPackingList);
            _model.SaveChanges();
        }

        public virtual ValidatedPackingList ValidatePackingList(List<string> tags, ValidatedPackingList? old)
        {
            tags = tags.Distinct().ToList();
            //   if (CaretagEPCPrefix != null)
            //       tags.RemoveAll(tag => !tag.StartsWith(CaretagEPCPrefix));

            var validTags = new List<string>();

            if (_checkboxStationAppSettings.Features.VerificationEnabled)
            {
                foreach(var tag in tags)
                {
                    try
                    {
                        var rfidEpc = new RfidEPC(tag);
                        if (rfidEpc.ValidCaretagEPC)
                            validTags.Add(tag);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {
                validTags = tags.Select(t => t).ToList();
            }

            ValidatedPackingList result;

            var manuallyPackedLines = new List<ValidatedPackingListLineItem>();

            if (old != null)
            {
                result = old;
                manuallyPackedLines.AddRange(old.Lines.Where(l => l.PackedManually));
                result.Lines.Clear();
            }

            else
                result = new ValidatedPackingList
                {
                    Location = _appSettingsBase.StationUniqueID
                };

            var rawTrays = _checkboxService.GetTrays(validTags);

            var trays = rawTrays.Select(tray => tray.TrayDescription).Distinct().ToList();
            var instruments = _instrumentService.GetByTagsWithOperationAndDescriptionAndPopulateServiceRequests(validTags);
            var unknownTags = validTags.Where(tag => instruments.All(i => i.EPC_Nr != tag) && rawTrays.All(t => t.Tray_EPC_Nr != tag));

            var groupedInstruments = instruments.GroupBy(i => i.Description_ID);

            void CorrectManuallyPackedLines()
            {
                // replace any old manually packed lines
                result.Lines.ForEach(l =>
                {
                    var manualLine = manuallyPackedLines.FirstOrDefault(mp => mp.DescriptionId == l.DescriptionId);
                    if (manualLine != null)
                    {
                        l.PackedManually = true;
                        l.Actual = manualLine.Actual;
                    }
                });
            }

            if (trays.Count != 1)
            {
                result.Result = trays.Count == 0 ? ValidatedPackingList.PackingListState.NoTray : ValidatedPackingList.PackingListState.MoreThanOneTray;
                result.Lines.AddRange(groupedInstruments.Select(gi => new ValidatedPackingListLineItem
                {
                    Instruments = gi.ToList(),
                    Actual = gi.Count(),
                    Expected = 0,
                    DescriptionId = gi.FirstOrDefault()?.Description_ID,
                    InstrumentDescription = gi.FirstOrDefault()?.InstrumentDescription,
                    Description =
                        $"{gi.FirstOrDefault()?.InstrumentDescription?.Description_Name ?? "Unknown"} {gi.FirstOrDefault()?.InstrumentDescription?.D ?? ""} {gi.FirstOrDefault()?.InstrumentDescription?.E ?? ""}",
                }));
                CorrectManuallyPackedLines();
            }
            else if (trays.Count == 1)
            {
                try
                {
                    var scannedTrayType = trays.First();
                    result.TrayEPC = rawTrays.First().Tray_EPC_Nr;
                    var packingListAsPacked = _packingListService.GetPackingListAsPackedFast(rawTrays.First().Tray_EPC_Nr);

                    result.Lines.AddRange(packingListAsPacked.Select(p =>
                    {
                        var instrumentDescription = _instrumentService.GetDescription(p.DescriptionId);
                        return new ValidatedPackingListLineItem
                        {
                            Actual = groupedInstruments.Where(g => g.Key == p.DescriptionId).Sum(i => i.Count()),
                            Expected = p.Quantity,
                            Instruments = instruments.Where(i => p.DescriptionId == i.Description_ID).ToList(),
                            DescriptionId = p.DescriptionId,
                            InstrumentDescription = instrumentDescription,
                            Description = $"{instrumentDescription?.Description_Name ?? "Unknown"} {instrumentDescription?.D ?? ""} {instrumentDescription?.E ?? ""}",
                            PackedManually = p.QuantityPackedManually > 0
                        };
                    }));

                    var extraInstruments = groupedInstruments
                        .Where(gi => !result.Lines.Any(row => row.DescriptionId == gi.Key) || !gi.Any()).ToList();

                    if (extraInstruments.Any())
                        result.Lines.AddRange(extraInstruments
                            .Select(gi =>
                            {
                                var instrumentDescription = gi.FirstOrDefault()?.InstrumentDescription;
                                return new ValidatedPackingListLineItem
                                {
                                    Instruments = gi.ToList(),
                                    Actual = gi.Count(),
                                    Expected = 0,
                                    DescriptionId = gi.First().Description_ID,
                                    InstrumentDescription = instrumentDescription,
                                    Description = $"{instrumentDescription?.Description_Name ?? "Unknown"} {instrumentDescription?.D ?? ""} {instrumentDescription?.E ?? ""}"
                                };
                            }));

                    result.Tray = scannedTrayType;

                    CorrectManuallyPackedLines();

                    result.ValidateResult();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
            if (unknownTags.Any())
                result.Lines.Add(new ValidatedPackingListLineItem()
                {
                    Instruments = new List<Instrument_RFID>(),
                    InstrumentDescription = null,
                    Actual = unknownTags.Count(),
                    DescriptionId = "Unknown",
                    Expected = 0,
                    Description = "Unknown"
                });


            return result;
        }

        public virtual List<Tray_PackList> GetUnpackedPacklistItems(Tray_Description tray, string trayEpcNr)
        {
            return _packingListService.GetUnpackedPacklistItems(tray, trayEpcNr);
        }


    }
}
