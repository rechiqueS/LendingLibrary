using System;
using FluentMigrator.Runner.Processors.SqlServer;
using PeanutButter.FluentMigrator;

namespace LendingLibraryUsingEntity.DbMigrations
{
    public class MigrationsRunner: DBMigrationsRunner<SqlServer2000ProcessorFactory>
    {
        private bool logMigrations;

        public MigrationsRunner(string connectionString, Action<string> textWriterAction = null) 
            : base(typeof(MigrationsRunner).Assembly, connectionString, textWriterAction)
        {
        }
    }
}