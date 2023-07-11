namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_EPC_To_Tray
    {
        [Key]
        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [StringLength(255)]
        public string Description_Name { get; set; }

        [StringLength(255)]
        public string Instrument_Company { get; set; }

        [StringLength(255)]
        public string Description_ID { get; set; }

        public int? Number { get; set; }

        public int? Tray_Descrip_ID { get; set; }

        [StringLength(255)]
        public string Instrument_Descrip_ID { get; set; }

        public long? Index_ID { get; set; }

        [StringLength(50)]
        public string Tray_Name { get; set; }

        public string Tray_Description { get; set; }

        public bool? Tray_Lock { get; set; }

        public DateTime? Date_Changed { get; set; }
    }
}
