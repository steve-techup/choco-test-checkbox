namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblPassword")]
    public partial class TblPassword
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(50)]
        [Index]
        public string UserName { get; set; }

        public string PassCode { get; set; }

        public DateTime? LastLogin { get; set; }

        public int? NumberLogins { get; set; }

        [StringLength(50)]
        public string WindowsUser { get; set; }

        public bool? DashBoard { get; set; }

        public bool? DashBoardAdmin { get; set; }

        public short? SecurityLevel { get; set; }

        [StringLength(50)]
        public string ChangedBy { get; set; }

        public DateTime? ChangeDate { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string FamilyName { get; set; }

        public string RFID_Code { get; set; }

        public string SEQ_Code { get; set; }

        public long? Log_ID { get; set; }

        public Guid? UserGuid { get; set; }

        public bool? Using_Action { get; set; }

        public DateTime? User_LastSeen_Date { get; set; }

        [StringLength(50)]
        public string User_LastSeen_Place { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(FamilyName))
                return UserName;
            else
                return UserName + " ("+ FirstName + " " + FamilyName + ")";
        }
    }
}
