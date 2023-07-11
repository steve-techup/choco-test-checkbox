using Caretag.Contracts.Models.v1.Checkbox;
using Caretag_Class.Model;
using Lextm.SharpSnmpLib;
using Main.Model.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckboxStation.Services.Bridge.Imlementations.CheckIn
{
    public class CheckInServiceDb : ICheckInService
    {
        private readonly CaretagModel _model;
        public CheckInServiceDb(CaretagModel model)
        {
            _model = model;
        }

        public Task<CheckboxInResponse> CheckIn(Guid sessionId, string[] tags, string operationId, List<ManuallyAddedAsset> manuallyAddedAssets = null)
        {
            throw new NotImplementedException();
        }

        public Task CompleteCheckIn(Guid sessionId)
        {
            throw new NotImplementedException();
        }

        public Task<CheckboxOutResponse> CheckOut(string[] tags, List<ManuallyAddedAsset> manuallyAddedAssets = null)
        {
            throw new NotImplementedException();
        }

        //public virtual void CheckIn(ICollection<Instrument_RFID> instruments, Operation operation)
        //{
        //    foreach (Instrument_RFID instrument in instruments)
        //    {
        //        var operationInstrument = new OperationInstrument
        //        {
        //            ActiveLink = true,
        //            Operation = operation
        //        };
        //        instrument.OperationInstruments ??= new List<OperationInstrument>();
        //        instrument.OperationInstruments.Add(operationInstrument);
        //    }

        //    _model.SaveChanges();
        //}
    }
}
