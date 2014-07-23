using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLibrary4.Mapper.Metadata;

namespace CommonLibrary4.Entity
{
    public class DbMetaInfo : MetaInfo, IDbMetaInfo
    {
        #region IDbMetaInfo

        private IDbIncrementMetaPropertyInfo _increment;
        private string[] _keys;

        public string TableName { get { return base.Name; } }

        public IDbIncrementMetaPropertyInfo Increment
        {
            get
            {
                Reorganize();
                return _increment;
            }
        }

        public int KeyCount
        {
            get
            {
                Reorganize();
                return _keys.Length;
            }
        }

        public int ColumnCount { get { return base.PropertyCount; } }

        public bool IsKey(string columnName)
        {
            Reorganize();
            return _keys.Any(x => x == columnName);
        }

        public string[] GetKeys()
        {
            Reorganize();
            var keys = new string[_keys.Length];
            _keys.CopyTo(keys, 0);
            return keys;
        }

        public string[] GetColumnNames()
        {
            return base.GetPropertyNames();
        }

        #endregion

        public DbMetaInfo(string tableName, Type entityType)
            : base(tableName, entityType)
        {
        }

        private object _syncObj = new object();
        private bool isReorganize;
        private void Reorganize()
        {
            if (!isReorganize)
            {
                lock (_syncObj)
                {
                    if (isReorganize)
                    {
                        return;
                    }
                    isReorganize = true;

                    _increment = (DbIncrementMetaPropertyInfo)GetProperties().FirstOrDefault(x => x is DbIncrementMetaPropertyInfo);

                    var keyList = new List<string>();
                    foreach (var property in GetProperties())
                        if (property is DbMetaPropertyInfo && ((DbMetaPropertyInfo)property).IsKey)
                            keyList.Add(((DbMetaPropertyInfo)property).PropertyName);
                    _keys = keyList.ToArray();
                }
            }
        }
    }
}
