using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary4.Weblog
{
    public class WeblogEntry
    {
        public string[] Data { get; set; }

        public WeblogEntry()
        {
        }

        public WeblogEntry(string[] data)
        {
            this.Data = data;
        }
    }
}
