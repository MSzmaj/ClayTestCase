namespace Infrastructure.DatabaseAccess.Queries
{
    public static class UserQuery
    {
        public static readonly string Table = "users";
        public static readonly string TablePrefix = "u";
        public static readonly string TableWithPrefix = Table + " " + TablePrefix;

        public static readonly string[] Columns =
        {
            Column.Id,
            Column.FullName,
            Column.UserName,
            Column.Email
        };

        public static class Column
        {
            public const string Id = "Id";
            public const string FullName = "FullName";
            public const string UserName = "UserName";
            public const string Email = "Email";
        }

        public static class Parameter
        {
            public const string Id = "@Id";
            public const string FullName = "@FullName";
            public const string UserName = "@UserName";
            public const string Email = "@Email";
        }

        public static readonly string BaseQuery = "SELECT {0} FROM " + Table;

        public static readonly string Insert = "INSERT INTO " + Table + " ({0}) VALUES ({1})";
    }
}
