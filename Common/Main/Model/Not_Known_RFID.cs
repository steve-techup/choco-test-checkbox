namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Not_Known_RFID
    {
        [Key]
        public long Not_Known_ID { get; set; }

        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [StringLength(50)]
        public string Not_Known_LastSeen_Place { get; set; }

        public DateTime? Not_Known_LastSeen_Date { get; set; }

        public bool? Not_Known_InUse { get; set; }
    }
}
