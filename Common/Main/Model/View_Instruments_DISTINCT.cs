namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Instruments_DISTINCT
    {
        [Key]
        [StringLength(255)]
        public string Description_ID { get; set; }

        [StringLength(255)]
        public string Description_Name { get; set; }

        [StringLength(255)]
        public string D { get; set; }

        [StringLength(255)]
        public string E { get; set; }

        [StringLength(255)]
        public string Instrument_Company { get; set; }

        [StringLength(765)]
        public string FullName { get; set; }
    }
}
