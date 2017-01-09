using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoledll
{
    class Program
    {
        static void Main(string[] args)
        {
            Reference.Synthesizer synthesizer = new Reference.Synthesizer();
           synthesizer.SayHello();
                
        }
    }
}
