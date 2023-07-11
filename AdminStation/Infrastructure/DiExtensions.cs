using System;
using System.Resources;
using AdminStation.Configuration;
using AdminStation.Services;
using AdminStation.ViewModels.DataTypeViewModels;
using AdminStation.ViewModels.ReactiveUI;
using AdminStation.Views;
using AdminStation.Views.Assets;
using AdminStation.Views.Reports;
using AdminStation.Views.Settings;
using Caretag_Class.EventReporting;
using Caretag_Class.Util;
using Main.ReactiveUI;
using Main.ReactiveUI.CommandBinders;
using Main.ReactiveUI.Interactions;
using Main.Repositories.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Surgical_Admin.Interactions;
using ScansView = AdminStation.Views.Reports.ScansView;

namespace AdminStation.Infrastructure;

public static class DiExtensions
{
    // Register a view model and a view factory to ensure that the view model injected into the constructor is the same that is used in the public view model property. 
    public static IServiceCollection AddViewModelAndViewFactory<TViewModel, TView>(this IServiceCollection services,
        Func<IServiceProvider, TViewModel, TView> factory)
        where TViewModel : class where TView : IViewFor<TViewModel>
    {
        return
            services.AddTransient<TViewModel>().AddTransient<
                Func<TViewModel, IViewFor<TViewModel>>,
                Func<TViewModel, IViewFor<TViewModel>>>(
                provider => vm => factory(provider, vm));
    }

    public static IServiceCollection AddAdminStation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<StringDistanceCalculator>();
        services.AddTransient<CSVImportService>();
        services.AddSingleton(new ResourceManager("Surgical_Admin.WinFormStrings",
            typeof(DiExtensions).Assembly));

        services.AddSingleton<LoginUnitOfWorkFactory>();
        services.AddSingleton<CommonInteractionsFactory>();
        services.AddSingleton<IViewLocator, ViewModelProvidingViewLocator>();
  
        services.AddViewModelAndViewFactory<InstrumentTypesViewModel, InstrumentTypesView>((provider, vm) =>
            new InstrumentTypesView(provider.GetService<EventReporter>(), vm));
        services.AddViewModelAndViewFactory<CSVImportViewModel, CSVImport>((provider, vm) =>
            new CSVImport(vm, provider.GetService<StringDistanceCalculator>()));

        services.AddViewModelAndViewFactory<HomeViewModel, HomeView>((_, vm) => new HomeView(vm));
        services.AddViewModelAndViewFactory<TraysViewModel, TraysView>((_, vm) => new TraysView(vm));
        services.AddViewModelAndViewFactory<CostCentersViewModel, CostCentersView>((_, vm) => new CostCentersView(vm));
        services.AddViewModelAndViewFactory<ScansViewModel, ScansView>((_, vm) => new ScansView(vm));
        services.AddViewModelAndViewFactory<PackingLogViewModel, PackingLogView>((_, vm) => new PackingLogView(vm));
        services.AddViewModelAndViewFactory<CostLogViewModel, CostLogView>((_, vm) => new CostLogView(vm));
        services.AddViewModelAndViewFactory<UsersViewModel, UsersView>((_, vm) => new UsersView(vm));

        services.AddTransient<IViewFor<MainViewModel>, MainView>();

        services.AddSingleton<ICreatesCommandBinding, BarButtonItemCommandBinder>();

        // Create MainViewModel and register as IScreen
        services.AddSingleton<IScreen>(new MainViewModel());

        return services.AddSingleton(m => configuration.Get<AdminStationAppSettings>());
    }
}