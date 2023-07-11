using DevExpress.Xpo;
using MiniExcelLibs.Attributes;

namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Instrument_Description
    {
        [Key]
        [StringLength(255)]
        [DisplayName("Description Id")]
        public string Description_ID { get; set; }

        [StringLength(255)]
        [DisplayName("Vendor")]
        public string Instrument_Company { get; set; }

        [StringLength(255)]
        [DisplayName("Name")]
        public string Description_Name { get; set; }

        [StringLength(255)]
        [DisplayName("Description 1")]
        public string D { get; set; }

        [StringLength(255)]
        [DisplayName("Description 2")]
        public string E { get; set; }

        [DisplayName("Date Changed")]
        public DateTime? Date_Changed { get; set; }

        [ExcelIgnore]
        public long? Treatment_ID { get; set; }

        [DisplayName("Vendor Id")]
        public int Vendor_ID { get; set; }

        public string GetFullDescription()
        {
            return $"{Description_Name} {D} {E}";
        }

        [DisplayName("RFID Untaggable")]
        public bool RfidUntaggable { get; set; }

        [ExcelIgnore]
        public string? ParentDescriptionId { get; set; }

        [ForeignKey("ParentDescriptionId")]
        [ExcelIgnore]
        public virtual Instrument_Description? Parent { get; set; }
    }
}
