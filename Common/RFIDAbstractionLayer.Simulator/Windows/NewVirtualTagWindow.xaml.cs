using System;
using System.Collections.Generic;
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

namespace RFIDAbstractionLayer.Simulator
{
    /// <summary>
    /// Interaction logic for NewVirtualTagWindow.xaml
    /// </summary>
    public partial class NewVirtualTagWindow : Window
    {
        public NewVirtualTagWindow()
        {
            InitializeComponent();

            var windowTitle = App.Translate("NewVirtualTag");
            tbTitle.Text = windowTitle;
            this.Title = windowTitle;
            lblWarning.Content = App.Translate("Warning");
            lblWarningDescription.Content = App.Translate("VirtualTagWarning");
            tbTagID.Text = App.Translate("TagID");
            BtnGenerateId.Content = App.Translate("GenerateID");
            BtnCancel.Content = App.Translate("btnCancel");
            BtnOk.Content = App.Translate("btnOK");
        }

        public bool Execute(Window owner, ref string NewID)
        {
            this.Owner = owner;
            TagIdBox.Text = NewID;
            TagIdBox.Focus();

            bool result = this.ShowDialog() ?? false;

            if (result)
            {
                NewID = TagIdBox.Text;
                NewID = NewID.Replace("-", "");
            }

            return result;
        }

        private async void BtnGenerateId_Click(object sender, RoutedEventArgs e)
        {
            
            //TagIdBox.Text = ;
        }


        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
