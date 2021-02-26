using CommandLine;

namespace TechSpace.Data.Migrations
{
    public class MigrationOptions
    {
        [Option('m', "migrate", Required = false, HelpText = "Migrate to the provided version.")]
        public long MigrateToVersion { get; set; } = long.MaxValue;
        
        [Option('r', "rollback", Required = false, HelpText = "Rollback to the provided version.")]
        public long? RollbackToVersion { get; set; }

        public MigrationMode MigrationMode => RollbackToVersion.HasValue ? MigrationMode.Rollback : MigrationMode.Migrate;
    }

    public enum MigrationMode
    {
        Migrate,
        Rollback
    }
}