namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// The Tray_Packed table reflects the current state of packed trays and their contents.
    /// If an untagged instrument is packed, the EPC_Nr will be null and the quantity of the type of instrument will be set in QuantityPackedManually. 
    /// </summary>
    public partial class Tray_Packed
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(50)]
        public string Tray_EPC_Nr { get; set; }
        
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tray_Description_ID { get; set; }
        [ForeignKey("Tray_Description_ID")]
        public Tray_Description TrayDescription { get;set;}
        
        [Column(Order = 1)]
        [StringLength(50)]
        public string? EPC_Nr { get; set; }
        /// <summary>
        /// The quantity of instruments packed manually. Is only > 0 if the instrument does *not* have an EPC_Nr.
        /// </summary>
        public int QuantityPackedManually { get; set; } 

        [StringLength(255)]
        public string Description_ID { get; set; }

        public bool? Packed_Locked { get; set; }

        public DateTime? Date_Changed { get; set; }

        public int? Pack_User_ID { get; set; }

        public int? Pack_Station_ID { get; set; }
    }
}
