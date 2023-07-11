namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Instru_To_Tray
    {
        [StringLength(255)]
        public string Instrument_Company { get; set; }

        [StringLength(767)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [StringLength(50)]
        public string Tray_Name { get; set; }

        public string Tray_Description { get; set; }

        public bool? Tray_Lock { get; set; }

        public long? Tray_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Description_ID { get; set; }
    }
}
