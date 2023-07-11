namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Reader_Overview
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Reader_Name { get; set; }

        public string Reader_Description { get; set; }

        [StringLength(50)]
        public string Area_Name { get; set; }

        public string Area_Description { get; set; }

        [StringLength(10)]
        public string In_Use { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Reader_ID { get; set; }

        public bool? CheckBox_IN { get; set; }

        public long? Area_ID { get; set; }

        [StringLength(50)]
        public string IP_Address { get; set; }
    }
}
