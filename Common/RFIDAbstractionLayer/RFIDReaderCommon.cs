using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using Serilog;
using RFIDAbstractionLayer.Readers;

namespace RFIDAbstractionLayer
{
    public class RFIDReaderCommon
    {
        // Used for SEQ convertion
        private const int Gen2Tag = 2;
        private const int ICMfg = 3;
        private const int ICModel = 3;
        private const int UniqueTID = 16;

        /// <summary>
        /// Removes the dashes in the Electronic Product Code format (ie. XX-XX-XX... -> XXXXXX...)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string RemoveDashes(string str)
        {
            string result = "";
            var items = str.Split('-');
            foreach (var item in items)
            {
                result += item;
            }
            return result;
        }
        

        public string RawTagToEPC(byte[] tag)
        {
            string tagStr = BitConverter.ToString(tag);
            tagStr = RemoveDashes(tagStr);
            return tagStr;
        }

        /// <summary>
        /// Fail gracefully with a properly formatted error message
        /// </summary>
        /// <param name="err">exception that was triggered</param>
        /// <param name="location">which method triggered the exception?</param>
        private void DisplayError(Exception err, string location)
        {
            MessageBox.Show("Class: " + this.GetType().Name + "\n" +
                            "Location: " + location + "\n" +
                            "Exception Type: " + err.GetType().Name + "\n" +
                            "Message: " + err.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        public string GetReaderSplashScreenPresentationString(IRFIDReader reader)
        {
            DeviceInformation devInfo = reader.GetDeviceInformation();
            var result = "Brand: " + devInfo.Brand + " - Model: " + devInfo.Model;

            return result;
        }

        public string GetReaderOriginName(IRFIDReader reader)
        {
            return GetReaderOriginName(reader.GetDeviceInformation());
        }
        public string GetReaderOriginName(DeviceInformation devInfo)
        {
            return String.Format("{0} {1} (Version: {2})", devInfo.Brand, devInfo.Model, devInfo.Version);
        }
    }
}
