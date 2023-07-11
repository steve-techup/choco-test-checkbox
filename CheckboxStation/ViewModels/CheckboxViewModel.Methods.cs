using Caretag_Class.Configuration;
using CheckboxStation.Verification;
using Main.Model.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckboxStation.ViewModels
{
    public partial class CheckboxViewModel
    {
        public async Task DoCheckIn()
        {
            var tags = _uniqueScannedTags.Where(t => !_checkedIdTags.Contains(t));

            if (tags.Any() || (ManuallyAddedAssets != null && ManuallyAddedAssets.Any()))
            {
                await _checkInOutService.CheckIn(CurrentScanningSession.Value, tags.ToArray(), SelectedOperation.OperationId, ManuallyAddedAssets);
                _checkedIdTags.AddRange(tags);
            }
        }

        private void ResetSession(OperationViewModel operation = null)
        {
            ManuallyAddedAssets = new List<ManuallyAddedAsset>();
            CurrentOperationId = operation?.OperationId;
            SelectedOperation = operation;
            CurrentScanningSession = null;
            CheckInInProgress = false;
            _currentTray = null;
            _currentTrayEpc = null;
            _unpackedItems = new List<UnpackedItem>();
            ValidatedPackingList = null;
            PackingListViewModel.Clear(); 
            _checkedIdTags.Clear();
            _uniqueScannedTags.Clear();
            TotalTagsScanned = 0;

            if (_appSettingsBase.UseApi)
            {
                _selectedOperation = operation;
            }

            if (Features.VerificationEnabled)
            {
                _updateReportSessionNumber = true;
                _verificationReportItems?.Clear();
                _verificationSessionTags?.Clear();
            }
        }
    }
}
