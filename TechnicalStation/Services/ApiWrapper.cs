using Caretag.Contracts.Api.v1;
using Caretag.Contracts.Core;
using Caretag.Contracts.Enums;
using Caretag.Contracts.Models;
using Caretag.Contracts.Models.v1.Assets;
using Caretag.Contracts.Models.v1.Settings;
using Caretag_Class.Configuration;
using Caretag_Class.Model;
using DevExpress.DataProcessing;
using DevExpress.LookAndFeel.Design;
using DevExpress.XtraEditors.Design;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Refit;
using RFIDAbstractionLayer;
using RFIDAbstractionLayer.TagEncoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Threading.Tasks;
using TechnicalStation.Configuration;
using TechnicalStation.Infrastructure;
using ReaderType = Caretag.Contracts.Enums.ReaderType;

namespace TechnicalStation.Services
{
    /// <summary>
    /// Caretag 3.0 API implemetation of IDataRepository
    /// </summary>
    public class ApiWrapper : IDataRepository
    {
        private readonly IIdentityService _identityService;
        private readonly IAssetTypesApi _assetTypesApi;
        private readonly IAssetsApi _assetApi;
        private readonly IAssetTagsApi _assetTagsApi;
        private readonly AppSettingsBase _appSettingsBase;
        private readonly ISettingsApi _settingsApi;
        private readonly TechnicalStationAppSettings _technicalStationAppSettings;
        public ApiWrapper(IIdentityService identityService,
                          IAssetsApi assetApi,
                          IAssetTypesApi assetTypesApi,
                          IAssetTagsApi assetTagsApi,
                          AppSettingsBase appSettings,
                          ISettingsApi settingsApi,
                          TechnicalStationAppSettings technicalStationAppSettings)
        {
            _identityService = identityService;
            _assetTypesApi = assetTypesApi;
            _assetApi = assetApi;
            _assetTagsApi = assetTagsApi;
            _appSettingsBase = appSettings;
            _settingsApi = settingsApi;
            _technicalStationAppSettings = technicalStationAppSettings;
        }

        //This method is not needed in 3.0
        public async Task CommitEpc(RfidEPC epc) { }
        public async Task CreateNewContainer(string epc, int? assetTagId = null, string lot = null, DateTime? productionDate = null, Instrument_Description instrumentDescription = null)
        {
            await _assetApi.Create(new AssetCreateRequest()
            {
                ParentAssetId = null,
                AssetTypeId = int.Parse(instrumentDescription.Description_ID),
                Status = Status.Active,
                LotNo = lot,
                ManufacturingDate = productionDate != null ? new DateTimeOffset(productionDate.Value, TimeSpan.Zero) : null,
                AssetTagId = (int)assetTagId
            });
        }
        public async Task CreateNewTray(string epc, int? assetTagId = null, string lot = null, DateTime? productionDate = null, Instrument_Description instrumentDescription = null)
        {
            await _assetApi.Create(new AssetCreateRequest()
            {
                ParentAssetId = null,
                AssetTypeId = int.Parse(instrumentDescription.Description_ID),
                Status = Status.Active,
                LotNo = lot,
                ManufacturingDate = productionDate != null ? new DateTimeOffset(productionDate.Value, TimeSpan.Zero) : null,
                AssetTagId = (int)assetTagId
            });
        }
        public async Task CreateNewTrolley(string epc, int? assetTagId = null, string lot = null, DateTime? productionDate = null, Instrument_Description instrumentDescription = null)
        {
            await _assetApi.Create(new AssetCreateRequest()
            {
                ParentAssetId = null,
                AssetTypeId = int.Parse(instrumentDescription.Description_ID),
                Status = Status.Active,
                LotNo = lot,
                ManufacturingDate = productionDate != null ? new DateTimeOffset(productionDate.Value, TimeSpan.Zero) : null,
                AssetTagId = (int)assetTagId
            });
        }
        public async Task CreateNewInstrument(string epc, string lot, DateTime productionDate, Instrument_Description instrumentDescription, int? assetTagId = null)
        {
            await _assetApi.Create(new AssetCreateRequest()
            {
                ParentAssetId = null,
                AssetTypeId = int.Parse(instrumentDescription.Description_ID),
                Status = Status.Active,
                LotNo = lot,
                ManufacturingDate = productionDate != null ? new DateTimeOffset(productionDate, TimeSpan.Zero) : null,
                AssetTagId = (int)assetTagId
            });
        }
        public async Task<RfidEPC> CreateNewUncommittedEpc(uint gs1CompanyPrefix, uint tenantId)
        {
            var draftAsset = await _assetTagsApi.CreateDraft();

            var epc = new RfidEPC(draftAsset.TagId);
            epc.AssetTagId = draftAsset.Id;

            return epc;
        }

