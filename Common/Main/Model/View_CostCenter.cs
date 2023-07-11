namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_CostCenter
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Index_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Cost_Center_Name { get; set; }

        public string Cost_Type { get; set; }

        public decimal? Cost_Price { get; set; }

        public bool? Hidden_Center { get; set; }

        public DateTime? Change_Date { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Cost_Center { get; set; }

        public long? Cost_Type_ID { get; set; }

        public bool? Default_Cost { get; set; }

        public string Cost_Center_Code { get; set; }

        public string Extra_Text { get; set; }

        public bool? Default_Always { get; set; }
    }
}
