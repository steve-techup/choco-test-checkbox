namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tray_Log
    {
        [Key]
        public long Index_ID { get; set; }

        public long? Tray_ID { get; set; }

        public string Packed_Name { get; set; }

        [StringLength(50)]
        public string Tray_Packed_Place { get; set; }

        public DateTime? Tray_Packed_Start { get; set; }

        public DateTime? Tray_Packed_End { get; set; }

        public int? Number_Instruments { get; set; }

        public bool? Packed_Locked { get; set; }

        [StringLength(50)]
        public string Tray_EPC_Nr { get; set; }
    }
}
