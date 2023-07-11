namespace Caretag_Class.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrayImageTrayDescription : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tray_Image", "Description_ID", c => c.Long());
            CreateIndex("dbo.Tray_Image", "Description_ID");
            AddForeignKey("dbo.Tray_Image", "Description_ID", "dbo.Tray_Description", "Description_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tray_Image", "Description_ID", "dbo.Tray_Description");
            DropForeignKey("dbo.Tray_Description", "Cost_ID", "dbo.Cost_Item");
            DropIndex("dbo.Tray_Image", new[] { "Description_ID" });
            DropIndex("dbo.Tray_Description", new[] { "Cost_ID" });
            AlterColumn("dbo.Tray_Image", "Description_ID", c => c.Int());
            AlterColumn("dbo.Tray_Description", "Cost_ID", c => c.Int(nullable: false));
        }
    }
}
