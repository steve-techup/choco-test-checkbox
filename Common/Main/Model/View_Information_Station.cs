namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Information_Station
    {
        [StringLength(255)]
        public string Description_ID { get; set; }

        [StringLength(255)]
        public string Description_Name { get; set; }

        public DateTime? Demand_Service { get; set; }

        public DateTime? Sent_Service { get; set; }

        public DateTime? Return_Service { get; set; }

        public int? Number_Service { get; set; }

        public int? Used_In_OR { get; set; }

        public int? Passed_Steri { get; set; }

        public int? DaysInService { get; set; }

        public DateTime? Instrument_LastSeen_Date { get; set; }

        [Key]
        [StringLength(50)]
        public string EPC_Nr { get; set; }
    }
}
