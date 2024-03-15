using FluentMigrator;

namespace HandlingCommandTimeoutWithDapper.Migrations
{
    [Migration(202303230001)]
    public class InitialTables_202303230001 : Migration
    {
        public override void Down()
        {
            Delete.Table("Employee");
            Delete.Table("Company");
        }

        public override void Up()
        {
            Create.Table("Company")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Address").AsString(60).NotNullable()
                .WithColumn("Country").AsString(50).NotNullable();

            Create.Table("Employee")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Age").AsInt32().NotNullable()
                .WithColumn("Position").AsString(50).NotNullable()
                .WithColumn("CompanyId").AsGuid().NotNullable().ForeignKey("Company", "Id");
        }
    }
}
