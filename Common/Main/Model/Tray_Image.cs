using Main.Annotations;

namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tray_Image
    {
        [Key]
        public long Image_ID { get; set; }

        public byte[] TheImage { get; set; }

        public int? Description_ID { get; set; }

        [StringLength(50)]
        public string Tray_Name { get; set; }

        public DateTime? Date_Changed { get; set; }
        
        [ForeignKey("Description_ID")]
        public virtual Tray_Description? Tray_Description { get; set; }
    }
}
