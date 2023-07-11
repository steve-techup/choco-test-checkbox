namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lend_Log
    {
        public int? UserID { get; set; }

        public long? Lend_ID { get; set; }

        public bool? Lend_IN { get; set; }

        public bool? IN_OUT_Issue { get; set; }

        public string OR_Relation { get; set; }

        [Key]
        public DateTime ChangeDate { get; set; }
    }
}
