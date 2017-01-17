using System;
using System.Collections.Generic;
using Factories;
using RoomRenderer;
using Managers;

namespace RoomRenderer
{
    public class Container
    {
        public Random Random { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Tuple<int, int>> ValidRoomCoordinates { get; set; }
        public int OriginX { get; set; }
        public int OriginY { get; set; }

        public Container(int defaultX = 1,
                         int defaultY = 1)
        {
            OriginX = defaultX;
            OriginY = defaultY;

            Rooms = new List<Room>();
            ValidRoomCoordinates = new List<Tuple<int, int>>();
            NewValidCoordinate(OriginX, OriginY);
        }

        public void AddRoom(char option = 'R')
        {
            var roomManager = new RoomManager() { Random = Random };
            var newRoom = roomManager.CreateRoom(Rooms, ValidRoomCoordinates, option);
            newRoom.BorderOverlay.AddRange(roomManager.NewOverlayFeatures(newRoom, 2, 'W'));
            newRoom.BorderOverlay.AddRange(roomManager.NewOverlayFeatures(newRoom, 2, 'D'));
            //newRoom.RoomFeatures.AddRange(roomManager.NewRandomRoomFeatures(newRoom, 2, 'C'));
            //newRoom.RoomFeatures.AddRange(roomManager.NewRoomFeatures(newRoom, 2, 'T'));
            newRoom.RoomFeatures.AddRange(roomManager.RandomDefaultFeature(newRoom, 3));

            newRoom.Index = Rooms.Count;
            CleanUp(newRoom);

            Rooms.Add(newRoom);
        }

        public void CleanUp(Room newRoom)
        {
            GeneratePossibleCoordinates(newRoom);

            var invalid = new List<Tuple<int, int>>();

            foreach (Tuple<int, int> coordinate in ValidRoomCoordinates)
            {
                if ((coordinate.Item1 > newRoom.X && coordinate.Item1 < newRoom.X + newRoom.Width + 1) &&
                    (coordinate.Item2 > newRoom.Y && coordinate.Item2 < newRoom.Y + newRoom.Height + 1))
                {
                    invalid.Add(coordinate);
                }
            }

            foreach (Tuple<int, int> coordinate in ValidRoomCoordinates)
            {
                if (coordinate.Item1 == newRoom.X &&
                    coordinate.Item2 < newRoom.Y + newRoom.Height)
                {
                    invalid.Add(coordinate);
                }
                else if (coordinate.Item2 == newRoom.Y &&
                         coordinate.Item1 < newRoom.X + newRoom.Width)
                {
                    invalid.Add(coordinate);
                }
            }

            foreach (Tuple<int, int> coordinate in invalid)
            {
                ValidRoomCoordinates.RemoveAll(c => c == coordinate);
            }

            int existingIndex;

            foreach (Room room in Rooms)
            {
                existingIndex = ExistingCoordinateIndex(room);
                if (existingIndex >= 0)
                {
                    ValidRoomCoordinates.RemoveAt(existingIndex);
                }
            }
        }

        public int ExistingCoordinateIndex(Room room)
        {
            return ValidRoomCoordinates.IndexOf(new Tuple<int, int>(room.X, room.Y));
        }

        public int ExistingCoordinateIndex(Tuple<int, int> coordinate)
        {
            return ValidRoomCoordinates.IndexOf(coordinate);
        }

        public void GeneratePossibleCoordinates(Room newRoom)
        {
            NewValidCoordinate(newRoom.X + newRoom.Width + 2,
                               newRoom.Y);
            //NewValidCoordinate(newRoom.X + newRoom.Width + 2,
            //                   newRoom.Y + newRoom.Height + 2);
            NewValidCoordinate(newRoom.X,
                               newRoom.Y + newRoom.Height + 2);
        }

        public void NewValidCoordinate(int x, int y)
        {
            ValidRoomCoordinates.Add(Tuple.Create<int, int>(x, y));
        }
    }
}
