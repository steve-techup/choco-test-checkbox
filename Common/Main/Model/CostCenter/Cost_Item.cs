namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Cost_Item
    {
        [Key]
        [Column(Order = 0)]
        public long Index_ID { get; set; }
        
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Cost_Center { get; set; }

        public DateTime? Change_Date { get; set; }

        public long? Cost_Type_ID { get; set; }

        public bool? Default_Cost { get; set; }

        [ForeignKey("Cost_Center")]
        public virtual Cost_Center CostCenter { get; set; }
        [ForeignKey("Cost_Type_ID")]
        public virtual Cost_Type CostType { get; set; }

        public override string ToString()
        {
            return $"{CostCenter.Cost_Center_Name} - {CostType.Cost_Type1}";
        }
    }
}
