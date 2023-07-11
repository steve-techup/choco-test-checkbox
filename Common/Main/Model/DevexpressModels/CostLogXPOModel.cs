using System;
using System.ComponentModel.DataAnnotations.Schema;
using Caretag_Class.Model;
using DevExpress.Xpo;

namespace Main.Model.DevexpressModels;

[Persistent("Cost_Log")]
public class CostLogXPOModel : XPLiteObject
{
    public CostLogXPOModel(Session session) : base(session) { }

    [Key]
    [DisplayName("Log ID")]
    public long Log_ID
    {
        get { return GetPropertyValue<long>(); }
        set { SetPropertyValue(nameof(Log_ID), value); }
    }

    [Association()]
    [DisplayName("Cost Item")]
    public virtual CostItemXPOModel CostItemId
    {
        get { return GetPropertyValue<CostItemXPOModel>(nameof(CostItemId)); }
        set { SetPropertyValue(nameof(CostItemId), value); }
    }

    [DisplayName("Note")]
    public string Extra_Text
    {
        get { return GetPropertyValue<string>(); }
        set { SetPropertyValue(nameof(Extra_Text), value); }
    }

    [DisplayName("Latest change")]
    public DateTime? ChangeDate
    {
        get => GetPropertyValue<DateTime?>();
        set => SetPropertyValue(nameof(ChangeDate), value);
    }


    [Association]
    public virtual TrayDescriptionXPOModel TrayDescriptionId
    {
        get => GetPropertyValue<TrayDescriptionXPOModel>(nameof(TrayDescriptionId));
        set => SetPropertyValue(nameof(TrayDescriptionId), value);
    }

    [Association]
    public XPCollection<PackingLogXPOModel> PackingLogLines => GetCollection<PackingLogXPOModel>(nameof(PackingLogLines));
}