using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRenderer
{
    public class Room : IContainer
    {
        public Random Random { get; set; }

        public int Index { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Border Border { get; set; }

        public List<List<IRenderable>> BorderOverlay { get; set; }
        public List<IAngled> RoomFeatures { get; set; }

        public Room(int x,
                    int y,
                    int width,
                    int height,
                    char horizontalGlyph,
                    char verticalGlyph,
                    char cornerGlyph,
                    Random random)
        {
            Random = random;
            X = x;
            Y = y;
            Width = width;
            Height = height;

            Border = new Border()
            {
                ContainerWidth = Width,
                ContainerHeight = Height,
                ContainerOriginX = X,
                ContainerOriginY = Y,
                CornerGlyph = cornerGlyph,
                HorizontalGlyph = horizontalGlyph,
                VerticalGlyph = verticalGlyph
            };

            Border.BorderPopulator();

            BorderOverlay = new List<List<IRenderable>>();
            RoomFeatures = new List<IAngled>();
        }

        public void CleanUpBorder()
        {
            foreach (var feature in BorderOverlay)
            {
                foreach (var point in feature)
                {
                    Border.Locations.RemoveAll(p => p.X == point.X && p.Y == point.Y);
                }
            }
        }
    }
}
