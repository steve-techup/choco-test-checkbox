using System.Windows.Forms;
using AdminStation.ViewModels.ReactiveUI;
using ReactiveUI;

namespace AdminStation.Views;

public partial class HomeView : UserControl, IViewFor<HomeViewModel>
{
    private HomeViewModel _vm;

    public HomeView(HomeViewModel vm)
    {
        _vm = vm;
        InitializeComponent();
    }

    object IViewFor.ViewModel
    {
        get => _vm;
        set => _vm = (HomeViewModel) value;
    }

    HomeViewModel IViewFor<HomeViewModel>.ViewModel
    {
        get => _vm;
        set => _vm = value;
    }
}