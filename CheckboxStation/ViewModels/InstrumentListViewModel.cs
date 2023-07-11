using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class.Model;
using CheckboxStation.Services;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;

namespace CheckboxStation.ViewModels
{
    internal class InstrumentListViewModel : ReactiveObject
    {
        public OperationViewModel OperationViewModel { get; }

        private List<IGrouping<string, Instrument_RFID>> _groupedInstruments = new();
        public List<IGrouping<string, Instrument_RFID>> GroupedInstruments
        {
            get => _groupedInstruments;
            set => this.RaiseAndSetIfChanged(ref _groupedInstruments, value);
        }
        
        public InstrumentListViewModel(OperationViewModel operationViewModel, CheckboxService checkboxService)
        {
            OperationViewModel = operationViewModel;

            _groupedInstruments = checkboxService.GetInstrumentsForOperation(operationViewModel.Operation);
        }


    }

}
