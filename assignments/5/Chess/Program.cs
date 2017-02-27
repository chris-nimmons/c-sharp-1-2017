using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        static void Main()
        {
            Program program = new Program();
            program.Start();

            Console.ReadLine();
        }

        public void Start()
        {
            List<IRenderable> renderables = new List<IRenderable>();
            King king = new King();

            king.X = 0;
            king.Y = 0;
            king.Length = 3;

           renderables.Add(king);


            Pawn pawn = new Pawn();

            pawn.X = 0;
            pawn.Y = 0;
            pawn.Length = 2;

           // renderables.Add(pawn);

            Bishop bishop = new Bishop();

            bishop.X = 10;
            bishop.Y = 10;
            bishop.Length = 10;

            renderables.Add(bishop);

            Castle castle = new Castle();
            castle.X = 10;
            castle.Y = 10;
            castle.Length = 10;

           // renderables.Add(castle);

            Queen queen = new Queen();
            queen.X = 10;
            queen.Y = 10;
            queen.Length = 10;

           // renderables.Add(queen);

            Knight knight = new Knight();
            knight.X = 10;
            knight.Y = 10;
            knight.Length = 10;

            //renderables.Add(knight);


            //var random = new Random();
            //var bpiece = new List<Bishop>();
            //for (int i = 0; i < 10; i++)
            //{
            //    var bishops = new Bishop()
            //    {
            //        X = 2,
            //        Y = 0
            //    };
            //    renderables.Add(bishops);
            //};


            //var cursor = new Cursor();
            //Bishop selection = null;

            //foreach (var bishops in bpiece)
            //{
            //    Console.SetCursorPosition(bishops.X, bishops.Y);
            //    //Console.Write("B");
            //}

            //Console.SetCursorPosition(cursor.X, cursor.Y);
            //bool running = true;
            //while (running)
            //{
            //    var info = Console.ReadKey(true);

            //    switch (info.Key)
            //    {
            //        case ConsoleKey.Escape:
            //            running = false;
            //            break;
            //        case ConsoleKey.UpArrow:
            //            cursor.Y--;
            //            break;

            //        case ConsoleKey.DownArrow:
            //            cursor.Y++;
            //            break;

            //        case ConsoleKey.LeftArrow:
            //            cursor.X--;
            //            break;

            //        case ConsoleKey.RightArrow:
            //            cursor.X++;
            //            break;
            //        case ConsoleKey.Enter:

            //            Bishop highlighted = null;
            //            foreach (var bishops in bpiece)
            //            {
            //                //if the cursor is over a piece
            //                if (cursor.X == bishops.X && cursor.Y == bishops.Y)
            //                {
            //                    highlighted = bishops;
            //                    break;
            //                }
            //            }
            //            if (highlighted != null)
            //            {
            //                if (selection != null)
            //                {
            //                    //if the piece the cursor is over is the same as the selection
            //                    if (highlighted == selection)
            //                    {
            //                        Console.Write("A");
            //                        //deselecting
            //                        selection = null;
            //                    }
            //                    //if the piece the cursor is over is not the same as selection
            //                    else
            //                    {
            //                        //do nothing
            //                    }

            //                }
            //                //if we have a selection
            //                else
            //                {
            //                    //selecting
            //                    selection = highlighted;
            //                    Console.Write(" ");
            //                }

            //            }
            //            //if the cursor is not over a place
            //            else
            //            {
            //                //if there is a piece selected
            //                if (selection != null)
            //                {

            //                    //moving
            //                    Console.Write("C");
            //                    selection.X = cursor.X;
            //                    selection.Y = cursor.Y;

            //                    selection = null;
            //                    break;
            //                }
            //            }
            //            break;
            //    }

            //    if (cursor.X < 0)
            //    {
            //        cursor.X = 0;
            //    }

            //    if (cursor.Y < 0)
            //    {
            //        cursor.Y = 0;
            //    }
            //    Console.SetCursorPosition(cursor.X, cursor.Y);

            //}

            Renderer renderer = new Renderer();
            renderer.Render(renderables);
        }
    }
    public class Renderer
    {
        public void Render(List<IRenderable> renderables)
        {
            foreach (IRenderable renderable in renderables)
            {
                renderable.Render();
            }
        }
    }

    public interface IRenderable
    {
        int X { get; set; }
        int Y { get; set; }
        int Length { get; set; }
        void GetMoves();
        void Render();
    }
}



