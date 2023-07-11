using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using Caretag_Class.ReactiveUI.ViewModels;
using ReactiveUI;

namespace Caretag_Class.ReactiveUI.Views
{
    public partial class StandardDialog : Form, IViewFor<StandardDialogViewModel>
    {
        private StandardDialogViewModel _vm;
        private readonly ResourceManager _resourceManager;

        object IViewFor.ViewModel
        {
            get => _vm;
            set => _vm = (StandardDialogViewModel)value;
        }

        StandardDialogViewModel IViewFor<StandardDialogViewModel>.ViewModel
        {
            get => _vm;
            set => _vm = value;
        }
        public StandardDialog(StandardDialogViewModel vm, ResourceManager resourceManager)
        {
            _vm = vm;
            _resourceManager = resourceManager;


            InitializeComponent();
        }

        private Button CreateButton(string text, CaretagMessageBoxResult result)
        {
            var button = new Button();
            button.Text = text;
            button.Size = new Size(100, 70);
            button.Anchor = AnchorStyles.None;

            button.Events().Click.Subscribe(_ => _vm.CloseCommand.Execute(result).
                Subscribe());
            return button;
        }

        private void SetLayout(int columnCount)
        {
            buttonTableLayoutPanel.ColumnCount = columnCount;
            buttonTableLayoutPanel.ColumnStyles.Clear();
            for (var i = 0; i < columnCount; i++)
            {
                buttonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / columnCount));
            }
        }

        private void StandardDialog_Shown(object sender, EventArgs e)
        {
            this.OneWayBind(_vm, vm => vm.Visible, view => view.Visible);
            this.OneWayBind(_vm, vm => vm.Arguments.Message, view => view.messageLabel.Text);
            this.OneWayBind(_vm, vm => vm.Arguments.Title, view => view.Text);
            
            switch (_vm.Arguments.Options)
            {
                case CaretagMessageBoxOptions.OkCancel:
                    SetLayout(2);
                    var okButton = CreateButton(_resourceManager.GetString("DialogButtonOk"), CaretagMessageBoxResult.Ok);
                    var cancelButton = CreateButton(_resourceManager.GetString("DialogButtonCancel"), CaretagMessageBoxResult.Cancel);
                    buttonTableLayoutPanel.Controls.Add(okButton, 0, 0);
                    buttonTableLayoutPanel.Controls.Add(cancelButton, 1, 0);
                    break;
                case CaretagMessageBoxOptions.Ok:
                    SetLayout(1);
                    var okButton2 = CreateButton(_resourceManager.GetString("DialogButtonOk"), CaretagMessageBoxResult.Ok);
                    buttonTableLayoutPanel.Controls.Add(okButton2, 0, 0);
                    break;
                case CaretagMessageBoxOptions.YesNoCancel:
                    SetLayout(3);
                    var yesButton = CreateButton(_resourceManager.GetString("DialogButtonYes"), CaretagMessageBoxResult.Yes);
                    var noButton = CreateButton(_resourceManager.GetString("DialogButtonNo"), CaretagMessageBoxResult.No);
                    var cancelButton2 = CreateButton(_resourceManager.GetString("DialogButtonCancel"), CaretagMessageBoxResult.Cancel);
                    buttonTableLayoutPanel.Controls.Add(yesButton, 0, 0);
                    buttonTableLayoutPanel.Controls.Add(noButton, 1, 0);
                    buttonTableLayoutPanel.Controls.Add(cancelButton2, 2, 0);
                    break;
                case CaretagMessageBoxOptions.YesNoAll:
                    SetLayout(3);
                    var yesButton2 = CreateButton(_resourceManager.GetString("DialogButtonYes"), CaretagMessageBoxResult.Yes);
                    var allButton = CreateButton(_resourceManager.GetString("DialogButtonAll"), CaretagMessageBoxResult.All);
                    var cancelButton3 = CreateButton(_resourceManager.GetString("DialogButtonNo"), CaretagMessageBoxResult.Cancel);
                    buttonTableLayoutPanel.Controls.Add(yesButton2, 0, 0);
                    buttonTableLayoutPanel.Controls.Add(allButton, 1, 0);
                    buttonTableLayoutPanel.Controls.Add(cancelButton3, 2, 0);
                    break;
                case CaretagMessageBoxOptions.YesNo:
                    SetLayout(2);
                    var yesButton3 = CreateButton(_resourceManager.GetString("DialogButtonYes"), CaretagMessageBoxResult.Yes);
                    var noButton2 = CreateButton(_resourceManager.GetString("DialogButtonNo"), CaretagMessageBoxResult.No);
                    buttonTableLayoutPanel.Controls.Add(yesButton3, 0, 0);
                    buttonTableLayoutPanel.Controls.Add(noButton2, 1, 0);
                    break;
            }
        }
    }
}
