using OnScreenKeyboard.Models;
using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace OnScreenKeyboard
{

    public class OskUiController
    {
        private ConcurrentDictionary<int, Control> _controls = new ConcurrentDictionary<int, Control>();
        private Timer _oskHideTimer;
        private OnScreenKeyboardConfig _config;
        private bool _isEnabled;
        private ToolButtonVisibility _toolButtonVisibility;

        protected static OskUiController _instance = null;

        public static OskUiController Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new OskUiController(new OnScreenKeyboardConfig()
                    {
                        AutoHideDelayInMsec = 300,
                        Enabled = true,
                        ToolButtonVisibility = ToolButtonVisibility.IfEnabled
                    }, "en-UK");
                }
                return _instance;
            }
        }

        public bool IsEnabled
        {
            get => _isEnabled;
        }

        public ToolButtonVisibility ToolButtonVisibility
        {
            get => _toolButtonVisibility;
        }

        public OskUiController(OnScreenKeyboardConfig config, string culture)
        {
            _config = config;
            OskUiController._instance = this;
            OSK.Instance.culture = new CultureInfo(culture);

            _oskHideTimer = new Timer(config.AutoHideDelayInMsec);
            _isEnabled = _config.Enabled;
            _toolButtonVisibility = config.ToolButtonVisibility;

            _oskHideTimer.AutoReset = true;
            _oskHideTimer.Elapsed += OskHideTimerOnElapsed;
        }

        public OskUiController AddControl(Control control)
        {
            if (_controls.ContainsKey(control.GetHashCode()))
            {
                return this;
            }

            _controls.TryAdd(control.GetHashCode(), control);
            HookControl(control);
            return this;
        }

        public OskUiController DeleteControl(Control control)
        {
            if (!_controls.ContainsKey(control.GetHashCode()))
                return this;

            Control value;
            _controls.TryRemove(control.GetHashCode(), out value);
            UnhookControl(control);
            return this;
        }

        private void HookControl(Control control)
        {
            control.GotFocus += ControlOnGotFocus;
            control.LostFocus += ControlOnLostFocus;
        }

        private void UnhookControl(Control control)
        {
            control.GotFocus -= ControlOnGotFocus;
            control.LostFocus -= ControlOnLostFocus;
        }

        private void ControlOnLostFocus(object sender, EventArgs e)
        {
            if (!IsEnabled)
                return;

            _oskHideTimer.Start();
        }

        private void ControlOnGotFocus(object sender, EventArgs e)
        {
            if (!IsEnabled)
                return;

            // Stop Autohide timer if new control is requesting OSK
            _oskHideTimer.Stop();

            // Show keyboard, if not already running
            if (!OSK.Instance.IsRunning)
                OSK.Instance.ShowKeyboard();
        }

        private void OskHideTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            _oskHideTimer.Stop();

            if (!OSK.Instance.IsRunning)
                return;

            OSK.Instance.HideKeyboard();
        }

    }
}