        //This method is not needed in 3.0 because the logic is moved to the server
        public async Task<AssetId> GetHighestUncommittedAssetId() => null;

        public async Task<Tuple<Instrument_RFID, AssetDetailsItem>> GetInstrumentRfidByEpc(string epc)
        {
            try
            {
                var asset = await _assetApi.GetByTagId(epc, (int)AssetClassType.Instrument, null);

                if (asset != null)
                {
                    return await ProcessInstrument(asset, epc, "Instrument");
                }
                return null;
            }
            catch (ApiException ex)
            {
                return await HandlGetAssetByTagIdeApiError<Tuple<Instrument_RFID, AssetDetailsItem>>(ex, epc, "Instrument");
            }
        }
        public async Task<Tuple<Tray_RFID, AssetDetailsItem>> GetTrayRfidByEpc(string epc)
        {
            try
            {
                var asset = await _assetApi.GetByTagId(epc, (int)AssetClassType.Tray, null);


                if (asset != null)
                {
                    return await ProcessTray(asset, epc);
                }
                return null;
            }
            catch (ApiException ex)
            {
                return await HandlGetAssetByTagIdeApiError<Tuple<Tray_RFID, AssetDetailsItem>>(ex, epc);
            }
        }
        public async Task<Tuple<Container_RFID, AssetDetailsItem>> GetContainerRfidByEpc(string epc)
        {
            try
            {
                var asset = await _assetApi.GetByTagId(epc, (int)AssetClassType.Container, null);


                if (asset != null)
                {
                    return await ProcessContainer(asset, epc);
                }
                return null;
            }
            catch (ApiException ex)
            {
                return await HandlGetAssetByTagIdeApiError<Tuple<Container_RFID, AssetDetailsItem>>(ex, epc);
            }
        }
        public async Task<IReadOnlyCollection<Instrument_Description>> SearchInstrumentType(string query, AssetClassType[] classTypes = null)
        {
            if(classTypes == null)
            {
                classTypes = new AssetClassType[] { AssetClassType.Instrument };
            }

            var request = new AssetTypeFullSearchRequest()
            {
                Query = query,
                ClassTypes = classTypes,
                Statuses = new Status[] { Status.Active, Status.Inactive, Status.Deleted, Status.Locked, Status.LimitedUse },
                Paging = new PaginatedRequest()
                {
                    PageNumber = 1,
                    PageSize = 10000
                }
            };

            var searchResult = await _assetTypesApi.FullSearch(request);

            return searchResult != null ? searchResult.Items.ConvertAll(item => new Instrument_Description()
            {
                Description_ID = item.Id.ToString(),
                Description_Name = item.Name,
                Instrument_Company = item.Manufacturer,
                D = $"{item.Dimension?.Dimension}{item.Dimension?.Uom}",
                E = item.OemSku
            }) : new List<Instrument_Description>();
        }
        public async Task<Tuple<bool, int?>> GetAssetTag(string tagId)
        {
            try
            {
                var assetTag = await _assetTagsApi.GetByTagId(tagId);
                return assetTag != null ? new Tuple<bool, int?>(true, assetTag.Id) : new Tuple<bool, int?>(false, null);
            }
            catch (ApiException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new Tuple<bool, int?>(false, null);
                }
                throw ex;
            }
        }
        public async Task UpdateInstrument(Instrument_RFID instrumentRfid, Instrument_Description instrumentDescription, string lot = null, DateTime? productionDate = null)
        {
            var updateRequest = new AssetUpdateRequest()
            {
                AssetTypeId = int.Parse(instrumentDescription.Description_ID),
                LotNo = lot,
                ManufacturingDate = new DateTimeOffset(productionDate.Value, TimeSpan.Zero),
                Status = Status.Active,
            };

            await _assetApi.Update((int)instrumentRfid.Instrument_ID, updateRequest);
        }
        public async Task<RfidEPC> GenereateNewEpc(long assetId, string lot, DateTime? productionDate)
        {
            var request = new AssetResetTagRequest
            {
                ManufacturingDate = productionDate != null ? new DateTimeOffset(productionDate.Value, TimeSpan.Zero) : null,
                LotNo = lot
            };

            var result = await _assetApi.ResetTag((int)assetId, request);
            return new RfidEPC(result?.TagId);
        }
        public async Task<EPC_Number_Serie> GetEpcNumberSerie()
        {
            ////This method need to be implemented in the API (Caretag 3.0)
            ////This is just a temporary solution
            return new EPC_Number_Serie()
            {
                Owner_Ship = "Caretag Aps",
                Owner_Serie = "5701234",
                Customer_Number = "101",
                Special_Number = "99",
                Max_Number = 100000000,
                Start_EPC = "00000000",
                New_EPC = "00001591",
                Confirm_To_GS1 = false,
                Last_Used_EPC = "00001591",
                Last_Used_Date = DateTime.Parse("2022-05-04 18:29:57.000")
            };
        }
        public async Task<bool> IsEpcValid(string epc, uint gs1CompanyPrefix)
        => await _assetTagsApi.ValidateTag(epc);


