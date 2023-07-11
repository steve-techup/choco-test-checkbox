namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SPD_Machine
    {
        [Key]
        [Column(Order = 0)]
        public long Machine_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Machine_Name { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Area_ID { get; set; }

        [Key]
        [Column(Order = 3)]
        public string Machine_Number { get; set; }

        public string Machine_Info { get; set; }

        public string Speciel_Text { get; set; }

        public DateTime? Last_Time_Used { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime Change_Date { get; set; }
    }
}
