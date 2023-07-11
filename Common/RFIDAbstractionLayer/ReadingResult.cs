using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.caen.RFIDLibrary;
using RFIDAbstractionLayer.Readers;

namespace RFIDAbstractionLayer
{
    public class ReadingResult
    {
        public ReadingType ReadingType { get; set; }
        public string Value { get; set; }
        public int SignalStrength { get; set; }
        public string OriginatingReader { get; set; }

        public ReadingResult(ReadingType type, string value, int signalStrength, string originatingReader)
        {
            ReadingType = type;
            Value = value;
            SignalStrength = signalStrength;
            OriginatingReader = originatingReader;
        }

        public ReadingResult()
        {
        }

        public ReadingResult(CAENRFIDNotify caenRFIDNotify, CAENReader source)
        {
            var common = new RFIDReaderCommon();
            ReadingType = ReadingType.RFID;

            Value = common.RawTagToEPC(caenRFIDNotify.TagID);
            SignalStrength = caenRFIDNotify.RSSI;
            OriginatingReader = common.GetReaderOriginName(source);
        }

        public static ReadingResult MakeRFIDSimReading(string EPC, string originatingReader)
        {
            return new ReadingResult(ReadingType.RFID, EPC, 100, originatingReader);
        }
    }
}
