using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnet_mvc5_sample.Framework
{
    public interface ILogger
    {
        void Log(String s);
    }

    public class Logger : ILogger
    {
        public void Log(string s)
        {
            System.Diagnostics.Trace.WriteLine(s);
        }
    }
}
