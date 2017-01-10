using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reference;

namespace ReferenceProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a reference program yo!");
            Console.ReadLine();


            // Added reference.dll under the "Project" tab above
            // Not really sure what to do right now

            Synthesizer synth = new Synthesizer();

            synth.SayHello();



        }
    }
}
