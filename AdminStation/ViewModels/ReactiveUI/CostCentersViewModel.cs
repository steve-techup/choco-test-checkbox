using System;
using System.Data.Entity;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using AdminStation.ViewModels.DataTypeViewModels;
using AdminStation.ViewModels.Validation;
using Caretag_Class;
using Caretag_Class.Configuration;
using Caretag_Class.Model;
using DevExpress.XtraGrid.Views.Base;
using DynamicData;
using Main.Util;
using ReactiveUI;

namespace AdminStation.ViewModels.ReactiveUI
{
    public class CostCentersViewModel : ReactiveObject, IRoutableViewModel, ExcelExportableViewModel
    {
        private readonly CaretagModel _caretagModel;
        public string? UrlPathSegment => "costCenters";
        public IScreen HostScreen { get; }
        public CostCentersViewModel(AppSettingsBase appSettingsBase, CaretagModelFactory caretagModelFactory)
        {
            _caretagModel = caretagModelFactory.Create();
            CostItemsForCostCenter =
                new EFBackedBindingList<CostItemViewModel, Cost_Item, long>(_caretagModel.Cost_Item,
                    () => _caretagModel.SaveChanges(), new CostItemValidator());
            
            CostCenters = new EFBackedBindingList<CostCenterViewModel, Cost_Center, long>(_caretagModel.Cost_Center, () => _caretagModel.SaveChanges(), new CostCenterValidator(),
            _caretagModel.Cost_Center.ToList().Select(cc => new CostCenterViewModel(cc)), 
                () => new Cost_Center {Cost_Center_Name = "", Default_Always = false, Hidden_Center = false});
            CostTypes = new EFBackedBindingList<CostTypeViewModel, Cost_Type, long>(_caretagModel.Cost_Type, () => _caretagModel.SaveChanges(), new CostTypeValidator(),
                _caretagModel.Cost_Type.ToList().Select(ct => new CostTypeViewModel(ct)));

            SaveChangesCommand = ReactiveCommand.Create<Unit, Unit>(SaveChanges);
            AddCostItemCommand = ReactiveCommand.Create<Unit, Unit>(AddCostTypeToCostCenter);
            RemoveCostItemCommand = ReactiveCommand.Create<Unit, Unit>(RemoveCostItemFromCostCenter);
            
            this.WhenAny(vm => vm.SelectedCostCenter, vm => vm.Value?.Pkid)
                .Subscribe(indexID =>
                {
                    if (indexID == null || indexID == 0)
                    {
                        CostItemsForCostCenter = new EFBackedBindingList<CostItemViewModel, Cost_Item, long>(_caretagModel.Cost_Item, () => _caretagModel.SaveChanges(),
                            new CostItemValidator());
                        return;
                    }
                    
                    CostItemsForCostCenter = new EFBackedBindingList<CostItemViewModel, Cost_Item, long>(_caretagModel.Cost_Item, () => _caretagModel.SaveChanges(), new CostItemValidator(),
                        _caretagModel.Cost_Item.Where(ci =>
                                    ci.Cost_Center == indexID).Include("CostCenter").Include("CostType").ToList().Select(ci => new CostItemViewModel(ci)).ToList());
                });

            ExportToExcelCommand = ReactiveCommand.Create(ExportToExcel, Observable.Return(true));
        }
        public ReactiveCommand<Unit, Unit> SaveChangesCommand { get; set; }
        public ReactiveCommand<Unit, Unit> AddCostItemCommand { get; set; }
        public ReactiveCommand<Unit, Unit> RemoveCostItemCommand { get; set; }
        
        // property for currently selected cost center
        private CostCenterViewModel? _selectedCostCenter;
        public CostCenterViewModel? SelectedCostCenter
        {
            get => _selectedCostCenter;
            set => this.RaiseAndSetIfChanged(ref _selectedCostCenter, value);
        }

        // property for currently selected cost type
        private CostTypeViewModel? _selectedCostType;
        public CostTypeViewModel? SelectedCostType
        {
            get => _selectedCostType;
            set => this.RaiseAndSetIfChanged(ref _selectedCostType, value);
        }

        private CostItemViewModel? _selectedCostItem;
        public CostItemViewModel? SelectedCostItem
        {
            get => _selectedCostItem;
            set => this.RaiseAndSetIfChanged(ref _selectedCostItem, value);
        }

        private EFBackedBindingList<CostItemViewModel, Cost_Item, long> _costItemsForCostCenter;
        public EFBackedBindingList<CostItemViewModel, Cost_Item, long> CostItemsForCostCenter
        {
            get => _costItemsForCostCenter;
            set => this.RaiseAndSetIfChanged(ref _costItemsForCostCenter, value);
        }

        public EFBackedBindingList<CostCenterViewModel, Cost_Center,long > CostCenters;
        public EFBackedBindingList<CostTypeViewModel, Cost_Type, long> CostTypes;




        private Unit SaveChanges(Unit unit)
        {   
            _caretagModel.SaveChanges();
            return Unit.Default;
        }
        
        private Unit AddCostTypeToCostCenter(Unit unit)
        {
            if (_caretagModel.Cost_Item.Any(ci =>
                    ci.Cost_Center == SelectedCostCenter.Pkid &&
                    ci.Cost_Type_ID == SelectedCostType.Pkid))
            {
                //TODO error via interactions
                return Unit.Default;
            }

            var dbItem = new Cost_Item
            {
                Cost_Center = SelectedCostCenter.Pkid,
                Cost_Type_ID = SelectedCostType.Pkid,
                Change_Date = DateTime.Now,
                Default_Cost = false
            };

            _caretagModel.Cost_Item.Add(dbItem);

            _caretagModel.SaveChanges();
            CostItemsForCostCenter.Add(new CostItemViewModel(dbItem));
            
            return Unit.Default;
        }

        private Unit RemoveCostItemFromCostCenter(Unit unit)
        {
            var costItem = _caretagModel.Cost_Item.First(ci => ci.Index_ID == SelectedCostItem.Pkid);
            if (SelectedCostItem != null)
            {   
                _caretagModel.Cost_Item.Remove(costItem);
                CostItemsForCostCenter.Remove(SelectedCostItem);

                _caretagModel.SaveChanges();
            }
            else
            {
                //TODO error via interactions
            }

            return Unit.Default;
        }
        private void ExportToExcel()
        {
            var filename = Common.ShowExcelSaveDialog();
            if (filename == null) return;
            var exporter = new ExcelExporter();
            exporter.AddSheet(CostCenters, "Cost Centers");
            exporter.AddSheet(CostTypes, "Cost Types");
            exporter.AddSheet(CostItemsForCostCenter, "Cost Items");
            exporter.Save(filename);
            Common.ShowSuccessDialog();   
        }
        
        public ReactiveCommand<Unit, Unit> ExportToExcelCommand { get; }
    }
}
