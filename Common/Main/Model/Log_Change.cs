namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Log_Change
    {
        [Key]
        public long Index_ID { get; set; }

        public string Text { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Change_Date { get; set; }

        [StringLength(50)]
        public string User_Name { get; set; }
    }
}
