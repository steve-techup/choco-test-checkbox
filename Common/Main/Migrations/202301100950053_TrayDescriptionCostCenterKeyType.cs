namespace Caretag_Class.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrayDescriptionCostCenterKeyType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tray_Description", "Cost_ID", c => c.Long(nullable:true));
            Sql("UPDATE dbo.Tray_Description SET Cost_ID = NULL WHERE Cost_ID = 0");
            CreateIndex("dbo.Tray_Description", "Cost_ID");
            AddForeignKey("dbo.Tray_Description", "Cost_ID", "dbo.Cost_Item", "Index_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tray_Description", "Cost_ID", "dbo.Cost_Item");
            DropIndex("dbo.Tray_Description", new[] { "Cost_ID" });
            AlterColumn("dbo.Tray_Description", "Cost_ID", c => c.Int(nullable: false));
        }
    }
}
