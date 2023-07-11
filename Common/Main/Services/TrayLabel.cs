using System;

namespace Main.Services
{
    public class TrayLabel
    {
        public string TrayName { get; set; }
        public string PackedBy { get; set; }

        public DateTime DatePacked { get; set; }

        public DateTime ExpiresDate { get; set; }
        public int AssetId { get; set; }

        public string[] getLabelArray()
        {
            return new[]
            {
                TrayName,
                PackedBy,
                DatePacked.ToString("yyyy-MM-dd"),
                ExpiresDate.ToString("yyyy-MM-dd"),
                $"{AssetId:00000000}"
            };
        }
    }
}
