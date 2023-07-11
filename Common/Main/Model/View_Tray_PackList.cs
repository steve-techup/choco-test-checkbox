namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Tray_PackList
    {
        public string Tray_Description { get; set; }

        [StringLength(50)]
        public string Tray_Name { get; set; }

        public int? Tray_Descrip_ID { get; set; }

        public int? Number { get; set; }

        [StringLength(255)]
        public string Description_Name { get; set; }

        [StringLength(255)]
        public string D { get; set; }

        [StringLength(255)]
        public string E { get; set; }

        [StringLength(255)]
        public string Description_ID { get; set; }

        [StringLength(255)]
        public string Instrument_Company { get; set; }

        [StringLength(767)]
        public string Full_Name { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Index_ID { get; set; }
    }
}
