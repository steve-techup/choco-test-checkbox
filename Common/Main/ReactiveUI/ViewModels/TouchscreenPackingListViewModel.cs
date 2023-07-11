using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caretag_Class.Model;
using Caretag_Class.My.Resources;
using Caretag_Class.Repositories;
using DynamicData;
using Main.Model.Assets;
using ReactiveUI;

namespace Caretag_Class.ReactiveUI.ViewModels
{
    public class TouchscreenPackingListViewModel : ReactiveObject
    {
        private readonly SourceCache<PackingListRowViewModel, string> _packingListRows; //identified by description id as PK
        private readonly BindingList<PackingListRowViewModel> _packingListRowsCollection = new();
        public BindingList<PackingListRowViewModel> PackingListRowsCollection => _packingListRowsCollection;

        public delegate void ManuallyAddedAssetEventHandler(object sender, ManuallyAddedAsset e);
        public event ManuallyAddedAssetEventHandler OnManuallyAddedAsset;

        public enum Mode
        {
            Standard,
            Checkbox
        }
        
        public TouchscreenPackingListViewModel()
        {
            _packingListRows = new SourceCache<PackingListRowViewModel, string>(x => x.DescriptionId);
            _packingListRows.Connect()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(_packingListRowsCollection)
                .Subscribe();

        }

        public void EditPackingListRows(Action<ISourceUpdater<PackingListRowViewModel, string>> updateAction)
        {
            _packingListRows.Edit(updateAction);
        }

        public void UpsertPackingListRow(PackingListRowViewModel packingListRow)
        {
            _packingListRows.AddOrUpdate(packingListRow);
        }
        
        public void UpsertPackingListRows(IEnumerable<PackingListRowViewModel> packingListRow)
        {
            _packingListRows.AddOrUpdate(packingListRow);
        }

        public void Clear()
        {
            _packingListRows.Clear();
        }

        public void AddManually(ManuallyAddedAsset asset)
        {
            OnManuallyAddedAsset(this, asset);
        }

        private PackingListRowViewModel _selectedPackingListRow;
        public PackingListRowViewModel SelectedPackingListRow
        {
            get => _selectedPackingListRow;
            set => this.RaiseAndSetIfChanged(ref _selectedPackingListRow, value);
        }

        private Mode _mode = Mode.Standard;
        public Mode PackingListMode
        {
            get => _mode;
            set => this.RaiseAndSetIfChanged(ref _mode, value);
        }

        private string _desctiptionIdColumnHeaderText;
        public string DescriptionIdColumnHeaderText
        {
            get => _desctiptionIdColumnHeaderText;
            set => this.RaiseAndSetIfChanged(ref _desctiptionIdColumnHeaderText, value);
        }

        private string _descriptionColumnHeaderText;
        public string DescriptionColumnHeaderText
        {
            get => _descriptionColumnHeaderText;
            set => this.RaiseAndSetIfChanged(ref _descriptionColumnHeaderText, value);
        }

        private string _brandColumnHeaderText;
        public string BrandColumnHeaderText
        {
            get => _brandColumnHeaderText;
            set => this.RaiseAndSetIfChanged(ref _brandColumnHeaderText, value);
        }

        private string _quantityColumnHeaderText;
        public string QuantityColumnHeaderText
        {
            get => _quantityColumnHeaderText;
            set => this.RaiseAndSetIfChanged(ref _quantityColumnHeaderText, value);
        }

        public class PackingListRowViewModel
        {
            private static readonly Image _emptyImage = new Bitmap(1, 1);
            public string DescriptionId { get; set; }
            public string InstrumentDescription { get; set; }
            public string InstrumentVendor { get; set; }
            public string Status { get; set; }
            public int Quantity { get; set; }
            public string QuantityRendered => $"{TotalPacked}/{Quantity}";
            public int QuantityPackedManually { get; set; }
            public int TotalPacked => PackedInstruments.Count + QuantityPackedManually;
            public bool CanPackManually { get; set; }
            public List<Instrument_RFID> PackedInstruments { get; set; } = new();
            public Image? ManualImageColumnValue => CanPackManually ? Resources.edit_round_line_icon_sm : _emptyImage;
            public bool NotPacked { get; set; }
            public List<int> AssetIds { get; set; }
            public int AssetTypeId { get; set; }
        }

    }
}
