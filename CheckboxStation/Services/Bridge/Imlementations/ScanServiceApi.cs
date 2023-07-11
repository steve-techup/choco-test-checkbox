using Caretag.Contracts.Api.v1;
using Caretag.Contracts.Core;
using Caretag.Contracts.Enums;
using Caretag.Contracts.Models.v1.Assets;
using Caretag.Contracts.Models.v1.Packsets;
using Caretag_Class.Configuration;
using Caretag_Class.Model;
using Caretag_Class.Model.Service;
using CheckboxStation.Verification;
using Main.Model.PackingList.Validation;
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
        public ScanServiceApi(
            IIdentityService identityService,
            AppSettingsBase appSettings,
            IAssetsApi assetsApi,
            IAssetTypesApi assetTypesApi,
            IPacksetsApi packsetsApi)
        {
            _identityService = identityService;
            _appSettings = appSettings;
            _assetsApi = assetsApi;
            _assetTypesApi = assetTypesApi;
            _packsetsApi = packsetsApi;

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
            var unknownTags = new List<string>();
            var trayTags = new List<string>();
            var instrumentTags = new List<string>();

            foreach (var tag in tags)
            {
                AssetDetailsResponse assetDetails = null;
                await _assetsApi.GetAssetDetailsByTagId(tag).MatchAsync(async asset =>
                        {
                            assetDetails = asset;

                            if (assetDetails.ClassType == AssetClassType.Tray)
                            {
                                trays.Add(assetDetails);
                                trayTags.Add(tag);
                            }
                            else if (assetDetails.ClassType == AssetClassType.Instrument)
                            {
                                instrumentTags.Add(tag);
                            }
                            else
                            {
                                unknownTags.Add(tag);
                            }
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

            var instruments = await GetInstruments(instrumentTags);
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
                    result.Lines.AddRange(tray.PackedAsset.Children.GroupBy(c => c.Asset.AssetType.Id).Select(group =>
                    {
                        var item = group.First();
                        return new ValidatedPackingListLineItem
                        {
                            Actual = groupedInstruments.Where(g => g.Key == item.Asset.OemSku).Sum(i => i.Count()),
                            Expected = group.Count(),
                            Instruments = instruments.Where(i => item.Asset.OemSku == i.Description_ID).ToList(),
                            DescriptionId = item.Asset.OemSku, // OemSku missing?
                            InstrumentDescription = new Instrument_Description
                            {
                                Description_ID = item.Asset.OemSku,
                                Description_Name = item.Asset.Name,
                                Instrument_Company = item.Asset.BrandName
                            },
                            Description = item.Asset.Name,
                            PackedManually = false // item.Asset.TagType != TagType.RFID - Missing
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
                            return new ValidatedPackingListLineItem
                            {
                                Instruments = gi.ToList(),
                                Actual = gi.Count(),
                                Expected = 0,
                                DescriptionId = gi.First().Description_ID,
                                InstrumentDescription = instrumentDescription,
                                Description = $"{instrumentDescription?.Description_Name ?? "Unknown"} {instrumentDescription?.D ?? ""} {instrumentDescription?.E ?? ""}"
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
                    DescriptionId = "Unknown",
                    Expected = 0,
                    Description = "Unknown"
                });

            return result;
        }

        public async Task<List<Instrument_RFID>> GetInstruments(List<string> tags)
        {
            var result = new List<Instrument_RFID>();

            foreach (var tag in tags)
            {
                await _assetsApi.GetByTagId(tag, (int)AssetClassType.Instrument, null).MatchAsync(async asset =>
                {
                    result.Add(await GetInstrument(asset, tag));
                },
                error =>
                {
                    return Task.CompletedTask;
                });
            }

            return result;
        }

        private async Task<Instrument_RFID> GetInstrument(AssetResponse asset, string tag)
        {
            var assetDetails = await _assetsApi.GetAssetDetailsByTagId(tag);

            var instrument = new Instrument_RFID
            {
                Instrument_ID = asset.Id,
                EPC_Nr = asset.TagId,
                Description_Text = $"{asset.Description} {asset.Name}",
                LotNumber = asset.LotNo,
                InstrumentProductionDate = asset.ManufacturingDate,
                Description_ID = assetDetails.OemSku,
                OperationInstruments = new List<OperationInstrument>(),
                ServiceRequests = new List<ServiceRequest>()
            };

            return instrument;
        }

        public async Task<List<UnpackedItem>> GetUnpackedItems(Tray_Description tray, string trayEpc)
        {
            var result = new List<UnpackedItem>();

            await _assetsApi.GetAssetDetailsByTagId(trayEpc).MatchAsync(async asset =>
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
