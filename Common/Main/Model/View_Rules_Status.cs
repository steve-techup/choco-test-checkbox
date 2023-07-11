namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Rules_Status
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Maintenance_RFID_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string EPC_Nr { get; set; }

        public int? Check_Ciffer { get; set; }

        public bool? Reset_Check_Ciffer { get; set; }

        public bool? Check_Status { get; set; }

        public bool? Sendt_To_Service { get; set; }

        public bool? Return_From_Service { get; set; }

        public int? Service_Counter { get; set; }

        public DateTime? Service_Date { get; set; }

        public DateTime? Maintenance_Period_Start { get; set; }

        public int? ServiceVendor_ID { get; set; }

        [StringLength(255)]
        public string Description_ID { get; set; }

        public DateTime? Demand_Service { get; set; }

        public string Maintenance_Text { get; set; }

        public short? Maintenance_Value { get; set; }

        public short? Maintenance_Periods { get; set; }

        public long? Rules_ID { get; set; }
    }
}
