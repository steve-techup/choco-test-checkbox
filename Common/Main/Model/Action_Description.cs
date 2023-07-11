namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Action_Description
    {
        [Key]
        [Column(Order = 0)]
        public long Index_ID { get; set; }

        [StringLength(64)]
        public string Action_Name { get; set; }

        public long? Department_ID { get; set; }

        public int? UserID { get; set; }

        public DateTime? Action_Date { get; set; }

        [StringLength(50)]
        public string Action_Type { get; set; }

        public long? Action_Type_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Action_Done { get; set; }

        public DateTime? Date_Changed { get; set; }
    }
}
