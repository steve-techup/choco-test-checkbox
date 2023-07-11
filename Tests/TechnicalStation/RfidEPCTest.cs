using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class.Model;
using NurApiDotNet;
using RFIDAbstractionLayer.TagEncoding;
using TechnicalStation;
using Xunit;
using Xunit.Abstractions;

namespace Tests.TechnicalStation
{
    public class RfidEPCTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public RfidEPCTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void TestEPCcodingRandom()
        {
            var ar = new BEBitArray(32);
            ar.Write(4, NurApi.HexStringToBin("BABE"));
            var x = ar.ToBytes( 4, 16).ToArray();
            var h = NurApi.BinToHexString(x);

            var gs1CompanyPrefix = "56FE72";
            var tenantId = "FF";
            var epc = new RfidEPC(1, gs1CompanyPrefix, tenantId);
            var bin = epc.GetBinaryRepresentation();
            var hex = NurApi.BinToHexString(bin);

            var decoded = new RfidEPC(bin);

            Assert.Equal(epc.Gs1CompanyPrefix, decoded.Gs1CompanyPrefix);
            Assert.Equal(epc.TenantId, decoded.TenantId);
            Assert.Equal(epc.AssetId, decoded.AssetId);


        }

        [Theory]
        [InlineData("56FE72", "AAAAA", 274877906943, "34155BF9CAAAAABFFFFFFFFF")]
        [InlineData("12D687", "32", 10005000, "34144B5A1C000C800098AA08")]
        [InlineData("10F447", "0", 1, "341443D11C00000000000001")]
        public void TestEPCcodingManual(string gs1CompanyPrefix, string tenantId, ulong assetId, string encoded)
        {
            var epc = new RfidEPC(assetId, gs1CompanyPrefix, tenantId);

            var hex = NurApi.BinToHexString(epc.GetBinaryRepresentation());
            Assert.Equal(encoded, BitConverter.ToString(epc.GetBinaryRepresentation()).Replace("-",""));
            Assert.Equal(encoded, epc.ToString());
            Assert.Equal(24, epc.ToString().Length);

            var decoded = new RfidEPC(epc.GetBinaryRepresentation());
            Assert.Equal(epc.AssetId, decoded.AssetId);
            
            Assert.Equal(epc.Gs1CompanyPrefix, decoded.Gs1CompanyPrefix);
            Assert.Equal(epc.TenantId, decoded.TenantId);
        }
    }
}
