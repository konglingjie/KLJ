using CommonLibrary4.Mapper;
using CommonLibrary4.Mapper.Metadata;

namespace CommonLibrary4.Entity
{
    /// <summary>
    /// 实体信息阐述
    /// </summary>
    public interface IEntityExplain : IEntityFieldAccessor, IEntity, IDbMetaInfo, IMappingTrigger
    {
        /// <summary>
        /// 实体对象
        /// </summary>
        object EntityData { get; }
    }

    /// <summary>
    /// 实体信息阐述
    /// </summary>
    public interface IEntityExplain<T> : IEntityExplain
    {
        /// <summary>
        /// 实体对象
        /// </summary>
        new T EntityData { get; }
    }
}
