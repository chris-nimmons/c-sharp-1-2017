using System;
using System.Collections.Generic;
using ContainerLib;
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
            var chalkboards = new string[]
            {
                "long chalkboard",
                "long chalkboard diagonal early down",
                "long chalkboard vertical",
                "long chalkboard diagonal late down",
                "long chalkboard left",
                "long chalkboard diagonal early up",
                "long chalkboard vertical up",
                "long chalkboard diagonal late up"
            };
            var renderer = new Renderer();
            LocationsManager manager;
            var random = new Random();
            var container = new Container() { Random = random };
            container.AddRoom('A');
            var factory = new FeatureFactory(container.Rooms[0]) { Random = random };

            while (true) {
                foreach (var chalkboard in chalkboards)
                {
                    Console.Clear();
                    container.Rooms[0].RoomFeatures = new List<List<IRenderable>>();
                    container.Rooms[0].RoomFeatures.Add(factory.DefaultChalkboard(chalkboard));
                    renderer.RenderRoom(container.Rooms[0]);
                    Console.ReadKey(true);
                } }
        }

        public void TestingAngles()
        {
            var validAngles = new int[]
            {
                5, 15, 25, 30, 35, 45, 55, 60
            };
            var renderer = new Renderer();
            LocationsManager manager;

            manager = new LocationsManager()
            {
                X = 4,
                Y = 4,
                Width = 4,
                Height = 2,
                Angle = 55,
                DisplayGlyph = '-',
                DiagonalGlyphEarly = '\\',
                DiagonalGlyphLate = '/',
                VerticalGlyph = '|'
            };

            renderer.RenderLocations(manager.Populate());
            Console.ReadKey(true); 

            foreach (var angle in validAngles)
            {
                Console.Clear();

                manager = new LocationsManager()
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
