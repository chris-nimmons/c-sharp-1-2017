using System;
using System.Collections.Generic;
using RoomRenderer;
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

        public IAngled NewChalkboard(Room room, Angle angle)
        {
            var width = Random.Next(2, 5);
            var height = 1;
            var x = RandomXFromFeatureSize(room, angle, width, height);
            var y = RandomYFromFeatureSize(room, angle, width, height);
            return new Chalkboard(x, y, width, height, angle);
        }

        public int RandomXFromFeatureSize(Room room, Angle angle, int width, int height)
        {
            switch (angle)
            {
                default:
                case Angle.HorizontalRight:
                    return Random.Next(room.X, room.X + room.Width - (width - 1));
                case Angle.DiagonalDownRight:
                    return Random.Next(room.X, room.X + room.Width - (width - 1) - (height - 1));
                case Angle.VerticalDown:
                    return Random.Next(room.X, room.X + room.Width - (height - 1));
                case Angle.DiagonalDownLeft:
                    return Random.Next(room.X + (width - 1), room.X + room.Width - (height - 1));
                case Angle.HorizontalLeft:
                    return Random.Next(room.X + (width - 1), room.X + room.Width);
                case Angle.DiagonalUpLeft:
                    return Random.Next(room.X + (width - 1) + (height - 1), room.X + room.Width);
                case Angle.VerticalUp:
                    return Random.Next(room.X, room.X + room.Width - (height - 1));
                case Angle.DiagonalUpRight:
                    return Random.Next(room.X, room.X + room.Width - (width - 1) - (height - 1));
            }
        }

        public int RandomYFromFeatureSize(Room room, Angle angle, int width, int height)
        {
            switch (angle)
            {
                default:
                case Angle.HorizontalRight:
                    return Random.Next(room.Y, room.Y + room.Height - (height - 1));
                case Angle.DiagonalDownRight:
                    return Random.Next(room.Y, room.Y + room.Height - (width - 1));
                case Angle.VerticalDown:
                    return Random.Next(room.Y, room.Y + room.Height - (width - 1));
                case Angle.DiagonalDownLeft:
                    return Random.Next(room.Y, room.Y + room.Height - (width - 1));
                case Angle.HorizontalLeft:
                    return Random.Next(room.Y, room.Y + room.Height - (height - 1));
                case Angle.DiagonalUpLeft:
                    return Random.Next(room.Y + (width - 1), room.Y + room.Height);
                case Angle.VerticalUp:
                    return Random.Next(room.Y + (width - 1), room.Y + room.Height);
                case Angle.DiagonalUpRight:
                    return Random.Next(room.Y + (width - 1), room.Y + room.Height);
            }
        }

        public IAngled NewRoomFeature()
        {
            var pick = Random.Next(0, DefaultOptions.Length);
            return NewRoomFeature(DefaultOptions[pick]);
        }

        public IAngled NewRoomFeature(string option)
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

        public Chalkboard DefaultChalkboard(Angle angle)
        {
            int width = 4;
            int height = 1;

            return new Chalkboard
                (
                    RandomXFromFeatureSize(Room, angle, width, height),
                    RandomYFromFeatureSize(Room, angle, width, height),
                    width,
                    height,
                    angle
                );
        }

        public Chalkboard DefaultChalkboard(string option)
        {
            int width;
            int height;
            Angle angle;

            switch (option)
            {
                default:
                case "small chalkboard":
                    width = 2;
                    height = 1;
                    angle = Angle.HorizontalRight;
                    return new Chalkboard
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
                case "small chalkboard vertical":
                    width = 2;
                    height = 1;
                    angle = Angle.VerticalDown;
                    return new Chalkboard
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
                case "small chalkboard diagonal early down":
                    width = 2;
                    height = 1;
                    angle = Angle.DiagonalDownRight;
                    return new Chalkboard
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
                case "small chalkboard diagonal late down":
                    width = 2;
                    height = 1;
                    angle = Angle.DiagonalDownLeft;
                    return new Chalkboard
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
                case "long chalkboard":
                    width = 4;
                    height = 1;
                    angle = Angle.HorizontalRight;
                    return new Chalkboard
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
                case "long chalkboard diagonal early down":
                    width = 4;
                    height = 1;
                    angle = Angle.DiagonalDownRight;
                    return new Chalkboard
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
                case "long chalkboard vertical":
                    width = 4;
                    height = 1;
                    angle = Angle.VerticalDown;
                    return new Chalkboard
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
                case "long chalkboard diagonal late down":
                    width = 4;
                    height = 1;
                    angle = Angle.DiagonalDownLeft;
                    return new Chalkboard
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
                case "long chalkboard left":
                    width = 4;
                    height = 1;
                    angle = Angle.HorizontalLeft;
                    return new Chalkboard
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
                case "long chalkboard diagonal early up":
                    width = 4;
                    height = 1;
                    angle = Angle.DiagonalUpLeft;
                    return new Chalkboard
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
                case "long chalkboard vertical up":
                    width = 4;
                    height = 1;
                    angle = Angle.VerticalUp;
                    return new Chalkboard
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
                case "long chalkboard diagonal late up":
                    width = 4;
                    height = 1;
                    angle = Angle.DiagonalUpRight;
                    return new Chalkboard
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
            }
        }

        public IAngled DefaultChair(string option)
        {
            int width;
            int height;
            Angle angle;

            switch (option)
            {
                default:
                case "small chair":
                    width = 1;
                    height = 1;
                    angle = Angle.HorizontalRight;
                    return new Chair
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
                case "long chair":
                    width = 3;
                    height = 1;
                    angle = Angle.HorizontalRight;
                    return new Chair
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
                case "long chair vertical":
                    width = 3;
                    height = 1;
                    angle = Angle.VerticalUp;
                    return new Chair
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
                case "long chair diagonal":
                    width = 3;
                    height = 1;
                    angle = Angle.DiagonalDownLeft;
                    return new Chair
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
            }
        }

        public IAngled DefaultTable(string option)
        {
            int width;
            int height;
            Angle angle;

            switch (option)
            {
                default:
                case "small table":
                    width = 1;
                    height = 1;
                    angle = Angle.HorizontalRight;
                    return new Table
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
                case "long table":
                    width = 4;
                    height = 2;
                    angle = Angle.HorizontalRight;
                    return new Table
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
                case "long table vertical":
                    width = 4;
                    height = 2;
                    angle = Angle.VerticalDown;
                    return new Table
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
                case "long table diagonal":
                    width = 4;
                    height = 2;
                    angle = Angle.DiagonalDownRight;
                    return new Table
                        (
                            RandomXFromFeatureSize(Room, angle, width, height),
                            RandomYFromFeatureSize(Room, angle, width, height),
                            width,
                            height,
                            angle
                        );
            }
        }

        public IAngled NewRoomFeature(int x, int y, int width, int height, Angle angle, char displayGlyph, char diagonalGlyphEarly = '\\', char diagonalGlyphLate = '/', char verticalGlyph = '|')
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

            return locationsManager.Populate() as IAngled;
        }

        public IAngled RandomRoomFeature(char displayGlyph = 'C')
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
                Angle = Angle.HorizontalRight
            };

            return locationsManager.Populate() as IAngled;
        }

    }
}
