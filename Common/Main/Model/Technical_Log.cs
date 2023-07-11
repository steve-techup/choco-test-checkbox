namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Technical_Log
    {
        [Key]
        public long Technical_Log_ID { get; set; }

        public int? UserID { get; set; }

        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [StringLength(50)]
        public string Description_ID { get; set; }

        [StringLength(50)]
        public string Technical_Type { get; set; }

        public DateTime? ChangeDate { get; set; }
    }
}
