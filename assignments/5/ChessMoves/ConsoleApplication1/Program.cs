using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Pawn pawn = new Pawn();
            King king = new King();
            Queen queen = new Queen();
            Bishop bishop = new Bishop();
            Castle castle = new Castle();
            Knight knight = new Knight();

            knight.Render();
            Console.ReadLine();
            Console.Clear();
            castle.Render();
            Console.ReadLine();
            Console.Clear();
            pawn.Render();
            Console.ReadLine();
            Console.Clear();
            king.Render();
            Console.ReadLine();
            Console.Clear();
            queen.Render();
            Console.ReadLine();
            Console.Clear();
            bishop.Render();
            Console.ReadLine();
        }
    }
}





