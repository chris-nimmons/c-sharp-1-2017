using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        public void Start()
        {
           
            King king = new King();
            king.Render();
            Console.ReadLine();           
            Console.Clear();

            Queen queen = new Queen();
            queen.Render();
            Console.ReadLine();
            Console.Clear();

            Knight knight = new Knight();
            knight.Render();
            Console.ReadLine();
            Console.Clear();

            Pawn pawn = new Pawn();
            pawn.Render();
            Console.ReadLine();           
            Console.Clear();

            Bishop bishop = new Bishop();
            bishop.Render();
            Console.ReadLine();
            Console.Clear();

            Castle castle = new Castle();
            castle.Render();
            Console.ReadLine();
            Console.Clear();

            
           Console.ReadLine();

        }
       
    }

    
}
