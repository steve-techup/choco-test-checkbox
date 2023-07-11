namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Instrument_Rules
    {
        [Key]
        public long Rules_ID { get; set; }

        [StringLength(255)]
        public string Description_ID { get; set; }

        public bool? Default_Rule { get; set; } = false;

        public string Maintenance_Text { get; set; }

        public short? Maintenance_Value { get; set; }

        public short? Maintenance_Periods { get; set; }

        public DateTime? Maintenance_Period_Start { get; set; }

        public bool? Maintenance_Alarm { get; set; } = true;

        public DateTime? ChangeDate { get; set; }

        public bool? Deleted { get; set; }
    }
}
