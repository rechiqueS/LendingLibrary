using FluentMigrator;
using _Loans = LendingLibraryUsingEntity.DbMigrations.Tables.Loans;

namespace LendingLibraryUsingEntity.DbMigrations.Migrations
{
    [Migration(201602121635)]
    public class Migration_201602121635_AddLoansTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Table(_Loans.TABLENAME)
                .WithColumn(_Loans.Columns.ID).AsInt32().PrimaryKey().Identity()
                .WithColumn(_Loans.Columns.BORROWER_NAME).AsString().NotNullable()
                .WithColumn(_Loans.Columns.ITEM_DESCRIPTION).AsString().NotNullable();
        }
    }
}
