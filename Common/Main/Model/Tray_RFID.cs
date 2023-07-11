namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tray_RFID
    {
        [Key]
        public long Tray_ID { get; set; }

        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [StringLength(50)]
        public string SEQ_Nr { get; set; }

        public int? Description_ID { get; set; }
        [ForeignKey("Description_ID")]
        public Tray_Description TrayDescription { get; set; }

        public string Description_Text { get; set; }

        public int? Tray_Contents { get; set; }

        [StringLength(50)]
        public string Tray_LastSeen_Place { get; set; }

        public DateTime? Tray_LastSeen_Date { get; set; }

        public bool? Tray_InUse { get; set; }

        public DateTime? Date_Changed { get; set; }

        public DateTime? Packed_Date { get; set; }

        public string Special_Text { get; set; }
    }
}
