namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Cart_Container_Tray_A
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Cart_ID { get; set; }

        [StringLength(50)]
        public string Cart_LastSeen_Place { get; set; }

        public DateTime? Cart_LastSeen_Date { get; set; }

        public int? Description_ID { get; set; }

        public DateTime? Container_LastSeen_Date { get; set; }

        [StringLength(50)]
        public string Container_LastSeen_Place { get; set; }

        public int? Container_Desc_ID { get; set; }

        [StringLength(50)]
        public string Tray_LastSeen_Place { get; set; }

        public DateTime? Tray_LastSeen_Date { get; set; }

        public int? Tray_Desc_ID { get; set; }

        public string Tray_Description { get; set; }

        [StringLength(255)]
        public string Instrument_Desc_ID { get; set; }

        public string Instrument_Description { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [StringLength(50)]
        public string Area_Name { get; set; }

        public string Area_Description { get; set; }

        [StringLength(50)]
        public string Instrument_LastSeen_Place { get; set; }

        public DateTime? Instrument_LastSeen_Date { get; set; }

        public int? ToDay { get; set; }

        public string Special_Text { get; set; }

        public string Expr1 { get; set; }

        public string Expr2 { get; set; }
    }
}
