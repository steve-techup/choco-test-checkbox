using System;
using System.Linq;
using NurApiDotNet;

namespace RFIDAbstractionLayer.TagEncoding
{
    /// <summary>
    /// Class for storing an RFID EPC code. It works with the full binary representation, including Header, Filter and Partition values. 
    /// </summary>
    public class RfidEPC
    {
        public readonly uint Gs1CompanyPrefix;
        public readonly uint TenantId;
        public readonly ulong AssetId;
        public const uint Header = 0b00110100;
        public static uint Filter = 0;
        public static uint Partition = 5;
        public const uint CaretagPrefix = 0x56FE72;
        public int? AssetTagId { get; set; }

        public bool ValidCaretagEPC = true;
        
        /// <summary>
        /// Creates an instance from assetId, GS1 Company Prefix and tenant id
        /// </summary>
        /// <param name="assetId">The asset id as an unsigned long</param>
        /// <param name="gs1CompanyPrefix">The GS1 company prefix in hex format without 0x prefix</param>
        /// <param name="tenantId">The tenantId in hex format without 0x prefix</param>
        public RfidEPC(ulong assetId, string gs1CompanyPrefix, string tenantId)
        {
            Gs1CompanyPrefix = uint.Parse(gs1CompanyPrefix, System.Globalization.NumberStyles.HexNumber);
            TenantId = uint.Parse(tenantId, System.Globalization.NumberStyles.HexNumber);
            AssetId = assetId;
        }

        /// <summary>
        /// Creates an instance from assetId, GS1 Company Prefix and tenant id
        /// </summary>
        /// <param name="assetId">The asset id as an unsigned long</param>
        /// <param name="gs1CompanyPrefix">The GS1 company prefix in hex format without 0x prefix</param>
        /// <param name="tenantId">The tenantId as an unsigned int</param>
        public RfidEPC(ulong assetId, uint gs1CompanyPrefix, uint tenantId)
        {
            Gs1CompanyPrefix = gs1CompanyPrefix;
            TenantId = tenantId;
            AssetId = assetId;
        }

        /// <summary>
        /// Converts the RfidEPC to a hex string without 0x prefix. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return NurApi.BinToHexString(GetBinaryRepresentation());

        }

        /// <summary>
        /// Converts to a GIAI-96 compliant byte array, with the asset part split into tenant id and asset it and partition=5.
        /// </summary>
        /// <returns></returns>
        public byte[] GetBinaryRepresentation()
        {
            var ba = new BEBitArray(12 * 8);
            ba.Write(0, Header.getBytes()[3]);
            
            ba.Write(8, (Filter << 5).getBytes()[3]);
            ba.Write(11, (Partition << 5).getBytes()[3]);

            var prefix = Gs1CompanyPrefix.getBytes().Skip(1).ToArray();
            ba.Write(14, prefix);

            var converted = TenantId.getBytes();
            var tenantHex = NurApi.BinToHexString(converted);

            ba.Write(38, 12, 20, converted);
            ba.Write(58, 26, 38, AssetId.getBytes());

            return ba.ToBytes().ToArray();
        }

        /// <summary>
        /// Constructs a new instance of an RfidEPC from GIAI-96 Caretag byte array
        /// </summary>
        /// <param name="raw"></param>
        /// <exception cref="Exception"></exception>
        public RfidEPC(byte[] raw)
        {
            var ba = new BEBitArray(raw);
            
            var header = 
                NurApi.BinToHexString(ba.ToBytes( 0, 8).ToArray());
            
            var realHeader = Convert.ToString(Header, 16);
            if (header != realHeader)
                ValidCaretagEPC = false;

            var partition = (uint)ba.ToBytes( 11, 3).ToArray()[0];

            if (partition != Partition)
                ValidCaretagEPC = false;

            var gs1bin = ba.ToBytes( 14, 24).ToArray();
            var gs1hex = NurApi.BinToHexString(gs1bin);
            Gs1CompanyPrefix = uint.Parse(gs1hex, System.Globalization.NumberStyles.HexNumber);
            if (Gs1CompanyPrefix != CaretagPrefix)
                ValidCaretagEPC = false;

            var tenantIdBin = ba.ToBytes(  38, 20).ToArray();
            var tenantIdHex = NurApi.BinToHexString(tenantIdBin);
            TenantId = uint.Parse(tenantIdHex, System.Globalization.NumberStyles.HexNumber);

            var assetidBin = ba.ToBytes( 58, 38).ToArray();
            var assetIdHex = NurApi.BinToHexString(assetidBin);
            AssetId = ulong.Parse(assetIdHex, System.Globalization.NumberStyles.HexNumber);

            if(AssetId <= 0)
                ValidCaretagEPC = false;
        }

        public RfidEPC(string hexEpc) : this(NurApi.HexStringToBin(hexEpc))
        {
        }
    }
}
