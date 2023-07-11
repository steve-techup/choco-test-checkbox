using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caretag_Class.ReactiveUI.ViewModels;
using ReactiveUI;

namespace Caretag_Class.ReactiveUI.Views
{
    public partial class TouchscreenNumberDialog : Form, IViewFor<TouchScreenNumberDialogViewModel>
    {
        public TouchscreenNumberDialog()
        {
            InitializeComponent();

            numberTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);

            this.Bind(ViewModel, vm => vm.Number, view => view.numberTextBox.Text);
            this.Bind(ViewModel, vm => vm.Message, view => view.messageLabel.Text);
            this.BindCommand(ViewModel, vm => vm.OkCommand, view => view.okButton);
            this.BindCommand(ViewModel, vm => vm.IncrementCommand, view => view.plusButton);
            this.BindCommand(ViewModel, vm => vm.DecrementCommand, view => view.minusButton);

            //when viewmodel.showdialog is false, close dialog
            this.WhenAnyValue(v => v.ViewModel.ShowDialog).Subscribe(show =>
            {
                if (!show)
                {
                    Close();
                }
            });

            
        }

        public TouchScreenNumberDialogViewModel ViewModel { get; set; }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (TouchScreenNumberDialogViewModel)value;
        }
    }
}
