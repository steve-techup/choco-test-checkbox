using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class.Model;
using CheckboxStation.Services;
using CheckboxStation.Views;
using Main.Model.PackingList.Validation;
using Main.ReactiveUI.Interactions;
using ReactiveUI;
using Surgical_Admin.Interactions;

namespace CheckboxStation.ViewModels
{
    public class CheckInViewModelFactory
    {
        private readonly CheckStateService _service;
        private readonly CheckboxInteractions _checkboxInteractions;
        private readonly CommonInteractions _commonInteractions;

        public CheckInViewModelFactory(CheckStateService service, CheckboxInteractions checkboxInteractions, CommonInteractionsFactory commonInteractionsFactory)
        {
            _service = service;
            _checkboxInteractions = checkboxInteractions;
            _commonInteractions = commonInteractionsFactory.Create(RxApp.MainThreadScheduler);
        }

        public CheckInViewModel Get(ValidatedPackingList validatedPackingList)
        {
            return new CheckInViewModel(validatedPackingList, _service, _checkboxInteractions, _commonInteractions);
        }
    }
}
