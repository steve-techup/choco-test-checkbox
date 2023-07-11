namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SW_Update
    {
        [Key]
        [Column(Order = 0)]
        public long Index_ID { get; set; }

        public string Software_Name { get; set; }

        [Key]
        [Column(Order = 1)]
        public string SW_Path { get; set; }

        public bool? Mandatory { get; set; }

        public bool? Blocked_Use { get; set; }

        public int? Update_Time_Start { get; set; }

        public int? Update_Time_End { get; set; }

        [StringLength(50)]
        public string Update_Code { get; set; }

        public DateTime? Changed_Date { get; set; }
    }
}
