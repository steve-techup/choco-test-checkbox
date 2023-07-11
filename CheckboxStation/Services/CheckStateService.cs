using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class.Model;

namespace CheckboxStation.Services
{
    public class CheckStateService
    {
        private readonly CaretagModel _model;

        public CheckStateService()
        {

        }

        public CheckStateService(CaretagModel model)
        {
            _model = model;
        }

        public virtual void CheckInstrumentsOut(IEnumerable<Instrument_RFID> instruments)
        {
            foreach (var instrument in instruments)
            {
                instrument.OperationInstruments.ToList().ForEach(io => io.ActiveLink = false);
            }
            
            _model.SaveChanges();
        }


        public virtual void CheckInstrumentsIn(ICollection<Instrument_RFID> instruments, Operation operation)
        {
            foreach (Instrument_RFID instrument in instruments)
            {
                var operationInstrument = new OperationInstrument
                {
                    ActiveLink = true,
                    Operation = operation
                };
                instrument.OperationInstruments ??= new List<OperationInstrument>();
                instrument.OperationInstruments.Add(operationInstrument);
            }

            _model.SaveChanges();
        }

        public virtual ICollection<Operation> GetOperations(OperationState state)
        {
            return _model.Operation.Where(o => o.State == state.ToString()).ToList();
        }
    }
}
