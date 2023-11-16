using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuronewsSelenium
{
    internal class TextLogger : ILogger
    {
        string _fileName;
        public TextLogger(string fileName)
        { 
            _fileName = fileName;
        }
        public void LogError(string error)
        {
            using (StreamWriter writer = new StreamWriter(_fileName))
            {
                writer.WriteLine(error);
            }
        }

        public void LogMessage(string message)
            {
            using (StreamWriter writer = new StreamWriter(_fileName,true))
            {
                writer.WriteLine(message);
            }
        }

        public void LogWarning(string warning)
        {
            throw new NotImplementedException();
        }
    }
}
