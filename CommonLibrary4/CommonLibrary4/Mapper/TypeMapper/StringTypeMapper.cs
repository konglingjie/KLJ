﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary4.Mapper.TypeMappers
{
    public class StringTypeMapper : ITypeMapper<String>
    {
        public string Cast(object value)
        {
            return Convert(value);
        }

        public Type DesctinationType
        {
            get { return typeof(string); }
        }

        object ITypeMapper.Cast(object value)
        {
            return Convert(value);
        }

        private string Convert(object value)
        {
            if (value == null)
                return null;

            if (value is string)
                return (string)value;

            return value.ToString();
        }
    }
}
