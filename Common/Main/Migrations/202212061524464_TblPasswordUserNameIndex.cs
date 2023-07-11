namespace Caretag_Class.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TblPasswordUserNameIndex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TblPassword", "UserName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TblPassword", new[] { "UserName" });
        }
    }
}
