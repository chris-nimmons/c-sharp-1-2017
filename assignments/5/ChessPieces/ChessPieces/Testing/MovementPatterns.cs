using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPieces.Testing
{
    public class MovementPatterns
    {
        // For testing the basic movement patterns

        public static void DiagonalIterations(int x, int y)
        {
            var upLeft = UpLeftIterations(x, y);

            Console.WriteLine("Up left iteration starting at ({0}, {1})", x, y);
            foreach (var coor in upLeft)
            {
                Console.WriteLine("\t\t({0}, {1})", coor.X, coor.Y);
            }
            Console.ReadKey(true);

            var upRight = UpRightIterations(x, y);

            Console.WriteLine("Up right iteration start at ({0}, {1})", x, y);
            foreach (var coor in upRight)
            {
                Console.WriteLine("\t\t({0}, {1})", coor.X, coor.Y);
            }
            Console.ReadKey(true);

            var downLeft = DownLeftIterations(x, y);

            Console.WriteLine("Down left iteration starting at ({0}, {1})", x, y);
            foreach (var coor in downLeft)
            {
                Console.WriteLine("\t\t({0}, {1})", coor.X, coor.Y);
            }
            Console.ReadKey(true);

            var downRight = DownRightIterations(x, y);

            Console.WriteLine("Down right iteration starting at ({0}, {1})", x, y);
            foreach (var coor in downRight)
            {
                Console.WriteLine("\t\t({0}, {1})", coor.X, coor.Y);
            }

            Console.ReadKey(true);
        }

        public static List<Move> UpLeftIterations(int x, int y)
        {
            var coordinatesChecked = new List<Move>();

            #region Old version
            //if (y <= (int)Limit.Size / 2)
            //{
            //    if (x <= (int)Limit.Size / 2)
            //    {
            //        if (x < y)
            //        {
            //            for (int width = 1; width <= x; width++)
            //            {
            //                coordinatesChecked.Add(new ChessPieces.Move() { X = x - width, Y = y - width });
            //            }
            //        }
            //        else // if (x >= y)
            //        {
            //            for (int height = 1; height <= y; height++)
            //            {
            //                coordinatesChecked.Add(new Move() { X = x - height, Y = y - height });
            //            }
            //        }
            //    }
            //    else // if (x > (int)Limit.Size / 2)
            //    {
            //        for (int height = 1; height <= y; height++)
            //        {
            //            coordinatesChecked.Add(new Move() { X = x - height, Y = y - height });
            //        }
            //    }
            //}
            //else // if (y > (int)Limit.Size / 2)
            //{
            //    if (x < y)
            //    {
            //        for (int width = 1; width <= x; width++)
            //        {
            //            coordinatesChecked.Add(new Move() { X = x - width, Y = y - width });
            //        }
            //    }
            //    else // if (x >= y)
            //    {
            //        for (int height = 1; height <= y; height++)
            //        {
            //            coordinatesChecked.Add(new Move() { X = x - height, Y = y - height });
            //        }
            //    }
            //}
            #endregion

            if (x <= y)
            {
                for (int width = 1; width <= x; width++)
                {
                    coordinatesChecked.Add(new Move() { X = x - width, Y = y - width });
                }
            }
            else
            {
                for (int height = 1; height <= y; height++)
                {
                    coordinatesChecked.Add(new Move() { X = x - height, Y = y - height });
                }
            }

            return coordinatesChecked;
        }

        public static List<Move> UpRightIterations(int x, int y)
        {
            var coordinatesChecked = new List<Move>();

            if (x <= (int)Limit.Size - y)
            {
                for (int height = 1; height <= y; height++)
                {
                    coordinatesChecked.Add(new Move() { X = x + height, Y = y - height });
                }
            }
            else
            {
                for (int width = 1; width <= (int)Limit.Size - x; width++)
                {
                    coordinatesChecked.Add(new Move() { X = x + width, Y = y - width });
                }
            }

            return coordinatesChecked;
        }

        public static List<Move> DownRightIterations(int x, int y)
        {
            var coordinatesChecked = new List<Move>();

            if (x >= y)
            {
                for (int width = 1; width <= (int)Limit.Size - x; width++)
                {
                    coordinatesChecked.Add(new Move() { X = x + width, Y = y + width });
                }
            }
            else
            {
                for (int height = 1; height <= (int)Limit.Size - y; height++)
                {
                    coordinatesChecked.Add(new Move() { X = x + height, Y = y + height });
                }
            }

            return coordinatesChecked;
        }

        public static List<Move> DownLeftIterations(int x, int y)
        {
            var coordinatesChecked = new List<Move>();

            if (x <= (int)Limit.Size - y)
            {
                for (int width = 1; width <= x; width++)
                {
                    coordinatesChecked.Add(new Move() { X = x - width, Y = y + width });
                }
            }
            else
            {
                for (int height = 1; height <= (int)Limit.Size - y; height++)
                {
                    coordinatesChecked.Add(new Move() { X = x - height, Y = y + height });
                }
            }

            return coordinatesChecked;
        }

        public static void HorizAndVertIterations(int x, int y)
        {
            var rightWard = RightWardIterations(x, y);

            Console.WriteLine("Rightward iterations beginning at point ({0}, {1})", x, y);
            foreach (var coor in rightWard)
            {
                Console.WriteLine("\t({0}, {1})", coor.X, coor.Y);
            }
            Console.ReadLine();

            var leftWard = LeftWardIterations(x, y);

            Console.WriteLine("Leftward iterations beginning at point ({0}, {1})", x, y);
            foreach (var coor in leftWard)
            {
                Console.WriteLine("\t({0}, {1})", coor.X, coor.Y);
            }
            Console.ReadLine();

            var upWard = UpWardIterations(x, y);

            Console.WriteLine("Upward iterations beginning at point ({0}, {1})", x, y);
            foreach (var coor in upWard)
            {
                Console.WriteLine("\t({0}, {1})", coor.X, coor.Y);
            }
            Console.ReadLine();

            var downWard = DownWardIterations(x, y);

            Console.WriteLine("Downward iterations beginning at point ({0}, {1})", x, y);
            foreach (var coor in downWard)
            {
                Console.WriteLine("\t({0}, {1})", coor.X, coor.Y);
            }
            Console.ReadLine();
        }

        public static List<Move> RightWardIterations(int x, int y)
        {
            var coordinatesChecked = new List<Move>();

            for (int width = 1; width <= (int)Limit.Size - x; width++)
            {
                coordinatesChecked.Add(new ChessPieces.Move() { X = x + width, Y = y });
            }

            return coordinatesChecked;
        }

        public static List<Move> LeftWardIterations(int x, int y)
        {
            var coordinatesChecked = new List<Move>();

            for (int width = 1; width <= x; width++)
            {
                coordinatesChecked.Add(new ChessPieces.Move() { X = x - width, Y = y });
            }

            return coordinatesChecked;
        }

        public static List<Move> UpWardIterations(int x, int y)
        {
            var coordinatesChecked = new List<Move>();

            for (int height = 1; height <= y; height++)
            {
                coordinatesChecked.Add(new Move() { X = x, Y = y - height });
            }

            return coordinatesChecked;
        }

        public static List<Move> DownWardIterations(int x, int y)
        {
            var coordinatesChecked = new List<Move>();

            for (int height = 1; height <= (int)Limit.Size - y; height++)
            {
                coordinatesChecked.Add(new ChessPieces.Move() { X = x, Y = y + height });
            }

            return coordinatesChecked;
        }
    }
}
