namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Login_Security
    {
        [Key]
        [Column(Order = 0)]
        public long Index_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Program_Name { get; set; }

        public int? The_Security { get; set; }

        public int? Default_Security { get; set; }

        public string Special_Text { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime Date_Changed { get; set; }
    }
}
