using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using RFIDAbstractionLayer.Simulator.Resources;

namespace RFIDAbstractionLayer.Simulator.Windows
{
    /// <summary>
    /// Interaction logic for SplashWindow.xaml
    /// </summary>
    public partial class SplashWindow : Window
    {
        public SplashWindow()
        {
            InitializeComponent();
            lblTitle.Content = App.Translate("Title");
            lblProgress.Content = "";
        }

        public void UpdateProgress(string message)
        {
            lblProgress.Content = message;
            lblProgress.InvalidateVisual();
        }
    }
}
