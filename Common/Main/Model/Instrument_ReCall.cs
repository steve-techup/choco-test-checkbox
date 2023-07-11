namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Instrument_ReCall
    {
        [Key]
        [Column(Order = 0)]
        public long Index_ID { get; set; }

        [StringLength(255)]
        public string Description_ID { get; set; }

        public string ReCall_Name { get; set; }

        [StringLength(50)]
        public string ReCall_Type { get; set; }

        public DateTime? ReCall_From { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool ReCall_Deleted { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string Special_Text { get; set; }

        public long? Total_Population { get; set; }

        public long? Numbers_Recall { get; set; }

        public DateTime? Changed_Date { get; set; }
    }
}
