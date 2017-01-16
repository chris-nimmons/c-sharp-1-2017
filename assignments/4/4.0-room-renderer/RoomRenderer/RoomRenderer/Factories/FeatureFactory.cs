using System;
using System.Collections.Generic;
using ContainerLib;
using Managers;

namespace Factories
{
    public class FeatureFactory
    {
        public Random Random { get; set; }

        public Room Room { get; set; }

        public List<IRenderable> Locations { get; set; }

        public string[] DefaultOptions { get; set; }

        public FeatureFactory(Room room)
        {
            Room = room;
            Locations = new List<IRenderable>();

            DefaultOptions = new string[]
            {
                "small table",
                "long table",
                "long table vertical",
                "long table diagonal",
                "small chair",
                "long chair",
                "long chair vertical",
                "small chalkboard",
                "small chalkboard diagonal early down",
                "small chalkboard diagonal late down",
                "small chalkboard vertical",
                "long chalkboard",
                "long chalkboard left",
                "long chalkboard diagonal early up",
                "long chalkboard vertical up",
                "long chalkboard diagonal late up",
                "long chalkboard vertical",
                "long chalkboard diagonal early down",
                "long chalkboard diagonal late down"
            };
        }

        public List<IRenderable> NewRoomFeature()
        {
            var pick = Random.Next(0, DefaultOptions.Length);
            return NewRoomFeature(DefaultOptions[pick]);
        }

        public List<IRenderable> NewRoomFeature(string option)
        {
            switch (option.ToLower())
            {
                default:
                case "small table":
                    return DefaultTable(option);
                case "long table":
                    return DefaultTable(option);
                case "long table vertical":
                    return DefaultTable(option);
                case "long table diagonal":
                    return DefaultTable(option);
                case "small chair":
                    return DefaultChair(option);
                case "long chair":
                    return DefaultChair(option);
                case "long chair vertical":
                    return DefaultChair(option);
                case "small chalkboard":
                    return DefaultChalkboard(option);
                case "small chalkboard diagonal early down":
                    return DefaultChalkboard(option);
                case "small chalkboard diagonal late down":
                    return DefaultChalkboard(option);
                case "small chalkboard vertical":
                    return DefaultChalkboard(option);
                case "long chalkboard":
                    return DefaultChalkboard(option);
                case "long chalkboard diagonal early up":
                    return DefaultChalkboard(option);
                case "long chalkboard diagonal late up":
                    return DefaultChalkboard(option);
                case "long chalkboard vertical":
                    return DefaultChalkboard(option);
                case "long chalkboard vertical up":
                    return DefaultChalkboard(option);
                case "long chalkboard left":
                    return DefaultChalkboard(option);
                case "long chalkboard diagonal early down":
                    return DefaultChalkboard(option);
                case "long chalkboard diagonal late down":
                    return DefaultChalkboard(option);

            }
        }

