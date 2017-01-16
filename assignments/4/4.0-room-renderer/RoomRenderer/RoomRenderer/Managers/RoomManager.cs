using System;
using System.Collections.Generic;
using ContainerLib;
using Factories;
using Managers;

namespace RoomRenderer
{
    public class RoomManager
    {
        public Random Random { get; set; }

        public Room CreateRoom(List<Room> rooms, List<Tuple<int, int>> ValidRoomCoordinates, char option = 'D')
        {
            var roomFactory = new RoomFactory() { Random = Random };
            //var isUnique = true;
            var overlap = true;
            Room newRoom;

            do
            {
                newRoom = null;
                newRoom = roomFactory.CreateRoom(ValidRoomCoordinates, option);

                if (rooms.Count != 0)
                {
                    foreach (Room room in rooms)
                    {
                        //isUnique = IsUnique(newRoom, room);
                        //isOkaySize = IsOkaySize(newRoom, room);
                        overlap = Overlap(newRoom, room);
                        if (overlap)
                        {
                            break;
                        }
                    }
                }
                else overlap = false;
            } while (overlap);

            return newRoom;
        }

        public List<List<IRenderable>> RandomDefaultFeature(Room room, int quantity = 1)
        {
            List<IRenderable> newFeature;
            var newFeatures = new List<List<IRenderable>>();
            var featureFactory = new FeatureFactory(room) { Random = Random };
            var overlap = true;

            for (int i = 0; i < quantity; i++)
            {
                do
                {
                    newFeature = featureFactory.NewRoomFeature();

                    if (room.RoomFeatures.Count != 0)
                    {
                        foreach (var oldFeature in room.RoomFeatures)
                        {
                            overlap = Overlap(newFeature, oldFeature);
                            if (overlap)
                                break;
                        }
                    }
                    else overlap = false;

                    if (newFeatures.Count != 0)
                    {
                        foreach (var oldFeature in newFeatures)
                        {
                            overlap = Overlap(newFeature, oldFeature);
                            if (overlap)
                                break;
                        }
                    }
                    else overlap = false;

                } while (overlap);

                newFeatures.Add(newFeature);
            }

            return newFeatures;
        }

        public List<List<IRenderable>> NewDefaultFeature(Room room, string option, int quantity = 1)
        {
            var newFeatures = new List<List<IRenderable>>();
            var featureFactory = new FeatureFactory(room) { Random = Random };

            for (int i = 0; i < quantity; i++)
            {
                newFeatures.Add(featureFactory.NewRoomFeature(option));
            }

            return newFeatures;
        }

        public List<List<IRenderable>> NewRandomRoomFeatures(Room room, int quantity, char displayGlyph = 'C')
        {
            var newFeatures = new List<List<IRenderable>>();
            var featureFactory = new FeatureFactory(room) { Random = Random };

            for (int i = 0; i < quantity; i++)
            {
                newFeatures.Add(featureFactory.RandomRoomFeature(displayGlyph));
            }

            return newFeatures;
        }

        public List<List<IRenderable>> NewOverlayFeatures(Room room, int quantity, char displayGlyph = 'W')
        {
            var overlayManager = new OverlayFeatureManager(room);
            List<List<IRenderable>> newFeatures = new List<List<IRenderable>>();

            for (int i = 0; i < quantity; i++)
            {
                newFeatures.Add(RandomOverlayFeature(overlayManager, displayGlyph));
            }

            return newFeatures;
        }

        public List<IRenderable> RandomOverlayFeature(OverlayFeatureManager overlayManager, char displayGlyph = 'W')
        {
            var side = Random.Next(0, 4);
            var width = Random.Next(1, 3);
            var y = Random.Next(overlayManager.Y + 1, overlayManager.Y + overlayManager.Height);
            var x = Random.Next(overlayManager.X + 1, overlayManager.X + overlayManager.Width);

            switch (side)
            {
                default:
                case 0:
                    return overlayManager.NewOverlayFeature(
                        overlayManager.X, y, width, displayGlyph);
                case 1:
                    return overlayManager.NewOverlayFeature(
                        x, overlayManager.Y, width, displayGlyph);
                case 2:
                    return overlayManager.NewOverlayFeature(
                        overlayManager.X + overlayManager.Width, y, width, displayGlyph);
                case 3:
                    return overlayManager.NewOverlayFeature(
                        x, overlayManager.Y + overlayManager.Height, width, displayGlyph);
            }
        }

        public bool Overlap(Room newRoom, Room oldRoom)
        {

            if (newRoom.X + newRoom.Width + 1 < oldRoom.X || oldRoom.X + oldRoom.Width + 1 < newRoom.X)
            {
                return false;
            }

            if (newRoom.Y + newRoom.Height + 1 < oldRoom.Y || oldRoom.Y + oldRoom.Height + 1 < newRoom.Y)
            {
                return false;
            }
            //else if ((newRoom.X + newRoom.Width < oldRoom.X || oldRoom.X + oldRoom.Width < newRoom.X) &&
            //         IsInYRange(newRoom, oldRoom))
            //{
            //    return Tuple.Create(true, 'y');
            //}
            //else if ((newRoom.Y + newRoom.Height < oldRoom.Y || oldRoom.Y + oldRoom.Height < newRoom.Y) &&
            //         IsInXRange(newRoom, oldRoom))
            //{
            //    return Tuple.Create(true, 'x');
            //}
            return true;
        }

