namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Instrument_Translation_Vendor
    {
        [Key]
        public long The_ID { get; set; }

        [StringLength(10)]
        public string The_Last_Vendor_Index { get; set; }

        public DateTime? ChangeDate { get; set; }

        [StringLength(50)]
        public string Vendor_Name_1 { get; set; }

        [StringLength(50)]
        public string Vendor_Name_2 { get; set; }
    }
}
