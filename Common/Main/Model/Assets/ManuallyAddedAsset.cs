using System.Collections.Generic;

namespace Main.Model.Assets
{
    public class ManuallyAddedAsset
    {
        public int AssetTypeId { get; set; }
        public List<int> AssetIds { get; set; }
        public int Quantity { get; set; }
    }
}
