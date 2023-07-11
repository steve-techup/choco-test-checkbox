namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Instrument_Translation_Log
    {
        [Key]
        public long Instrument_Translation_Log_ID { get; set; }

        public int? UserID { get; set; }

        [StringLength(50)]
        public string The_Item { get; set; }

        public DateTime? ChangeDate { get; set; }
    }
}
