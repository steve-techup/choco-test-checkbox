using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caretag_Class;
using Caretag_Class.Configuration;
using Caretag_Class.EventReporting;
using Caretag_Class.Exceptions;
using Caretag_Class.Model;
using Caretag_Class.Model.Service;
using Microsoft.Extensions.DependencyInjection;
using RFIDAbstractionLayer;
using RFIDAbstractionLayer.Readers;
using Serilog;

namespace CheckboxStation.Services
{
    public class CheckboxService
    {
        private readonly CaretagModel _model;
        private readonly RFIDReaderCollection _rfidReaderCollection;
        private readonly EventReporter _eventReporter;
        private readonly ILogger _logger;
        private readonly string CaretagEPCPrefix;


        public CheckboxService()
        {
        }

        public CheckboxService(CaretagModel model, RFIDReaderCollection rfidReaderCollection, EventReporter eventReporter, ILogger logger)
        {
            _model = model;
            _rfidReaderCollection = rfidReaderCollection;
            _eventReporter = eventReporter;
            _logger = logger;

            CaretagEPCPrefix = model.EPC_Number_Serie.FirstOrDefault()?.Owner_Serie;
            _model.Database.Log = s => _logger.Debug(s);
        }

        public virtual bool StartupShowSplash()
        {
            var formWelcome = new SplashScreen(Program.Kernel.GetRequiredService<AppSettingsBase>().StationUniqueID, "Checkbox Station");
            formWelcome.Icon = Properties.Resources.Knowledge_Hub_TransP;
            Application.CurrentCulture = new CultureInfo("en-US");


            formWelcome.Show();

            try
            {
                var connectionString = new SqlConnectionStringBuilder(Program.Kernel.GetRequiredService<AppSettingsBase>().ConnectionStrings.SQLServer);
                formWelcome.Message = WinFormStrings.MainForm_StartupShowSplash_Connecting_to_SQL_server__ + connectionString.DataSource;

                Program.Kernel.GetRequiredService<CaretagModel>().Database.Exists();
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred when trying to connect to the database. ",
                    "An error occurred when trying to connect to the database.", "Checkbox-2", true, true);

                formWelcome.Close();
                return false;
            }

            try
            {
                formWelcome.Message = WinFormStrings.MainForm_StartupShowSplash_Searching_for_RFID_reader____;
                _rfidReaderCollection.ConnectAll();

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
            _model.Operation.Add(operation);
            _model.SaveChanges();
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
            return _model.Operation.Where(o => o.Timestamp >= from && o.Timestamp <= to && (o.State != OperationState.FINISHED.ToString() || showFinishedOperations))
               .Include(o => o.OperationInstruments).ToList();
        }

        public virtual List<IGrouping<string, Instrument_RFID>> GetInstrumentsForOperation(Operation operation)
        {
            _model.Entry(operation).Collection(o => o.OperationInstruments).Query()
                .Include(o => o.Instrument.InstrumentDescription).Load();

            return operation.OperationInstruments.Select(oi => oi.Instrument).GroupBy(i => i?.Description_ID ?? "Unknown Instrument").ToList();
        }
    }



}
