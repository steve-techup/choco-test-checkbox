namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Instrument_RFID_History
    {
        [StringLength(50)]
        public string EPC_Nr { get; set; }

        public int? Instrument_InUse { get; set; }

        [StringLength(50)]
        public string Last_Seen { get; set; }

        [StringLength(50)]
        public string Now_Seen { get; set; }

        public DateTime? Last_Seen_Date { get; set; }

        [Key]
        public DateTime Change_Date { get; set; }
    }
}
