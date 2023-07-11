namespace Caretag_Class.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckboxManualPackingSupport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ValidatedPackingListLineItems", "PackedManually", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ValidatedPackingListLineItems", "DescriptionId", c => c.String(maxLength: 255));
            CreateIndex("dbo.ValidatedPackingListLineItems", "DescriptionId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ValidatedPackingListLineItems", new[] { "DescriptionId" });
            AlterColumn("dbo.ValidatedPackingListLineItems", "DescriptionId", c => c.String());
            DropColumn("dbo.ValidatedPackingListLineItems", "PackedManually");
        }
    }
}
