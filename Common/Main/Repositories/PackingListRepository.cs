using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Caretag_Class.Model;
using DynamicData;

namespace Caretag_Class.Repositories
{
    public enum ManualPackingState
    {
        Unpacked = 0,
        PackedManually = 1,
        HasTag = 2,
    }
    public class PackingListRow
    {
        public string DescriptionId { get; set; }
        public string InstrumentDescription { get; set; }
        public string InstrumentVendor { get; set; }
        public int Quantity { get; set; }
        public bool? PackedManually { get; set; }
    }

    public class PackedInstrument
    {
        public int Quantity { get; set; }
        public string DescriptionId { get; set; }
    }

    public class PackedInstrumentWithManualQuantity : PackedInstrument
    {
        public int QuantityPackedManually { get; set; }
    }


    public class PackingListRepository
    {
        private readonly CaretagModel _model;

        // Unit test only
        public PackingListRepository()
        {

        }

        public PackingListRepository(CaretagModel model)
        {
            _model = model;
        }

        public virtual List<Tray_Description> GetTraysForInstrument(Instrument_Description instrumentDescription)
        {
            return (from tray in _model.Tray_Description
                    join packConnection in _model.Tray_PackList on tray.Description_ID equals packConnection.Tray_Descrip_ID
                    where packConnection.Instrument_Descrip_ID == instrumentDescription.Description_ID
                    select tray).ToList();
        }

        public virtual List<PackedInstrumentWithManualQuantity> GetPackingListAsPackedFast(string trayEpc)
        {
            return
                (from packlistItem in _model.Tray_Packed
                 join desc in _model.Instrument_Description on packlistItem.Description_ID equals desc
                     .Description_ID
                 where packlistItem.Tray_EPC_Nr == trayEpc
                 select new { desc.Description_ID, packlistItem.QuantityPackedManually }).GroupBy(x => x).ToList()
                .Select(g =>
                    new PackedInstrumentWithManualQuantity { DescriptionId = g.Key.Description_ID, Quantity = g.Count(), QuantityPackedManually = g.Key.QuantityPackedManually }).ToList();
        }

        public virtual void ClearPackingListForTray(string trayEpc)
        {
            var packed = _model.Tray_Packed.Where(p => p.Tray_EPC_Nr == trayEpc).ToList();
            _model.Tray_Packed.RemoveRange(packed);
        }

        public virtual void AddPackingList(Tray_Description trayType, Tray_RFID tray, List<Instrument_RFID> taggedInstruments, List<PackedInstrument> untaggedPackedInstruments, int userID, int location, bool packedLocked)
        {
            _model.Tray_Packed.AddRange(taggedInstruments.Select(i => new Tray_Packed()
            {
                Description_ID = i.Description_ID,
                Date_Changed = DateTime.Now,
                EPC_Nr = i.EPC_Nr,
                Pack_Station_ID = location,
                Pack_User_ID = userID,
                TrayDescription = trayType,
                Tray_EPC_Nr = tray.EPC_Nr,
                Packed_Locked = packedLocked,
                Tray_Description_ID = trayType.Description_ID
            }));

            _model.Tray_Packed.AddRange(untaggedPackedInstruments.Select(untaggedInstrument => new Tray_Packed()
            {
                Description_ID = untaggedInstrument.DescriptionId,
                Date_Changed = DateTime.Now,
                EPC_Nr = null,
                QuantityPackedManually = untaggedInstrument.Quantity,
                Pack_Station_ID = location,
                Pack_User_ID = userID,
                TrayDescription = trayType,
                Tray_EPC_Nr = tray.EPC_Nr,
                Packed_Locked = packedLocked,
                Tray_Description_ID = trayType.Description_ID
            }));
        }

        public virtual List<PackingListRow> GetPackingListForRendering(int trayDescriptionId)
        {
            return GetPackingList(trayDescriptionId).Select(r => new PackingListRow()
            {
                InstrumentDescription = r.InstrumentDescription,
                Quantity = r.Quantity,
                DescriptionId = r.DescriptionId,
                PackedManually = !(r.PackedManually ?? true),
                InstrumentVendor = r.InstrumentVendor
            }).ToList();
        }

        public virtual List<PackingListRow> GetPackingList(int trayDescriptionId)
        {
            return
                (from packlistItem in _model.Tray_PackList
                 join vendor in _model.Instrument_Vendor on packlistItem.InstrumentDescription.Vendor_ID equals vendor.Vendor_ID
                 where packlistItem.Tray_Descrip_ID == trayDescriptionId
                 select new PackingListRow
                 {
                     DescriptionId = packlistItem.Instrument_Descrip_ID,
                     Quantity = packlistItem.Number ?? -1,

                     //String interpolation would be nice but is not supported by LINQ
                     InstrumentDescription = packlistItem.InstrumentDescription.Description_Name + " " + packlistItem.InstrumentDescription.D + " " + packlistItem.InstrumentDescription.E,
                     PackedManually = packlistItem.InstrumentDescription.RfidUntaggable ? false : null,
                     InstrumentVendor = vendor.Vendor_Name
                 }).ToList();
        }

        public virtual async Task<List<Tray_PackList>> GetUnpackedPacklistItems(Tray_Description tray, string trayEpcNr)
        {
            var packedInstruments = await _model.Tray_Packed.Where(tp => tp.Tray_EPC_Nr == trayEpcNr) 
                                                            .Select(tp => tp.Description_ID)
                                                            .Distinct()
                                                            .ToListAsync();

            var result = await _model.Tray_PackList.Where(pl => pl.Tray_Descrip_ID == tray.Description_ID && !packedInstruments.Contains(pl.Instrument_Descrip_ID))
                                             .Include(pl => pl.InstrumentDescription)
                                             .ToListAsync();


            return result;
        }
    }
}
