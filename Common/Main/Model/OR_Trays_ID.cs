namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OR_Trays_ID
    {
        [Key]
        public long Index_ID { get; set; }

        public long? OR_Procedure_ID { get; set; }

        public long? Tray_ID { get; set; }

        public int Numbers { get; set; }

        public DateTime? Date_Changed { get; set; }
    }
}