        public bool Overlap(List<IRenderable> newFeature, List<IRenderable> oldFeature)
        {
            foreach (var oldCoor in oldFeature)
            {
                foreach (var newCoor in newFeature)
                {
                    if (!IsUnique(newCoor, oldCoor))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsUnique(IRenderable newCoor, IRenderable oldCoor)
        {
            if (oldCoor.X != newCoor.X ||
                oldCoor.Y != newCoor.Y)
                return true;
            else
                return false;
        }

        public bool IsUnique(Room newRoom, Room oldRoom)
        {
            if (oldRoom.X != newRoom.X ||
                oldRoom.Y != oldRoom.Y)
                return true;
            else
                return false;
        }

        public bool IsInXRange(Room newRoom, Room oldRoom)
        {
            if ((newRoom.X >= oldRoom.X && newRoom.X <= oldRoom.X + oldRoom.Width) ||
                (newRoom.X + newRoom.Width >= oldRoom.X && newRoom.X + newRoom.Width <= oldRoom.X + oldRoom.Width))
            {
                return true;
            }
            else return false;
        }

        public bool IsInYRange(Room newRoom, Room oldRoom)
        {
            if ((newRoom.Y >= oldRoom.Y && newRoom.Y <= oldRoom.Y + oldRoom.Height) ||
                (newRoom.Y + newRoom.Height >= oldRoom.Y && newRoom.Y + newRoom.Height <= oldRoom.Y + oldRoom.Height))
            {
                return true;
            }
            else return false;
        }

        public bool IsOkaySize(Room newRoom, Room oldRoom)
        {
            if (IsInXRange(newRoom, oldRoom) && IsInYRange(newRoom, oldRoom))
            {
                return false;
            }
            else return true;
            
            
            //if (((newRoom.X < oldRoom.X) && (newRoom.X + newRoom.Width > oldRoom.X)) ||
            //    ((oldRoom.X < newRoom.X) && (oldRoom.X + oldRoom.Width > newRoom.X)))
            //{
            //    if (((newRoom.Y < oldRoom.Y) && (newRoom.Y + newRoom.Height > oldRoom.Y)) ||
            //        ((newRoom.Y > oldRoom.Y) && (newRoom.Y < oldRoom.Y + oldRoom.Height)))
            //    {
            //        return false;
            //    }
            //}

            //if (((newRoom.Y < oldRoom.Y) && (newRoom.Y + newRoom.Height > oldRoom.Y)) ||
            //    ((oldRoom.Y < newRoom.Y) && (oldRoom.Y + oldRoom.Height > newRoom.Y)))
            //{
            //    if (((newRoom.X < oldRoom.X) && (newRoom.X + newRoom.Width > oldRoom.X)) ||
            //        ((newRoom.X > oldRoom.X) && (newRoom.X < oldRoom.Y + oldRoom.Height)))
            //    {
            //        return false;
            //    }
            //}

            //if ((newRoom.Y == oldRoom.Y) &&
            //    (newRoom.X > oldRoom.X && newRoom.X < oldRoom.X + oldRoom.Width))
            //{
            //    return false;
            //}

            //if ((newRoom.X == oldRoom.X) &&
            //    (newRoom.Y > oldRoom.Y && newRoom.Y < oldRoom.Y + oldRoom.Height))
            //{
            //    return false;
            //}

            //return true;

            //if ((newRoom.Y < oldRoom.Y) &&
            //    (newRoom.X < oldRoom.X + oldRoom.Width) &&
            //    (newRoom.Y + newRoom.Height > oldRoom.Y))
            //{
            //    return false;
            //}

            //if ((newRoom.X < oldRoom.X) &&
            //    (newRoom.Y < oldRoom.Y + oldRoom.Height) &&
            //    (newRoom.X + newRoom.Width > oldRoom.X))
            //{
            //    return false;
            //}

            //if ((newRoom.Y < oldRoom.Y) &&
            //    (oldRoom.X == newRoom.X) &&
            //    (newRoom.Y + newRoom.Height > oldRoom.Y))
            //{
            //    return false;
            //}

            //if ((newRoom.X < oldRoom.X) &&
            //    (oldRoom.Y == newRoom.Y) &&
            //    (newRoom.X + newRoom.Width > oldRoom.X))
            //{
            //    return false;
            //}

            //else return true;

            //if ((newRoom.X + newRoom.Width > oldRoom.X && newRoom.Y == oldRoom.Y) ||
            //    (newRoom.Y + newRoom.Height > oldRoom.Y && newRoom.X == oldRoom.X))
            //    return false;
            //else
            //    return true;
        }
    }
}
