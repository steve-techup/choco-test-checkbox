using Caretag_Class.Model;
using CheckboxStation.Verification;
using DevExpress.LookAndFeel.Design;
using Main.Model.PackingList.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckboxStation.Services.Bridge
{
    public class ScanServiceDb : IScanService
    {
        private readonly PackingListValidationService _packingListValidationService;
        private readonly InstrumentService _instrumentService;
        private readonly ScanEventService _scanEventService;

        public ScanServiceDb(
            PackingListValidationService packingListValidationService,
            InstrumentService instrumentService,
            ScanEventService scanEventService)
        {
            _packingListValidationService = packingListValidationService;
            _instrumentService = instrumentService;
            _scanEventService = scanEventService;
        }

        public async Task<List<Instrument_RFID>> GetInstruments(List<string> tags)
        {
            return _instrumentService.GetByTagsWithOperationAndDescriptionAndPopulateServiceRequests(tags);
        }

        public async Task<ValidatedPackingList> ValidatePackingList(List<string> tags, ValidatedPackingList old)
        {
            return _packingListValidationService.ValidatePackingList(tags, old);
        }

        public async Task<List<UnpackedItem>> GetUnpackedItems(Tray_Description tray, string trayEpc)
        {
            return (await _packingListValidationService.GetUnpackedPacklistItems(tray, trayEpc))
                                                       .Select(ui => UnpackedItem.FromTrayPacklistItem(ui)).ToList();
        }

        public void SaveValidatedPackingList(ValidatedPackingList validatedPackingList)
        {
            _packingListValidationService.Save(validatedPackingList);
        }

        public void SaveScanLog(List<string> tags)
        {
            _scanEventService.Save(tags);
        }

        public async Task Test(Guid sessionId, string[] tags)
        {

        }
    }
}
