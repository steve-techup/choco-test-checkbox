namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Instrument_Translation
    {
        [Key]
        public long Caretag_ID { get; set; }

        public string Description_Name { get; set; }

        public DateTime? ChangeDate { get; set; }

        [StringLength(50)]
        public string Vendor_ID_1 { get; set; }

        [StringLength(50)]
        public string Vendor_ID_2 { get; set; }
    }
}
