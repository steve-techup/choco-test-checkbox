using Caretag.Contracts.Enums;
using Caretag_Class.Model;
using RFIDAbstractionLayer.TagEncoding;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalStation.Configuration;
using TechnicalStation.Infrastructure;

namespace TechnicalStation.Services
{
    /// <summary>
    /// Bridge between Caretag classic and 3.0
    /// </summary>
    public interface IDataRepository
    {
        /// <summary>
        /// Get instrument/asset by passing EPC/TagId
        /// </summary>
        /// <param name="epc"></param>
        Task<Tuple<Instrument_RFID, AssetDetailsItem>> GetInstrumentRfidByEpc(string epc);

        /// <summary>
        /// Get tray by passing EPC/TagId
        /// </summary>
        /// <param name="epc"></param>
        Task<Tuple<Tray_RFID, AssetDetailsItem>> GetTrayRfidByEpc(string epc);

        /// <summary>
        /// Get container by passing EPC/TagId
        /// </summary>
        /// <param name="epc"></param>
        Task<Tuple<Container_RFID, AssetDetailsItem>> GetContainerRfidByEpc(string epc);

        /// <summary>
        /// Method used for commiting uncommited EPC in the Database in Classic
        /// Not implemented on 3.0
        /// </summary>
        /// <param name="epc"></param>
        Task CommitEpc(RfidEPC epc);

        /// <summary>
        /// Get highest uncommited AssetId from the database in Classic
        /// Not implemented in 3.0
        /// </summary>
        Task<AssetId> GetHighestUncommittedAssetId();

        /// <summary>
        /// Generate new EPC/TagId
        /// </summary>
        /// <param name="gs1CompanyPrefix"></param>
        /// <param name="tenantId"></param>
        Task<RfidEPC> CreateNewUncommittedEpc(uint gs1CompanyPrefix, uint tenantId);

        /// <summary>
        /// Create new asset (Tray)
        /// </summary>
        /// <param name="epc"></param>
        Task CreateNewTray(string epc, int? assetTagId = null, string lot = null, DateTime? productionDate = null, Instrument_Description instrumentDescription = null);

        /// <summary>
        /// Create new asset (Container)
        /// </summary>
        /// <param name="epc"></param>
        Task CreateNewContainer(string epc, int? assetTagId = null, string lot = null, DateTime? productionDate = null, Instrument_Description instrumentDescription = null);

        /// <summary>
        /// Search for asset types 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="classTypes"></param>
        /// <returns></returns>
        Task<IReadOnlyCollection<Instrument_Description>> SearchInstrumentType(string query, AssetClassType[] classTypes = null);

        /// <summary>
        /// Update existing instrument/asset
        /// </summary>
        /// <param name="instrumentRfid"></param>
        /// <param name="instrumentDescription"></param>
        /// <param name="lot"></param>
        /// <param name="productionDate"></param>
        Task UpdateInstrument(Instrument_RFID instrumentRfid, Instrument_Description instrumentDescription, string lot = null, DateTime? productionDate = null);

        /// <summary>
        /// Create new asset (Instrument)
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="lot"></param>
        /// <param name="productionDate"></param>
        /// <param name="instrumentDescription"></param>
        /// <param name="assetTagId"></param>
        /// <returns></returns>
        Task CreateNewInstrument(string epc, string lot, DateTime productionDate, Instrument_Description instrumentDescription, int? assetTagId = null);

        /// <summary>
        /// Get the TenantId and the GS1 Company Prefix from the database in Classic
        /// Currently not implemented in 3.0
        /// </summary>
        Task<EPC_Number_Serie> GetEpcNumberSerie();

        /// <summary>
        /// Generate new EPC/TagId
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="lot"></param>
        /// <param name="productionDate"></param>
        Task<RfidEPC> GenereateNewEpc(long assetId, string lot, DateTime? productionDate);

        /// <summary>
        /// Check if the supplied EPC/TagId is valid
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="gs1CompanyPrefix"></param>
        /// <returns></returns>
        Task<bool> IsEpcValid(string epc, uint gs1CompanyPrefix);

        /// <summary>
        /// Get asset tag by passing the TagId in 3.0
        /// Not implemented in Classic
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        Task<Tuple<bool, int?>> GetAssetTag(string tagId);

        /// <summary>
        /// Get trolley by passing EPC/TagId
        /// </summary>
        /// <param name="epc"></param>
        Task<Tuple<Instrument_RFID, AssetDetailsItem>> GetTrolleyRfidByEpc(string epc);

        /// <summary>
        /// Create new asset (Trolley)
        /// </summary>
        /// <param name="epc"></param>
        Task CreateNewTrolley(string epc, int? assetTagId = null, string lot = null, DateTime? productionDate = null, Instrument_Description instrumentDescription = null);
        
        /// <summary>
        /// Get sterilization cart by passing EPC/TagId
        /// </summary>
        /// <param name="epc"></param>
        Task<Tuple<Tray_RFID, AssetDetailsItem>> GetSterilizationCartRfidByEpc(string epc);

        /// <summary>
        /// Create new asset (Sterilization cart)
        /// </summary>
        /// <param name="epc"></param>
        Task CreateNewSterilizationCart(string epc, int? assetTagId = null, string lot = null, DateTime? productionDate = null, Instrument_Description instrumentDescription = null);
        Task<TechnicalStationConfig> GetStationConfig();
    }
}
