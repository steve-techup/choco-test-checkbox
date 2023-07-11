namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Sync_Missing
    {
        [Key]
        [StringLength(255)]
        public string Description_ID { get; set; }

        [StringLength(255)]
        public string Instrument_Company { get; set; }

        [StringLength(765)]
        public string Full_Name { get; set; }

        [StringLength(50)]
        public string Sync_ID { get; set; }

        public DateTime? Insert_Time { get; set; }

        [StringLength(50)]
        public string Insert_Place { get; set; }

        public bool? Read_Tag { get; set; }
    }
}
