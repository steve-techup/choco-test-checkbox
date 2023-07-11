using System.Reactive;
using ReactiveUI;

namespace CheckboxStation.ViewModels
{
    public class NewOperationViewModel : ReactiveObject
    {
        public NewOperationViewModel()
        {
            Ok = ReactiveCommand.Create(() =>
            {
                CreateSuccess = true;
                ShowForm = false;
            });

            Cancel = ReactiveCommand.Create(() =>
            {
                CreateSuccess = false;
                ShowForm = false;
            });
        }

        private string _id;
        public string Id
        {
            get => _id;
            set => this.RaiseAndSetIfChanged(ref _id, value);
        }

        private string _ORname;
        public string ORName
        {
            get => _ORname;
            set => this.RaiseAndSetIfChanged(ref _ORname, value);
        }

        private bool _showForm = true;
        public bool ShowForm
        {
            get => _showForm;
            set => this.RaiseAndSetIfChanged(ref _showForm, value);
        }

        public bool CreateSuccess { get; set; }
        public ReactiveCommand<Unit, Unit> Ok { get; private set; }
        public ReactiveCommand<Unit, Unit> Cancel { get; private set; }
    }
}
