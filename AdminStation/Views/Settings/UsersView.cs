using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminStation.ViewModels.ReactiveUI;
using DevExpress.XtraPrinting.Native;
using ReactiveUI;

namespace AdminStation.Views.Settings
{
    public partial class UsersView : UserControl, IViewFor<UsersViewModel>
    {
        private UsersViewModel _vm;
        public UsersView(UsersViewModel vm)
        {
            _vm = vm;
            InitializeComponent();

            usersGridControl.DataSource = _vm.Users;
            this.WhenActivated(b =>
            {
                b(Observable.FromEventPattern(usersGridView, nameof(usersGridView.ValidateRow))
                    .Subscribe(vm.Users.RowValidating));
            });
        }

        object? IViewFor.ViewModel
        {
            get => _vm;
            set => _vm = (UsersViewModel)value!;
        }

        UsersViewModel IViewFor<UsersViewModel>.ViewModel
        {
            get => _vm;
            set => _vm = value;
        }
    }
}
