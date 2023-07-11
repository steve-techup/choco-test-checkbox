namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Gate_Log
    {
        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [Key]
        public DateTime Gate_Time { get; set; }

        [StringLength(50)]
        public string Gate_Place { get; set; }

        public long? Reader_ID { get; set; }
    }
}
