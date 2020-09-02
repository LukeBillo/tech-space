using FluentMigrator;

namespace TechSpace.Database
{
    [Migration(1, "Sets up initial tables for Reddit")]
    public class _0001InitialTablesAndRedditSetup : Migration
    {
        public override void Up()
        {
            Create.Table("TechnologySpace")
                .WithColumn("Identifier").AsString().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Description").AsString();

            Create.Table("TechnologySpaceFeeds")
                .WithColumn("SpaceIdentifier").AsString().NotNullable()
                .WithColumn("FeedProvider").AsString().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Resource").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("TechnologySpace");
            Delete.Table("TechnologySpaceFeeds");
        }
    }
}