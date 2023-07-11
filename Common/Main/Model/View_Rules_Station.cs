namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Rules_Station
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [StringLength(255)]
        public string Description_ID { get; set; }

        public string Maintenance_Text { get; set; }

        public short? Maintenance_Value { get; set; }

        public short? Maintenance_Periods { get; set; }

        public bool? Default_Rule { get; set; }

        public int? Check_Ciffer { get; set; }

        public bool? Check_Status { get; set; }

        public DateTime? Instrument_LastSeen_Date { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Maintenance_RFID_ID { get; set; }

        [StringLength(255)]
        public string Description_Name { get; set; }

        public bool? Sendt_To_Service { get; set; }

        public int? Service_Counter { get; set; }

        public bool? Return_From_Service { get; set; }

        public DateTime? Service_Date { get; set; }

        public int? Service_Diff { get; set; }

        public DateTime? Demand_Service { get; set; }

        public long? Rules_ID { get; set; }
    }
}
