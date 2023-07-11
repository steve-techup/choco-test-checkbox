namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reader_Description
    {
        [Key]
        public long Reader_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Reader_Name { get; set; }

        public long? Area_ID { get; set; }

        [Column("Reader_Description")]
        public string Reader_Description1 { get; set; }

        public bool? Reader_Attach { get; set; }

        [StringLength(10)]
        public string In_Use { get; set; }

        public bool? CheckBox_IN { get; set; }

        [StringLength(50)]
        public string IP_Address { get; set; }

        public DateTime Last_Edited { get; set; }

        public DateTime Start_Date { get; set; }

        [StringLength(50)]
        public string External_IP_Address { get; set; }

        [StringLength(50)]
        public string SoftwareVersion { get; set; }

        public Guid? ReaderGUID { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        public string Last_Stand { get; set; }
    }
}
