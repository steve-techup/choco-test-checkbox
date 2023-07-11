namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Instrument_External
    {
        [Key]
        [StringLength(255)]
        public string Description_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string External_ID { get; set; }

        [StringLength(255)]
        public string External_Description { get; set; }

        public DateTime? Date_Changed { get; set; }
    }
}
