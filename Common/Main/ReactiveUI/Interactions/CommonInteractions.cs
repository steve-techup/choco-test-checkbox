using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caretag_Class.EventReporting;
using Caretag_Class.Extensions;
using Caretag_Class.Model;
using Caretag_Class.ReactiveUI;
using Caretag_Class.ReactiveUI.Services;
using Caretag_Class.ReactiveUI.ViewModels;
using Caretag_Class.ReactiveUI.Views;
using DevExpress.DataAccess.Native.Sql.MasterDetail;
using DevExpress.Xpo.Logger;
using Main.ReactiveUI.ViewModels;
using Main.ReactiveUI.Views;
using Main.Repositories.UnitOfWork;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using Serilog;
using Westwind.Utilities;
using ILogger = Serilog.ILogger;

namespace Surgical_Admin.Interactions
{
    public class CommonInteractions
    {
        private readonly ILogger<CommonInteractions> _logger;
        private readonly ResourceManager _resourceManager;
        private readonly LoginUnitOfWorkFactory _loginUnitOfWorkFactory;
        private IScheduler _scheduler;

        public IScheduler Scheduler
        {
            get
            {
                return _scheduler;
            }
            set
            {
                _scheduler = value;
            }
        }


        private string getLocalized(string str)
        {
            var locstr = _resourceManager.GetString(str);

            var missingLoc = Debugger.IsAttached ? "[Missing localization] " : "";

            return string.IsNullOrWhiteSpace(locstr) ? missingLoc + str : locstr;
        }

        public CommonInteractions(ILogger<CommonInteractions> logger, ResourceManager resourceManager, LoginUnitOfWorkFactory loginUnitOfWorkFactory, IScheduler scheduler)
        {
            _logger = logger;
            _resourceManager = resourceManager;
            _loginUnitOfWorkFactory = loginUnitOfWorkFactory;
            _scheduler = scheduler;
            Setup();
        }

        public CommonInteractions()
        {
            _scheduler = RxApp.MainThreadScheduler;
            Setup();
        }

        public Interaction<Exception, Unit> ExceptionInteraction { get; set; }
        public Interaction<KeyValuePair<string, Exception>, Unit> ApiExceptionInteraction { get; set; }

        public Interaction<CaretagMessageBoxArguments, CaretagMessageBoxResult> Confirm { get; set; }

        // Browse interaction
        public Interaction<Unit, string> BrowseOpenCSVInteraction { get; set; }
        public Interaction<ErrorReport, Unit> ErrorReportInteraction { get; set; }
        public Interaction<Unit, TblPassword?> LoginInteraction { get; set; }
        public Interaction<string, string> BrowseSaveFileInteraction { get; set; }

        public void Clear()
        {
            InitializeInteractions();
        }

        private void InitializeInteractions()
        {
            ExceptionInteraction = new(_scheduler);
            ApiExceptionInteraction = new(_scheduler);
            Confirm = new(_scheduler);
            BrowseOpenCSVInteraction = new(_scheduler);
            ErrorReportInteraction = new(_scheduler);
            LoginInteraction = new(_scheduler);
            BrowseSaveFileInteraction = new(_scheduler);
        }

