using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary4.Mapper
{
    /// <summary>
    /// 数据映射触发接口
    /// </summary>
    public interface IMappingTrigger
    {
        void Begin();
        void End();
    }
}
