﻿using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRenderer
{
    public class Chalkboard : IAngled
    {
        public char displayGlyph = '=';
        public char diagonalGlyphEarly = '\\';
        public char diagonalGlyphLate = '/';
        public char verticalGlyph = '|';

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
        public LocationsManager LocationsManager { get; set; }

        public Chalkboard(int x,
                          int y,
                          int width,
                          int height,
                          Angle angle = Angle.HorizontalRight)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Angle = angle;

            DisplayGlyph = displayGlyph;
            DiagonalGlyphEarly = diagonalGlyphEarly;
            DiagonalGlyphLate = diagonalGlyphLate;
            VerticalGlyph = verticalGlyph;

            Locations = new List<IRenderable>();
            LocationsManager = new LocationsManager()
            {
                X = X,
                Y = Y,
                Width = Width,
                Height = Height,
                Angle = Angle,
                DisplayGlyph = DisplayGlyph,
                DiagonalGlyphLate = DiagonalGlyphLate,
                DiagonalGlyphEarly = DiagonalGlyphEarly,
                VerticalGlyph = VerticalGlyph
            };

            Locations = LocationsManager.Populate();
        }

        public void AdjustX(int shiftX)
        {
            LocationsManager.X += shiftX;
            Locations = LocationsManager.Populate();
        }

        public void AdjustY(int shiftY)
        {
            LocationsManager.Y += shiftY;
            Locations = LocationsManager.Populate();
        }

        public void AdjustWidth(int shiftWidth)
        {
            LocationsManager.Width += shiftWidth;
            Locations = LocationsManager.Populate();
        }

        public void AdjustHeight(int shiftHeight)
        {
            LocationsManager.Height += shiftHeight;
            Locations = LocationsManager.Populate();
        }

        public void AdjustAngle(Angle angle)
        {
            LocationsManager.Angle = angle;
            Locations = LocationsManager.Populate();
        }
    }
}