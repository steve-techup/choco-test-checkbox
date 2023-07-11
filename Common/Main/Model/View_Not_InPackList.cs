namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Not_InPackList
    {
        [StringLength(255)]
        public string Description_Name { get; set; }

        [StringLength(255)]
        public string D { get; set; }

        [StringLength(255)]
        public string E { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string Description_ID { get; set; }

        [StringLength(255)]
        public string Instrument_Company { get; set; }

        [StringLength(765)]
        public string Full_Name { get; set; }

        public int? Number { get; set; }

        public int? Tray_Descrip_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Index_ID { get; set; }
    }
}
