using AdminStation.ViewModels.ReactiveUI;
using ReactiveUI;
using System.Windows.Forms;

namespace AdminStation.Views.Reports
{
    public partial class ValidatedPackingListDetails : Form, IViewFor<ValidatedPackingListDetailsViewModel>
    {
        private ValidatedPackingListDetailsViewModel _vm;
        
        public ValidatedPackingListDetails(ValidatedPackingListDetailsViewModel vm)
        {
            _vm = vm;
            InitializeComponent();

            validatedPackingListGridView.DataController.AllowIEnumerableDetails = true;
            validatedPackingListGridControl.DataSource = _vm.LineItems;
        }
         
        object IViewFor.ViewModel
        {
            get => _vm;
            set => _vm = (ValidatedPackingListDetailsViewModel)value;
        }

        ValidatedPackingListDetailsViewModel IViewFor<ValidatedPackingListDetailsViewModel>.ViewModel
        {
            get => _vm;
            set => _vm = value;
        }
    }
}
