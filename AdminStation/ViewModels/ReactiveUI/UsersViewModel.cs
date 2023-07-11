using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using AdminStation.ViewModels.DataTypeViewModels;
using AdminStation.ViewModels.Validation;
using Caretag_Class;
using Caretag_Class.Configuration;
using Caretag_Class.Model;
using Main.Util;
using ReactiveUI;

namespace AdminStation.ViewModels.ReactiveUI
{
    public class UsersViewModel : ReactiveObject, IDisposable, ExcelExportableViewModel, IRoutableViewModel
    {
        private readonly CaretagModel _caretagModel;
        public UsersViewModel(CaretagModelFactory caretagModelFactory, AppSettingsBase appSettingsBase)
        {
            _caretagModel = caretagModelFactory.Create();
            Users = new EFBackedBindingList<UserViewModel, TblPassword, int>(_caretagModel.TblPassword,
                () => _caretagModel.SaveChanges(), new UserValidator(caretagModelFactory), _caretagModel.TblPassword.ToList().Select(t => new UserViewModel(t)).ToList());
            UrlPathSegment = "Users";
            ExportToExcelCommand = ReactiveCommand.Create(ExportToExcel);
        }

        public EFBackedBindingList<UserViewModel, TblPassword, int> Users { get; set; }
        public ReactiveCommand<Unit, Unit> ExportToExcelCommand { get; }
        public void Dispose()
        {
            _caretagModel.Dispose();
        }

        private void ExportToExcel()
        {
            var filename = Common.ShowExcelSaveDialog();
            if (filename == null) return;
            var exporter = new ExcelExporter();
            exporter.AddSheet(Users, "Trays");
            exporter.Save(filename);
            Common.ShowSuccessDialog();
        }
        public string? UrlPathSegment { get; }
        public IScreen HostScreen { get; }
    }
}
