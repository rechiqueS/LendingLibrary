namespace LendingLibrary.DbMigrations
{
    public class Tables
    {
        public class Loans
        {
            public const string TABLENAME = "Loans";
            public class Columns
            {
                public const string ID = "Id";
                public const string BORROWER_NAME = "BorrowerName";
                public const string ITEM_DESCRIPTION = "ItemDescription";
            }
        }
    }
}
