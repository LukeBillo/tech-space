using System;
using CommandLine;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace TechSpace.Data.Migrations
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            var serviceProvider = CreateServices();
            using var scope = serviceProvider.CreateScope();

            Parser.Default
                .ParseArguments<MigrationOptions>(args)
                .WithParsed(options =>
                {
                    switch(options.MigrationMode)
                    {
                        case MigrationMode.Migrate:
                            MigrateDatabase(serviceProvider, options.MigrateToVersion);
                            break;
                        case MigrationMode.Rollback:
                            if (!options.RollbackToVersion.HasValue)
                                return;
                            
                            RollbackDatabase(serviceProvider, options.RollbackToVersion.Value);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    };
                });
        }

        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer2016()
                    .WithGlobalConnectionString("Server=localhost;Database=TechSpace.Web;Trusted_Connection=True;")
                    .ScanIn(typeof(_0001InitialTablesAndRedditSetup).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void MigrateDatabase(IServiceProvider serviceProvider, long version)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }

        private static void RollbackDatabase(IServiceProvider serviceProvider, long version)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateDown(0);
        }
    }
}