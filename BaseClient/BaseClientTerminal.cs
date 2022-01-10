using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClient
{
    public class BaseClientTerminal
    {
        public virtual void HandleResponse(string res)
        {
            Console.WriteLine($"Received responsed for request:\n{res}");
        }
    }
}
