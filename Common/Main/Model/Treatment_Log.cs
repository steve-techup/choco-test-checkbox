namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Treatment_Log
    {
        public long? Treatment_ID { get; set; }

        [StringLength(50)]
        public string EPC_Nr { get; set; }

        public long? Detail_ID { get; set; }

        [Key]
        [Column(Order = 0)]
        public long TreatLog_ID { get; set; }

        public int? UserID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime ChangeDate { get; set; }

        public long? Done_ID { get; set; }

        public DateTime? Start_Time { get; set; }
    }
}