        public async Task<Tuple<Instrument_RFID, AssetDetailsItem>> GetTrolleyRfidByEpc(string epc)
        {
            try
            {
                var asset = await _assetApi.GetByTagId(epc, (int)AssetClassType.TrolleyOpen, null);

                if (asset != null)
                {
                    return await ProcessInstrument(asset, epc, "Surgical Trolley");
                }
            }
            catch (ApiException ex)
            {
                var result = await HandlGetAssetByTagIdeApiError<Tuple<Instrument_RFID, AssetDetailsItem>>(ex, epc, "Surgical Trolley");

                if (result != null)
                    return result;
            }

            try
            {
                var asset = await _assetApi.GetByTagId(epc, (int)AssetClassType.TrolleyClosed, null);

                if (asset != null)
                {
                    return await ProcessInstrument(asset, epc, "Surgical Trolley");
                }
                return null;
            }
            catch (ApiException ex)
            {
                return await HandlGetAssetByTagIdeApiError<Tuple<Instrument_RFID, AssetDetailsItem>>(ex, epc, "Surgical Trolley");
            }
        }

        public async Task<Tuple<Tray_RFID, AssetDetailsItem>> GetSterilizationCartRfidByEpc(string epc)
        {
            try
            {
                var asset = await _assetApi.GetByTagId(epc, (int)AssetClassType.SterilizationCart, null);


                if (asset != null)
                {
                    return await ProcessTray(asset, epc, true);
                }
                return null;
            }
            catch (ApiException ex)
            {
                return await HandlGetAssetByTagIdeApiError<Tuple<Tray_RFID, AssetDetailsItem>>(ex, epc);
            }
        }

