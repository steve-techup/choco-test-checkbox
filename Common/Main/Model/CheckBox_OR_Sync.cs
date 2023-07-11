namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CheckBox_OR_Sync
    {
        [Key]
        public long Index_ID { get; set; }

        public bool? Synchronization { get; set; }

        public long? Check_IN_ID { get; set; }

        public int? Check_IN_Number { get; set; }

        public DateTime? Check_IN_Start { get; set; }

        public DateTime? Check_IN_End { get; set; }

        public bool? Check_IN_Closed { get; set; }

        public long? Check_OUT_ID { get; set; }

        public int? Check_OUT_Number { get; set; }

        public DateTime? Check_OUT_Start { get; set; }

        public DateTime? Check_OUT_End { get; set; }

        public bool? Check_OUT_Closed { get; set; }

        public bool? Check_IN_Waiting { get; set; }

        [StringLength(50)]
        public string Check_IN_Light { get; set; }
    }
}
