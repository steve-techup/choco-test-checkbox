using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class.EventReporting;
using Main.ReactiveUI.Interactions;
using ReactiveUI;
using Surgical_Admin.Interactions;

namespace Caretag_Class.ReactiveUI.Services
{
    public class ReactiveCommandService
    {
        private readonly CommonInteractions _commonInteractions;
        // depends on CommonInteractions with default scheduler
        
        public ReactiveCommandService(CommonInteractionsFactory commonInteractionsFactory)
        {
            _commonInteractions = commonInteractionsFactory.Create(RxApp.MainThreadScheduler);
        }

        public ReactiveCommandService(CommonInteractions commonInteractions)
        {
            _commonInteractions = commonInteractions;
        }

        public ReactiveCommand<Unit, Unit> ConfirmCommand(ReactiveCommand<Unit, Unit> command, string message, IObservable<bool>? canExecute = null)
        {
            return ReactiveCommand.CreateFromObservable(() =>
            {
                return _commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments
                {
                    IsWarning = false,
                    Options = CaretagMessageBoxOptions.YesNo,
                    Message = message,
                    Title = "Confirm"
                }).Select(result =>
                {
                    if (result == CaretagMessageBoxResult.Yes)
                        command.Execute().Subscribe();
                    return Unit.Default;
                });
            }, canExecute);
        }
        public void HandleExceptions<T, U>(ReactiveCommand<T, U> cmd, string userErrorMessage, string logMessage, string errorCode, ReportLevel reportLevel)
        {
            cmd.ThrownExceptions.Subscribe(ex => _commonInteractions.ErrorReportInteraction
                .Handle(new ErrorReport()
                {
                    Exception = ex,
                    AddContactMessage = true,
                    AddRestartMessage = true,
                    UserErrorMessage = userErrorMessage,
                    LogMessage = logMessage,
                    ErrorCode = errorCode,
                    ReportLevel = reportLevel
                }).Subscribe());
        }

    }
}
