using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Resources;
using System.Windows.Forms;
using AdminStation.ViewModels.ReactiveUI;
using Caretag_Class.Util;
using DevExpress.Utils.Extensions;
using ReactiveUI;

namespace AdminStation.Views.Assets;

public partial class CSVImport : UserControl, IViewFor<CSVImportViewModel>
{
    private readonly ResourceManager _localRm = new("Surgical_Admin.WinFormStrings", typeof(CSVImport).Assembly);
    public DataTable _fileDataTable;
    private string _filename;

    private CSVImportViewModel _vm;

    public CSVImport(CSVImportViewModel viewModel, StringDistanceCalculator stringDistanceCalculator)
    {
        _vm = viewModel;

        InitializeComponent();

        tabWizardControl.Appearance = TabAppearance.FlatButtons;
        tabWizardControl.ItemSize = new Size(0, 1);
        tabWizardControl.SizeMode = TabSizeMode.Fixed;

        this.BindCommand(_vm, vm => vm.Back, view => view.backButton);
        this.BindCommand(_vm, vm => vm.Browse, view => view.browseButton);
        this.OneWayBind(_vm, vm => vm.Filename, view => view.filenameTextbox.Text);
        this.Bind(_vm, vm => vm.Delimiter, view => view.delimiterTextBox.Text);
        this.BindCommand(_vm, vm => vm.OpenFileCommand, view => view.openButton);
        this.Bind(_vm, vm => vm.CurrentWizardPage, view => view.tabWizardControl.SelectedIndex);
        this.BindCommand(_vm, vm => vm.Import, view => view.uploadButton);
        this.Bind(_vm, vm => vm.AutoImageSearch, view => view.autoImageSearchCheckBox.Checked);
        this.OneWayBind(_vm, vm => vm.ProgressBarState, view => view.progressBar.Value);

        _vm.ConnectToColumnNames()
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe(columnName =>
                columnName.ForEach(change =>
                {
                    instrumentDescriptionComboBox.Items.Clear();
                    quantityComboBox.Items.Clear();
                    descriptionIdComboBox.Items.Clear();
                    imageUrlComboBox.Items.Clear();
                    packingSetNameComboBox.Items.Clear();
                    instrumentVendorComboBox.Items.Clear();
                    untaggableCombobox.Items.Clear();

                    change.Range.ToList().ForEach(i =>
                    {
                        instrumentDescriptionComboBox.Items.Add(i);
                        quantityComboBox.Items.Add(i);
                        descriptionIdComboBox.Items.Add(i);
                        imageUrlComboBox.Items.Add(i);
                        packingSetNameComboBox.Items.Add(i);
                        instrumentVendorComboBox.Items.Add(i);
                        untaggableCombobox.Items.Add(i);
                    });

                    descriptionIdComboBox.SelectedIndex =
                        stringDistanceCalculator.GetClosestIndex(new List<string> {"Item number", "Description ID"},
                            change.Range.ToList());
                    quantityComboBox.SelectedIndex =
                        stringDistanceCalculator.GetClosestIndex(
                            new List<string> {"Quantity", "Qty", "Amount", "Article No."},
                            change.Range.ToList());
                    instrumentDescriptionComboBox.SelectedIndex = stringDistanceCalculator.GetClosestIndex(
                        new List<string> {"Description", "Instrument Description"}, change.Range.ToList());
                    packingSetNameComboBox.SelectedIndex = stringDistanceCalculator.GetClosestIndex(
                        new List<string> {"Packing Set Name", "Packing List Name"}, change.Range.ToList());
                    instrumentVendorComboBox.SelectedIndex = stringDistanceCalculator.GetClosestIndex(
                        new List<string> {"Vendor", "Instrument Vendor"}, change.Range.ToList());
                    untaggableCombobox.SelectedIndex = stringDistanceCalculator.GetClosestIndex(
                        new List<string> {"Untaggable", "No tag", "Missing tag"}, change.Range.ToList());

                    if (change.Range.Count > 4)
                        imageUrlComboBox.SelectedIndex =
                            stringDistanceCalculator.GetClosestIndex(
                                new List<string> {"Image URL", "Packing Set Image"},
                                change.Range.ToList());
                }));

        this.Bind(_vm, vm => vm.SelectedDescriptionIdColumnIndex, form => form.descriptionIdComboBox.SelectedIndex,
            Observable.FromEventPattern(descriptionIdComboBox, "SelectedIndexChanged"));
        this.Bind(_vm, vm => vm.SelectedInstrumentDescriptionColumnIndex,
            form => form.instrumentDescriptionComboBox.SelectedIndex,
            Observable.FromEventPattern(instrumentDescriptionComboBox, "SelectedIndexChanged"));
        this.Bind(_vm, vm => vm.SelectedImageUrlColumnIndex, form => form.imageUrlComboBox.SelectedIndex,
            Observable.FromEventPattern(imageUrlComboBox, "SelectedIndexChanged"));
        this.Bind(_vm, vm => vm.SelectedPackingSetNameColumnIndex, form => form.packingSetNameComboBox.SelectedIndex,
            Observable.FromEventPattern(packingSetNameComboBox, "SelectedIndexChanged"));
        this.Bind(_vm, vm => vm.SelectedQuantityColumnIndex, form => form.quantityComboBox.SelectedIndex,
            Observable.FromEventPattern(quantityComboBox, "SelectedIndexChanged"));
        this.Bind(_vm, vm => vm.SelectedInstrumentVendorColumnIndex,
            form => form.instrumentVendorComboBox.SelectedIndex,
            Observable.FromEventPattern(instrumentVendorComboBox, "SelectedIndexChanged"));
        this.Bind(_vm, vm => vm.SelectedUntaggableColumnIndex, form => form.untaggableCombobox.SelectedIndex,
            Observable.FromEventPattern(untaggableCombobox, "SelectedIndexChanged"));

        this.Bind(_vm, vm => vm.ImageSearchPattern, form => form.imageSearchPatternTextBox.Text);

        //enable image search pattern when auto image search is enabled
        this.WhenAnyValue(form => form.autoImageSearchCheckBox.Checked)
            .Subscribe(enabled => imageSearchPatternTextBox.Enabled = enabled);

        // enable the image url combobox when auto image search is disabled
        this.WhenAnyValue(form => form.autoImageSearchCheckBox.Checked)
            .Subscribe(enabled => imageUrlComboBox.Enabled = !enabled);
    }

    object IViewFor.ViewModel
    {
        get => _vm;
        set => _vm = (CSVImportViewModel) value;
    }

    CSVImportViewModel IViewFor<CSVImportViewModel>.ViewModel
    {
        get => _vm;
        set => _vm = value;
    }

    private void CSVImport_FormClosing(object sender, FormClosingEventArgs e)
    {
    }
}