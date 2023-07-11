using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Resources;
using System.Threading.Tasks;
using Caretag_Class.Model;
using Caretag_Class.ReactiveUI;
using CheckboxStation.Infrastructure;
using CheckboxStation.Services;
using CheckboxStation.Views;
using Main.Model.PackingList.Validation;
using ReactiveUI;
using Surgical_Admin.Interactions;

namespace CheckboxStation.ViewModels
{
    public class CheckInViewModel : ReactiveObject
    {
        public CheckInViewModel(ValidatedPackingList validatedValidatedPackingList, CheckStateService service, CheckboxInteractions checkboxInteractions, CommonInteractions commonInteractions)
        {
            ValidatedValidatedPackingList = validatedValidatedPackingList;
            Instruments = ValidatedValidatedPackingList.Lines.SelectMany(row => row.Instruments).ToList();
            Operations = Observable.Return(service.GetOperations(OperationState.ACTIVE).ToList());
            Cancel = ReactiveCommand.Create(() =>
            {
                ShowForm = false;
            });
            Ok = ReactiveCommand.CreateFromObservable<Unit>(() =>
            {
                if (SelectedOperation == null)
                {
                    return commonInteractions.Confirm.Warning(Local_RM.GetString("No operation chosen."),
                        Local_RM.GetString("Choose operation")).Select(_ => new Unit());
                }
                else
                {
                    var isWarning = ValidatedValidatedPackingList.Result switch
                    {
                        ValidatedPackingList.PackingListState.MoreThanOneTray => true,
                        ValidatedPackingList.PackingListState.NotOk => true,
                        ValidatedPackingList.PackingListState.Ok => false,
                        ValidatedPackingList.PackingListState.NoTray => false,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                    var message = Status + Local_RM.GetString("Continue?");
                    return commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments
                        {Options = CaretagMessageBoxOptions.OkCancel, IsWarning = isWarning, Message = message, Title = Local_RM.GetString("Check in")
                    }).Select(
                        continueSelected =>
                        {
                            if (continueSelected == CaretagMessageBoxResult.Ok)
                            {
                                service.CheckInstrumentsIn(Instruments, SelectedOperation);
                                commonInteractions.Confirm.Message(Local_RM.GetString("Success"), Local_RM.GetString("Instruments checked in"))
                                    .Subscribe();
                                ShowForm = false;
                            }
                            return new Unit();
                        });
                }
            });

            this.WhenAnyObservable(m=> m.Operations).Subscribe(m =>
            {
                if (!m.Any())
                    commonInteractions.Confirm.Warning(Local_RM.GetString("No active operation"), 
                        Local_RM.GetString("Create or start operation")).Subscribe();
            });
        }

        private ResourceManager Local_RM = new ResourceManager("CheckBoxStation.WinFormStrings", typeof(CheckInViewModel).Assembly);

        public IObservable<List<Operation>> Operations { get; set; }
        public string TrayName { get; set; }
        public List<Instrument_RFID> Instruments { get; set; }
        public ValidatedPackingList ValidatedValidatedPackingList { get; set; }
        public string Status => ValidatedValidatedPackingList.Result switch
        {
            ValidatedPackingList.PackingListState.MoreThanOneTray =>
                Local_RM.GetString($"More than one tray scanned. \nPacking list NOT validated. \nChecking in: {Instruments.Count} instruments. "),
            ValidatedPackingList.PackingListState.NotOk =>
                Local_RM.GetString($"Found tray: {TrayName}. Packing list NOT ok. \nMissing instruments. \nChecking in: {Instruments.Count} instruments. "),
            ValidatedPackingList.PackingListState.Ok=>
                Local_RM.GetString($"Found tray: {TrayName}. Packing list OK! \nChecking in: {Instruments.Count} instruments. "),
            ValidatedPackingList.PackingListState.NoTray =>
                Local_RM.GetString($"No tray found. Cannot validate packing list. \nChecking in: {Instruments.Count} instruments. "),
            _ => throw new ArgumentOutOfRangeException()
        };
        public Color StatusColor => ValidatedValidatedPackingList.Result switch
        {
            ValidatedPackingList.PackingListState.MoreThanOneTray => Color.Red,
            ValidatedPackingList.PackingListState.NotOk => Color.Red,
            ValidatedPackingList.PackingListState.Ok => Color.Green,
            ValidatedPackingList.PackingListState.NoTray => Color.Black
        };
        public ReactiveCommand<Unit, Unit> Ok { get; private set; }
        public ReactiveCommand<Unit, Unit> Cancel { get; private set; } 

        private Operation _selectedOperation;
        public Operation SelectedOperation
        {
            get => _selectedOperation;
            set => this.RaiseAndSetIfChanged(ref _selectedOperation, value);
        }

        private bool _showForm = true;
        public bool ShowForm
        {
            get => _showForm;
            set => this.RaiseAndSetIfChanged(ref _showForm, value);
        }
    }
}
