using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuronewsSelenium
{
    internal class LoggerManager
    {
        public static ILogger GetLoggerInstance() 
        {
            return new TextLogger("D:\\logger.txt");
        }
    }
}
