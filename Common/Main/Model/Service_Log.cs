namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Service_Log
    {
        [Key]
        public long Service_Log_ID { get; set; }

        public int? UserID { get; set; }

        [StringLength(50)]
        public string EPC_Nr { get; set; }

        public long? Rules_ID { get; set; }

        public int? ServiceVendor_ID { get; set; }

        public DateTime? ChangeDate { get; set; }
    }
}
