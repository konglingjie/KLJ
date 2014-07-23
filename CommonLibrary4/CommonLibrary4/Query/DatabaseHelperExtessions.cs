using CommonLibrary4.Database;
using CommonLibrary4.Database.SqlBuilder;
using CommonLibrary4.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CommonLibrary4.Query
{
    public static class DatabaseHelperExtessions
    {
        public static Queryable<T> CreateQueryable<T>(this DatabaseHelper database)
        {
            return new Queryable<T>(database);
        }

    }
}
