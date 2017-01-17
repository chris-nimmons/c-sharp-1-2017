using RoomRenderer;
using System.Collections.Generic;

namespace Managers
{
    public class OverlayFeatureManager
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public List<IRenderable> Locations { get; set; }

        public OverlayFeatureManager(Room room)
        {
            Locations = new List<IRenderable>();
            X = room.X - 1;
            Y = room.Y - 1;
            Width = room.Width + 1;
            Height = room.Height + 1;
        }

        public List<IRenderable> NewOverlayFeature(int x,
                                                  int y,
                                                  int width,
                                                  char displayGlyph)
        {
            if (x == X)
            {
                NewWestOverlayFeature(y, width, displayGlyph);
            }
            else if (y == Y)
            {
                NewNorthOverlayFeature(x, width, displayGlyph);
            }
            else if (x == X + Width)
            {
                NewEastOverlayFeature(y, width, displayGlyph);
            }
            else
            {
                NewSouthOverlayFeature(x, width, displayGlyph);
            }

            return Locations;
        }

        public void NewWestOverlayFeature(int y,
                                          int width,
                                          char displayGlyph)
        {
            for (int w = 0; w < width; w++)
            {
                Locations.Add(new Renderable()
                {
                    X = X,
                    Y = y + w,
                    DisplayGlyph = displayGlyph
                });
            }
        }

        public void NewNorthOverlayFeature(int x,
                                           int width,
                                           char displayGlyph)
        {
            for (int w = 0; w < width; w++)
            {
                Locations.Add(new Renderable()
                {
                    X = x + w,
                    Y = Y,
                    DisplayGlyph = displayGlyph
                });
            }
        }

        public void NewEastOverlayFeature(int y,
                                          int width,
                                          char displayGlyph)
        {
            for (int w = 0; w < width; w++)
            {
                Locations.Add(new Renderable()
                {
                    X = X + Width,
                    Y = y + w,
                    DisplayGlyph = displayGlyph
                });
            }
        }

        public void NewSouthOverlayFeature(int x,
                                           int width,
                                           char displayGlyph)
        {
            for (int w = 0; w < width; w++)
            {
                Locations.Add(new Renderable()
                {
                    X = x + w,
                    Y = Y + Height,
                    DisplayGlyph = displayGlyph
                });
            }
        }
    }
}
