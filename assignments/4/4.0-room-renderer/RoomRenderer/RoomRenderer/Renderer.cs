using System;
using RoomRenderer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRenderer
{
    public class Renderer
    {
        public void RenderContainer(Container container)
        {
            foreach (Room room in container.Rooms)
            {
                RenderRoom(room);
            }
        }

        public void RenderRoom(Room room)
        {
            RenderLocations(room.Border.Locations);
            RenderRange(room.BorderOverlay);
            RenderRange(room.RoomFeatures);
            //RenderRoomIndex(room);
        }

        public void RenderRoomIndex(Room room)
        {
            WriteAt(room.X, room.Y, room.Index.ToString().ToCharArray()[0]);
        }

        public void RenderRange(List<IAngled> listOfIAngled)
        {
            foreach (IAngled feature in listOfIAngled)
            {
                RenderLocations(feature.Locations);
            }
        }

        public void RenderRange(List<List<IRenderable>> listOfLocations)
        {
            foreach (List<IRenderable> location in listOfLocations)
            {
                RenderLocations(location);
            }
        }

        public void RenderLocations(List<IRenderable> locations)
        {
            foreach (IRenderable renderable in locations)
            {
                WriteAt(renderable.X, renderable.Y, renderable.DisplayGlyph);
            }
        }

        public void WriteAt(int x, int y, char displayGlyph)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(displayGlyph);
        }

    }
}
