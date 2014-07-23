using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary4.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDbIncrementMetaPropertyInfo : IDbMetaPropertyInfo
    {
        string IncrementName { get; }

        int StartVal { get; }
    }
}
