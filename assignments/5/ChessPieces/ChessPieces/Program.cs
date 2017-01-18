using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPieces
{
    class Program
    {
        static void Main(string[] args)
        {
            int startX = 10;
            int startY = 10;
            var program = new Program();
            program.Render(program.QueenMovement(startX, startY), startX, startY);
            program.Render(program.RookMovement(startX, startY), startX, startY);
            program.Render(program.KingMovement(startX, startY), startX, startY);
            program.Render(program.PawnMovement(startX, startY), startX, startY);
            program.Render(program.BishopMovement(startX, startY), startX, startY);
            program.Render(program.KnightMovement(startX, startX), startX, startX);
        }

        public void Render(List<Tuple<int, int>> movements, int originX, int originY)
        {
            Console.Clear();
            foreach (var movement in movements)
            {
                Console.SetCursorPosition(movement.Item1, movement.Item2);
                Console.Write('x');
            }
            Console.SetCursorPosition(originX, originY);
            Console.Write('o');

            Console.ReadKey(true);
        }

        public List<Tuple<int, int>> KnightMovement(int x, int y)
        {
            var possibleMovements = new List<Tuple<int, int>>();
            int z;

            for (int i = 1; i <= 2; i++)
            {
                possibleMovements.Add(Tuple.Create(x + i - 3, y + i));
                possibleMovements.Add(Tuple.Create(x + i - 3, y + i * -1));
                possibleMovements.Add(Tuple.Create(x + i, y + i - 3));
                possibleMovements.Add(Tuple.Create(x + i, y + (i - 3) * -1));
            }

            return possibleMovements;
        }

        public List<Tuple<int, int>> RookMovement(int x, int y)
        {
            var possibleMovements = new List<Tuple<int, int>>();
            possibleMovements.AddRange(UpDown(x, y, x));
            possibleMovements.AddRange(LeftRight(x, y, x));
            return possibleMovements;
        }

        public List<Tuple<int, int>> KingMovement(int x, int y)
        {
            var possibleMovements = new List<Tuple<int, int>>();
            possibleMovements.AddRange(UpDown(x, y, 1));
            possibleMovements.AddRange(LeftRight(x, y, 1));
            possibleMovements.AddRange(DiagonalDown(x, y, 1));
            possibleMovements.AddRange(DiagonalUp(x, y, 1));
            return possibleMovements;
        }

        public List<Tuple<int, int>> QueenMovement(int x, int y)
        {
            var possibleMovements = new List<Tuple<int, int>>();
            possibleMovements.AddRange(LeftRight(x, y, x));
            possibleMovements.AddRange(UpDown(x, y, x));
            possibleMovements.AddRange(DiagonalDown(x, y, x));
            possibleMovements.AddRange(DiagonalUp(x, y, x));
            return possibleMovements;
        }

        public List<Tuple<int, int>> PawnMovement(int x, int y)
        {
            var possibleMovements = new List<Tuple<int, int>>();
            possibleMovements.Add(Tuple.Create(x, y - 1));
            return possibleMovements;
        }

        public List<Tuple<int, int>> BishopMovement(int startX, int startY)
        {
            var possibleMovements = new List<Tuple<int, int>>();
            possibleMovements.AddRange(DiagonalDown(startX, startY, startX));
            possibleMovements.AddRange(DiagonalUp(startX, startX, startX));
            return possibleMovements;
        }

        public List<Tuple<int, int>> LeftRight(int startX, int startY, int range)
        {
            var possibleMovements = new List<Tuple<int, int>>();

            for (int i = 0 - range; i < range + 1; i++)
            {
                possibleMovements.Add(Tuple.Create(startX + i, startY));
            }

            possibleMovements.RemoveAll(p => p.Item1 < 0 || p.Item1 > Console.BufferWidth);
            return possibleMovements;
        }

        public List<Tuple<int, int>> UpDown(int startX, int startY, int range)
        {
            var possibleMovements = new List<Tuple<int, int>>();

            for (int i = 0 - range; i < range + 1; i++)
            {
                possibleMovements.Add(Tuple.Create(startX, startY + i));
            }
            possibleMovements.RemoveAll(p => p.Item2 < 0 || p.Item2 > Console.BufferHeight);

            return possibleMovements;
        }

        public List<Tuple<int, int>> DiagonalDown(int startX, int startY, int range)
        {
            var possibleMovements = new List<Tuple<int, int>>();

            for (int i = 0 - range; i < range + 1; i++)
            {
                possibleMovements.Add(Tuple.Create(startX + i, startY + i));
            }
            possibleMovements.RemoveAll(p => p.Item1 < 0 || p.Item2 < 0 || p.Item1 > Console.BufferWidth || p.Item2 > Console.BufferHeight);

            return possibleMovements;
        }

        public List<Tuple<int, int>> DiagonalUp(int startX, int startY, int range)
        {
            var possibleMovements = new List<Tuple<int, int>>();

            for (int i = 0; i < range + 1; i++)
            {
                possibleMovements.Add(Tuple.Create(startX + i, startY - i));
                possibleMovements.Add(Tuple.Create(startY - i, startY + i));
            }
            possibleMovements.RemoveAll(p => p.Item1 < 0 || p.Item2 < 0 || p.Item1 > Console.BufferWidth || p.Item2 > Console.BufferHeight);

            return possibleMovements;
        }
    }
}
