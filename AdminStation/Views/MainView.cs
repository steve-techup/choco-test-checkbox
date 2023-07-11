using System;
using System.Reactive.Linq;
using System.Windows.Forms;
using AdminStation.ViewModels.ReactiveUI;
using Caretag_Class.EventReporting;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace AdminStation.Views;

public partial class MainView : Form, IViewFor<MainViewModel>
{
    private readonly EventReporter _eventReporter;
    private MainViewModel _vm;
    

    public MainView()
    {
        _eventReporter = Program.Kernel.GetRequiredService<EventReporter>();
        this.WhenActivated(b =>
        {
            b(this.OneWayBind(_vm, vm => vm.Router, v => v.routedControlHost.Router));
            b(this.BindCommand(_vm, vm => vm.ExitCommand, v => v.exitToolStripMenuItem));
            b(this.BindCommand(_vm, vm => vm.NavigateToInstrumentTypesCommand,
                v => v.instrumentTypesToolStripMenuItem));
            b(this.BindCommand(_vm, vm => vm.NavigateToImportCommand, v => v.importToolStripMenuItem));
            b(this.BindCommand(_vm, vm => vm.NavigateToTraysCommand, v => v.traysToolStripMenuItem));
            b(this.BindCommand(_vm, vm => vm.NavigateToCostCentersCommand, v => v.costCentersToolStripMenuItem));
            b(this.BindCommand(_vm, vm => vm.NavigateToScansCommand, v => v.scansToolStripMenuItem));
            b(this.BindCommand(_vm, vm => vm.NavigateToPackingLogCommand, v => v.packingLogsToolStripMenuItem));
            b(this.BindCommand(_vm, vm => vm.NavigateToCostLogCommand, v => v.costLogToolStripMenuItem));
            b(this.BindCommand(_vm, vm => vm.ExportToExcelCommand, v => v.exportToExcelToolStripMenuItem));
            b(this.BindCommand(_vm, vm => vm.NavigateToUsersCommand, v => v.usersToolStripMenuItem1));
            b(this.BindCommand(_vm, vm => vm.Login, v => v.logOutToolStripMenuItem));
            
            _vm.Login.Execute().ObserveOn(RxApp.MainThreadScheduler).Subscribe(result =>
            {
                if (!result)
                {
                    Close();
                    Application.Exit();
                }
                else
                {
                    try
                    {
                        Application.DoEvents();
                        WindowState = FormWindowState.Normal;
                    }
                    catch (Exception ex)
                    {
                        _eventReporter.ReportError(ex, "An error occurred when loading the application. ", "An error occurred when loading the form", "AdminStation-1", true, true);
                    }
                }
            });
        });

        InitializeComponent();
    }

    object IViewFor.ViewModel
    {
        get => _vm;
        set => _vm = (MainViewModel) value;
    }

    MainViewModel IViewFor<MainViewModel>.ViewModel
    {
        get => _vm;
        set => _vm = value;
    }
}