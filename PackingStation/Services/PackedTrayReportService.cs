using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Model.PackingList;
using PackingStation.Repositories;

namespace PackingStation.Services
{
    public class PackedTrayReportService
    {
        // Returns a human-readable report of the packed tray
        public List<Tuple<string, string>> ReportPackedTray(PackingLog packingListAsPacked)
        {
            var report = new List<Tuple<string, string>>
            {
                new("Sterilization Lot Number",
                    packingListAsPacked.SterilizationIndicatorLotNumber),
                new("Total Instrument Count",
                    packingListAsPacked.TotalInstruments.ToString()),
                new("Instrument Types", packingListAsPacked.TotalInstrumentTypes.ToString()),
                new("Packed as locked", packingListAsPacked.PackedLocked ? "Yes" : "No"),
                new("Packed in Container", packingListAsPacked.ContainerRfid != null ? "Yes" : "No"),
                new("Packed by", packingListAsPacked.PackedByUser.UserName),
                new("Packed on", packingListAsPacked.Timestamp.ToString()),
                new("Packing Set Name", packingListAsPacked.TrayDescription.Tray_Name),
                new("Cost Center", packingListAsPacked.CostLog != null ? packingListAsPacked.CostLog.CostItem.CostCenter.Cost_Center_Name : "N/A"),
                new("Cost Type", packingListAsPacked.CostLog != null ? packingListAsPacked.CostLog.CostItem.CostType.Cost_Type1 : "N/A"),
                new("Untagged instruments", packingListAsPacked.TotalPackedManually.ToString())
            };

            return report;
        }
    }
}
