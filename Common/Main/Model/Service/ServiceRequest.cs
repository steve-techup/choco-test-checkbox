using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caretag_Class.Model.Service
{
    public class ServiceRequest
    {
        [Key]
        public int Id { get; set; }
        public long InstrumentId { get; set; }

        public string InstrumentEPC { get; set; }
        [ForeignKey("InstrumentId")]
        public Instrument_RFID Instrument { get; set; }
        public DateTime Timestamp { get; set; } 
        [StringLength(50)]
        public string State { get; set; }
        public string Note { get; set; }
        [StringLength(50)]
        public string TriggeredBy { get; set; }
        public int ServiceRuleId { get; set; }
        [ForeignKey("ServiceRuleId")]
        public ServiceRule TriggeringServiceRule { get; set; }
    }
}
