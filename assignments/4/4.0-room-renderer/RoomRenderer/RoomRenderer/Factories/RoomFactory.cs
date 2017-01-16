using ContainerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories
{
    public class RoomFactory
    {
        public Random Random { get; set; }

        public Room CreateRoom(List<Tuple<int, int>> validRoomCoordinates,
                               char option = 'D')
        {
            var newRoomCoordinates = RandomValidCoordinate(validRoomCoordinates);
            var defHoriz = '-';
            var defVert = '|';
            var defCorner = '+';
            switch (option)
            {
                default:
                case 'D':
                    return new Room(newRoomCoordinates.Item1,
                                    newRoomCoordinates.Item2,
                                    10,
                                    5,
                                    defHoriz,
                                    defVert,
                                    defCorner,
                                    Random);
                case 'W':
                    return new Room(newRoomCoordinates.Item1,
                                    newRoomCoordinates.Item2,
                                    20,
                                    5,
                                    defHoriz,
                                    defVert,
                                    defCorner,
                                    Random);
                case 'L':
                    return new Room(newRoomCoordinates.Item1,
                                    newRoomCoordinates.Item2,
                                    10,
                                    20,
                                    defHoriz,
                                    defVert,
                                    defCorner,
                                    Random);
                case 'T':
                    return new Room(newRoomCoordinates.Item1,
                                    newRoomCoordinates.Item2,
                                    30,
                                    15,
                                    defHoriz,
                                    defVert,
                                    defCorner,
                                    Random);
                case 'R':
                    return new Room(newRoomCoordinates.Item1,
                                    newRoomCoordinates.Item2,
                                    Random.Next(10, 31),
                                    Random.Next(10, 31),
                                    'x',
                                    'x',
                                    'x',
                                    Random);
                case 'A':
                    return new Room(newRoomCoordinates.Item1,
                                    newRoomCoordinates.Item2,
                                    5,
                                    5,
                                    defHoriz,
                                    defVert,
                                    defCorner,
                                    Random);
            }
        }

        public Tuple<int, int> RandomValidCoordinate(List<Tuple<int, int>> validRoomCoordinates)
        {
            int i = Random.Next(0, validRoomCoordinates.Count);
            return validRoomCoordinates[i];
        }
    }
}