        private void Setup()
        {
            InitializeInteractions();
            LoginInteraction.RegisterHandler(async interaction =>
            {
                var vm = new LoginViewModel(_loginUnitOfWorkFactory, new ReactiveCommandService(this), _scheduler);
                using var dialog = new Login(vm);
                await dialog.ShowDialogAsync();
                interaction.SetOutput(vm.LoggedInUser);
            });

            Confirm.RegisterHandler(
                async interaction =>
                {
                    var vm = new StandardDialogViewModel(new CaretagMessageBoxArguments
                    {
                        Title = interaction.Input.Title,
                        Message = interaction.Input.Message,
                        IsWarning = interaction.Input.IsWarning,
                        Options = interaction.Input.Options
                    });

                    using var dialog = new StandardDialog(vm, _resourceManager);
                    await dialog.ShowDialogAsync();
                    interaction.SetOutput(vm.Result);
                });

            ExceptionInteraction.RegisterHandler(interaction =>
            {
                var vm = new StandardDialogViewModel(new CaretagMessageBoxArguments
                {
                    Title = getLocalized("Error"),
                    Message = getLocalized("An unexpected exception happened: ") + interaction.Input.Message + getLocalized(". Try again or restart application. "),
                    IsWarning = true,
                    Options = CaretagMessageBoxOptions.Ok
                });

                using var dialog = new StandardDialog(vm, _resourceManager);
                dialog.ShowDialog();
                interaction.SetOutput(Unit.Default);
            });

            ApiExceptionInteraction.RegisterHandler(interaction =>
            {
                var vm = new StandardDialogViewModel(new CaretagMessageBoxArguments
                {
                    Title = interaction.Input.Key,
                    Message = interaction.Input.Value.Message,
                    IsWarning = true,
                    Options = CaretagMessageBoxOptions.Ok
                });

                using var dialog = new StandardDialog(vm, _resourceManager);
                dialog.ShowDialog();
                interaction.SetOutput(Unit.Default);
            });

            // register handler to browse file
            BrowseOpenCSVInteraction.RegisterHandler(interaction =>
            {
                using var dialog = new OpenFileDialog();
                dialog.Filter = "CSV files (*.csv)|*.csv";
                dialog.FilterIndex = 1;
                dialog.RestoreDirectory = true;

                interaction.SetOutput(dialog.ShowDialog() == DialogResult.OK
                    ? dialog.FileName
                    : null);
            });
            BrowseSaveFileInteraction.RegisterHandler(interaction =>
            {
                using var dialog = new SaveFileDialog();
                dialog.Filter = interaction.Input;
                dialog.FilterIndex = 1;
                dialog.RestoreDirectory = true;

                interaction.SetOutput(dialog.ShowDialog() == DialogResult.OK
                    ? dialog.FileName
                    : null);
            });


            ErrorReportInteraction.RegisterHandler(async interaction =>
            {
                var userErrorMessage = getLocalized(interaction.Input.UserErrorMessage);

                if (interaction.Input.AddRestartMessage)
                    userErrorMessage += "\n" + getLocalized("Please restart the application.");

                if (interaction.Input.AddContactMessage)
                    userErrorMessage += "\n" + getLocalized("If this does not solve the problem, contact Caretag support and report the error code.");

                userErrorMessage += $"\n{getLocalized("Error code:")} {interaction.Input.ErrorCode}";

                string title;

                switch (interaction.Input.ReportLevel)
                {
                    case ReportLevel.Error:
                        if (interaction.Input.Exception != null)
                            _logger.LogError(interaction.Input.Exception, interaction.Input.LogMessage);
                        else
                            _logger.LogError(interaction.Input.LogMessage);
                        title = getLocalized("Error");
                        break;
                    case ReportLevel.Fatal:
                        if (interaction.Input.Exception != null)
                            _logger.LogCritical(interaction.Input.Exception, interaction.Input.LogMessage);
                        else
                            _logger.LogCritical(interaction.Input.LogMessage);
                        title = getLocalized("Fatal ");
                        break;
                    case ReportLevel.Information:
                        if (interaction.Input.Exception != null)
                            _logger.LogInformation(interaction.Input.Exception, interaction.Input.LogMessage);
                        else
                            _logger.LogInformation(interaction.Input.LogMessage);
                        title = getLocalized("Information");
                        break;
                    case ReportLevel.Debug:
                        if (interaction.Input.Exception != null)
                            _logger.LogDebug(interaction.Input.Exception, interaction.Input.LogMessage);
                        else
                            _logger.LogDebug(interaction.Input.LogMessage);
                        title = getLocalized("Debug");
                        break;
                    case ReportLevel.Warning:
                        if (interaction.Input.Exception != null)
                            _logger.LogWarning(interaction.Input.Exception, interaction.Input.LogMessage);
                        else
                            _logger.LogWarning(interaction.Input.LogMessage);
                        title = getLocalized("Warning");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                var vm = new StandardDialogViewModel(new CaretagMessageBoxArguments
                {
                    Title = title,
                    Message = userErrorMessage,
                    IsWarning = true,
                    Options = CaretagMessageBoxOptions.Ok
                });

                using var dialog = new StandardDialog(vm, _resourceManager);
                await dialog.ShowDialogAsync();
                interaction.SetOutput(Unit.Default);
            });
        }
    }
}