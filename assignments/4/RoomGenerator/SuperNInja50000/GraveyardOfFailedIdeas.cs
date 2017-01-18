using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNInja50000
{
    class GraveyardOfFailedIdeas
    {
        //Please ignore; these are all ideas that didn't work
        //entoombed here for posterity
    }
}

//public class RoomFactory
//{
//}

/* This is a room generator
{
    public Random random { get; set; }
    public RoomFactory()
    {
        random = new Random();
    }
    public Room Create()
    {

        Room room = new Room()
        {
            Height = random.Next(8, 10),
            Width = random.Next(10, 30),
            Length = random.Next(10, 30),
        };

        return room;
    }
}

{
    public RoomFactory()
    {
        Random random = new Random();


        int totalRows = random.Next(10, 40);
        int totalCols = random.Next(10, 40);
        int currentRow = 0;
        int totalRows2 = random.Next(40, 80);
        int totalCols2 = random.Next(40, 80);
        int startRow2 = random.Next(10, 40);
        int startCol2 = random.Next(10, 40);


        Console.WriteLine("Please press Enter to generate furniture.");

        for (int i = 0; i <= 10; i++)
        {
            if (currentRow <= totalRows)
            {
                for (currentRow = 0; currentRow <= totalRows; currentRow++)
                {
                    for (int currentCol = 0; currentCol <= totalCols; currentCol++)
                    {
                        if (currentRow == 0)
                        {
                            Console.Write('X');
                        }
                        else if (currentCol == 0)
                        {
                            Console.Write("X");
                        }
                        else if (currentRow == totalRows)
                        {
                            Console.Write('X');
                        }
                        else if (currentCol == totalCols)
                        {
                            Console.Write('X');
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
            }
            else if (startRow2 <= totalRows2)
            {
                Console.SetCursorPosition(startRow2, startRow2);
                for (int currentRow2 = startRow2; currentRow2 <= totalRows2; currentRow2++)
                {
                    for (int currentCol2 = startCol2; currentCol2 <= totalCols2; currentCol2++)
                    {
                        if (currentRow2 == startRow2)
                        {
                            Console.Write("X");
                        }
                        else if (currentCol2 == startCol2)
                        {
                            Console.Write("X");
                        }
                        else if (currentRow2 == totalRows2)
                        {
                            Console.Write("X");
                        }
                        else if (currentCol2 == totalCols2)
                        {
                            Console.Write("X");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
            }
            else
            {
                //Console.Write("Elsed");
            }


        }

        Console.ReadLine();
    }

    /*
    for (int row = 0; row <= totalRows; row++)
    {
        for (int col = 0; col <= totalCols; col++)
        {
            if (row == 0)
            {
                Console.Write('X');
            }
            else if (col == 0)
            {
                Console.Write("X");
            }
            else if (row == totalRows)
            {
                Console.Write('X');
            }
            else if (col == totalCols)
            {
                Console.Write('X');
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();

    */
