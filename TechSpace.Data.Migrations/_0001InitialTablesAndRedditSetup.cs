using FluentMigrator;

namespace TechSpace.Data.Migrations
{
    [Migration(1, "Sets up initial tables for Reddit")]
    public class _0001InitialTablesAndRedditSetup : Migration
    {
        public override void Up()
        {
            Create.Table("Space")
                .WithColumn("Identifier").AsString().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Description").AsString();

            Create.Table("SpaceFeed")
                .WithColumn("SpaceIdentifier").AsString().NotNullable()
                .WithColumn("FeedProvider").AsString().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Resource").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Space");
            Delete.Table("SpaceFeed");
        }
    }
}