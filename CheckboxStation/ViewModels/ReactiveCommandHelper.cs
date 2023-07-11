using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace CheckboxStation.ViewModels
{
    public static class ReactiveCommandHelper
    {
        // Create ReactiveCommand from task
        public static ReactiveCommand<Unit, Unit> CreateCommandFromTask(Func<Task> task, IScheduler scheduler)
        {
            return ReactiveCommand.CreateFromObservable(() => task().ToObservable(scheduler));
        }
    }
}
