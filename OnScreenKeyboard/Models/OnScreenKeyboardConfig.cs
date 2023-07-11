using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboard.Models
{
    public class OnScreenKeyboardConfig
    {
        public int AutoHideDelayInMsec { get; set; }
        public bool Enabled { get; set; }
        public ToolButtonVisibility ToolButtonVisibility { get; set; }

        public OnScreenKeyboardConfig()
        {
            Enabled = false;
            AutoHideDelayInMsec = 1000;
            ToolButtonVisibility = ToolButtonVisibility.Always;
        }
    }

    public enum ToolButtonVisibility
    {
        Never,
        IfEnabled,
        Always
    }
}
