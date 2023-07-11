using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Native;
using Main.ReactiveUI.Interactions;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Surgical_Admin.Interactions;

namespace AdminStation.ViewModels.ReactiveUI;

public class MainViewModel : ReactiveObject, IScreen
{
    public MainViewModel()
    {
        Router = new RoutingState();

        Router
            .NavigateAndReset
            .Execute(new HomeViewModel())
            .Subscribe();

        ExitCommand = ReactiveCommand.Create(Exit);
        NavigateToHomeCommand = ReactiveCommand.Create(NavigateToHome);
        NavigateToInstrumentTypesCommand = ReactiveCommand.Create(NavigateToInstrumentTypes);
        NavigateToImportCommand = ReactiveCommand.Create(NavigateToImport);
        NavigateToTraysCommand = ReactiveCommand.Create(NavigateToTrays);
        NavigateToCostCentersCommand = ReactiveCommand.Create(NavigateToCostCenters);
        NavigateToScansCommand = ReactiveCommand.Create(NavigateToScans);
        NavigateToPackingLogCommand = ReactiveCommand.Create(NavigateToPackingLog);
        NavigateToCostLogCommand = ReactiveCommand.Create(NavigateToCostLog);
        NavigateToUsersCommand = ReactiveCommand.Create(NavigateToUsers);
        ExportToExcelCommand = ReactiveCommand.Create(() =>
        {
            if (Router.GetCurrentViewModel() is ExcelExportableViewModel excelVm)
            {
                excelVm.ExportToExcelCommand.Execute().Subscribe();
            }
        },
            Router.CurrentViewModel.SelectMany(vm =>
            {
                if (vm is ExcelExportableViewModel excelVm)
                {
                    return excelVm.ExportToExcelCommand.CanExecute;
                }

                return Observable.Return(false);
            }));
        Login = ReactiveCommand.CreateFromObservable(() =>
        {
            _commonInteractions ??=
                Program.Kernel.GetRequiredService<CommonInteractionsFactory>().Create(RxApp.MainThreadScheduler);

            return _commonInteractions.LoginInteraction.Handle(Unit.Default).Select(result =>
            {
                if (result == null) return false;
                LoggedInUserId = result.UserID;
                return true;
            });
        });

    }

    private int _loggedInUserId;
    public int LoggedInUserId
    {
        get => _loggedInUserId;
        set => this.RaiseAndSetIfChanged(ref _loggedInUserId, value);
    }
    private CommonInteractions _commonInteractions;
    private void NavigateToUsers()
    {
        var vm = Program.Kernel.GetRequiredService<UsersViewModel>();

        Router.NavigateAndReset
            .Execute(vm)
            .Subscribe();
    }


    private IObservable<bool> CanExportToExcel;
    

    public ReactiveCommand<Unit, Unit> ExportToExcelCommand { get; }
    public ReactiveCommand<Unit, bool> Login { get; set; }
    public ReactiveCommand<Unit, Unit> NavigateToCostLogCommand { get; set; }
    public ReactiveCommand<Unit, Unit> NavigateToPackingLogCommand { get; set; }
    public ReactiveCommand<Unit, Unit> NavigateToTraysCommand { get; set; }

    public ReactiveCommand<Unit, Unit> ExitCommand { get; set; }
    public ReactiveCommand<Unit, Unit> NavigateToHomeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> NavigateToInstrumentTypesCommand { get; set; }
    public ReactiveCommand<Unit, Unit> NavigateToImportCommand { get; set; }
    public ReactiveCommand<Unit, Unit> NavigateToCostCentersCommand { get; set; }
    public ReactiveCommand<Unit, Unit> NavigateToUsersCommand { get; set; }
    public ReactiveCommand<Unit, Unit> NavigateToScansCommand { get; set; }
    public RoutingState Router { get; }
    
    private void NavigateToCostLog()
    {
        var vm = Program.Kernel.GetRequiredService<CostLogViewModel>();

        Router.NavigateAndReset
            .Execute(vm)
            .Subscribe();
    }
    private void NavigateToPackingLog()
    {
        var vm = Program.Kernel.GetRequiredService<PackingLogViewModel>();

        Router.NavigateAndReset
            .Execute(vm)
            .Subscribe();
    }

    private void NavigateToScans()
    {
        var vm = Program.Kernel.GetRequiredService<ScansViewModel>();

        Router.NavigateAndReset
            .Execute(vm)
            .Subscribe();
    }


    private void NavigateToTrays()
    {
        var vm = Program.Kernel.GetRequiredService<TraysViewModel>();

        Router
            .NavigateAndReset
            .Execute(vm)
            .Subscribe();
    }
    public void NavigateToHome()
    {
        Router
            .NavigateAndReset
            .Execute(new HomeViewModel())
            .Subscribe();
    }

    public void NavigateToInstrumentTypes()
    {
        var vm = Program.Kernel.GetRequiredService<InstrumentTypesViewModel>();
        Router
            .Navigate
            .Execute(vm)
            .Subscribe();
    }

    public void NavigateToImport()
    {
        var vm = Program.Kernel.GetRequiredService<CSVImportViewModel>();
        Router.Navigate
            .Execute(vm)
            .Subscribe();
    }

    public void NavigateToCostCenters()
    {
        var vm = Program.Kernel.GetRequiredService<CostCentersViewModel>();
        Router.Navigate
            .Execute(vm)
            .Subscribe();
    }

    private void Exit()
    {
        Application.Exit();
    }
}