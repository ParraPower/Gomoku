using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;
using Tofi.Framework.Data.Constraints;
using Tofi.Framework.Data.Extensions;

namespace Gomoku.Data.Migrations
{

    [Migration(202107241133, "202107241133_InitialMigration")]
    public class _202107241133_InitialMigration : Migration
    {
        private readonly ICreateConstraintFields _constraintFields;
        private readonly ICreateTableAuditFields _createTableAuditFields;

        public _202107241133_InitialMigration(ICreateConstraintFields createConstraintFields, ICreateTableAuditFields createTableAuditFields)
        {
            _constraintFields = createConstraintFields;
            _createTableAuditFields = createTableAuditFields;
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey("PK_User")
                .WithColumn("UniqueKey").AsGuid().NotNullable()
                .WithColumn("Username").AsString().Nullable()
                .WithColumn("Firstname").AsString().NotNullable()
                .WithColumn("Lastname").AsString().NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("IsRegistered").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("IsGuest").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithAuditColumns(_createTableAuditFields);
        }
    }
}
