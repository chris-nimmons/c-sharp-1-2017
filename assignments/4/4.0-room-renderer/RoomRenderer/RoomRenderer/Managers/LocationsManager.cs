using RoomRenderer;
using System.Collections.Generic;

namespace Managers
{
    public class LocationsManager
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Angle Angle { get; set; }

        public char DisplayGlyph { get; set; }
        public char DiagonalGlyphEarly { get; set; }
        public char DiagonalGlyphLate { get; set; }
        public char VerticalGlyph { get; set; }

        public List<IRenderable> Locations { get; set; }

        public List<IRenderable> Populate()
        {
            Locations = new List<IRenderable>();
            switch (Angle)
            {
                default:
                case Angle.HorizontalRight:
                    return HorizontalRight();
                case Angle.DiagonalDownRight:
                    return DiagonalDownRight();
                case Angle.VerticalDown:
                    return VerticalDown();
                case Angle.DiagonalDownLeft:
                    return DiagonalDownLeft();
                case Angle.HorizontalLeft:
                    return HorizontalLeft();
                case Angle.DiagonalUpLeft:
                    return DiagonalUpLeft();
                case Angle.VerticalUp:
                    return VerticalUp();
                case Angle.DiagonalUpRight:
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
                for (int h = 0 - w; h < Height - w; h++)
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
