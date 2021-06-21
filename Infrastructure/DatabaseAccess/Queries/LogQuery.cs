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
            Column.OwnerId
        };

        public static class Column
        {
            public const string Id = "Id";
            public const string OwnerId = "OwnerId";
        }

        public static class Parameter
        {
            public const string Id = "@Id";
            public const string OwnerId = "@OwnerId";
        }

        public static readonly string BaseQuery = "SELECT {0} FROM " + Table;

        public static readonly string Insert = "INSERT INTO " + Table + " ({0}) VALUES ({1})";
    }
}
