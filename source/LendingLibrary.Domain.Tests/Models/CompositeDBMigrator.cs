using System;
using LendingLibraryUsingEntity.DbMigrations;
using PeanutButter.FluentMigrator;
using PeanutButter.TestUtils.Entity;

namespace LendingLibrary.Domain.Tests.Models
{
    public class CompositeDBMigrator : IDBMigrationsRunner
    {
        private bool _logMigrations;
        private MigrationsRunner _migrationsRunner; 

        public CompositeDBMigrator(string connectionString, bool logMigrations)
        {
            _logMigrations = logMigrations;
            _migrationsRunner = new MigrationsRunner(connectionString, LogMigration);
        }

        private void LogMigration(string logMessage)
        {
            if (_logMigrations)
            {
                Console.WriteLine(logMessage);
            }
        }


        public void MigrateToLatest()
        {
            _migrationsRunner.MigrateToLatest();
        }
    }
}