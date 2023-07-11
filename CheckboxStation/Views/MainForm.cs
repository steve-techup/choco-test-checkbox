using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using Caretag_Class.Configuration;
using Caretag_Class.Model;
using Caretag_Class.Util.UI;
using CheckboxStation.Services;
using CheckboxStation.ViewModels;
using Main.Extensions;
using Main.Model.PackingList.Validation;
using OnScreenKeyboard;
using Org.BouncyCastle.Bcpg.Sig;
using ReactiveUI;

namespace CheckboxStation.Views
{

    public partial class MainForm : Form, IViewFor<CheckboxViewModel>
    {
        private CheckboxViewModel _vm;

        object IViewFor.ViewModel
        {
            get => _vm;
            set => _vm = (CheckboxViewModel)value;
        }

        CheckboxViewModel IViewFor<CheckboxViewModel>.ViewModel
        {
            get => _vm;
            set => _vm = value;
        }


        public MainForm(CheckboxViewModel vm)
        {

            this.Icon = Properties.Resources.CaretagApplicationIcon;
            _vm = vm;
            InitializeComponent();

            operationsGridView.AutoGenerateColumns = false;

            FormBorderStyle = FormBorderStyle.None;
            assetScanGridView.ViewModel = _vm.PackingListViewModel;

            this.OneWayBind(_vm, vm => vm.TotalInstrumentsCounted, form => form.instrumentTotalCountDataLabel.Text);
            this.OneWayBind(_vm, vm => vm.ExpectedInstrumentCount, form => form.expectedDataLabel.Text);

            this.OneWayBind(_vm, vm => vm.TotalTagsScanned, form => form.scannedDataLabel.Text);
            this.OneWayBind(_vm, vm => vm.TotalTagsScanned, form => form.lifecycleScannedTagsDataLabel.Text);
            this.OneWayBind(_vm, vm => vm.ExpectedInstrumentCount, form => form.expectedDataLabel.Text);

            this.OneWayBind(_vm, vm => vm.AppSettingsBase, form => form.operationsFilterPanel.Visible,
                settings => !settings.UseApi);

            this.OneWayBind(_vm, vm => vm.AppSettingsBase, form => form.lifeCyclePage.Visible,
                settings => !settings.UseApi);


            this.OneWayBind(_vm, vm => vm.CurrentOperationId, form => form.currentOperationText.Visible,
                selectedOperationId => !string.IsNullOrEmpty(selectedOperationId));

            this.WhenAnyValue(v => v._vm.CurrentOperationId)
                .Subscribe(operationId =>
                {
                    currentOperationText.Text = !string.IsNullOrEmpty(operationId) ? $"[{operationId}]" : string.Empty;
                });


            this.OneWayBind(_vm, vm => vm.AppSettingsBase, form => form.operationStatusGroupBox.Visible,
                settings => !settings.UseApi);

            this.OneWayBind(_vm, vm => vm.AppSettingsBase, form => form.operationsGridView.Size,
                settings => settings.UseApi ? new Size(867, 588) : new Size(324, 160));

            this.OneWayBind(_vm, vm => vm.AppSettingsBase, form => form.newOperationButton.Location,
                settings => settings.UseApi ? new Point(879, 547) : new Point(653, 376));

            this.OneWayBind(vm, vm => vm.Title, form => form._TopTitle.Text);

            this.OneWayBind(_vm, x => x.TrayStatus, x => x.trayDataLabel.Text);
            this.OneWayBind(_vm, vm => vm.PackingListState, x => x.packingListIcon.Image, result =>
            {
                if (result == null)
                    return Properties.Resources.ok;
                return result switch
                {
                    ValidatedPackingList.PackingListState.NoTray => Properties.Resources.question_mark_round_icon,
                    ValidatedPackingList.PackingListState.Ok => Properties.Resources.ok,
                    ValidatedPackingList.PackingListState.NotOk => Properties.Resources.nok,
                    ValidatedPackingList.PackingListState.MoreThanOneTray => Properties.Resources.question_mark_round_icon,
                    _ => throw new ArgumentOutOfRangeException()
                };
            });

            this.Events().Load.InvokeCommand(this, x => x._vm.OnLoad);
            this.BindCommand(_vm, vm => vm.ScanExtra, main => main.scanExtraButton, Observable.Return(new Tuple<bool, int, int, bool>(true, 1, 1, true)));
            this.BindCommand(_vm, vm => vm.Scan, main => main.scanButton);
            this.BindCommand(_vm, vm => vm.SendInstrumentToService, main => main.btnSendToService);
            this.BindCommand(_vm, vm => vm.Scan, main => main.btnScanLifecycleInstruments);
            //this.BindCommand(_vm, vm => vm.GenerateHtmlReport, main => main.restartSessionBtn);
            this.BindCommand(_vm, vm => vm.RestartSession, main => main.reportButton);
            this.BindCommand(_vm, vm => vm.StartOperation, form => form.operationStartButton);
            this.BindCommand(_vm, vm => vm.FinishOperation, form => form.operationFinishButton);
            this.BindCommand(_vm, vm => vm.InspectOperationInstruments, form => form.inspectInstrumentsButton);
            this.BindCommand(_vm, vm => vm.CheckIn, form => form.checkinButton);
            this.BindCommand(_vm, vm => vm.CheckOut, form => form.checkoutButton);
            this.BindCommand(_vm, vm => vm.NewOperation, form => form.newOperationButton);
            this.BindCommand(_vm, vm => vm.CompleteCheckIn, form => form.finishButton);
            this.BindCommand(_vm, vm => vm.EnableForcedValidationOnNextScan, main => main.expectedLabel);

            this.OneWayBind(_vm, vm => vm.ScanProgress, form => form.scannedLabel.Visible,
                progress => progress < 100);

            this.OneWayBind(_vm, vm => vm.ScanProgress, form => form.lifecycleTagCountTablePanel.Visible, progress => progress < 100);
            this.OneWayBind(_vm, vm => vm.ScanProgress, form => form.tagCountTablePanel.Visible, progress => progress < 100);
            this.OneWayBind(_vm, vm => vm.ScanProgress, form => form.scannedDataLabel.Visible, progress => progress < 100);

            this.OneWayBind(_vm, vm => vm.ScanProgress, x => x.progressBar.Visible, val => val < 100);
            this.OneWayBind(_vm, vm => vm.ScanProgress, x => x.scanInProgressLabel.Visible, val => val < 100);
            this.OneWayBind(_vm, vm => vm.ScanProgress, x => x.progressBar.Value);


            this.OneWayBind(_vm, vm => vm.ScanProgress, form => form.lifecycleScannedTagsLabel.Visible, progress => progress < 100);
            this.OneWayBind(_vm, vm => vm.ScanProgress, form => form.lifecycleScannedTagsDataLabel.Visible, progress => progress < 100);

            this.OneWayBind(_vm, vm => vm.ScanProgress, x => x.lifecycleScanProgressBar.Visible, val => val < 100);
            this.OneWayBind(_vm, vm => vm.ScanProgress, x => x.lifecycleScanProgressLabel.Visible, val => val < 100);
            this.OneWayBind(_vm, vm => vm.ScanProgress, x => x.lifecycleScanProgressBar.Value);
            this.OneWayBind(_vm, vm => vm.Operations, form => form.operationsGridView.DataSource);
            this.OneWayBind(_vm, vm => vm.InstrumentScanEvents, form => form.lbInstrumentsLifecycle.DataSource);

            this.OneWayBind(vm, vm => vm.SelectedOperation.State, form => form.stateDataLabel.Text,
                state => state ?? "N/A");
            this.OneWayBind(vm, vm => vm.CheckedInInstruments, form => form.instrumentsCheckedInDataLabel.Text);

            this.OneWayBind(vm, vm => vm.CheckedOutInstruments, form => form.instrumentsCheckedOutDataLabel.Text);

            this.OneWayBind(vm, vm => vm.TotalInstrumentsCounted, form => form.totalInstrumentsDataLabel.Text);
            this.OneWayBind(vm, vm => vm.TotalInstrumentsCounted, form => form.lifecycleTotalInstrumentsDataLabel.Text);

            this.OneWayBind(vm, vm => vm.SelectedOperation.OperatingRoom, form => form.operatingRoomDataLabel.Text,
                or => or ?? "");

            this.OneWayBind(vm, vm => vm.SelectedOperation, form => form.inspectInstrumentsButton.Enabled,
                operation => operation != null);

            this.OneWayBind(_vm, vm => vm.ScanProgress, x => x.scanInProgressLabel.Visible, val => val < 100);

            this.OneWayBind(vm, vm => vm.CurrentScanningSession, form => form.scanExtraButton.Enabled,
                session => session != null);


            this.WhenAnyValue(v => v._vm.InstrumentLifecycleRfids)
                .Where(m=> m is {})
                .Subscribe(list =>
            {

                if (!_vm.AppSettingsBase.UseApi)
                {
                    lvInstrumentsLifecycle.Items.Clear();
                    lvInstrumentsLifecycle.Items.AddRange(list.Select(instrument =>
                    {
                        var i = new[]
                        {
                        instrument.Description_ID,
                        $"{instrument.InstrumentDescription?.Description_Name ?? "Unknown"} " +
                        $"{instrument.InstrumentDescription?.D ?? ""} " +
                        $"{instrument.InstrumentDescription?.E ?? ""}",
                    };
                        var item = new ListViewItem(i)
                        {
                            Tag = instrument
                        };
                        return item;
                    }).ToArray());
                }
            });

            var operationPage = tabs.TabPages["operationPage"];
            var lifeCyclePage = tabs.TabPages["lifeCyclePage"];
            var scanPage = tabs.TabPages["scanPage"];

            this.WhenAnyValue(v => v._vm.Features).Subscribe(features =>
            {
                btnSendToService.Visible = features.ServiceDemandEnabled;
                checkinButton.Visible = features.CheckInEnabled && !features.VerificationEnabled;
                checkoutButton.Visible = features.CheckOutEnabled && !features.VerificationEnabled;

                if (features.ScanTabEnabled)
                {
                    if (!tabs.TabPages.ContainsKey("scanPage"))
                    {
                        tabs.TabPages.Insert(0, scanPage);
                    }
                }
                else
                {
                    if (tabs.TabPages.ContainsKey("scanPage"))
                    {
                        tabs.TabPages.RemoveByKey("scanPage");
                    }
                }

                if (features.OperationsEnabled && !features.VerificationEnabled && !features.CheckOutEnabled)
                {
                    if (!tabs.TabPages.ContainsKey("operationPage"))
                    {
                        tabs.TabPages.Add(operationPage);
                    }
                }
                else
                {
                    if (tabs.TabPages.ContainsKey("operationPage"))
                    {
                        tabs.TabPages.RemoveByKey("operationPage");
                    }
                }

                if (!vm.AppSettingsBase.UseApi && !features.VerificationEnabled && !features.CheckOutEnabled)
                {
                    if (!tabs.TabPages.ContainsKey("lifeCyclePage"))
                    {
                        tabs.TabPages.Add(lifeCyclePage);
                    }
                }
                else
                {
                    if (tabs.TabPages.ContainsKey("lifeCyclePage"))
                    {
                        tabs.TabPages.RemoveByKey("lifeCyclePage");
                    }
                }
            });

            this.WhenAnyValue(v => v._vm.Features.VerificationEnabled).Subscribe(val =>
            {   
                if (!val && tableLayoutPanel1.RowCount > 3)
                {
                    tableLayoutPanel1.RowStyles.RemoveAt(3);
                }
            });

            //this.WhenAnyValue(v => v._vm.CheckInInProgress).Subscribe(val =>
            //{
            //    if (!vm.Features.VerificationEnabled)
            //    {
            //        if (val)
            //        {
            //            //finishButton.Visible = true;
            //            //tableLayoutPanel1.SetColumn(finishButton, 5);
            //            tableLayoutPanel1.SetColumn(scanButton, 4);
            //        }
            //        else
            //        {
            //            //tableLayoutPanel1.SetColumn(finishButton, 4);
            //            tableLayoutPanel1.SetColumn(scanButton, 5);
            //            //finishButton.Visible = false;
            //        }
            //    }
            //});

            this.Bind(_vm, vm => vm.From, form => form.fromDateTimePicker.Value);
            this.Bind(_vm, vm => vm.To, form => form.toDateTimePicker.Value);
            this.Bind(_vm, vm => vm.ShowFinishedOperations, form => form.showFinishedCheckbox.Checked);

            //operationsListBox.DisplayMember = "OperationId";
            //operationsListBox.ValueMember = "Id";

            this.WhenAnyValue(x => x.lvInstrumentsLifecycle.SelectedItems)
                .Select(x => x.Count > 0 ? x[0].Tag : null)
                .BindTo(this, x => x._vm.SelectedInstrumentLifecycleRfid);


            //this.Bind(_vm, vm => vm.SelectedOperation, form => form.operationsListBox.SelectedItem
            //    , Observable.FromEventPattern(operationsListBox, "SelectedIndexChanged"));

            foreach (var control in ControlExtensions.GetAllControlsRecusrvive<TextBox>(this).Where(c => !c.ReadOnly))
            {
                OskUiController.Instance.AddControl(control);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData & Keys.Alt) != 0)
            {
                FormBorderStyle = FormBorderStyle == FormBorderStyle.None ? FormBorderStyle.Sizable : FormBorderStyle.None;
                return true;
            }
            else if ((keyData & Keys.Control) != 0 && (keyData & Keys.C) == Keys.C)
            {
                var instruments = string.Join("\n", _vm.ValidatedPackingList.Lines.Select(row => $"{row.Actual},{row.Expected},{row.Instruments.FirstOrDefault()?.Description_ID}"));
                Clipboard.SetText(instruments);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void lvInstrumentsLifecycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvInstrumentsLifecycle.SelectedItems.Count == 0)
            {
                _vm.SelectedInstrumentLifecycleRfid = null;
                return;
            }

            _vm.SelectedInstrumentLifecycleRfid = (Instrument_RFID) lvInstrumentsLifecycle.SelectedItems[0].Tag;
        }

        private void trayDataLabel_LocationChanged(object sender, EventArgs e)
        {
            if (trayDataLabel.Location.X == 0)
            {
                tableLayoutPanel1.RowStyles[0].Height = 76;
            }
            else
            {
                tableLayoutPanel1.RowStyles[0].Height = 38;
            }
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowStyles[0].Height = 38;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var control in ControlExtensions.GetAllControlsRecusrvive<TextBox>(this).Where(c => !c.ReadOnly))
            {
                OskUiController.Instance.DeleteControl(control);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (OSK.Instance.IsRunning)
                OSK.Instance.HideKeyboard();
        }
    }
}
