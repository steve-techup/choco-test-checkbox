namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Service_Vendor
    {
        [Key]
        public int ServiceVendor_ID { get; set; }

        [Required]
        public string Vendor_Name { get; set; }

        public string Vendor_Street_1 { get; set; }

        public string Vendor_Street_2 { get; set; }

        [StringLength(50)]
        public string Vendor_City { get; set; }

        [StringLength(50)]
        public string Vendor_Zip_Code { get; set; }

        [StringLength(50)]
        public string Vendor_Country { get; set; }

        public string Special_Text { get; set; }

        public DateTime? Changed_Date { get; set; }
    }
}
