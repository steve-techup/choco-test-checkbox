using Caretag_Class.Model.Service;
using Main.Model.PackingList.Validation;

namespace Caretag_Class.Model
{
    using Caretag.Contracts.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Instrument_RFID
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Instrument_ID { get; set; }
        
        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [StringLength(50)]
        public string SEQ_Nr { get; set; }

        [StringLength(255)]
        public string? SERIAL_NR { get; set; }

        [StringLength(255)]
        public string Description_ID { get; set; }
        [ForeignKey("Description_ID")]
        public Instrument_Description InstrumentDescription { get; set; }

        public string Description_Text { get; set; }

        [StringLength(50)]
        public string Instrument_LastSeen_Place { get; set; }

        public DateTime? Instrument_LastSeen_Date { get; set; }

        public bool? Instrument_InUse { get; set; }

        public int? Maintance_Code { get; set; }

        public int? Department_ID { get; set; }

        public long? Tray_ID { get; set; }

        public bool? UDI_Database { get; set; }

        public ICollection<OperationInstrument> OperationInstruments { get; set; }
        
        public ICollection<ServiceRequest> ServiceRequests { get; set; }

        public ICollection<ValidatedPackingListLineItem> ValidatedPackingListLineItems { get; set; }
        public DateTime? InstrumentProductionDate { get; set; }
        public string? LotNumber { get; set; }

        public TagType TagType { get; set; }
        public AssetClassType AssetClassType { get; set; }

        public string getDescription()
        {
            if (InstrumentDescription != null)
                return $"{InstrumentDescription.Description_Name} {InstrumentDescription.D} {InstrumentDescription.E}";
            else
                return Description_Text;
        }
    }
}
