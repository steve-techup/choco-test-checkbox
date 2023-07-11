using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Caretag_Class.Model;

namespace Main.Model.PackingList.Validation
{
    public class ValidatedPackingListLineItem
    {
        public ValidatedPackingListLineItem()
        {
            Timestamp = DateTime.Now;
        }
        
        [Key]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public int Expected { get; set; }
        public int Actual { get; set; }
        public bool PackedManually { get; set; }
        public List<Instrument_RFID> Instruments { get; set; }
        public string? DescriptionId { get; set; }
        public string Description { get; set; }

        [ForeignKey("DescriptionId")]
        public virtual Instrument_Description? InstrumentDescription { get; set; }
    }
}
