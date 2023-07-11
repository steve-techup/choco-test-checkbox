namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Steril_Central
    {
        [Key]
        public int SterilCentral_ID { get; set; }

        [Required]
        public string Steril_Name { get; set; }

        public string Steril_Street_1 { get; set; }

        public string Steril_Street_2 { get; set; }

        [StringLength(50)]
        public string Steril_City { get; set; }

        [StringLength(50)]
        public string Steril_Zip_Code { get; set; }

        [StringLength(50)]
        public string Steril_Country { get; set; }

        public string Special_Text { get; set; }

        public byte[] The_Logo { get; set; }

        public DateTime? Changed_Date { get; set; }
    }
}
