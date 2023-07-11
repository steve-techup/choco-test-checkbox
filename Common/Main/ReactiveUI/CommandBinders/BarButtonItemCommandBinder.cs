using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.XtraBars;
using ReactiveUI;

namespace Main.ReactiveUI.CommandBinders
{
    public class BarButtonItemCommandBinder : ICreatesCommandBinding
    {
        public int GetAffinityForObject(Type type, bool hasEventTarget)
        {
            return type.GetTypeInfo().IsAssignableFrom(typeof(BarButtonItem).GetTypeInfo()) ? 2 : 0;
        }

        public IDisposable BindCommandToObject(ICommand command, object target, IObservable<object> commandParameter)
        {
            var item = (BarButtonItem)target;

            var canExecute = new EventHandler((_, _) => item.Enabled = command.CanExecute(null));
            var itemClick = new ItemClickEventHandler((_, _) => command.Execute(null));

            command.CanExecuteChanged += canExecute;
            item.ItemClick += itemClick;

            return Disposable.Create(() =>
            {
                item.ItemClick -= itemClick;
                command.CanExecuteChanged -= canExecute;
            });
        }

        public IDisposable BindCommandToObject<TEventArgs>(ICommand command, object target, IObservable<object> commandParameter,
            string eventName)
        {
            throw new NotImplementedException();
        }
    }
}