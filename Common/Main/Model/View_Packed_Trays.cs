namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Packed_Trays
    {
        [StringLength(50)]
        public string Tray_EPC_Nr { get; set; }

        [StringLength(50)]
        public string Tray_Name { get; set; }

        public string Tray_Description { get; set; }

        public bool? Tray_Lock { get; set; }

        [Key]
        [StringLength(50)]
        public string EPC_Nr { get; set; }

        public bool? Packed_Locked { get; set; }

        public int? Pack_User_ID { get; set; }

        public int? Pack_Station_ID { get; set; }

        public DateTime? Date_Changed { get; set; }

        [StringLength(50)]
        public string Reader_Name { get; set; }

        [StringLength(765)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public int? ToDay { get; set; }
    }
}
