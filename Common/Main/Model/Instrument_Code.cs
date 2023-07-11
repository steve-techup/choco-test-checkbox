namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Instrument_Code
    {
        [Key]
        public long Code_ID { get; set; }

        public string Description_ID { get; set; }

        public int? Code { get; set; }
    }
}
