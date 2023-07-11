using System.Data.Entity.Migrations;
namespace Caretag_Class.Migrations.Base
{
    public abstract class DbMigrationBase : DbMigration
    {
        protected void DropView(string viewName)
        {
            Sql($"DROP VIEW {viewName}");
        }

        protected void DropProcedure(string procedureName)
        {
            Sql($"DROP PROCEDURE {procedureName}");
        }
    }
}

