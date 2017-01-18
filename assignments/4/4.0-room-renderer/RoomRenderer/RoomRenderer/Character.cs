using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRenderer
{
    public class Character : IRenderable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char DisplayGlyph { get; set; }

        public Character(int x, int y, char displayGlyph = 'G')
        {
            X = x;
            Y = y;
            DisplayGlyph = displayGlyph;
        }

        public void Up()
        {
            Y--;
        }

        public void Down()
        {
            Y++;
        }

        public void Right()
        {
            X++;
        }

        public void Left()
        {
            X--;
        }
    }
}
