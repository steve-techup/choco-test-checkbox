namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CheckBox_OR_Log
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [StringLength(50)]
        public string CheckBox_Function { get; set; }

        public long? Area_ID { get; set; }

        public long? Tray_ID { get; set; }

        public bool? Tray_Locked { get; set; }

        public string OR_Relation { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime ChangeDate { get; set; }

        public long? Total_OR_Time { get; set; }

        public long? Instr_OR_Time { get; set; }
    }
}
