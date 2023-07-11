using System.Reactive;
using System.Windows.Forms;
using Caretag_Class.ReactiveUI.Views;
using ReactiveUI;

namespace Caretag_Class.ReactiveUI.ViewModels
{
    public class StandardDialogViewModel : ReactiveObject
    {
        public StandardDialogViewModel(CaretagMessageBoxArguments arguments)
        {
            Arguments = arguments;
            
            CloseCommand = ReactiveCommand.Create<CaretagMessageBoxResult, Unit>(result =>
            {
                Result = result;
                Visible = false;
                return Unit.Default;
            });
        }

        // command to close
        public ReactiveCommand<CaretagMessageBoxResult, Unit> CloseCommand { get; private set; }

        private bool _visible = true;
        public bool Visible
        {
            get => _visible;
            set => this.RaiseAndSetIfChanged(ref _visible, value);
        }


        // property for columns
        public CaretagMessageBoxResult Result { get; set; }
        public CaretagMessageBoxArguments Arguments { get; set; }
        

    }
}
