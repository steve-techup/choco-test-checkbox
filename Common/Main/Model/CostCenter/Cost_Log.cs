namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    
    public class Cost_Log
    {
        [Key]
        public long Log_ID { get; set; }
        public long? The_Item_ID { get; set; }
        public long? CostItemId { get; set; }

        [ForeignKey("CostItemId")]
        public virtual Cost_Item CostItem{ get; set; }
        public string Extra_Text { get; set; }
        public DateTime? Used_Date { get; set; }
        public int? Reader_ID { get; set; }
        public DateTime? ChangeDate { get; set; }
        public int? TrayDescriptionId { get; set; }

        [ForeignKey("TrayDescriptionId")]
        public virtual Tray_Description? Tray_Description { get; set; }
    }
}