        public List<IRenderable> DefaultChalkboard(string option)
        {
            LocationsManager locationsManager;

            var displayGlyph = '=';
            var earlyGlyph = '\\';
            var lateGlyph = '/';
            var vertGlyph = '|';

            switch (option)
            {
                default:
                case "small chalkboard":
                    locationsManager = new LocationsManager()
                    {
                        X = Random.Next(Room.X, Room.X + Room.Width),
                        Y = Random.Next(Room.Y, Room.Y + Room.Height + 1),
                        Width = 2,
                        Height = 1,
                        Angle = 15,
                        DisplayGlyph = displayGlyph
                    };
                    return locationsManager.Populate();
                case "small chalkboard vertical":
                    locationsManager = new LocationsManager()
                    {
                        X = Random.Next(Room.X, Room.X + Room.Width + 1),
                        Y = Random.Next(Room.Y, Room.Y + Room.Height),
                        Width = 2,
                        Height = 1,
                        Angle = 30,
                        DisplayGlyph = displayGlyph,
                        VerticalGlyph = vertGlyph
                    };
                    return locationsManager.Populate();
                case "small chalkboard diagonal early down":
                    locationsManager = new LocationsManager()
                    {
                        X = Random.Next(Room.X, Room.X + Room.Width),
                        Y = Random.Next(Room.Y, Room.Y + Room.Height),
                        Width = 2,
                        Height = 1,
                        Angle = 25,
                        DisplayGlyph = displayGlyph,
                        DiagonalGlyphEarly = earlyGlyph
                    };
                    return locationsManager.Populate();
                case "small chalkboard diagonal late down":
                    locationsManager = new LocationsManager()
                    {
                        X = Random.Next(Room.X + 1, Room.X + Room.Width + 1),
                        Y = Random.Next(Room.Y, Room.Y + Room.Height),
                        Width = 2,
                        Height = 1,
                        Angle = 35,
                        DisplayGlyph = displayGlyph,
                        DiagonalGlyphLate = lateGlyph
                    };
                    return locationsManager.Populate();
                case "long chalkboard":
                    locationsManager = new LocationsManager()
                    {
                        X = Random.Next(Room.X, Room.X + Room.Width - 2),
                        Y = Random.Next(Room.Y, Room.Y + Room.Height + 1),
                        Width = 4,
                        Height = 1,
                        Angle = 15,
                        DisplayGlyph = displayGlyph
                    };
                    return locationsManager.Populate();
                case "long chalkboard diagonal early down":
                    locationsManager = new LocationsManager()
                    {
                        X = Random.Next(Room.X, Room.X + Room.Width - 2),
                        Y = Random.Next(Room.Y, Room.Y + Room.Height - 2),
                        Width = 4,
                        Height = 1,
                        Angle = 25,
                        DisplayGlyph = displayGlyph,
                        DiagonalGlyphEarly = earlyGlyph
                    };
                    return locationsManager.Populate();
                case "long chalkboard vertical":
                    locationsManager = new LocationsManager()
                    {
                        X = Random.Next(Room.X, Room.X + Room.Width + 1),
                        Y = Random.Next(Room.Y, Room.Y + Room.Height - 2),
                        Width = 4,
                        Height = 1,
                        Angle = 30,
                        DisplayGlyph = displayGlyph,
                        VerticalGlyph = vertGlyph
                    };
                    return locationsManager.Populate();
                case "long chalkboard diagonal late down":
                    locationsManager = new LocationsManager()
                    {
                        X = Random.Next(Room.X + 3, Room.X + Room.Width + 1),
                        Y = Random.Next(Room.Y, Room.Y + Room.Height - 2),
                        Width = 4,
                        Height = 1,
                        Angle = 35,
                        DisplayGlyph = displayGlyph,
                        DiagonalGlyphLate = lateGlyph
                    };
                    return locationsManager.Populate();
                case "long chalkboard left":
                    locationsManager = new LocationsManager()
                    {
                        X = Random.Next(Room.X + 3, Room.X + Room.Width + 1),
                        Y = Random.Next(Room.Y, Room.Y + Room.Height + 1),
                        Width = 4,
                        Height = 1,
                        Angle = 45,
                        DisplayGlyph = displayGlyph
                    };
                    return locationsManager.Populate();
                case "long chalkboard diagonal early up":
                    locationsManager = new LocationsManager()
                    {
                        X = Random.Next(Room.X + 4, Room.X + Room.Width + 1),
                        Y = Random.Next(Room.Y + 3, Room.Y + Room.Height + 1),
                        Width = 4,
                        Height = 1,
                        Angle = 55,
                        DisplayGlyph = displayGlyph,
                        DiagonalGlyphEarly = earlyGlyph
                    };
                    return locationsManager.Populate();
                case "long chalkboard vertical up":
                    locationsManager = new LocationsManager()
                    {
                        X = Random.Next(Room.X, Room.X + Room.Width + 1),
                        Y = Random.Next(Room.Y + 3, Room.Y + Room.Height + 1),
                        Width = 4,
                        Height = 1,
                        Angle = 60,
                        DisplayGlyph = displayGlyph,
                        VerticalGlyph = vertGlyph
                    };
                    return locationsManager.Populate();
                case "long chalkboard diagonal late up":
                    locationsManager = new LocationsManager()
                    {
                        X = Random.Next(Room.X, Room.X + Room.Width - 2),
                        Y = Random.Next(Room.Y + 3, Room.Y + Room.Height + 1),
                        Width = 4,
                        Height = 1,
                        Angle = 5,
                        DisplayGlyph = displayGlyph,
                        DiagonalGlyphLate = lateGlyph
                    };
                    return locationsManager.Populate();
            }
        }

