namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Instrument_Image
    {
        [Key]
        public long Image_ID { get; set; }

        public byte[] TheImage { get; set; }

        [StringLength(255)]
        public string Description_ID { get; set; }

        public DateTime? Date_Changed { get; set; }
    }
}
