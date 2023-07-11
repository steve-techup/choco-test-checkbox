using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Caretag_Class.Model;

namespace Main.Model.PackingList
{
    /// <summary>
    /// A packing is generated every time a tray is packed.
    /// It links instruments with a tray and, possibly a container, a cost center and a cost type at a moment in time
    /// </summary>
    public class PackingLog
    {
        [Key]
        public long Id { get; set; }
        public DateTime Timestamp { get; set; }

        public int TrayTypeId { get; set; }
        [ForeignKey("TrayTypeId")]
        public Tray_Description TrayDescription { get; set; }
        
        public long TrayRfidId { get; set; }
        [ForeignKey("TrayRfidId")]
        public Tray_RFID TrayRfid { get; set; }

        
        public virtual long? ContainerRfidId { get; set; }
        [ForeignKey("ContainerRfidId")]
        public virtual Container_RFID? ContainerRfid { get; set; }

        public virtual long? CostLogId { get; set; }
        [ForeignKey("CostLogId")]
        public virtual Cost_Log? CostLog { get; set; }

        public virtual ICollection<PackingLogLine> PackingLogLines { get; set; }

        public string SterilizationIndicatorLotNumber { get; set; }
        public bool PackedLocked { get; set; }
        
        public int TotalInstruments { get; set; }
        public int TotalInstrumentTypes { get; set; }
        public int TotalPackedManually { get; set; }
        public int PackedByUserId { get; set; }

        [ForeignKey("PackedByUserId")]
        public TblPassword PackedByUser { get; set; }
    }
}
