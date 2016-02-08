using System;
using PeanutButter.FluentMigrator;
using PeanutButter.TestUtils.Entity;

namespace LendingLibrary.Domain.Tests.Models
{
    public class CompositeDBMigrator : IDBMigrationsRunner
    {
        private DbSchemaImporter _schemaImporter;
        private bool _logMigrations;
        private MigrationsRunner _migrationsRunner; 

        public CompositeDBMigrator(string connectionString, bool logMigrations)
        {
            throw new NotImplementedException();
        }
    }
}