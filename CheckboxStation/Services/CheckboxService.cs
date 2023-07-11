using Caretag.Contracts.Api.v1;
using Caretag.Contracts.Core;
using Caretag_Class;
using Caretag_Class.Configuration;
using Caretag_Class.EventReporting;
using Caretag_Class.Exceptions;
using Caretag_Class.Model;
using CheckboxStation.Services.Bridge;
using CheckboxStation.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RFIDAbstractionLayer;
using RFIDAbstractionLayer.Readers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckboxStation.Services
{
    public class CheckboxService
    {
        private readonly CaretagModel _model;
        private readonly RFIDReaderCollection _rfidReaderCollection;
        private readonly EventReporter _eventReporter;
        private readonly ILogger<CheckboxViewModel> _logger;
        private readonly string CaretagEPCPrefix;
        private readonly AppSettingsBase _appSettings;
        private List<Operation> _operations;
        private readonly ISettingsApi _settingsApi;
        private readonly IScanService _scanService;


        public CheckboxService()
        {
        }

        public CheckboxService(
            RFIDReaderCollection rfidReaderCollection, 
            EventReporter eventReporter, 
            ILogger<CheckboxViewModel> logger, 
            AppSettingsBase appSettings,
            ISettingsApi settingsApi,
            IScanService scanService,
            CaretagModel model = null)
        {
            _model = model;
            _rfidReaderCollection = rfidReaderCollection;
            _eventReporter = eventReporter;
            _logger = logger;
            _operations = new List<Operation>();
            _appSettings = appSettings;
            _settingsApi = settingsApi;
            _scanService = scanService;

            if (!appSettings.UseApi)
            {
                CaretagEPCPrefix = model.EPC_Number_Serie.FirstOrDefault()?.Owner_Serie;
                _model.Database.Log = s => _logger.LogDebug(s);
            }
        }

        public virtual bool StartupShowSplash()
        {
            var formWelcome = new SplashScreen(Program.Kernel.GetRequiredService<AppSettingsBase>().StationUniqueID, "Checkbox Station");
            formWelcome.Icon = Properties.Resources.CaretagApplicationIcon;
            Application.CurrentCulture = new CultureInfo("en-US");


            formWelcome.Show();

            //try
            //{
            //    var connectionString = new SqlConnectionStringBuilder(Program.Kernel.GetRequiredService<AppSettingsBase>().ConnectionStrings.SQLServer);
            //    formWelcome.Message = WinFormStrings.MainForm_StartupShowSplash_Connecting_to_SQL_server__ + connectionString.DataSource;

            //    Program.Kernel.GetRequiredService<CaretagModel>().Database.Exists();
            //}
            //catch (Exception ex)
            //{
            //    _eventReporter.ReportError(ex, "An error occurred when trying to connect to the database. ",
            //        "An error occurred when trying to connect to the database.", "Checkbox-2", true, true);

            //    formWelcome.Close();
            //    return false;
            //}

            try
            {
                formWelcome.Message = WinFormStrings.MainForm_StartupShowSplash_Searching_for_RFID_reader____;

                RfIdConfig config = null;

                if (_appSettings.UseApi)
                {
                    Task.Run(async () =>
                    {
                        await _settingsApi.GetAppInstanceSettings().MatchAsync(
                           appInstanceResponse => {

                               var appInstanceRfidConfig = appInstanceResponse?.Settings?.CheckboxSetting?.Rfid;

                               if (appInstanceRfidConfig != null)
                               {

                                   config = new RfIdConfig
                                   {
                                       ReaderIpAddress = appInstanceRfidConfig.ReaderIpAddress,
                                       CachedPorts = appInstanceRfidConfig.CachedPorts?.ToList()
                                   };

                                   config.ReaderType = appInstanceRfidConfig.ReaderType switch
                                   {
                                       Caretag.Contracts.Enums.ReaderType.SimulationOnly => ReaderType.Simulator,
                                       Caretag.Contracts.Enums.ReaderType.NordicIdOnly => ReaderType.NordicIdOrCAEN,
                                       Caretag.Contracts.Enums.ReaderType.CaenOnly => ReaderType.NordicIdOrCAEN,
                                       Caretag.Contracts.Enums.ReaderType.ImpinjOnly => ReaderType.Impinj,
                                       _ => ReaderType.Simulator
                                   };
                               }

                               return Task.CompletedTask;
                           }, erorResponse => { return Task.CompletedTask; });
                    }).Wait();
                }

                if (config == null)
                {
                    config = _appSettings.RFID;
                }

                _rfidReaderCollection.ConnectAll(config);

            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred when trying to connect to the RFID reader. ", "An error occurred when trying to connect to the RFID reader.", "Checkbox-3", true, true);

                formWelcome.Close();
                return false;
            }

            if (_rfidReaderCollection.Count == 0)
            {
                _eventReporter.ReportError("An error occurred, no RFID reader was found. ", "An error occurred, no RFID reader was found.", "Checkbox-4", true, true);

                formWelcome.Close();
                return false;
            }

            formWelcome.Close();

            _rfidReaderCollection.Readers.ForEach(r => r.SetPower(PowerLevel.Highest));
            return true;
        }
        
        public virtual List<Tray_Packed> GetTrays(List<string> tags)
        {
            return _model.Tray_Packed.Where(i => tags.Contains(i.Tray_EPC_Nr))
                .Include(tp => tp.TrayDescription)
                .Distinct()
                .ToList();
        }

        public virtual void NewOperation(Operation operation)
        {
            if (!_appSettings.UseApi)
            {
                _model.Operation.Add(operation);
                _model.SaveChanges();
            }
            else
            {
                _operations.Add(operation);
            }
        }

        public virtual void Update<T>(T obj)
        {
            if (_model.Entry(obj).State == EntityState.Detached)
                throw new CaretagApplicationException("Object does not exist in database");
            _model.SaveChanges();
        }

        public virtual void Update<T>(IEnumerable<T> obj)
        {
            foreach (var o in obj)
            {
                if (_model.Entry(o).State == EntityState.Detached)
                    throw new CaretagApplicationException("Object does not exist in database");
            }
            _model.SaveChanges();
        }


        public virtual List<Operation> GetOperations(DateTime from, DateTime to, bool showFinishedOperations)
        {
            if (!_appSettings.UseApi)
            {
                return _model.Operation.Where(o => o.Timestamp >= from && o.Timestamp <= to && (o.State != OperationState.FINISHED.ToString() || showFinishedOperations))
                   .Include(o => o.OperationInstruments).ToList();
            }
            else
            {
                return _operations;
            }
        }

        public virtual List<IGrouping<string, Instrument_RFID>> GetInstrumentsForOperation(Operation operation)
        {
            _model.Entry(operation).Collection(o => o.OperationInstruments).Query()
                .Include(o => o.Instrument.InstrumentDescription).Load();

            return operation.OperationInstruments.Select(oi => oi.Instrument).GroupBy(i => i?.Description_ID ?? "Unknown Instrument").ToList();
        }
    }



}
