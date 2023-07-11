namespace Caretag_Class.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewEPCStrategy : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UncommittedAssetIds");
            
            AddColumn("dbo.UncommittedAssetIds", "EPC", c => c.String());
            AddColumn("dbo.UncommittedAssetIds", "WrittenToTag", c => c.Boolean(nullable: false));
            AlterColumn("dbo.UncommittedAssetIds", "Id", c => c.Long(nullable: false, identity: false));
            
            AddPrimaryKey("dbo.UncommittedAssetIds", "Id");

            CreateTable("AssetIds",
                c => new
                {
                    Id = c.Long(nullable: false, identity: false),
                    Timestamp = c.DateTime(nullable: false),
                    EPC = c.String(),
                    WrittenToTag = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UncommittedAssetIds");
            AlterColumn("dbo.UncommittedAssetIds", "Id", c => c.Long(nullable: false, identity: true));
            DropColumn("dbo.UncommittedAssetIds", "WrittenToTag");
            DropColumn("dbo.UncommittedAssetIds", "EPC");
            AddPrimaryKey("dbo.UncommittedAssetIds", "Id");

            DropTable("AssetIds");
        }
    }
}
