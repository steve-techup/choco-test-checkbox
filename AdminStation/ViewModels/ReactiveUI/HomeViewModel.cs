using ReactiveUI;

namespace AdminStation.ViewModels.ReactiveUI;

public class HomeViewModel : ReactiveObject, IRoutableViewModel
{
    public string? UrlPathSegment { get; } = "Home";
    public IScreen HostScreen { get; }
}