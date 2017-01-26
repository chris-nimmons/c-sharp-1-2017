using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMovement
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameLoop();
            game.Start();
        }
    }
}
