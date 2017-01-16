using ContainerLib;
using System.Collections.Generic;

namespace Managers
{
    public class LocationsManager
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Angle { get; set; }

        public char DisplayGlyph { get; set; }
        public char DiagonalGlyphEarly { get; set; }
        public char DiagonalGlyphLate { get; set; }
        public char VerticalGlyph { get; set; }

        public List<IRenderable> Locations { get; set; }

        public LocationsManager()
        {
            Locations = new List<IRenderable>();
        }

        public List<IRenderable> Populate()
        {
            switch (Angle)
            {
                default:
                case 15:
                    return HorizontalRight();
                case 25:
                    return DiagonalDownRight();
                case 30:
                    return VerticalDown();
                case 35:
                    return DiagonalDownLeft();
                case 45:
                    return HorizontalLeft();
                case 55:
                    return DiagonalUpLeft();
                case 60:
                    return VerticalUp();
                case 5:
                    return DiagonalUpRight();
            }
        }

        public List<IRenderable> HorizontalRight()
        {
            for (int h = 0; h < Height; h++)
            {
                for (int w = 0; w < Width; w++)
                {
                    Locations.Add(new Renderable()
                    {
                        X = X + w,
                        Y = Y + h,
                        DisplayGlyph = DisplayGlyph
                    });
                }
            }

            return Locations;
        }

        public List<IRenderable> DiagonalDownRight()
        {
            for (int w = 0; w < Width; w++)
            {
                for (int h = 0 + w; h < Height + w; h++)
                {
                    Locations.Add(new Renderable()
                    {
                        X = X + h,
                        Y = Y + w,
                        DisplayGlyph = DiagonalGlyphEarly
                    });
                }
            }

            return Locations;
        }

        public List<IRenderable> VerticalDown()
        {
            for (int w = 0; w < Width; w++)
            {
                for (int h = 0; h < Height; h++)
                {
                    Locations.Add(new Renderable()
                    {
                        X = X + h,
                        Y = Y + w,
                        DisplayGlyph = VerticalGlyph
                    });
                }
            }

            return Locations;
        }

        public List<IRenderable> DiagonalDownLeft()
        {
            for (int w = 0; w < Width; w++)
            {
                for (int h = 0 - w; h < Height - w; h++)
                {
                    Locations.Add(new Renderable()
                    {
                        X = X + h,
                        Y = Y + w,
                        DisplayGlyph = DiagonalGlyphLate
                    });
                }
            }

            return Locations;
        }

        public List<IRenderable> HorizontalLeft()
        {
            for (int h = 0; h < Height; h++)
            {
                for (int w = 0; w < Width; w++)
                {
                    Locations.Add(new Renderable()
                    {
                        X = X - w,
                        Y = h + Y,
                        DisplayGlyph = DisplayGlyph
                    });
                }
            }

            return Locations;
        }

        public List<IRenderable> DiagonalUpLeft()
        {
            for (int w = 0; w < Width; w++)
            {
                for (int h = 0 - w - 1; h < Height - w - 1; h++)
                {
                    Locations.Add(new Renderable()
                    {
                        X = X + h,
                        Y = Y - w,
                        DisplayGlyph = DiagonalGlyphEarly
                    });
                }
            }

            return Locations;
        }

        public List<IRenderable> VerticalUp()
        {
            for (int w = 0; w < Width; w++)
            {
                for (int h = 0; h < Height; h++)
                {
                    Locations.Add(new Renderable()
                    {
                        X = X - h,
                        Y = Y - w,
                        DisplayGlyph = VerticalGlyph
                    });
                }
            }

            return Locations;
        }

        public List<IRenderable> DiagonalUpRight()
        {
            for (int w = 0; w < Width; w++)
            {
                for (int h = 0 + w; h < Height + w; h++)
                {
                    Locations.Add(new Renderable()
                    {
                        X = X + h,
                        Y = Y - w,
                        DisplayGlyph = DiagonalGlyphLate
                    });
                }
            }

            return Locations;
        }
    }
}
