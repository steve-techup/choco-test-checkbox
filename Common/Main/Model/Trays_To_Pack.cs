namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trays_To_Pack
    {
        [Key]
        [Column(Order = 0)]
        public long Tray_Pack_ID { get; set; }

        public DateTime? Arrived_Date { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Priority { get; set; }

        public DateTime? Desired_Date { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tray_ID { get; set; }

        public string Special_Text { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool Is_Taken_For_Pack { get; set; }

        public DateTime? Changed_Date { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool Pack_Done { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int User_ID { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Cost_Center_ID { get; set; }

        public int? Identity_Num { get; set; }

        public long? Demand_ID { get; set; }
    }
}
