using System.Collections.Generic;
using CommonLibrary4.Weblog;

namespace CommonLibrary4.Weblog.Writer
{
    public interface IWeblogWriter
    {
        void AddParameter(string name, string value);
        string GetParameter(string name);
        void Write(WeblogEntryCollection weblogEntry);
    }
}
