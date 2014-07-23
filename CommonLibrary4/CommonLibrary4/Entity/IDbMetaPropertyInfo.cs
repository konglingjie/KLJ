using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary4.Entity
{
    public interface IDbMetaPropertyInfo
    {
        string ColumnName { get; }

        bool IsKey { get; }
    }
}
