using OnScreenKeyboard;
using System;
using System.Windows.Forms;

namespace UIControls.WinForms.Controls
{
    /// <summary>
    /// Button to handle opening and closing OnScreenKeyboard. Nothing to setup, just drop it on a form.
    /// Notice: Uses one timer per instance
    /// </summary>
    public partial class BtnOSK : UserControl
    {
        //private readonly OnScreenKeyboard _osk = new();
        private bool _oskIsRunning;
        private Timer _isRunningTimer;

        public BtnOSK()
        {
            InitializeComponent();
            InitTimer();
        }

        /// <summary>
        /// Initialises the timer that will check if the OSK process is running.
        /// </summary>
        private void InitTimer()
        {
            _isRunningTimer = new Timer();
            _isRunningTimer.Interval = 1000;
            _isRunningTimer.Tick += IsRunningTimerOnTick;
            _isRunningTimer.Enabled = true;
            IsRunningTimerOnTick(this, EventArgs.Empty);
        }

        private void IsRunningTimerOnTick(object sender, EventArgs e)
        {
            // Poll once for efficency
            bool isRunning = OSK.Instance.IsRunning;
            // Only update UI, if the value has changed
            if (isRunning != _oskIsRunning)
            {
                UpdateImg(isRunning);
            }
        }
        

        private void UpdateImg(bool oskIsRunning)
        {
            if (oskIsRunning)
            {
                BtnOnScreenKeyboard.ImageIndex = 0;
                _oskIsRunning = true;
            }
            else
            {
                BtnOnScreenKeyboard.ImageIndex = 1;
                _oskIsRunning = false;
            }
        }

        private void BtnOnScreenKeyboard_Click_1(object sender, EventArgs e)
        {
            UpdateImg(OSK.Instance.ToggleKeyboard());

        }
    }
}
