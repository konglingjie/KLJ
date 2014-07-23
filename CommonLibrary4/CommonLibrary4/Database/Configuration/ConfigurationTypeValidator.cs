using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using CommonLibrary4.Database.SqlBuilder;
using CommonLibrary4.Database.DbCommon;

namespace CommonLibrary4.Database.Configuration
{
    public class ConfigurationISqlBuilderTypeValidator : ConfigurationValidatorBase
    {
        public override bool CanValidate(Type type)
        {
            return type == typeof(Type);
        }
        public override void Validate(object value)
        {
            if (!((Type)value).GetInterfaces().Any(x => x == typeof(ISqlBuilder)))
                throw new ConfigurationErrorsException("type类型未实现接口" + typeof(ISqlBuilder).FullName);
        }
    }
    public class ConfigurationDatabaseHelperTypeValidator : ConfigurationValidatorBase
    {
        public override bool CanValidate(Type type)
        {
            return type == typeof(Type);
        }
        public override void Validate(object value)
        {
            if (!((Type)value).GetInterfaces().Any(x => x == typeof(DatabaseHelper)))
                throw new ConfigurationErrorsException("type类型未继承" + typeof(DatabaseHelper).FullName);
        }
    }
}
