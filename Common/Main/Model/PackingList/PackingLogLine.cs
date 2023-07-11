using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Caretag_Class.Model;

namespace Main.Model.PackingList
{
    /// <summary>
    /// A packing log line is generated for each physical instrument packed.
    /// If the instrument is untagged the InstrumentRfidId will be null and PackedManually set to true. 
    /// </summary>
    public class PackingLogLine
    {
        [Key]
        public long Id { get; set; }
        public int QuantityPackedManually { get; set; }
        public long PackingLogId { get; set; }
        
        [ForeignKey("PackingLogId")]
        public PackingLog PackingLog { get; set; }
        public long? InstrumentRfidId { get; set; }

        [ForeignKey("InstrumentRfidId")]
        public virtual Instrument_RFID? InstrumentRfid { get; set; }
        public string InstrumentDescriptionId { get; set; }

        [ForeignKey("InstrumentDescriptionId")]
        public Instrument_Description InstrumentDescription { get; set; }

    }
}
