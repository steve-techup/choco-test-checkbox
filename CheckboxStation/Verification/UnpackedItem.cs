using Caretag_Class.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckboxStation.Verification
{
    public class UnpackedItem : Tray_PackList
    {
        public int ManuallyPackedCount { get; set; }

        public static UnpackedItem FromTrayPacklistItem(Tray_PackList packListItem)
        {
            return new UnpackedItem
            {
                Index_ID = packListItem.Index_ID,
                Tray_Descrip_ID = packListItem.Tray_Descrip_ID,
                TrayDescription = packListItem.TrayDescription,
                InstrumentDescription = packListItem.InstrumentDescription,
                Instrument_Descrip_ID = packListItem.Instrument_Descrip_ID,
                Number = packListItem.Number,
                Date_Changed = packListItem.Date_Changed
            };
        }
    }
}
