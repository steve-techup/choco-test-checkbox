using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Caretag_Class.Model.Service;
using Main.Model.PackingList;
using Main.Model.PackingList.Validation;

namespace Caretag_Class.Model
{
    public partial class CaretagModel : DbContext
    {
        public CaretagModel()
        {
            //For unit testing
        }

        public CaretagModel(string connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
        }
        public virtual DbSet<Antenna_Reader> Antenna_Reader { get; set; }
        public virtual DbSet<Area_Name_List> Area_Name_List { get; set; }
        public virtual DbSet<Cart_Description> Cart_Description { get; set; }
        public virtual DbSet<Cart_RFID> Cart_RFID { get; set; }
        public virtual DbSet<Cart_RFID_Life> Cart_RFID_Life { get; set; }
        public virtual DbSet<ConfigTable> ConfigTable { get; set; }
        public virtual DbSet<Container_Description> Container_Description { get; set; }
        public virtual DbSet<Container_RFID> Container_RFID { get; set; }
        public virtual DbSet<Container_RFID_Life> Container_RFID_Life { get; set; }
        public virtual DbSet<Cost_Center> Cost_Center { get; set; }
        public virtual DbSet<Demand_Text> Demand_Text { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Instrument_Description> Instrument_Description { get; set; }
        public virtual DbSet<Instrument_External> Instrument_External { get; set; }
        public virtual DbSet<Instrument_Group> Instrument_Group { get; set; }
        public virtual DbSet<Instrument_RFID_Life> Instrument_RFID_Life { get; set; }
        public virtual DbSet<Instrument_Rules> Instrument_Rules { get; set; }
        public virtual DbSet<Instrument_Vendor> Instrument_Vendor { get; set; }
        public virtual DbSet<LogIn_Table> LogIn_Table { get; set; }
        public virtual DbSet<OR_Procedure> OR_Procedure { get; set; }
        public virtual DbSet<OR_Trays_ID> OR_Trays_ID { get; set; }
        public virtual DbSet<Reader_Description> Reader_Description { get; set; }
        public virtual DbSet<Reader_ErrorLog> Reader_ErrorLog { get; set; }
        public virtual DbSet<Service_Vendor> Service_Vendor { get; set; }
        public virtual DbSet<Steril_Central> Steril_Central { get; set; }
        public virtual DbSet<TblPassword> TblPassword { get; set; }
        public virtual DbSet<Tray_Description> Tray_Description { get; set; }
        public virtual DbSet<Tray_Items> Tray_Items { get; set; }
        public virtual DbSet<Tray_PackList> Tray_PackList { get; set; }
        public virtual DbSet<Tray_RFID_Life> Tray_RFID_Life { get; set; }
        public virtual DbSet<Action_Description> Action_Description { get; set; }
        public virtual DbSet<Action_Type> Action_Type { get; set; }
        public virtual DbSet<CheckBox_OR_Log> CheckBox_OR_Log { get; set; }
        public virtual DbSet<CheckBox_OR_Sync> CheckBox_OR_Sync { get; set; }
        public virtual DbSet<CheckBox_SPD_Log> CheckBox_SPD_Log { get; set; }
        public virtual DbSet<CheckBox_SPD_Sync> CheckBox_SPD_Sync { get; set; }
        public virtual DbSet<Cost_Item> Cost_Item { get; set; }
        public virtual DbSet<Cost_Log> Cost_Log { get; set; }
        public virtual DbSet<Cost_Type> Cost_Type { get; set; }
        public virtual DbSet<Demand_Service_Log> Demand_Service_Log { get; set; }
        public virtual DbSet<Disposables_Description> Disposables_Description { get; set; }
        public virtual DbSet<Disposables_Log> Disposables_Log { get; set; }
        public virtual DbSet<EPC_Number_Serie> EPC_Number_Serie { get; set; }
        public virtual DbSet<Exchange_Log> Exchange_Log { get; set; }
        public virtual DbSet<Exchange_Table> Exchange_Table { get; set; }
        public virtual DbSet<Gate_Log> Gate_Log { get; set; }
        public virtual DbSet<Instrument_Code> Instrument_Code { get; set; }
        public virtual DbSet<Instrument_Image> Instrument_Image { get; set; }
        public virtual DbSet<Instrument_Maintenance_RFID> Instrument_Maintenance_RFID { get; set; }
        public virtual DbSet<Instrument_ReCall> Instrument_ReCall { get; set; }
        public virtual DbSet<Instrument_Packed_Log> Instrument_Packed_Log { get; set; }
        public virtual DbSet<Instrument_RFID> Instrument_RFID { get; set; }
        public virtual DbSet<Instrument_RFID_History> Instrument_RFID_History { get; set; }
        public virtual DbSet<Instrument_Translation> Instrument_Translation { get; set; }
        public virtual DbSet<Instrument_Translation_Log> Instrument_Translation_Log { get; set; }
        public virtual DbSet<Instrument_Translation_Vendor> Instrument_Translation_Vendor { get; set; }
        public virtual DbSet<Lend_Entity> Lend_Entity { get; set; }
        public virtual DbSet<Lend_Instrument> Lend_Instrument { get; set; }
        public virtual DbSet<Lend_Log> Lend_Log { get; set; }
        public virtual DbSet<Log_Change> Log_Change { get; set; }
        public virtual DbSet<Login_Security> Login_Security { get; set; }
        public virtual DbSet<Not_Known_RFID> Not_Known_RFID { get; set; }
        public virtual DbSet<Procedure_Demand_List> Procedure_Demand_List { get; set; }
        public virtual DbSet<PackingLog> PackingLogs { get; set; }
        public virtual DbSet<PackingLogLine> PackingLogLines { get; set; }
        public virtual DbSet<ReCall_Log> ReCall_Log { get; set; }
        public virtual DbSet<Rules_Log> Rules_Log { get; set; }
        public virtual DbSet<ScanEvent> ScanEvent { get; set; }
        public virtual DbSet<Service_Connections> Service_Connections { get; set; }
        public virtual DbSet<Service_Log> Service_Log { get; set; }
        public virtual DbSet<SPD_Machine> SPD_Machine { get; set; }
        public virtual DbSet<Stop_Instrument> Stop_Instrument { get; set; }
        public virtual DbSet<Storage_Item> Storage_Item { get; set; }
        public virtual DbSet<Storage_Log> Storage_Log { get; set; }
        public virtual DbSet<Storage_Station> Storage_Station { get; set; }
        public virtual DbSet<SW_Update> SW_Update { get; set; }
        public virtual DbSet<SystemInfo> SystemInfo { get; set; }
        public virtual DbSet<Technical_Log> Technical_Log { get; set; }
        public virtual DbSet<Tray_Image> Tray_Image { get; set; }
        public virtual DbSet<Tray_Log> Tray_Log { get; set; }
        public virtual DbSet<Tray_Packed> Tray_Packed { get; set; }
        public virtual DbSet<Tray_RFID> Tray_RFID { get; set; }
        public virtual DbSet<Tray_Translation> Tray_Translation { get; set; }
        public virtual DbSet<Trays_To_Pack> Trays_To_Pack { get; set; }
        public virtual DbSet<TreatMachine_Log> TreatMachine_Log { get; set; }
        public virtual DbSet<Treatment_Description> Treatment_Description { get; set; }
        public virtual DbSet<Treatment_Detail> Treatment_Detail { get; set; }
        public virtual DbSet<Treatment_Log> Treatment_Log { get; set; }
        public virtual DbSet<Treatment_Machine> Treatment_Machine { get; set; }
        public virtual DbSet<Treatment_Type> Treatment_Type { get; set; }
        public virtual DbSet<View_AllInstruments> View_AllInstruments { get; set; }
        public virtual DbSet<View_Cart_Container_Tray_A> View_Cart_Container_Tray_A { get; set; }
        public virtual DbSet<View_Cart_Container_Tray_B> View_Cart_Container_Tray_B { get; set; }
        public virtual DbSet<View_Carts_In_Database> View_Carts_In_Database { get; set; }
        public virtual DbSet<View_Combine> View_Combine { get; set; }
        public virtual DbSet<View_CostCenter> View_CostCenter { get; set; }
        public virtual DbSet<View_EPC_DescriptionName_New> View_EPC_DescriptionName_New { get; set; }
        public virtual DbSet<View_EPC_DescriptionName_Org> View_EPC_DescriptionName_Org { get; set; }
        public virtual DbSet<View_EPC_To_Tray> View_EPC_To_Tray { get; set; }
        public virtual DbSet<View_Exchange_OverView> View_Exchange_OverView { get; set; }
        public virtual DbSet<View_Full_UserName> View_Full_UserName { get; set; }
        public virtual DbSet<View_GridView_1> View_GridView_1 { get; set; }
        public virtual DbSet<View_Information_Schema> View_Information_Schema { get; set; }
        public virtual DbSet<View_Information_Station> View_Information_Station { get; set; }
        public virtual DbSet<View_Instru_To_Tray> View_Instru_To_Tray { get; set; }
        public virtual DbSet<View_Instruments_DISTINCT> View_Instruments_DISTINCT { get; set; }
        public virtual DbSet<View_Life_GridView> View_Life_GridView { get; set; }
        public virtual DbSet<View_Not_InPackList> View_Not_InPackList { get; set; }
        public virtual DbSet<View_Packed_Trays> View_Packed_Trays { get; set; }
        public virtual DbSet<View_Reader_Log_Error> View_Reader_Log_Error { get; set; }
        public virtual DbSet<View_Reader_Overview> View_Reader_Overview { get; set; }
        public virtual DbSet<View_ReaderList> View_ReaderList { get; set; }
        public virtual DbSet<View_Rules_Log_New> View_Rules_Log_New { get; set; }
        public virtual DbSet<View_Rules_Report> View_Rules_Report { get; set; }
        public virtual DbSet<View_Rules_Station> View_Rules_Station { get; set; }
        public virtual DbSet<View_Rules_Status> View_Rules_Status { get; set; }
        public virtual DbSet<View_Schemas> View_Schemas { get; set; }
        public virtual DbSet<View_Service_GridView> View_Service_GridView { get; set; }
        public virtual DbSet<View_Set_Syncbox_ComboBox> View_Set_Syncbox_ComboBox { get; set; }
        public virtual DbSet<View_Sync_Missing> View_Sync_Missing { get; set; }
        public virtual DbSet<View_TotalInstruments> View_TotalInstruments { get; set; }
        public virtual DbSet<View_Tray_Life_GridView> View_Tray_Life_GridView { get; set; }
        public virtual DbSet<View_Tray_PackList> View_Tray_PackList { get; set; }
        public virtual DbSet<View_Treatment_Detail> View_Treatment_Detail { get; set; }
        public virtual DbSet<View_Treatment_Detail_Report> View_Treatment_Detail_Report { get; set; }
        public virtual DbSet<Operation> Operation { get; set; }
        public virtual DbSet<OperationInstrument> OperationInstrument { get; set; }

        //Service models
        public virtual DbSet<ServiceActionRecord> ServiceActionRecord { get; set; }
        public virtual DbSet<ServiceActionRecordLine> ServiceActionRecordLine { get; set; }
        public virtual DbSet<ServiceActionTemplate> ServiceActionTemplate { get; set; }
        public virtual DbSet<ServiceActionTemplateLine> ServiceActionTemplateLine { get; set; }
        public virtual DbSet<ServiceRequest> ServiceRequest { get; set; }
        public virtual DbSet<ServiceRule> ServiceRule { get; set; }

        //PackingListValidation models
        public virtual DbSet<ValidatedPackingList> ValidatedPackingList { get; set; }
        public virtual DbSet<ValidatedPackingListLineItem> ValidatedPackingListLineItem { get; set; }
        public virtual DbSet<AssetId> AssetId { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Antenna_Reader>()
                .Property(e => e.In_Use)
                .IsFixedLength();

            modelBuilder.Entity<Instrument_Group>()
                .Property(e => e.Group_Identifier)
                .IsFixedLength();

            modelBuilder.Entity<Instrument_Vendor>()
                .Property(e => e.Vendor_Abbreviation)
                .IsFixedLength();

            modelBuilder.Entity<Instrument_Vendor>()
                .Property(e => e.Delimiter_Sign)
                .IsFixedLength();

            modelBuilder.Entity<LogIn_Table>()
                .Property(e => e.Log_Type)
                .IsFixedLength();

            modelBuilder.Entity<Reader_Description>()
                .Property(e => e.In_Use)
                .IsFixedLength();

            modelBuilder.Entity<CheckBox_SPD_Log>()
                .Property(e => e.CheckBox_Function)
                .IsFixedLength();

            modelBuilder.Entity<EPC_Number_Serie>()
                .Property(e => e.Customer_Number)
                .IsFixedLength();

            modelBuilder.Entity<EPC_Number_Serie>()
                .Property(e => e.Special_Number)
                .IsFixedLength();

            modelBuilder.Entity<Instrument_Translation_Vendor>()
                .Property(e => e.The_Last_Vendor_Index)
                .IsFixedLength();

            modelBuilder.Entity<Lend_Entity>()
                .Property(e => e.Lend_Email)
                .IsFixedLength();

            modelBuilder.Entity<Lend_Entity>()
                .Property(e => e.Lend_Department)
                .IsFixedLength();

            modelBuilder.Entity<Lend_Entity>()
                .Property(e => e.Lend_Address)
                .IsFixedLength();

            modelBuilder.Entity<Lend_Entity>()
                .Property(e => e.Lend_ZIP)
                .IsFixedLength();

            modelBuilder.Entity<Lend_Entity>()
                .Property(e => e.Lend_City)
                .IsFixedLength();

            modelBuilder.Entity<Lend_Entity>()
                .Property(e => e.Lend_State)
                .IsFixedLength();

            modelBuilder.Entity<Lend_Entity>()
                .Property(e => e.Lend_Country)
                .IsFixedLength();

            modelBuilder.Entity<Treatment_Description>()
                .Property(e => e.Treatment_Path)
                .IsUnicode(false);

            modelBuilder.Entity<Treatment_Detail>()
                .Property(e => e.Detail_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Treatment_Type>()
                .Property(e => e.Description_Type)
                .IsFixedLength();

            modelBuilder.Entity<View_Reader_Overview>()
                .Property(e => e.In_Use)
                .IsFixedLength();

            modelBuilder.Entity<View_ReaderList>()
                .Property(e => e.R_In_Use)
                .IsFixedLength();

            modelBuilder.Entity<View_ReaderList>()
                .Property(e => e.In_Use)
                .IsFixedLength();

            modelBuilder.Entity<View_Treatment_Detail>()
                .Property(e => e.Description_Type)
                .IsFixedLength();

            modelBuilder.Entity<OperationInstrument>()
                .HasRequired(o => o.Operation)
                .WithMany(o => o.OperationInstruments);

            modelBuilder.Entity<OperationInstrument>()
                .HasRequired(o => o.Instrument)
                .WithMany(o => o.OperationInstruments);

            modelBuilder.Entity<Instrument_RFID>()
                .HasRequired(i => i.InstrumentDescription)
                .WithMany();

            modelBuilder.Entity<Tray_RFID>()
                .HasRequired(t => t.TrayDescription)
                .WithMany();

            modelBuilder.Entity<Tray_Packed>()
                .HasRequired(t => t.TrayDescription)
                .WithMany();

            modelBuilder.Entity<Tray_PackList>()
                .HasOptional(tp => tp.TrayDescription)
                .WithMany();

            modelBuilder.Entity<Tray_PackList>()
                .HasRequired(tp => tp.InstrumentDescription)
                .WithMany();

            modelBuilder.Entity<Cost_Item>()
                .HasRequired(c => c.CostCenter)
                .WithMany(c => c.CostItems);
            
            modelBuilder.Entity<Cost_Item>()
                .HasRequired(c => c.CostType)
                .WithMany();

            modelBuilder.Entity<PackingLogLine>()
                .HasRequired(pl => pl.PackingLog)
                .WithMany(pl => pl.PackingLogLines);
        }
    }
}
