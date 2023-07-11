namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Stop_Instrument
    {
        [Key]
        public int Stop_ID { get; set; }

        public string Stop_Descripting { get; set; }

        public short? Stop_Action { get; set; }

        public DateTime? Changed_Date { get; set; }
    }
}
