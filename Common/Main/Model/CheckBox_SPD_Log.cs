namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CheckBox_SPD_Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Instrument_ID { get; set; }

        [StringLength(20)]
        public string CheckBox_Function { get; set; }

        public long? Area_ID { get; set; }

        public long? Tray_ID { get; set; }

        public bool? Tray_Locked { get; set; }

        public DateTime? ChangeDate { get; set; }

        public string SPD_Relation { get; set; }

        public string Ext_Machine_1 { get; set; }

        public string Ext_Machine_2 { get; set; }

        public string Ext_Machine_3 { get; set; }
    }
}
