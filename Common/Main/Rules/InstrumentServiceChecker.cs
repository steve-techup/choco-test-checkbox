using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caretag_Class.Configuration;
using Caretag_Class.EventReporting;
using Caretag_Class.Model;
using Microsoft.VisualBasic;

namespace Caretag_Class.Rules
{
    /// <summary>
    /// Checks if an instrument needs servicing
    /// </summary>
    public class InstrumentServiceChecker
    {
        private readonly AppSettingsBase _appSettingsBase;
        private readonly EventReporter _eventReporter;


        public InstrumentServiceChecker(AppSettingsBase appSettingsBase, EventReporter eventReporter)
        {
            _appSettingsBase = appSettingsBase;
            _eventReporter = eventReporter;
        }

        public List<TriggeredRule> CheckServiceRequired(string EPC)
        {
            using var ctx = new CaretagModel(_appSettingsBase.ConnectionStrings.SQLServer);

            var alreadySentToService =
                (from life in ctx.Instrument_RFID_Life
                    where life.EPC_Nr == EPC && life.Sent_To_Service.HasValue && life.Sent_To_Service.Value
                    select new { life.EPC_Nr }).Any();

            if (alreadySentToService)
                return new List<TriggeredRule> { new() { AlreadySentToService = true, EPC = EPC } };

            var matchingRules = (from r in ctx.View_Rules_Status where r.EPC_Nr == EPC && r.Check_Ciffer >= r.Maintenance_Value && r.Maintenance_Value != 0
                select new {r.Check_Ciffer, r.Maintenance_Value, r.Maintenance_Text, r.EPC_Nr, r.Rules_ID, r.Description_ID, r.Maintenance_Period_Start}).ToList();

            return matchingRules.Select(r =>
                    r.Check_Ciffer.HasValue && r.EPC_Nr != null && r.Maintenance_Text != null && r.Maintenance_Value.HasValue && r.Rules_ID.HasValue
                        ? new TriggeredRule
                        {
                            Cycles = r.Check_Ciffer.Value, EPC = r.EPC_Nr,
                            MaintenanceInterval = r.Maintenance_Value.Value, RuleDescription = r.Maintenance_Text,
                            RuleId = r.Rules_ID.Value, InstrumentSKU = r.Description_ID, MaintenancePeriodStart = r.Maintenance_Period_Start
                        }
                        : null)
                .Where(r => r != null).ToList();
        }


        public void SetServiceStatusForInstrument(bool Do_Service, string epc, string ruleId, string instrumentSKU, string maintenancePeriodStart)
        {
            // Be aware that the logic is that each Rule can be sent to service separately

            try
            {
                string The_Number = SQLUtil.LookUpInDataBase("Instrument_Maintenance_RFID", " EPC_Nr='" + epc + "' AND Rules_ID ='" + ruleId + "'", "Maintenance_RFID_ID");
                if (The_Number.Contains("Not"))
                {
                    string str_SQL = "(EPC_Nr, Description_ID, Rules_ID,Maintenance_Period_Start, Check_Ciffer, Sendt_To_Service, Return_From_Service, Service_Date, ChangeDate) " + "VALUES ('" + epc + "','" + instrumentSKU + "','" + ruleId + "','" + maintenancePeriodStart + "' ,'1','" + Do_Service + "' ,'False' ,'" + Strings.Format(DateAndTime.Now, "yyyy-MM-dd HH:mm:ss") + "','" + Strings.Format(DateAndTime.Now, "yyyy-MM-dd HH:mm:ss") + "')";
                    SQLUtil.WriteToDatabase("Instrument_Maintenance_RFID", str_SQL, "Maintenance_RFID_ID");
                }
                else
                {
                    bool Updating = SQLUtil.UpdateToDatabase("Instrument_Maintenance_RFID", " Sendt_To_Service ='" + Do_Service + "', Return_From_Service ='False', ChangeDate ='" + Strings.Format(DateAndTime.Now, "yyyy-MM-dd HH:mm:ss") + "' WHERE Rules_ID='" + ruleId + "' AND EPC_Nr ='" + epc + "'");
                    if (!Updating)
                    {
                        throw new Exception("Updated Failed - Try Again ! ");
                    }
                }
                SQLUtil.UpdateToDatabase("Instrument_RFID_Life", " Sent_Service ='" + Strings.Format(DateAndTime.Now, "yyyy-MM-dd HH:mm:ss") + "', Sent_To_Service='True', Return_Service=NULL   WHERE EPC_Nr='" + epc + "'");

                string serviceCounter = SQLUtil.LookUpInDataBase_Empty("Instrument_RFID_Life", "EPC_Nr='" + epc + "'", "Number_Service");
                int num;
                if (int.TryParse(serviceCounter, out num))
                {
                    num += 1;
                    string str_SQL = "Number_Service='" + num + "'  WHERE EPC_Nr='" + epc + "'";
                    if (!SQLUtil.UpdateToDatabase("Instrument_RFID_Life", str_SQL))
                    {
                        throw new Exception("Update Last Seen  Instrument_RFID_Life  Failed:");
                    }
                }
                else
                {
                    string InsertSQL = " (Number_Service) VALUES('1')";
                    SQLUtil.WriteToDatabase("Instrument_RFID_Life", InsertSQL, "EPC_Nr");
                }
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex,
                    "An error occurred while performing database operations related to servicing the instrument",
                    "An error occurred while performing database operations related to servicing the instrument",
                    "Common-1", true, true);
            }
        }
    }

}
