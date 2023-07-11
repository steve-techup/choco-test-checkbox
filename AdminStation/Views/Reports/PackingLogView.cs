using AdminStation.ViewModels.ReactiveUI;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Main.Extensions;

namespace AdminStation.Views.Reports
{
    public partial class PackingLogView : UserControl, IViewFor<PackingLogViewModel>
    {
        private PackingLogViewModel _vm;

        public PackingLogView(PackingLogViewModel vm)
        {
            _vm = vm;
            InitializeComponent();

            packingLogGridControl.DataSource = vm.ServerModeDS;

            packingLogGridView.RemoveForeignKeyDuplicateColumns();
                                                                                            
        }

        object? IViewFor.ViewModel
        {
            get => _vm;
            set => _vm = (PackingLogViewModel)value!;
        }

        PackingLogViewModel IViewFor<PackingLogViewModel>.ViewModel
        {
            get => _vm;
            set => _vm = value;
        }
    }
}
