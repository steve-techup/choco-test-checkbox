namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Storage_Log
    {
        [Key]
        public long Log_ID { get; set; }

        [StringLength(50)]
        public string EPC_Nr { get; set; }

        public long? Tray_ID { get; set; }

        public long? Container_ID { get; set; }

        public bool? Returned { get; set; }

        public DateTime? Date_Changed { get; set; }
    }
}
