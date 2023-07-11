namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_GridView_1
    {
        [Key]
        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [StringLength(50)]
        public string Instrument_LastSeen_Place { get; set; }

        public DateTime? Instrument_LastSeen_Date { get; set; }

        public bool? Instrument_InUse { get; set; }

        public string Department_Name { get; set; }

        [StringLength(767)]
        public string Description_Name { get; set; }

        public int? Day_To_Now { get; set; }

        [StringLength(255)]
        public string Description_ID { get; set; }

        [StringLength(255)]
        public string SERIAL_NR { get; set; }
    }
}
