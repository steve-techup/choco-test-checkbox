namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tray_PackList
    {
        [Key]
        public long Index_ID { get; set; }

        public int? Tray_Descrip_ID { get; set; }
        [ForeignKey("Tray_Descrip_ID")]
        public Tray_Description TrayDescription {
            get;
            set;
        }
        [ForeignKey("Instrument_Descrip_ID")]
        public Instrument_Description InstrumentDescription
        {
            get;
            set;
        }
        

        [StringLength(255)]
        public string Instrument_Descrip_ID { get; set; }

        public int? Number { get; set; }

        public DateTime? Date_Changed { get; set; }
    }
}
