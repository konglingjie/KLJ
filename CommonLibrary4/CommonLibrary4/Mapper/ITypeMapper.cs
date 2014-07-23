using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary4.Mapper
{
    public interface ITypeMapper
    {
        Type DesctinationType { get; }
        object Cast(object value);
    }

    public interface ITypeMapper<TDestination> : ITypeMapper
    {
        new TDestination Cast(object value);
    }
}
