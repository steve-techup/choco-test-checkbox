using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class.Model;
using ReactiveUI;

namespace CheckboxStation.ViewModels
{
    public class OperationViewModel : ReactiveObject
    {
        private readonly Operation _operation;

        public OperationViewModel(Operation operation)
        {
            _operation = operation;
            Id = _operation.Id;
            OperationId = _operation.OperationId;
            OperatingRoom = _operation.OperatingRoom;
            State = _operation.State;
            Timestamp = _operation.Timestamp;
        }

        public Operation Operation => _operation;
        
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _operation.Id = value;
                this.RaiseAndSetIfChanged(ref _id, value);
            }
        }

        private string _operationId;
        public string OperationId
        {
            get => _operationId;
            set
            {
                _operation.OperationId = value;
                this.RaiseAndSetIfChanged(ref _operationId, value);
            }
        }

        private string _operatingRoom;
        public string OperatingRoom
        {
            get => _operatingRoom;
            set
            {
                _operation.OperatingRoom = value;
                this.RaiseAndSetIfChanged(ref _operatingRoom, value);
            }
        }

        private string _state;
        public string State
        {
            get => _state;
            set
            {
                _operation.State = value;
                this.RaiseAndSetIfChanged(ref _state, value);
            }
        }

        private DateTimeOffset _timestamp;
        public DateTimeOffset Timestamp
        {
            get => _timestamp;
            set
            {
                _operation.Timestamp = value;
                this.RaiseAndSetIfChanged(ref _timestamp, value);
            }
        }

        private Guid? _sessionId;
        public Guid? SessionId
        {
            get => _sessionId;
            set
            {
                _sessionId = value;
                this.RaiseAndSetIfChanged(ref _sessionId, value);
            }
        }
    }
}
