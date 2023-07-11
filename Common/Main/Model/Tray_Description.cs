namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Tray_Description
    {
        [Key]
        [Column(TypeName = "bigint")]
        public int Description_ID { get; set; }

        [StringLength(50)]
        public string Tray_Name { get; set; }

        [Column("Tray_Description")]
        public string Tray_Description1 { get; set; }

        public bool? Tray_Lock { get; set; }

        public DateTime? Date_Changed { get; set; }

        public bool? Hide_Tray { get; set; }

        public bool? Deleted_Tray { get; set; }
        
        public long? Cost_ID { get; set; }

        [ForeignKey("Cost_ID")]
        public Cost_Item? CostItem { get; set; }
        public string Special_Text { get; set; }

        public ICollection<Tray_Image> Images { get; set; } 
        
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Tray_Description1))
                return Tray_Name;
            return Tray_Name + " - " + Tray_Description1;
        }
    }
}