        public List<IRenderable> DefaultChair(string option)
        {
            LocationsManager locationsManager;

            var chairGlyph = 'C';

            switch (option)
            {
                default:
                case "small chair":
                    locationsManager = new LocationsManager()
                    {
                        X = Random.Next(Room.X, Room.X + Room.Width + 1),
                        Y = Random.Next(Room.Y, Room.Y + Room.Height + 1),
                        Width = 1,
                        Height = 1,
                        Angle = 15,
                        DisplayGlyph = chairGlyph
                    };
                    return locationsManager.Populate();
                case "long chair":
                    locationsManager = new LocationsManager()
                    {
                        X = Random.Next(Room.X, Room.X + Room.Width - 1),
                        Y = Random.Next(Room.Y, Room.Y + Room.Height + 1),
                        Width = 3,
                        Height = 1,
                        Angle = 15,
                        DisplayGlyph = chairGlyph
                    };
                    return locationsManager.Populate();
                case "long chair vertical":
                    locationsManager = new LocationsManager()
                    {
                        X = Random.Next(Room.X, Room.X + Room.Width - 1),
                        Y = Random.Next(Room.Y, Room.Y + Room.Height + 1),
                        Width = 3,
                        Height = 1,
                        Angle = 30,
                        DisplayGlyph = chairGlyph,
                        VerticalGlyph = chairGlyph
                    };
                    return locationsManager.Populate();
                case "long chair diagonal":
                    locationsManager = new LocationsManager()
                    {
                        X = Random.Next(Room.X + 2, Room.X + Room.Width + 1),
                        Y = Random.Next(Room.Y, Room.Y + Room.Height - 1),
                        Width = 3,
                        Height = 1,
                        Angle = 35,
                        DisplayGlyph = chairGlyph,
                        DiagonalGlyphLate = chairGlyph
                    };
                    return locationsManager.Populate();
            }
        }

        public List<IRenderable> DefaultTable(string option)
        {
            LocationsManager locationsManager;

            var tableGlyph = 'T';

            switch (option)
            {
                default:
                case "small table":
                    locationsManager = new Managers.LocationsManager()
                    {
                        X = Random.Next(Room.X, Room.X + Room.Width + 1),
                        Y = Random.Next(Room.Y, Room.Y + Room.Height + 1),
                        Width = 1,
                        Height = 1,
                        Angle = 15,
                        DisplayGlyph = tableGlyph
                    };
                    return locationsManager.Populate();
                case "long table":
                    locationsManager = new LocationsManager()
                    {
                        X = Random.Next(Room.X, Room.X + Room.Width - 2),
                        Y = Random.Next(Room.Y, Room.Y + Room.Height),
                        Width = 4,
                        Height = 2,
                        Angle = 15,
                        DisplayGlyph = tableGlyph
                    };
                    return locationsManager.Populate();
                case "long table vertical":
                    locationsManager = new LocationsManager()
                    {
                        X = Random.Next(Room.X + 1, Room.X + Room.Width + 1),
                        Y = Random.Next(Room.Y, Room.Y + Room.Height - 2),
                        Width = 4,
                        Height = 2,
                        Angle = 30,
                        DisplayGlyph = tableGlyph,
                        VerticalGlyph = tableGlyph
                    };
                    return locationsManager.Populate();
                case "long table diagonal":
                    locationsManager = new LocationsManager()
                    {
                        X = Random.Next(Room.X, Room.X + Room.Width - 2),
                        Y = Random.Next(Room.Y, Room.Y + Room.Height - 2),
                        Width = 4,
                        Height = 2,
                        Angle = 25,
                        DisplayGlyph = tableGlyph,
                        DiagonalGlyphEarly = tableGlyph
                    };
                    return locationsManager.Populate();
            }
        }

        public List<IRenderable> NewRoomFeature(int x, int y, int width, int height, int angle, char displayGlyph, char diagonalGlyphEarly = '\\', char diagonalGlyphLate = '/', char verticalGlyph = '|')
        {
            var locationsManager = new LocationsManager()
            {
                X = x,
                Y = y,
                Width = width,
                Height = height,
                Angle = angle,
                DisplayGlyph = displayGlyph,
                DiagonalGlyphEarly = diagonalGlyphEarly,
                DiagonalGlyphLate = diagonalGlyphLate,
                VerticalGlyph = verticalGlyph
            };

            return locationsManager.Populate();
        }

        public List<IRenderable> RandomRoomFeature(char displayGlyph = 'C')
        {
            var width = Random.Next(1, 4);
            var height = Random.Next(1, 4);
            var x = Random.Next(Room.X, Room.X + Room.Width - width);
            var y = Random.Next(Room.Y, Room.Y + Room.Height - width);

            var locationsManager = new LocationsManager()
            {
                X = x,
                Y = y,
                Width = width,
                Height = height,
                DisplayGlyph = displayGlyph,
                Angle = 15
            };

            return locationsManager.Populate();
        }

    }
}
