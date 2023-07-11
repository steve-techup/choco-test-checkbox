namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Instrument_Vendor
    {
        [Key]
        public int Vendor_ID { get; set; }

        [Required]
        public string Vendor_Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Vendor_Abbreviation { get; set; }

        public DateTime? Last_Date_Change { get; set; }

        public int? Barcode_Prefix { get; set; }

        public int? Barcode_Suffix { get; set; }

        [StringLength(10)]
        public string Delimiter_Sign { get; set; }
    }
}
