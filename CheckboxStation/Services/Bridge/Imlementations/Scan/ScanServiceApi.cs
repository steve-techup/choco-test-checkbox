using Caretag.Contracts.Api.v1;
using Caretag.Contracts.Core;
using Caretag.Contracts.Enums;
using Caretag.Contracts.Models.v1.Assets;
using Caretag_Class.Configuration;
using Caretag_Class.Model;
using Caretag_Class.Model.Service;
using CheckboxStation.Services.Bridge.Imlementations;
using CheckboxStation.Verification;
using Main.Model.PackingList.Validation;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckboxStation.Services.Bridge
{
    public class ScanServiceApi : IScanService
    {
        private readonly IIdentityService _identityService;
        private readonly AppSettingsBase _appSettings;
        private readonly IAssetsApi _assetsApi;
        private readonly IAssetTypesApi _assetTypesApi;
        private readonly IPacksetsApi _packsetsApi;
        private readonly ILogger<CheckInServiceApi> _logger;
        public ScanServiceApi(
            IIdentityService identityService,
            AppSettingsBase appSettings,
            IAssetsApi assetsApi,
            IAssetTypesApi assetTypesApi,
            IPacksetsApi packsetsApi,
            ILogger<CheckInServiceApi> logger)
        {
            _identityService = identityService;
            _appSettings = appSettings;
            _assetsApi = assetsApi;
            _assetTypesApi = assetTypesApi;
            _packsetsApi = packsetsApi;
            _logger = logger;

            Task.Run(async () =>
            {
                await PerformLogin();
            }).Wait();
        }

        private async Task PerformLogin()
        {
            // *** TODO: REMOVE HARDCODED CREDENTIALS
            var Password = "Administrator1!";
            var UserName = "administrator@localhost";

            var loginResult = await _identityService.Login(UserName, Password);

            if (!loginResult)
            {
                MessageBox.Show("API Login failed!",
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        public async Task<ValidatedPackingList> ValidatePackingList(List<string> tags, ValidatedPackingList? old)
        {
            var trays = new List<AssetDetailsResponse>();
            //var trayTags = new List<string>();
            //var instrumentTags = new List<string>();


            var fullSearchResponse = await AssetsFullSearchByTags(tags.ToArray());
            _logger.LogDebug("FULL SEARCH FROM VALIDATION!");
            var assets = await GetInstruments(fullSearchResponse);

            var trayAssets = fullSearchResponse.Where(a => a.AssetType.AssetClass.ClassType == AssetClassType.Tray).ToList();
            var trayTags = trayAssets.Select(a => a.Tag.TagId).ToList();
            var unknownTags = tags.Where(t => !fullSearchResponse.Any(a => a.Tag.TagId == t)).ToList();

            var instruments = assets.Where(a => a.AssetClassType == AssetClassType.Instrument);

            foreach (var tag in trayTags)
            {
                await _assetsApi.GetAssetDetailsByTagId(tag).MatchAsync(trayDetails =>
                {
                    trays.Add(trayDetails);
                    return Task.CompletedTask;
                },
                error =>
                {
                    if (error.Status == 404)
                    {
                        unknownTags.Add(tag);
                    }
                    return Task.CompletedTask;
                });
            }

            ValidatedPackingList result;
            var manuallyPackedLines = new List<ValidatedPackingListLineItem>();

            if (old != null)
            {
                result = old;
                manuallyPackedLines.AddRange(old.Lines.Where(l => l.PackedManually));
                result.Lines.Clear();
            }
            else
            {
                result = new ValidatedPackingList
                {
                    Location = _appSettings.StationUniqueID
                };
            }
            var groupedInstruments = instruments.GroupBy(i => i.Description_ID);

            if (trays.Count != 1)
            {
                result.Result = trays.Count == 0 ? ValidatedPackingList.PackingListState.NoTray : ValidatedPackingList.PackingListState.MoreThanOneTray;
                result.Lines.AddRange(groupedInstruments.Select(gi => new ValidatedPackingListLineItem
                {
                    Instruments = gi.ToList(),
                    Actual = gi.Count(),
                    Expected = 0,
                    DescriptionId = gi.FirstOrDefault()?.Description_ID,
                    InstrumentDescription = gi.FirstOrDefault()?.InstrumentDescription,
                    Description = gi.First().Description_Text
                }));
            }
            else if (trays.Count == 1)
            {
                var tray = trays.First();
                var scannedTrayType = new Tray_Description
                {
                    Description_ID = tray.Id,
                    Tray_Name = tray.Name,
                    Tray_Description1 = tray.Description
                };
                result.TrayEPC = trayTags.First();
                result.Tray = scannedTrayType;


                if (tray.PackedAsset != null)
                {

                    var packset = await _packsetsApi.GetWithDetails(tray.PackedAsset.Packset.Id);

                    result.Lines.AddRange(tray.PackedAsset.Children.GroupBy(c => c.Asset.AssetType.Id).Select(group =>
                    {
                        var item = group.First();
                        var assetsIds = group.Select(a => a.Asset.Id).ToList();

                        var instrumentDetails = instruments.Where(i => i.Description_ID == item.Asset.OemSku).FirstOrDefault();
                        var tagType = instrumentDetails != null ? instrumentDetails.TagType : item.Asset.TagType;

                        return new ValidatedPackingListLineItem
                        {
                            Actual = groupedInstruments.Where(g => g.Key == item.Asset.OemSku).Sum(i => i.Count()),
                            Expected = group.Count(),
                            Instruments = instruments.Where(i => item.Asset.OemSku == i.Description_ID).ToList(),
                            DescriptionId = item.Asset.OemSku,
                            InstrumentDescription = new Instrument_Description
                            {
                                Description_ID = item.Asset.OemSku,
                                Description_Name = instrumentDetails != null ? instrumentDetails.Description_Text : item.Asset.Name,
                                Instrument_Company = instrumentDetails != null && instrumentDetails.InstrumentDescription != null
                                                                                    ? instrumentDetails.InstrumentDescription.Instrument_Company : item.Asset.BrandName
                            },
                            Description = instrumentDetails != null ? instrumentDetails.Description_Text : item.Asset.Name,
                            PackedManually = tagType != TagType.RFID,
                            AssetIds = assetsIds,
                            AssetTypeId = group.Key
                        };
                    }));
                }

                var extraInstruments = groupedInstruments
                        .Where(gi => !result.Lines.Any(row => row.DescriptionId == gi.Key) || !gi.Any()).ToList();

                if (extraInstruments.Any())
                    result.Lines.AddRange(extraInstruments
                        .Select(gi =>
                        {
                            var instrumentDescription = gi.FirstOrDefault()?.InstrumentDescription;
                            var instrumentDetails = instruments.Where(i => i.Description_ID == gi.First().Description_ID).FirstOrDefault();
                            var description = instrumentDetails != null ? instrumentDetails.Description_Text : $"{instrumentDescription?.Description_Name ?? "Unknown"} {instrumentDescription?.D ?? ""} {instrumentDescription?.E ?? ""}";

                            if (instrumentDetails != null)
                            {
                                instrumentDescription = instrumentDetails.InstrumentDescription;
                            };


                            return new ValidatedPackingListLineItem
                            {
                                Instruments = gi.ToList(),
                                Actual = gi.Count(),
                                Expected = 0,
                                DescriptionId = gi.First().Description_ID,
                                InstrumentDescription = instrumentDescription,
                                Description = description
                            };
                        }));

                result.ValidateResult();
            }

            if (unknownTags.Any())
                result.Lines.Add(new ValidatedPackingListLineItem()
                {
                    Instruments = new List<Instrument_RFID>(),
                    InstrumentDescription = null,
                    Actual = unknownTags.Count(),
                    DescriptionId = "Unknown asset",
                    Expected = 0,
                    Description = "Unknown asset"
                });

            return result;
        }

        private async Task<List<AssetFullSearchResponse>> AssetsFullSearchByTags(string[] tags)
        {

            List<AssetFullSearchResponse> assetFullSearchResponse = new List<AssetFullSearchResponse>();
            if (tags.Length > 0)
            {
                var assetSearchRequest = new AssetFullSearchRequest
                {
                    TagIds = tags
                };

                await _assetsApi.FullSearch(assetSearchRequest).MatchAsync(
                    response =>
                    {
                        assetFullSearchResponse = response.Items;
                        return Task.CompletedTask;
                    }, _ =>
                    {
                        //log error
                        return Task.CompletedTask;
                    });
            }

            return assetFullSearchResponse;
        }

        public async Task<List<Instrument_RFID>> GetInstruments(List<string> tags)
        {
            List<Instrument_RFID> result = new List<Instrument_RFID>();

            if(tags.Count > 0)
            {
                var fullSearchResponse = await AssetsFullSearchByTags(tags.ToArray());
                result = await GetInstruments(fullSearchResponse);
            }
            return result;
        }

        private async Task<List<Instrument_RFID>> GetInstruments(List<AssetFullSearchResponse> instrumentAssets)
        {
            var result = new List<Instrument_RFID>();

            foreach (var asset in instrumentAssets)
            {
                try
                {
                    result.Add(new Instrument_RFID
                    {
                        Instrument_ID = asset.Id,
                        EPC_Nr = asset.Tag.TagId,
                        Description_Text = asset.Name,
                        Description_ID = asset.AssetType.OemSku,
                        TagType = asset.AssetType.AssetClass.TagType,
                        OperationInstruments = new List<OperationInstrument>(),
                        ServiceRequests = new List<ServiceRequest>(),
                        AssetClassType = asset.AssetType.AssetClass.ClassType,
                        InstrumentDescription = new Instrument_Description
                        {
                            Description_ID = asset.AssetType.OemSku,
                            Description_Name = asset.Name,
                            Instrument_Company = asset.AssetType.Brand?.Name
                        }
                    });
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "GetInstruments Error for asset " + asset.Id);
                }
               
            }

            return result;
        }

        private async Task<Instrument_RFID> GetInstrument(string tag)
        {
            AssetDetailsResponse assetDetails = null; ;


            await _assetsApi.GetAssetDetailsByTagId(tag).MatchAsync(
                assetDetailsResponse =>
                {
                    assetDetails = assetDetailsResponse;
                    return Task.CompletedTask;
                }, errorResponse =>
                {
                    _logger.LogError($"Error while fetching asset details: {JsonConvert.SerializeObject(errorResponse)}");
                    return Task.CompletedTask;
                });

            if (assetDetails != null)
            {

                var instrument = new Instrument_RFID
                {
                    Instrument_ID = assetDetails.Id,
                    EPC_Nr = tag,
                    Description_Text = $"{assetDetails.Description} {assetDetails.Name}",
                    Description_ID = assetDetails.OemSku,
                    OperationInstruments = new List<OperationInstrument>(),
                    ServiceRequests = new List<ServiceRequest>()
                };

                AssetResponse asset = null;
                await _assetsApi.GetAssetById(assetDetails.Id).MatchAsync(
                assetResponse =>
                {
                    asset = assetResponse;
                    return Task.CompletedTask;
                }, errorResponse =>
                {
                    _logger.LogError($"Error while fetching asset by ID: {JsonConvert.SerializeObject(errorResponse)}");
                    return Task.CompletedTask;
                });

                if (asset != null)
                {
                    instrument.LotNumber = asset.LotNo;
                    instrument.InstrumentProductionDate = asset.ManufacturingDate;

                    AssetTypeResponse assetType = null;

                    await _assetTypesApi.Get(asset.AssetType.Id).MatchAsync(
                        assetTypeResponse =>
                        {
                            assetType = assetTypeResponse;
                            return Task.CompletedTask;
                        }, errorResponse =>
                        {
                            _logger.LogError($"Error while fetching asset type by ID: {JsonConvert.SerializeObject(errorResponse)}");
                            return Task.CompletedTask;
                        });

                    if (assetType != null)
                    {
                        instrument.InstrumentDescription = new Instrument_Description
                        {
                            Description_ID = assetDetails.OemSku,
                            Description_Name = assetDetails.Description,
                            Instrument_Company = assetType.Brand?.Name
                        };

                        return instrument;
                    }
                }
            }

            return null;
        }

        public async Task<List<UnpackedItem>> GetUnpackedItems(Tray_Description tray, string trayEpc)
        {
            var result = new List<UnpackedItem>();

            await _assetsApi.GetAssetDetailsByTagId(trayEpc).MatchAsync(async asset =>
            {
                if (asset?.PackedAsset != null)
                {
                    var packset = await _packsetsApi.GetWithDetails(asset.PackedAsset.Packset.Id);

                    var packedItems = asset.PackedAsset.Children;

                    var unpackedItems = packset.Items.Where(pi => (pi.PreferredType != null && !packedItems.Any(pa => pa.Asset.AssetType.Id == pi.PreferredType)))
                                                           .ToList();

                    var assetClasses = new List<int>();

                    foreach (var packedItem in packedItems.Where(pai => !unpackedItems.Any(ui => ui.PreferredType == pai.Asset.AssetType.Id)))
                    {
                        var _asset = await _assetsApi.GetAssetById(packedItem.Asset.Id);

                        assetClasses.Add(_asset.AssetClass.Id);
                    }

                    unpackedItems.AddRange(packset.Items.Where(pi => !assetClasses.Contains(pi.PreferredClass)).ToList());

                    result = unpackedItems.ConvertAll(ui => new UnpackedItem
                    {
                        Index_ID = ui.Id,
                        Tray_Descrip_ID = null,
                        TrayDescription = tray,
                        InstrumentDescription = new Instrument_Description
                        {
                            Instrument_Company = ui.BrandName ?? "N/A",
                            Description_Name = ui.Name
                        },
                        Instrument_Descrip_ID = ui.OemSku ?? $"No OemSku - {ui.PreferredClass}",
                        Number = ui.Quantity,

                    });
                }
            },
            error =>
            {
                return Task.CompletedTask;
            });

            return result;
        }

        public void SaveValidatedPackingList(ValidatedPackingList validatedPackingList)
        {
        }
        public void SaveScanLog(List<string> tags)
        {
        }
    }
}
