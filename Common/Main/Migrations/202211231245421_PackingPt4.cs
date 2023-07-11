namespace Caretag_Class.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PackingPt4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PackingLogLines", "QuantityPackedManually", c => c.Int(nullable: false));
            DropColumn("dbo.PackingLogLines", "PackedManually");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PackingLogLines", "PackedManually", c => c.Boolean(nullable: false));
            DropColumn("dbo.PackingLogLines", "QuantityPackedManually");
        }
    }
}
