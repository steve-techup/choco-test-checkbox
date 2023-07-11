namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reader_ErrorLog
    {
        [Key]
        public long ErrorLog_ID { get; set; }

        public int? Department_ID { get; set; }

        public long Reader_ID { get; set; }

        public string Error_Description { get; set; }

        public DateTime? ChangeDate { get; set; }

        [StringLength(50)]
        public string IP_Address { get; set; }
    }
}
