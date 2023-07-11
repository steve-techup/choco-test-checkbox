using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Model.DevexpressModels
{
    using Caretag_Class.Model;
    using DevExpress.Xpo;
    using Main.Model.PackingList;

    [Persistent("PackingLogLines")]
    public class PackingLogLineXPOModel : XPLiteObject
    {
        public PackingLogLineXPOModel(Session session) : base(session) { }

        [Key]
        public long Id
        {
            get => GetPropertyValue<long>();
            set => SetPropertyValue("Id", value);
        }

        [DisplayName("Quantity Packed Manually")]
        public int QuantityPackedManually
        {
            get => GetPropertyValue<int>();
            set => SetPropertyValue(nameof(QuantityPackedManually), value);
        }
        
        [Association]
        [Browsable(false)]
        public PackingLogXPOModel PackingLogId
        {
            get => GetPropertyValue<PackingLogXPOModel>();
            set => SetPropertyValue(nameof(PackingLogId), value);
        }
        
        [Association]
        [DisplayName("Instrument Description")]
        public InstrumentDescriptionXPOModel InstrumentDescriptionId
        {
            get => GetPropertyValue<InstrumentDescriptionXPOModel>(nameof(InstrumentDescriptionId));
            set { SetPropertyValue(nameof(InstrumentDescriptionId), value); }
        }
    }

}
