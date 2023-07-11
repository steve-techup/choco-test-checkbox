using AdminStation.ViewModels.ReactiveUI;
using AdminStation.Views;
using ReactiveUI;
using Splat;

namespace AdminStation;

public class Bootstrapper
{
    public Bootstrapper()
    {
        ConfigureServices();
    }

    private void ConfigureServices()
    {
        // Register views
        Locator.CurrentMutable.Register(() => new MainView(), typeof(IViewFor<MainViewModel>));
    }

    public void Run()
    {
    }
}