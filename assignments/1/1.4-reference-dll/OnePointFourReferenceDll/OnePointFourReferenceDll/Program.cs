using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reference;

namespace OnePointFourReferenceDll
{
    class Program
    {
        static void Main(string[] args)
        {
            Synthesizer synth = new Synthesizer();
            synth.SayHello();
            Console.ReadLine();
        }
    }
}
