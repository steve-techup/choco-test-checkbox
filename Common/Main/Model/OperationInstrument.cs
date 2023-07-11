using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretag_Class.Model
{
    public class OperationInstrument
    {
        [Key]
        public int Id { get; set; }
        public long InstrumentId { get; set; }
        [ForeignKey("InstrumentId")]
        public Instrument_RFID Instrument { get; set; }
        public string InstrumentEPC { get; set; }
        [Column("OperationId")]
        public int OperationId { get; set; }
        [ForeignKey("OperationId")]
        public Operation Operation  { get; set; }
        public bool ActiveLink { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
