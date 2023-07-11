namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Rules_Log_New
    {
        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Rules_ID { get; set; }

        [StringLength(255)]
        public string Description_ID { get; set; }

        public bool? Default_Rule { get; set; }

        public string Maintenance_Text { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Types_Service { get; set; }

        public int? ServiceVendor_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime ChangeDate { get; set; }

        public short? Maintenance_Value { get; set; }

        public int? UserID { get; set; }

        public int? ToDay { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Vendor_Name { get; set; }

        [StringLength(50)]
        public string Vendor_City { get; set; }

        public string Description_Text { get; set; }

        public long? Expr1 { get; set; }
    }
}
