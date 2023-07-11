namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// This class is used to represent a cost center.
    /// </summary>
    public partial class Cost_Center
    {
        [Key]
        public long Index_ID { get; set; }

        [Required]
        public string Cost_Center_Name { get; set; }

        public string Cost_Center_Code { get; set; }

        public bool? Hidden_Center { get; set; }

        public DateTime? Change_Date { get; set; }

        public string Extra_Text { get; set; }

        public bool? Default_Always { get; set; }

        public virtual ICollection<Cost_Item> CostItems { get; set; }

        public override string ToString()
        {
            return $"{Cost_Center_Name}[{Cost_Center_Code}]";
        }
    }
}
