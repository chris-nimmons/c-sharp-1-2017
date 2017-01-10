using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Fox;


/*
 Using for, foreach, split and if statements translate what the fox says.  

"wa pow ring ding tchoff pa joff ho hatee tchoffo dingeringeding"

Legend:

like - tchoffo
owe - pow
acorn - pa
and - joff
I - ho
me - Ring 
dont - hatee
a - ding
squirrels - dingeringeding
you - wa
new - tchoff
*/


namespace WhatDoesTheFoxSay
{

    class Program
    {
        static void Main(string[] args)
        {
            FoxSay foxsay = new FoxSay();
            foxsay.FoxTranslate();

        }
    }
}