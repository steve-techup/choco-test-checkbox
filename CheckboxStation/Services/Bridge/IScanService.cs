using Caretag_Class.Model;
using CheckboxStation.Verification;
using Main.Model.PackingList.Validation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckboxStation.Services.Bridge
{
    public interface IScanService
    {
        Task<ValidatedPackingList> ValidatePackingList(List<string> tags, ValidatedPackingList? old);
        Task<List<Instrument_RFID>> GetInstruments(List<string> tags);
        Task<List<UnpackedItem>> GetUnpackedItems(Tray_Description tray, string trayEpc);
        void SaveValidatedPackingList(ValidatedPackingList validatedPackingList);
        void SaveScanLog(List<string> tags);
    }
}
