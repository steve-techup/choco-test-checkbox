using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageExt;
using ReactiveUI;

namespace Caretag_Class.ReactiveUI.ViewModels
{
    public class TouchScreenNumberDialogViewModel : ReactiveObject
    {

        public TouchScreenNumberDialogViewModel()
        {
            OkCommand = ReactiveCommand.Create<Unit, Unit>(_ =>
            {
                ShowDialog = false;
                return Unit.Default;
            });
            IncrementCommand = ReactiveCommand.Create<Unit, Unit>(_ =>
            {
                Number++;
                return Unit.Default;
            });
            DecrementCommand = ReactiveCommand.Create<Unit, Unit>(_ =>
            {
                if (Number > 0)
                    Number--;
                return Unit.Default;
            });
        }

        private bool _showDialog = true;
        public bool ShowDialog
        {
            get => _showDialog;
            set => this.RaiseAndSetIfChanged(ref _showDialog, value);
        }

        public ReactiveCommand<Unit, Unit> OkCommand;
        public ReactiveCommand<Unit, Unit> IncrementCommand;
        public ReactiveCommand<Unit, Unit> DecrementCommand;

        public string Message { get; set; }

        private int _number;
        public int Number
        {
            get => _number;
            set => this.RaiseAndSetIfChanged(ref _number, value);
        }
        
    }
}
