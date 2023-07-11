namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Set_Syncbox_ComboBox
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Index_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Reader_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Reader_Name { get; set; }

        [StringLength(104)]
        public string Full_Name { get; set; }

        public long? Check_OUT_ID { get; set; }
    }
}
