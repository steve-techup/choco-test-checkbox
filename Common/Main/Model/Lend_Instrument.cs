namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lend_Instrument
    {
        [Key]
        public long Lend_Instrument_ID { get; set; }

        public long? Lend_ID { get; set; }

        public DateTime? Lend_Receive_Date { get; set; }

        public string Lend_Place { get; set; }

        [StringLength(50)]
        public string EPC_Nr { get; set; }

        public DateTime? Lend_Return_Date { get; set; }

        public string LOT { get; set; }

        public string Batch_Number { get; set; }

        public string Lend_Description { get; set; }

        public bool? Lend_In_Coming { get; set; }

        public bool? Lend_OUT_Going { get; set; }

        public string External_ID { get; set; }

        public bool? External_KIT { get; set; }

        public bool? Digi_Sign_IN { get; set; }

        public bool? Digi_Sign_OUT { get; set; }
    }
}
