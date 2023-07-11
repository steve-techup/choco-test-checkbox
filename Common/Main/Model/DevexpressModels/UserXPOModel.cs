using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;

namespace Main.Model.DevexpressModels
{
    [Persistent("TblPassword")]
    public class UserXPOModel : XPLiteObject
    {
        public UserXPOModel(Session session) : base(session)
        {

        }
        
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string FamilyName { get; set; }

        [Association]
        public XPCollection<PackingLogXPOModel> PackingLogs => GetCollection<PackingLogXPOModel>(nameof(PackingLogs));

        public override string ToString()
        {
            return $"{UserName} ({FirstName} {FamilyName})";
        }
    }
}
