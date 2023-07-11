using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class.EventReporting;
using Main.ReactiveUI.Interactions;
using ReactiveUI;
using Surgical_Admin.Interactions;

namespace Caretag_Class.ReactiveUI
{
    public class DefaultExceptionHandler : IObserver<Exception>
    {
        private CommonInteractions _commonInteractions;

        public DefaultExceptionHandler(CommonInteractionsFactory commonInteractionsFactory)
        {
            _commonInteractions = commonInteractionsFactory.Create(RxApp.MainThreadScheduler);
        }

        private void HandleError(Exception value)
        {
            if (Debugger.IsAttached) Debugger.Break();

            RxApp.MainThreadScheduler.Schedule(() =>
            {
                _commonInteractions.ErrorReportInteraction.Handle(new ErrorReport()
                {
                    Exception = value,
                    AddContactMessage = true,
                    AddRestartMessage = true,
                    UserErrorMessage = "An unhandled error has occurred",
                    LogMessage = "An unhandled error has occurred",
                    ErrorCode = "generic-0001",
                    ReportLevel = ReportLevel.Error
                }).Subscribe();
            });
        }

        public void OnNext(Exception value)
        {
            HandleError(value);
        }

        public void OnError(Exception error)
        {
            HandleError(error);
        }

        public void OnCompleted()
        {
            if (Debugger.IsAttached) Debugger.Break();
            
            RxApp.MainThreadScheduler.Schedule(() => { throw new NotImplementedException(); });
        }
    }
}
