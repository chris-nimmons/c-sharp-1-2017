using System;
using System.Collections.Generic;
using RoomRenderer;
using Factories;
using Managers;

namespace RoomRenderer
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Start();
            Console.ReadKey(true);
        }

        public void Start()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            var random = new Random();
            var container = new Container() { Random = random };
            var renderer = new Renderer();

            for (int i = 0; i < 10; i++)
            {
                container.AddRoom();
                //renderer.RenderRoom(container.Rooms[container.Rooms.Count - 1]);
            }

            //var renderer = new Renderer();
            renderer.RenderContainer(container);
        }

        public void TestingBoundaries()
        {
            var validAngles = new Angle[]
            {
                Angle.HorizontalRight,
                Angle.DiagonalDownRight,
                Angle.VerticalDown,
                Angle.DiagonalDownLeft,
                Angle.HorizontalLeft,
                Angle.DiagonalUpLeft,
                Angle.VerticalUp,
                Angle.DiagonalUpRight
            };
            var renderer = new Renderer();
            var random = new Random();
            var container = new Container() { Random = random };
            container.AddRoom('G');
            var factory = new FeatureFactory(container.Rooms[0]) { Random = random };

            while (true) {
                foreach (var angle in validAngles)
                {
                    Console.Clear();
                    container.Rooms[0].RoomFeatures = new List<IAngled>();
                    container.Rooms[0].RoomFeatures.Add(factory.DefaultChalkboard(angle));
                    renderer.RenderRoom(container.Rooms[0]);
                    Console.ReadKey(true);
                } }
        }

        public void TestingAngles()
        {
            var validAngles = new Angle[]
            {
                Angle.HorizontalRight,
                Angle.DiagonalDownRight,
                Angle.VerticalDown,
                Angle.DiagonalDownLeft,
                Angle.HorizontalLeft,
                Angle.DiagonalUpLeft,
                Angle.VerticalUp,
                Angle.DiagonalUpRight
            };
            var renderer = new Renderer();

            foreach (var angle in validAngles)
            {
                Console.Clear();

                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write(i);
                }

                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write(i);
                }

                var manager = new LocationsManager()
                {
                    X = 4,
                    Y = 4,
                    Width = 4,
                    Height = 2,
                    Angle = angle,
                    DisplayGlyph = '-',
                    DiagonalGlyphEarly = '\\',
                    DiagonalGlyphLate = '/',
                    VerticalGlyph = '|'
                };

                renderer.RenderLocations(manager.Populate());
                Console.ReadKey(true);
            }
        }
    }
}
