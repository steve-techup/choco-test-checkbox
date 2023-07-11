using System;
using Caretag_Class.ReactiveUI;
using CheckboxStation.ViewModels;
using ReactiveUI;

namespace CheckboxStation.Infrastructure
{
    public static class ConfirmInteractionExtensions
    {
        public static IObservable<CaretagMessageBoxResult> Warning(this Interaction<CaretagMessageBoxArguments, CaretagMessageBoxResult> confirm, string title, string message)
            => confirm.Handle(new CaretagMessageBoxArguments
            {
                Options = CaretagMessageBoxOptions.Ok,
                IsWarning = true,
                Message = message,
                Title = title
            });
        
        public static IObservable<CaretagMessageBoxResult> Message(this Interaction<CaretagMessageBoxArguments, CaretagMessageBoxResult> confirm, string title, string message)
            => confirm.Handle(new CaretagMessageBoxArguments
            {
                Options = CaretagMessageBoxOptions.Ok,
                IsWarning = false,
                Message = message,
                Title = title
            });
    }
}