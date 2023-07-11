using OnScreenKeyboard.Models;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using Path = System.IO.Path;

namespace OnScreenKeyboard;

public class OSK
{
    // Old school OnScreenKeyboard
    //private string _onScreenKeyboardProcessName = @"osk";
    //private string _onScreenKeyboardProcessExtension = @"exe";
    //private string _onScreenKeyboardProcessFolder = Environment.SystemDirectory;

    private string _onScreenKeyboardProcessName = @"TabTip";
    private string _onScreenKeyboardProcessExtension = @"exe";
    private string _onScreenKeyboardProcessFolder =
        Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles) + @"\Microsoft Shared\ink";

    private string _onScreenKeyboardFilename;

    protected static OSK _instance = null;

    public static OSK Instance
    {
        get
        {
            if (_instance is null)
                _instance = new OSK();
            return _instance;
        }
    }
    public OnScreenKeyboardConfig? config;

    public OSK()
    {
        _onScreenKeyboardFilename = string.Format(@"{0}\{1}.{2}", _onScreenKeyboardProcessFolder,
            _onScreenKeyboardProcessName,
            _onScreenKeyboardProcessExtension);
        _instance = this;
    }

    public bool IsRunning
    {
        get
        {
            return Osklib.OnScreenKeyboard.IsOpened();
        }
    }

    public void HideKeyboard()
    {
        Osklib.OnScreenKeyboard.Close();
    }

    public void ShowKeyboard()
    {
        Osklib.OnScreenKeyboard.Show();

        if (config != null)
        {
            SetCulture(config.Culture);
        }
    }

    public void SetCulture(CultureInfo cultureInfo)
    {
        var inputLanguageManager = InputLanguageManager.Current;
        if (inputLanguageManager.CurrentInputLanguage != cultureInfo)
        {
            if (inputLanguageManager.AvailableInputLanguages.Cast<CultureInfo>().Contains(cultureInfo))
            {
                inputLanguageManager.CurrentInputLanguage = cultureInfo;
            }
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

    public bool IsKeyboardProcessRunning()
    {
        try
        {
            Process[] listProc = GetKeyboardProcesses();
            return listProc.Length > 0;
        }
        catch
        {
            return false;
        }
    }

    private Process[] GetKeyboardProcesses()
    {
        return Process.GetProcessesByName(Path.GetFileNameWithoutExtension(_onScreenKeyboardFilename));
    }
}