using Caretag.Contracts.Models.v1.Checkbox;
using Main.Model.Assets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckboxStation.Services.Bridge
{
    public interface ICheckInService
    {
        Task<CheckboxInResponse> CheckIn(Guid sessionId, string[] tags, string operationId, List<ManuallyAddedAsset> manuallyAddedAssets = null);
        Task CompleteCheckIn(Guid sessionId);
        Task<CheckboxOutResponse> CheckOut(string[] tags, List<ManuallyAddedAsset> manuallyAddedAssets = null);
    }
}
