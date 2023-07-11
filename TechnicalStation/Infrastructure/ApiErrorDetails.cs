using DevExpress.ClipboardSource.SpreadsheetML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalStation.Infrastructure
{
    public class ApiErrorDetails
    {
        public string Type { get; set; }
        public string Status { get; set; }
        public List<ApiError> Errors { get; set; }
    }

    public class ApiError
    {
        public string Key { get; set; }
        public List<ApiErrorDetailsItem> Details { get; set; }
    }
    public class ApiErrorDetailsItem
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
    }

    public enum ApiErrorType
    {
        NotFound,
        AssetWrongClassTypeError,
        Undefined
    }

    public class AssetIdResponse
    {
        public int AssetId { get; set; }
    }
}
