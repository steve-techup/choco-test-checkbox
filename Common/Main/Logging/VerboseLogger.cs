using Caretag_Class.Model;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Main.Model.PackingList.Validation;
using Main.Model.PackingList;
using static Caretag_Class.ReactiveUI.ViewModels.TouchscreenPackingListViewModel;
using LanguageExt;

namespace Caretag_Class.Logging
{
    /// <summary>
    /// Used for creating verbose logs using the standard logging mechanism
    /// </summary>
    public class VerboseLogger
    {
        private readonly ILogger _logger;
        public VerboseLogger(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Log the server name, database name and the user of the database used
        /// </summary>
        /// <param name="connectionString"></param>
        public void LogDatabaseSettings(string connectionString)
        {
            try
            {
                var _connectionString = new SqlConnectionStringBuilder(connectionString);

                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("DATABASE CONNECTION SETTINGS");
                stringBuilder.AppendLine($"Server: {_connectionString?.DataSource}");
                stringBuilder.AppendLine($"Database: {_connectionString?.InitialCatalog}");
                stringBuilder.AppendLine($"User: {_connectionString?.UserID}");

                Log(stringBuilder.ToString());
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error ocurred while trying to create a new instance of SqlConnectionStringBuilder using the following connection string {connectionString}");
            }
        }

        /// <summary>
        /// Log the current application version
        /// </summary>
        /// <param name="applicationVersion"></param>
        public void LogApplicationVersion(string applicationVersion)
        {
            Log($"App Version: {applicationVersion}");
        }

        /// <summary>
        /// Log Checkbox Station scan results
        /// </summary>
        /// <param name="instrumentLifecycleRfids"></param>
        /// <param name="packingList"></param>
        /// <param name="tags"></param>
        public void LogScanResult(List<Instrument_RFID> instrumentLifecycleRfids, ValidatedPackingList packingList, List<string> tags)
        {
            if (instrumentLifecycleRfids != null)
            {
                var unknownTags = tags.Where(t => !instrumentLifecycleRfids.Select(i => i.EPC_Nr).Contains(t) && t != packingList.TrayEPC).ToList();

                foreach (var tag in unknownTags)
                {
                    Log($"EPC {tag}");
                }

                foreach (var instrument in instrumentLifecycleRfids)
                {
                    Log($"EPC {instrument.EPC_Nr} - {instrument.Description_ID} - {instrument.Description_Text}");
                }
            }

            if (packingList?.Tray != null)
            {
                var traySb = new StringBuilder();
                traySb.AppendLine($"EPC {packingList.TrayEPC} - Tray tag");
                traySb.AppendLine($"Last packed by: Admin (Admin Caretag)");
                traySb.AppendLine($"Tray definition: {packingList.Tray.Tray_Name}");
                traySb.AppendLine($"Instrument count: {packingList.Lines?.Sum(l => l.Expected)}");
                traySb.AppendLine($"Distinct instrument types: {packingList.Lines?.Count}");
                traySb.AppendLine();
                traySb.AppendLine($"Packing lines");

                foreach (var line in packingList.Lines)
                {
                    traySb.AppendLine($"{line.DescriptionId} - {line.Description} {string.Join(", ", line.Instruments?.Select(i => i.EPC_Nr).ToArray())} - {line.Expected}");
                }

                Log(traySb.ToString());
            }
        }

        /// <summary>
        /// Log Packing station scan results
        /// </summary>
        /// <param name="packingLog"></param>
        /// <param name="{"></param>
        /// <param name="session"></param>
        public void LogPacking(PackingLog packingLog, List<PackingListRowViewModel> packingLines, Guid? session)
        {
            if(packingLog != null)
            {
                var logBuilder = new StringBuilder();
                logBuilder.AppendLine($"Packing finished for session {session}");
                logBuilder.AppendLine();
                logBuilder.AppendLine($"Packed by user: {packingLog.PackedByUser?.FirstName} {packingLog.PackedByUser?.FamilyName}");
                logBuilder.AppendLine($"Tray EPC: {packingLog.TrayRfid?.EPC_Nr}");
                logBuilder.AppendLine($"Tray name: {packingLog.TrayRfid?.TrayDescription?.Tray_Name}");
                logBuilder.AppendLine($"Packed locked: {packingLog.PackedLocked}");
                logBuilder.AppendLine($"Expected instrument count: {packingLines?.Sum(pr => pr.Quantity)}");
                logBuilder.AppendLine($"Actual instruments count: {packingLog.TotalInstruments}");
                logBuilder.AppendLine($"Container EPC: {packingLog.ContainerRfid?.EPC_Nr}");
                logBuilder.AppendLine($"Cost center: {packingLog.CostLog?.CostItem?.CostCenter?.Cost_Center_Name}");
                logBuilder.AppendLine($"Sterilization lot number: {packingLog.SterilizationIndicatorLotNumber}");
                logBuilder.AppendLine();
                logBuilder.AppendLine($"Packing lines");
                logBuilder.AppendLine();

                foreach (var line in packingLines)
                {
                    var manuallyPacked = line.QuantityPackedManually > 0 ? $" - Manually packed quantity: {line.QuantityPackedManually}" : string.Empty;
                    var pcsLabel = line.Quantity > 1 ? "pcs" : "pc";
                    logBuilder.AppendLine(@$"{line.DescriptionId} - {line.Quantity} {pcsLabel} - {line.InstrumentDescription} - {string.Join(", ", line.PackedInstruments?.Select(i => i.EPC_Nr).ToArray())}{manuallyPacked}");
                }

                Log(logBuilder.ToString());
            }
        }

        /// <summary>
        /// Log a message
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
            _logger.Verbose(message);
        }
    }
}
