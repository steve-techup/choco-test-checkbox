using Caretag_Class.Model;
using Main.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class.Caretag_Common;
using Caretag_Class.Forms;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;
using DevExpress.Xpo;
using MiniExcelLibs.Attributes;

namespace AdminStation.ViewModels.DataTypeViewModels
{
    public class UserViewModel : DataTypeViewModel<int, TblPassword>
    {
        private static string HiddenPasswordString = "***";
        public UserViewModel()
        {

        }
        public UserViewModel(TblPassword tblPassword)
        {
            UpdateFromDbItem(tblPassword);
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        private string _firstName;
        [DisplayName("First Name")]
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string _familyName;
        [DisplayName("Family Name")]
        public string FamilyName
        {
            get => _familyName;
            set
            {
                _familyName = value;
                OnPropertyChanged("FamilyName");
            }
        }

        private string _password;
        [DisplayName("New Password")]
        [ExcelIgnore]
        public string Password
        {
            get => _password;
            set
            {
                HasPassword = !string.IsNullOrWhiteSpace(value);
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        
        Guid? _guid;

        [Display(AutoGenerateField = false, Description = "This column isn't created")]
        public bool HasPassword { get; set; }

        
        [Display(AutoGenerateField = false, Description = "This column isn't created")]
        public override int Pkid { get; set; }
        public override void UpdateToDbItem(TblPassword dbItem)
        {
            dbItem.UserName= Username;
            dbItem.FirstName = FirstName;
            dbItem.FamilyName = FamilyName;
            dbItem.UserGuid = _guid ?? Guid.NewGuid();

            if (Password != HiddenPasswordString)
            {
                dbItem.PassCode = PasswordEncryptionUtil.EncryptWithGuid(Password, _guid ?? Guid.Empty);
                _password = HiddenPasswordString;
            }
        }

        public override void UpdateFromDbItem(TblPassword dbItem)
        {
            if (!string.IsNullOrWhiteSpace(dbItem.PassCode))
                HasPassword = true;
            Password= HiddenPasswordString;
            Pkid = dbItem.UserID;
            Username = dbItem.UserName;
            FirstName = dbItem.FirstName;
            FamilyName = dbItem.FamilyName;
            _guid = dbItem.UserGuid;
        }
    }
}
