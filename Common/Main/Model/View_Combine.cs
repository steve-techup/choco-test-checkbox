namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Combine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(255)]
        public string Description_ID { get; set; }

        public short? Maintenance_Value { get; set; }

        public short? Maintenance_Periods { get; set; }

        public DateTime? Maintenance_Period_Start { get; set; }
    }
}
