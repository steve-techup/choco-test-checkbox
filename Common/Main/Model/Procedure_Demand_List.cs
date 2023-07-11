namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Procedure_Demand_List
    {
        [Key]
        [Column(Order = 0)]
        public long Demand_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Time_Arrived { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Priority { get; set; }

        public DateTime? Packed_Day { get; set; }

        public string Procedure_ID { get; set; }

        public string Note { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime Date_Changed { get; set; }

        public DateTime? Is_Used { get; set; }

        public string User_Name { get; set; }

        public DateTime? Desired_Date { get; set; }

        public int? Cost_Center_ID { get; set; }

        public bool? Sent_To_PackList { get; set; }
    }
}
