namespace Caretag_Class.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidatedPackingListTrayEPC : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ValidatedPackingLists", "TrayEPC", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ValidatedPackingLists", "TrayEPC");
        }
    }
}
