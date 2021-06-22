using System;
namespace Infrastructure.DatabaseAccess.Queries
{
    public static class LogQuery
    {
        public static readonly string Table = "logs";
        public static readonly string TablePrefix = "lg";
        public static readonly string TableWithPrefix = Table + " " + TablePrefix;

        public static readonly string[] Columns =
        {
            Column.Id,
            Column.LockId,
            Column.UserId,
            Column.TokenId,
            Column.Succcess,
            Column.EntryDate
        };

        public static class Column
        {
            public const string Id = "Id";
            public const string LockId = "LockId";
            public const string UserId = "UserId";
            public const string TokenId = "TokenId";
            public const string Succcess = "Success";
            public const string EntryDate = "EntryDate";
        }

        public static class Parameter
        {
            public const string Id = "@Id";
            public const string LockId = "@LockId";
            public const string UserId = "@UserId";
            public const string TokenId = "@TokenId";
            public const string Succcess = "@Success";
            public const string EntryDate = "@EntryDate";
        }

        public static readonly string BaseQuery = "SELECT {0} FROM " + Table;

        public static readonly string Insert = "INSERT INTO " + Table + " ({0}) VALUES ({1})";
    }
}
