using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caretag_Class.Model
{
    using System.ComponentModel.DataAnnotations;

    public partial class Instrument_Packed_Log
    {
        [Key, Column(Order=0)]
        public long The_Log_ID { get; set; }
        [Key, Column(Order=1)]
        [StringLength(50)]
        public string EPC_Nr { get; set; }
        public DateTime? ChangeDate { get; set; }
    }
}
