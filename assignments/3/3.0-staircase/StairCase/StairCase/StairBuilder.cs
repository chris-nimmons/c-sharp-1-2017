using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StairCase
{
    class StairBuilder
    {
        public string NextStep(int stepNumber, int totalSteps)
        {
            //blanks = totalSteps - stepNumber
            //"x"s = stepNumber
            
            int blanks = totalSteps - stepNumber;

            return Blanks(blanks) + Exes(stepNumber);

        }

        public string Blanks(int blanks)
        {
            StringBuilder airSpace = new StringBuilder();
            
            for (int i = 0; i < blanks; i++)
            {
                airSpace.Append(" ");
            }
            
            return airSpace.ToString();
        }

        public string Exes(int stepNumber)
        {
            StringBuilder exes = new StringBuilder();

            for (int i = 0; i < stepNumber; i++)
            {
                exes.Append("x");
            }

            return exes.ToString();
        }
    }
}
