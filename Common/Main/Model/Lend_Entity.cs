namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lend_Entity
    {
        [Key]
        [Column(Order = 0)]
        public long Lend_ID { get; set; }

        public string Lend_Name { get; set; }

        [StringLength(255)]
        public string Lend_Email { get; set; }

        [StringLength(255)]
        public string Lend_Department { get; set; }

        [StringLength(255)]
        public string Lend_Address { get; set; }

        [StringLength(10)]
        public string Lend_ZIP { get; set; }

        [StringLength(255)]
        public string Lend_City { get; set; }

        [StringLength(255)]
        public string Lend_State { get; set; }

        [StringLength(255)]
        public string Lend_Country { get; set; }

        public DateTime? Change_Date { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Lend_Company_ID { get; set; }
    }
}
