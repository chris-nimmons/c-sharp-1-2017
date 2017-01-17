using System.Collections.Generic;
using RoomRenderer;

namespace Managers
{
    public class BorderManager
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public char CornerGlyph { get; set; }
        public char HorizontalGlyph { get; set; }
        public char VerticalGlyph { get; set; }

        public List<IRenderable> Locations { get; set; }

        public BorderManager(int containerWidth,
                             int containerHeight,
                             int containerOriginX,
                             int containerOriginY,
                             char cornerGlyph,
                             char horizontalGlyph,
                             char verticalGlyph)
        {
            Width = containerWidth + 1;
            Height = containerHeight + 1;
            X = containerOriginX - 1;
            Y = containerOriginY - 1;
            CornerGlyph = cornerGlyph;
            HorizontalGlyph = horizontalGlyph;
            VerticalGlyph = verticalGlyph;

            Locations = new List<IRenderable>();
        }

        public List<IRenderable> Populate()
        {
            PopulateHorizontal();
            PopulateVertical();
            PopulateCorners();

            return Locations;
        }

        public void PopulateHorizontal()
        {
            for (int x = X; x < Width + X; x++)
            {
                Locations.Add(new Renderable()
                {
                    X = x,
                    Y = Y,
                    DisplayGlyph = HorizontalGlyph
                });
                Locations.Add(new Renderable()
                {
                    X = x,
                    Y = Y + Height,
                    DisplayGlyph = HorizontalGlyph
                });
            }
        }

        public void PopulateVertical()
        {
            for (int y = Y; y < Height + Y; y++)
            {
                Locations.Add(new Renderable()
                {
                    X = X,
                    Y = y,
                    DisplayGlyph = VerticalGlyph
                });
                Locations.Add(new Renderable()
                {
                    X = X + Width,
                    Y = y,
                    DisplayGlyph = VerticalGlyph
                });
            }
        }

        public void PopulateCorners()
        {
            Locations.Add(new Renderable()
            {
                X = X,
                Y = Y,
                DisplayGlyph = CornerGlyph
            });
            Locations.Add(new Renderable()
            {
                X = X + Width,
                Y = Y,
                DisplayGlyph = CornerGlyph
            });
            Locations.Add(new Renderable()
            {
                X = X,
                Y = Y + Height,
                DisplayGlyph = CornerGlyph
            });
            Locations.Add(new Renderable()
            {
                X = X + Width,
                Y = Y + Height,
                DisplayGlyph = CornerGlyph
            });
        }
    }
}
