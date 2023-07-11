using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UIControls
{

    public class OnScreenKeyboard
    {
        [DllImport("kernel32")]
        static extern bool Wow64DisableWow64FsRedirection(ref long oldvalue);
        [DllImport("kernel32")]
        static extern bool Wow64EnableWow64FsRedirection(ref long oldvalue);

        private string _onScreenKeyboardProcessName = @"osk";
        private string _onScreenKeyboardProcessExtension = @"exe";
        private string _onScreenKeyboardProcessFolder = Environment.SystemDirectory;

        private string _onScreenKeyboardFilename;

        public OnScreenKeyboard()
        {
            _onScreenKeyboardFilename = string.Format(@"{0}\{1}.{2}", _onScreenKeyboardProcessFolder,
                                                                      _onScreenKeyboardProcessName, 
                                                                      _onScreenKeyboardProcessExtension);
        }

        public bool IsRunning
        {
            get
            {
                return Check_Process_Running(_onScreenKeyboardProcessName);
            }
        }

        public void HideKeyboard()
        {
            try
            {
                Process.GetProcessesByName(_onScreenKeyboardProcessName)[0].Kill();
            }
            catch
            {
            }

        }

        public void ShowKeyboard()
        {
            try
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    long argoldvalue = 0;
                    Wow64DisableWow64FsRedirection(ref argoldvalue);
                    Process.Start(_onScreenKeyboardFilename); 
                    long argoldvalue1 = 1;
                    Wow64EnableWow64FsRedirection(ref argoldvalue1);
                }
                else
                {
                    Process.Start(_onScreenKeyboardFilename);
                }
            }
            catch
            {
            }
        }

        public bool ToggleKeyboard()
        {
            if (IsRunning)
            {
                HideKeyboard();
                return false;
            }
            else
            {
                ShowKeyboard();
                return true;
            }
        }

        public bool Check_Process_Running(string sProcessName)
        {
            bool result = false;
            try
            {
                Process[] listProc = Process.GetProcessesByName(sProcessName);
                result = listProc.Length > 0;
            }
            catch
            {
                result = false;
            }

            return result;
        }

    }
}
