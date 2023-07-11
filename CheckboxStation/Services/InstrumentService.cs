using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Caretag_Class.Model;
using Caretag_Class.Model.Service;
using CheckboxStation.Configuration;
using Serilog;

namespace CheckboxStation.Services
{
    public class InstrumentService
    {
        private readonly CaretagModel _dbModel;
        private readonly ILogger _logger;

        public InstrumentService()
        {}

        public InstrumentService(CaretagModel dbModel,
            ILogger logger)
        {
            _dbModel = dbModel;
            _logger = logger;
            _dbModel.Database.Log = s => _logger.Debug(s);
        }
        
        public virtual List<Instrument_RFID> GetByTagsWithOperationAndDescriptionAndPopulateServiceRequests(List<string> tags)
        {
            var instruments = _dbModel.Instrument_RFID.Where(i => tags.Contains(i.EPC_Nr))
                .Include(i => i.OperationInstruments)
                .Include(i => i.InstrumentDescription)
                .ToList();

            var epcs = instruments.Select(i => i.EPC_Nr).ToList();
            var serviceRequests = _dbModel.ServiceRequest.Where(s => epcs.Contains(s.InstrumentEPC)).ToList();

            instruments.ForEach(i =>
            {
                i.ServiceRequests = serviceRequests.Where(s => s.InstrumentEPC == i.EPC_Nr).ToList();
            });
            return instruments;
        }

        public virtual List<Instrument_RFID> GetByTagsWithDescription(List<string> tags)
        {
            return _dbModel.Instrument_RFID.Where(i => tags.Contains(i.EPC_Nr))
                .Include(i => i.InstrumentDescription).ToList();
        }

        public virtual Instrument_Description GetDescription(string descriptionId)
        {
            return _dbModel.Instrument_Description.FirstOrDefault(id => id.Description_ID == descriptionId);
        }

        public virtual ServiceRequest SendToService(string tagId, long instrumentId)
        {
            var serviceRequest = _dbModel.ServiceRequest.FirstOrDefault(m =>
                m.InstrumentEPC== tagId && m.State != "RESOLVED");

            if (serviceRequest == null)
            {
                var sr = new ServiceRequest()
                {
                    InstrumentEPC = tagId,
                    InstrumentId = instrumentId,
                    Note = "",
                    TriggeredBy = "Manual",
                    State = ServiceState.ACTIVE.ToString(),
                    Timestamp = DateTime.Now
                };
                _dbModel.ServiceRequest.Add(sr);

                _dbModel.SaveChanges();

                return sr;
            }

            return null;
        }
    }
}