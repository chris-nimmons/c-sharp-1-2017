using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {

            Reference.Synthesizer synthesizer = new Reference.Synthesizer();
            string output = synthesizer.SayHello();
        }
    }
}
