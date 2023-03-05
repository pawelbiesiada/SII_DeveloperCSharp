using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsole.Exercises.Solutions
{
    internal class AppConfiguration
    {
        public LoggingLevel LogLevel { get; set; }
        public CultureInfo Language { get; set; }

        public AppConfiguration()
        {
            var loglevel = ConfigurationManager.AppSettings["loggingLevel"];
            var codinglanguage = ConfigurationManager.AppSettings["language"];
                        
            Language = new CultureInfo(codinglanguage); 
            LogLevel = (LoggingLevel)Enum.Parse(typeof(LoggingLevel), loglevel, true);
        }
    }

    enum LoggingLevel
    {
        Debug,
        Warning,
        Error
    }
}
