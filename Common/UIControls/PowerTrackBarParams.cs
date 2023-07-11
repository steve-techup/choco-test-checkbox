using System.Collections.Generic;
using RFIDAbstractionLayer.Readers;

namespace UIControls
{
    public class PowerTrackBarParams
    {
        public string PowerTitle { get; set; }
        public string[] PowerStepNames { get; set; }
        public List<IRFIDReader> ActiveReaders { get; set; }

        public PowerTrackBarParams()
        {

        }
        public PowerTrackBarParams(string title, string[] powerStepNames, List<IRFIDReader> activeReaders)
        {
            PowerTitle = title;
            PowerStepNames = powerStepNames;
            ActiveReaders = activeReaders;
        }
    }
}
