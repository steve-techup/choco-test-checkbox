using System;
using System.Collections.Generic;
using System.Linq;
using Caretag_Class.Configuration;
using Caretag_Class.Model;

namespace CheckboxStation.Services
{
    public class ScanEventService
    {
        private readonly CaretagModel _dbContext;
        private readonly AppSettingsBase _appSettings;

        public ScanEventService(CaretagModel dbContext,
            AppSettingsBase appSettings)
        {
            _dbContext = dbContext;
            _appSettings = appSettings;
        }
        
        public ScanEventService()
        {}

        public virtual void Save(List<string> tags)
        {
            foreach (var tag in tags)
            {
                _dbContext.ScanEvent.Add(new ScanEvent
                {
                    EPC = tag,
                    Time_stamp = DateTime.Now,
                    Scan_location = _appSettings.StationUniqueID
                }); 
            }
            _dbContext.SaveChanges();
        }
        
        public virtual List<ScanEvent> GetByTag(string tag, int amount = 20)
        {
            var result = _dbContext.ScanEvent.Where(m => m.EPC == tag)
                .Take(amount)
                .OrderByDescending(m=> m.Time_stamp)
                .ToList();
            return result;
        }
    }
}