        public async Task CreateNewSterilizationCart(string epc, int? assetTagId = null, string lot = null, DateTime? productionDate = null, Instrument_Description instrumentDescription = null)
        {
            await _assetApi.Create(new AssetCreateRequest()
            {
                ParentAssetId = null,
                AssetTypeId = int.Parse(instrumentDescription.Description_ID),
                Status = Status.Active,
                LotNo = lot,
                ManufacturingDate = productionDate != null ? new DateTimeOffset(productionDate.Value, TimeSpan.Zero) : null,
                AssetTagId = (int)assetTagId
            });
        }

        private async Task<Tuple<Instrument_RFID, AssetDetailsItem>> ProcessInstrument(AssetResponse asset, string epc, string assetClassType)
        {
            var assertType = await _assetTypesApi.Get(asset.AssetType.Id);

            var details = new AssetDetailsItem
            {
                Id = asset.Id,
                Epc = epc,
                Type = assetClassType,
                Name = asset.Name,
                Description = asset.Description,
                Status = asset.Status.ToString(),
                Sku = assertType?.OemSku,
                Manufacturer = assertType?.Brand?.Name,
                LotNumber = asset.LotNo,
                ManufacturingDate = asset.ManufacturingDate
            };

            var instrument = new Instrument_RFID
            {
                Instrument_ID = asset.Id,
                EPC_Nr = epc,
                Description_Text = $"{asset.Description} {asset.Name}",
                LotNumber = asset.LotNo,
                InstrumentProductionDate = asset.ManufacturingDate,
                Description_ID = asset.AssetType.Id.ToString()
            };

            return new Tuple<Instrument_RFID, AssetDetailsItem>(instrument, details);
        }

        private async Task<Tuple<Tray_RFID, AssetDetailsItem>> ProcessTray(AssetResponse asset, string epc, bool isSterlizationCart = false)
        {
            var assertType = await _assetTypesApi.Get(asset.AssetType.Id);

            var details = new AssetDetailsItem
            {
                Id = asset.Id,
                Epc = epc,
                Type = isSterlizationCart ? "Sterilization Cart" : "Tray",
                Name = asset.Name,
                Description = asset.Description,
                Status = asset.Status.ToString(),
                Sku = assertType?.OemSku,
                Manufacturer = assertType?.Brand?.Name,
                LotNumber = asset.LotNo,
                ManufacturingDate = asset.ManufacturingDate
            };

            var tray = new Tray_RFID
            {
                Tray_ID = asset.Id,
                EPC_Nr = epc,
                Description_Text = $"{asset.Description} {asset.Name}",
                Description_ID = asset.AssetType.Id
            };

            return new Tuple<Tray_RFID, AssetDetailsItem>(tray, details);
        }

        private async Task<Tuple<Container_RFID, AssetDetailsItem>> ProcessContainer(AssetResponse asset, string epc)
        {
            var assertType = await _assetTypesApi.Get(asset.AssetType.Id);

            var details = new AssetDetailsItem
            {
                Id = asset.Id,
                Epc = epc,
                Type = "Container",
                Name = asset.Name,
                Description = asset.Description,
                Status = asset.Status.ToString(),
                Sku = assertType?.OemSku,
                Manufacturer = assertType?.Brand?.Name,
                LotNumber = asset.LotNo,
                ManufacturingDate = asset.ManufacturingDate
            };

            var container = new Container_RFID
            {
                Container_ID = asset.Id,
                EPC_Nr = epc,
                Description_ID = asset.AssetType.Id
            };
            return new Tuple<Container_RFID, AssetDetailsItem>(container, details);
        }

