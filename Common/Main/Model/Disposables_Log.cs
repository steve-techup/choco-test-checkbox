namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Disposables_Log
    {
        [Key]
        public DateTime ChangeDate { get; set; }

        public long? Disposables_ID { get; set; }

        public string OR_Relation { get; set; }

        [StringLength(250)]
        public string Used_Place { get; set; }

        public string Disposables_External { get; set; }
    }
}
