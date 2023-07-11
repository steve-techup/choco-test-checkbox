namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Action_Type
    {
        [Key]
        [Column(Order = 0)]
        public long Action_Type_ID { get; set; }

        public string Action_Type_Description { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Only_Administrator { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Is_Hidden { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Can_Expired { get; set; }

        public DateTime? Date_Changed { get; set; }
    }
}
