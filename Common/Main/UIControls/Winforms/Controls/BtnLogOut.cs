using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIControls.WinForms.Controls
{
    public enum BtnLogOutLabel
    {
        Logout,
        Quit
    }

    /// <summary>
    /// Button will present user with a confirm dialog. If Logout is confirmed event OnLogout is fired
    /// </summary>
    public partial class BtnLogOut : UserControl
    {
        public event _OnLogout OnLogout;
        public event EventHandler<CanLogOutArgs> OnCanLogOut;
        private BtnLogOutLabel _buttonType = BtnLogOutLabel.Logout;

        public BtnLogOutLabel ButtonType
        {
            get
            {
                return _buttonType;
            }
            set
            {
                if (value == _buttonType)
                    return;

                _buttonType = value;
                UpdateButtonType();
            }
        }

        public BtnLogOut()
        {
            InitializeComponent();
        }

        private void UpdateButtonType()
        {
            switch(_buttonType)
            {
                case BtnLogOutLabel.Logout:
                    LogoutBtn.Text = "Logout";
                    break;
                case BtnLogOutLabel.Quit:
                    LogoutBtn.Text = "Quit";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            var args = new CanLogOutArgs() {BlockLogOut = false};
            OnCanLogOut?.Invoke(this, args);
            if (args.BlockLogOut)
            {
                return;
            }

            var result = MessageBox.Show("Do you want to Log Out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                OnLogout?.Invoke();
            }
        }
    }

    public class CanLogOutArgs : EventArgs
    {
        public bool BlockLogOut { get; set; }
    }

    public delegate void _OnLogout();

}