        private async Task<T> HandlGetAssetByTagIdeApiError<T>(ApiException ex, string epc, string assetClassType = null)
        {
            if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                return default;

            ApiErrorDetails errorDetails = null;
            if (!string.IsNullOrEmpty(ex.Content))
            {
                try
                {
                    errorDetails = JsonConvert.DeserializeObject<ApiErrorDetails>(ex.Content);
                }
                catch { }
            }

            if (errorDetails != null)
            {
                var errorDetailItems = errorDetails.Errors.Select(e => e.Details).FirstOrDefault();

                if (errorDetailItems != null && errorDetailItems.Any())
                {
                    var errorDetailsItem = errorDetailItems.First();


                    switch (errorDetailsItem.ErrorCode)
                    {
                        case "AssetWrongClassTypeError":
                            return default;
                        case "AssetInactiveStatusError":
                        case "AssetLimitedStatusError":
                        case "AssetLockedStatusError":
                            break;
                        default:
                            throw ex;
                    }

                    var jObject = errorDetailsItem.Data as JObject;

                    if (jObject != null && jObject.First != null)
                    {
                        var errorData = jObject.ToObject<AssetIdResponse>();

                        if (errorData != null)
                        {
                            try
                            {
                                var asset = await _assetApi.GetAssetById(errorData.AssetId);
                                object result;
                                if(asset != null)
                                {
                                    var type = typeof(T);
                                    if (type == typeof(Tuple<Container_RFID, AssetDetailsItem>))
                                    {
                                        result = await ProcessContainer(asset, epc);
                                    }
                                    else if (type == typeof(Tuple<Tray_RFID, AssetDetailsItem>))
                                    {
                                        result = await ProcessTray(asset, epc);
                                    }
                                    else
                                    {
                                        result = await ProcessInstrument(asset, epc, assetClassType);
                                    }

                                    return (T)Convert.ChangeType(result, type);
                                }

                            }
                            catch (Exception exc)
                            {
                                throw exc; ;
                            }
                        }
                    }

                    throw ex;
                }
            }

            throw ex;
        }

        public async Task<TechnicalStationConfig> GetStationConfig()
        {
            TechnicalStationConfig config = null;

            await _settingsApi.GetAppInstanceSettings().MatchAsync(
                appInstance =>
                {
                    config = new TechnicalStationConfig
                    {
                        StationName = appInstance.Name,
                        AppSettings = new TechnicalStationAppSettings
                        {
                            ResetEnabled = appInstance.Settings?.TechnicalStationSetting?.ResetEnabled
                        }
                    };

                    if(appInstance.Settings?.TechnicalStationSetting?.Rfid != null)
                    {
                        var appInstanceRfidConfig = appInstance.Settings.TechnicalStationSetting?.Rfid;

                        config.RFID = new RfIdConfig
                        {
                            ReaderIpAddress = appInstanceRfidConfig.ReaderIpAddress,
                            CachedPorts = appInstanceRfidConfig.CachedPorts?.ToList()
                        };

                        config.RFID.ReaderType = appInstanceRfidConfig.ReaderType switch
                        {
                            ReaderType.SimulationOnly => RFIDAbstractionLayer.ReaderType.Simulator,
                            ReaderType.NordicIdOnly => RFIDAbstractionLayer.ReaderType.NordicIdOrCAEN,
                            ReaderType.CaenOnly => RFIDAbstractionLayer.ReaderType.NordicIdOrCAEN,
                            ReaderType.ImpinjOnly => RFIDAbstractionLayer.ReaderType.Impinj,
                            _ => RFIDAbstractionLayer.ReaderType.Simulator
                        };
                    }

                    return Task.CompletedTask;
                }, _ => { return Task.CompletedTask; });


            if (config == null)
            {
                config = new TechnicalStationConfig();
                config.AppSettings = new();
            }

            if (string.IsNullOrEmpty(config.StationName))
            {
                config.StationName = "Technical Station";
            }

            if (config.RFID == null)
            {
                config.RFID = _appSettingsBase.RFID;
            }

            if (config.AppSettings.ResetEnabled == null)
            {
                config.AppSettings.ResetEnabled = false;
            }


            config.AppSettings.AccessPasswordEnabled = _technicalStationAppSettings.AccessPasswordEnabled;
            config.AppSettings.MinimumStrength = _technicalStationAppSettings.MinimumStrength;
            config.AppSettings.NextInternalId = _technicalStationAppSettings.NextInternalId;

            return config;
        }
    }
}
