using FluentMigrator;
using System;

namespace Gomoku.Data.Migrations
{

    [Migration(202107242122, "202107242122_InitialMigration")]
    public class _202107242122_UserTable_Modify : Migration
    {
        
        public _202107242122_UserTable_Modify()
        {

        }

        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Alter.Table("User")
                .AddColumn("Password").AsString().Nullable();
        }
    }
}
