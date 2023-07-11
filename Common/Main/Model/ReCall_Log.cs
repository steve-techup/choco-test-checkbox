namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReCall_Log
    {
        [Key]
        public long Index_ID { get; set; }

        public string Log_Text { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        public DateTime? Changed_Date { get; set; }
    }
}
