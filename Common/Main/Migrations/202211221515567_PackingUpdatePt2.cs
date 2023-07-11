namespace Caretag_Class.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PackingUpdatePt2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cost_Log", "CostCenterId", "dbo.Cost_Center");
            DropForeignKey("dbo.Cost_Log", "CostTypeId", "dbo.Cost_Type");
            DropIndex("dbo.Cost_Log", new[] { "CostCenterId" });
            DropIndex("dbo.Cost_Log", new[] { "CostTypeId" });
            AddColumn("dbo.Cost_Log", "CostItemId", c => c.Long());
            CreateIndex("dbo.Cost_Log", "CostItemId");
            CreateIndex("dbo.Cost_Log", "TrayDescriptionId");
            AddForeignKey("dbo.Cost_Log", "CostItemId", "dbo.Cost_Item", "Index_ID");
            AddForeignKey("dbo.Cost_Log", "TrayDescriptionId", "dbo.Tray_Description", "Description_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cost_Log", "CostTypeId", c => c.Long(nullable: false));
            AddColumn("dbo.Cost_Log", "CostCenterId", c => c.Long(nullable: false));
            DropForeignKey("dbo.Cost_Log", "TrayDescriptionId", "dbo.Tray_Description");
            DropForeignKey("dbo.Cost_Log", "CostItemId", "dbo.Cost_Item");
            DropIndex("dbo.Cost_Log", new[] { "TrayDescriptionId" });
            DropIndex("dbo.Cost_Log", new[] { "CostItemId" });
            DropColumn("dbo.Cost_Log", "CostItemId");
            CreateIndex("dbo.Cost_Log", "CostTypeId");
            CreateIndex("dbo.Cost_Log", "CostCenterId");
            AddForeignKey("dbo.Cost_Log", "CostTypeId", "dbo.Cost_Type", "Index_ID", cascadeDelete: true);
            AddForeignKey("dbo.Cost_Log", "CostCenterId", "dbo.Cost_Center", "Index_ID", cascadeDelete: true);
        }
    }
}
