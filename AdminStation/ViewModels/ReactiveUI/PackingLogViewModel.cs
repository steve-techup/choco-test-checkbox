using System;
using System.Collections.Generic;
using Caretag_Class;
using System.Data.Entity;
using Caretag_Class.Configuration;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Main.Model.DevexpressModels;
using Main.Model.PackingList;
using ReactiveUI;

namespace AdminStation.ViewModels.ReactiveUI
{
    public class PackingLogViewModel : ReactiveObject, IRoutableViewModel, IDisposable
    {
        private readonly Session _session
            ;

        public PackingLogViewModel(AppSettingsBase appSettingsBase)
        {
            XpoDefault.DataLayer =
                XpoDefault.GetDataLayer(appSettingsBase.ConnectionStrings.SQLServer, AutoCreateOption.None);
            _session = new Session(XpoDefault.DataLayer);
            ServerModeDS =
                new XPServerCollectionSource(_session, typeof(PackingLogXPOModel));

            UrlPathSegment = "PackingLog";
        }
        
        public XPServerCollectionSource ServerModeDS { get;  }
        

        public string? UrlPathSegment { get; }
        public IScreen HostScreen { get; }
        public void Dispose()
        {
            _session.Dispose();
        }
    }
}
