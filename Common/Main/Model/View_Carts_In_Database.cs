namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Carts_In_Database
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Cart_ID { get; set; }

        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [StringLength(50)]
        public string SEQ_Nr { get; set; }

        [StringLength(50)]
        public string Cart_Name { get; set; }

        public string Cart_Description { get; set; }

        public bool? Cart_Lock { get; set; }

        public DateTime? Date_Changed { get; set; }

        public int? Description_ID { get; set; }

        [StringLength(50)]
        public string Cart_LastSeen_Place { get; set; }

        public DateTime? Cart_LastSeen_Date { get; set; }

        public DateTime? Cart_Changed { get; set; }

        public int? Cart_Contents { get; set; }

        public int? Days { get; set; }

        public string Special_Text { get; set; }
    }
}
