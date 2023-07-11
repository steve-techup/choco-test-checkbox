namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tray_Translation
    {
        [Key]
        public long Tray_Trans_ID { get; set; }

        public string OutSide_ID { get; set; }

        public int? Tray_ID { get; set; }

        public string Special_Text { get; set; }

        public DateTime? Changed_Date { get; set; }
    }
}
