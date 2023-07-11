namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConfigTable")]
    public partial class ConfigTable
    {
        [Key]
        public int ConfigID { get; set; }

        [Required]
        [StringLength(50)]
        public string TableName { get; set; }

        public int ValueColumStart { get; set; }

        public bool AllowDelete { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ChangeDate { get; set; }

        public bool AllowInsert { get; set; }
    }
}
