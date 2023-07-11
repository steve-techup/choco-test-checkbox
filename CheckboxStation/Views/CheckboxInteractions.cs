using System;
using System.Reactive;
using System.Windows.Forms;
using CheckboxStation.ViewModels;
using ReactiveUI;

namespace CheckboxStation.Views
{
    public class CheckboxInteractions
    {
        public Interaction<Unit, NewOperationViewModel> NewOperation { get; } = new(RxApp.MainThreadScheduler);

        public Interaction<CheckInViewModel, Unit> CheckIn { get; } = new(RxApp.MainThreadScheduler);
        public Interaction<CheckboxViewModel, Unit> ChooseOperation { get; } = new(RxApp.MainThreadScheduler);
        public Interaction<CheckboxViewModel, Unit> ConfirmCheckIn { get; } = new(RxApp.MainThreadScheduler);

        public virtual void Setup()
        {
            NewOperation.RegisterHandler(interaction =>
            {
                var form = new NewOperationForm();
                form.ShowDialog();
                interaction.SetOutput(form.ViewModel);
            });

            CheckIn.RegisterHandler(interaction =>
            {
                var checkInForm = new CheckInForm(interaction.Input);
                checkInForm.ShowDialog();
                interaction.SetOutput(Unit.Default);
            });

            ChooseOperation.RegisterHandler(interaction =>
            {
                var chooseOperationForm = new ChooseOperationForm(interaction.Input);
                chooseOperationForm.ShowDialog();
                interaction.SetOutput(Unit.Default);
            });

            ConfirmCheckIn.RegisterHandler(interaction =>
            {
                var confirmCheckIn = new ConfirmCheckIn(interaction.Input);
                confirmCheckIn.ShowDialog();
                interaction.SetOutput(Unit.Default);
            });
        }
    }
}