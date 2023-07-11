namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LogIn_Table
    {
        [Key]
        public long Log_ID { get; set; }

        public long? Connect_ID { get; set; }

        [StringLength(10)]
        public string Log_Type { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Log_Place { get; set; }

        public DateTime? Log_Time { get; set; }
    }
}
