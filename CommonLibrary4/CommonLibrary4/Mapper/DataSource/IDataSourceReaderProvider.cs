using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary4.Mapper.DataSource
{
    public interface IDataSourceReaderProvider
    {
        bool IsSupported(object dataSource);
        IDataSourceReader CreateReader(object dataSource);
    }
}
