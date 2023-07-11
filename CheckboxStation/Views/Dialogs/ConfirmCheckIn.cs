using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Forms;
using Caretag_Class.Model;
using CheckboxStation.ViewModels;
using DynamicData.Binding;
using ReactiveUI;

namespace CheckboxStation
{
    public partial class ConfirmCheckIn : Form, IViewFor<CheckboxViewModel>
    {
        private CheckboxViewModel _vm;

        object IViewFor.ViewModel
        {
            get => _vm;
            set => _vm = (CheckboxViewModel)value;
        }

        CheckboxViewModel IViewFor<CheckboxViewModel>.ViewModel
        {
            get => _vm;
            set => _vm = value;
        }
        public ConfirmCheckIn(CheckboxViewModel vm)
        {
            InitializeComponent();
            operationsGridView.AutoGenerateColumns = false;


            _vm = vm;

            this.OneWayBind(_vm, vm => vm.UnfinishedOperations, form => form.operationsGridView.DataSource);

            Observable.FromEventPattern<EventHandler, EventArgs>(
                ev => operationsGridView.SelectionChanged += ev,
                ev => operationsGridView.SelectionChanged -= ev)
                .Select(ev =>
                {
                    if(operationsGridView.CurrentRow.Index >= 0)
                    {
                        var operationId = operationsGridView.CurrentRow.Cells["OperationId"].Value;
                        return operationId?.ToString();
                    }
                    return null;
                })
                .BindTo(this, x => x._vm.SelectedOperationIdOnConfirmCheckIn);


            _vm.WhenValueChanged(vm => vm.ConfirmCheckInResult)
               .Where(x => null != x)
               .Subscribe(result =>
            {
                this.DialogResult = result.Value;
                Close();
            });

            this.BindCommand(vm, vm => vm.OnCancelNewCheckIn, form => form.cancelButton);
            this.BindCommand(vm, vm => vm.OnConfirmNewCheckIn, form => form.scanNewButton);
            this.BindCommand(vm, vm => vm.OnAddToCurrentSurgery, form => form.addToCurrentButton);
        }
    }
}
