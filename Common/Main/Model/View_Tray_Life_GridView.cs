namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Tray_Life_GridView
    {
        public int? Life_Days { get; set; }

        public string Full_Name { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Tray_ID { get; set; }

        public int? Description_ID { get; set; }

        public int? Tray_Contents { get; set; }

        [StringLength(50)]
        public string Tray_LastSeen_Place { get; set; }

        public DateTime? Tray_LastSeen_Date { get; set; }

        public DateTime? Date_Changed { get; set; }

        [StringLength(50)]
        public string Tray_Name { get; set; }

        public string Tray_Description { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime Date_Birth { get; set; }

        public DateTime? Date_End { get; set; }

        public DateTime? Return_Service { get; set; }

        public DateTime? Last_Service { get; set; }

        public int? Number_Service { get; set; }

        public int? Wash_Counter { get; set; }

        public DateTime? Steri_In { get; set; }

        public DateTime? Steri_Out { get; set; }

        [StringLength(255)]
        public string Steri_Name { get; set; }

        public DateTime? OR_In { get; set; }

        public DateTime? OR_Out { get; set; }

        [StringLength(255)]
        public string OR_Name { get; set; }

        public int? Used_In_OR { get; set; }

        public int? Passed_Steri { get; set; }

        [StringLength(255)]
        public string Expr1 { get; set; }

        public DateTime? Last_Change { get; set; }
    }
}
