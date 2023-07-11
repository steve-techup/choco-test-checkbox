namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Demand_Text
    {
        [Key]
        public long Index_ID { get; set; }

        [Required]
        public string The_Text { get; set; }

        public bool? Text_Hidden { get; set; }

        public DateTime? Change_Date { get; set; }
    }
}
