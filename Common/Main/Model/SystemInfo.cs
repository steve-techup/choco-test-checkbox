namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemInfo")]
    public partial class SystemInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50)]
        public string SoftwareName { get; set; }

        [StringLength(50)]
        public string SoftwareVersion { get; set; }

        public bool? Mandatory { get; set; }

        [StringLength(50)]
        public string Copyrights { get; set; }

        public bool? PackingSt_Counter { get; set; }

        public bool? Security_Code { get; set; }

        public bool? TechnicalST_Locked { get; set; }

        public bool? Unique_Rules { get; set; }

        public bool? GateNameSwitch { get; set; }

        public string UDI_Database { get; set; }

        public string Path_To_Files { get; set; }

        public string AdgangsKode { get; set; }

        public bool? Use_Cost_Center { get; set; }

        public bool? Use_Login { get; set; }

        public bool? Use_ActiveDirectory { get; set; }

        public string Login_Verification { get; set; }

        public string Device_Numbers { get; set; }

        public bool? Use_Action { get; set; }
    }
}
