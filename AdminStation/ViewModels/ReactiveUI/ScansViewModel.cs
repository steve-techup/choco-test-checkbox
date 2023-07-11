using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class;
using Caretag_Class.Configuration;
using DevExpress.Xpo.DB;
using DevExpress.Xpo;
using Main.Model.DevexpressModels;
using DevExpress.Xpo.DB.Exceptions;
using NurApiDotNet;
using System.Diagnostics;
using System.IO;
using System.Reactive;
using System.Windows.Forms;
using AdminStation.Views.Reports;

namespace AdminStation.ViewModels.ReactiveUI
{
    public class ScansViewModel : ReactiveObject, IRoutableViewModel, IDisposable
    {
        private readonly CaretagModelFactory _caretagModelFactory;
        private readonly Session _session;
        public string? UrlPathSegment { get; }
        public IScreen HostScreen { get; }
        public ScansViewModel(AppSettingsBase appSettingsBase, CaretagModelFactory caretagModelFactory)
        {
            _caretagModelFactory = caretagModelFactory;
            XpoDefault.DataLayer =
                XpoDefault.GetDataLayer(appSettingsBase.ConnectionStrings.SQLServer, AutoCreateOption.None);
            _session = new Session(XpoDefault.DataLayer);
            ServerModeDS =
                new XPServerCollectionSource(_session, typeof(ValidatedPackingListXPOModel));

            ShowValidatedPackingListDetailsCommand = ReactiveCommand.Create<int, Unit>(ShowValidatedPackingListDetails);
        }

        private Unit ShowValidatedPackingListDetails(int validatedPackingListId)
        {
            using var detailsForm = new ValidatedPackingListDetails(new ValidatedPackingListDetailsViewModel(_caretagModelFactory, validatedPackingListId));
            detailsForm.ShowDialog();
            return Unit.Default;
        }


        public ReactiveCommand<int, Unit> ShowValidatedPackingListDetailsCommand { get; }

        public XPServerCollectionSource ServerModeDS { get; set; }

        public void Dispose()
        {
            _session.Dispose();
            ServerModeDS.Dispose();
        }
    }
}
