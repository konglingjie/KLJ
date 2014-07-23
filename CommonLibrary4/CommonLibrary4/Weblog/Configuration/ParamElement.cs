﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace CommonLibrary4.Weblog.Configuration
{
    public class ParamElement : ConfigurationElement
    {
        private const string NAME = "name";
        private const string VALUE = "value";

        [ConfigurationProperty(NAME, IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this[NAME]; }
            set { this[NAME] = value; }
        }

        [ConfigurationProperty(VALUE)]
        public string Value
        {
            get { return (string)this[VALUE]; }
            set { this[VALUE] = value; }
        }
    }
}
