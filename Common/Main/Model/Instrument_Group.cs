namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Instrument_Group
    {
        [Key]
        public int Group_ID { get; set; }

        [Required]
        public string Group_Description { get; set; }

        [Required]
        [StringLength(10)]
        public string Group_Identifier { get; set; }

        public DateTime? Last_Date_Change { get; set; }
    }
}
