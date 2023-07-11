using Caretag.Contracts.Api.v1;
using Caretag.Contracts.Core;
using Caretag.Contracts.Models;
using Caretag.Contracts.Models.v1.Checkbox;
using Caretag_Class.Configuration;
using CheckboxStation.ViewModels;
using DevExpress.DataAccess.Native.Web;
using Main.Extensions;
using Main.Model.Assets;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;

namespace CheckboxStation.Services.Bridge.Imlementations
{
    public class CheckInServiceApi : ICheckInService
    {
        private readonly ICheckboxApi _checkboxApi;
        private readonly AppSettingsBase _appSettingsBase;
        private readonly ILogger<CheckInServiceApi> _logger;
        private readonly ResourceManager _resourceManager;

        public CheckInServiceApi(
            ICheckboxApi checkboxApi,
            AppSettingsBase appSettingsBase,
            ILogger<CheckInServiceApi> logger,
            ResourceManager resourceManager)
        {
            _checkboxApi = checkboxApi;
            _appSettingsBase = appSettingsBase;
            _logger = logger;
            _resourceManager = resourceManager;
        }

        public async Task<CheckboxInResponse> CheckIn(Guid sessionId, string[] tags, string operationId, List<ManuallyAddedAsset> manuallyAddedAssets = null)
        {
            List<int> assetIds = new List<int>();

            if (manuallyAddedAssets != null)
            {
                foreach (var asset in manuallyAddedAssets)
                {
                    for (var i = 1; i <= asset.Quantity; i++)
                    {

                        if (asset.AssetIds.Count >= asset.Quantity)
                        {
                            assetIds.Add(asset.AssetIds[i - 1]);
                        }
                    }
                }
            }

            var request = new CheckboxInRequest
            {
                SessionId = sessionId,
                TagIds = tags,
                SurgeryId = operationId,
                AssetIds = assetIds.ToArray()
            };

            _logger.LogInformation($"CHECK IN REQUEST: {JsonConvert.SerializeObject(request)}");
            CheckboxInResponse result = null;
            await _checkboxApi.CheckIn(request).MatchAsync(
                response =>
                {
                    result = response;
                    _logger.LogInformation($"CHECK IN RESPONSE: {JsonConvert.SerializeObject(response)}");
                    return Task.CompletedTask;
                },
            errorResponse =>
            {
                _logger.LogError($"CHECK IN ERROR: {JsonConvert.SerializeObject(errorResponse)}");
                throw errorResponse.GetException(_resourceManager);
            });

            return result;
        }

        public async Task CompleteCheckIn(Guid sessionId)
        {
            await _checkboxApi.CheckInComplete(sessionId);
        }

        public async Task<CheckboxOutResponse> CheckOut(string[] tags, List<ManuallyAddedAsset> manuallyAddedAssets = null)
        {
            List<int> assetIds = new List<int>();

            if (manuallyAddedAssets != null)
            {
                foreach (var asset in manuallyAddedAssets)
                {
                    for (var i = 1; i <= asset.Quantity; i++)
                    {

                        if (asset.AssetIds.Count >= asset.Quantity)
                        {
                            assetIds.Add(asset.AssetIds[i - 1]);
                        }
                    }
                }
            }
            var request = new CheckboxOutRequest { TagIds = tags, AssetIds = assetIds.ToArray() };
            CheckboxOutResponse result = null;
            _logger.LogInformation($"CHECK OUT REQUEST: {JsonConvert.SerializeObject(request)}");
            await _checkboxApi.CheckOut(request).MatchAsync(
                response =>
                {
                    result = response;
                    _logger.LogInformation($"CHECK OUT RESPONSE: {JsonConvert.SerializeObject(response)}");
                    return Task.CompletedTask;
                },
             errorResponse =>
            {
                _logger.LogError($"CHECK OUT ERROR: {JsonConvert.SerializeObject(errorResponse)}");
                throw errorResponse.GetException(_resourceManager);
            });

            return result;
        }
    }
}
