using RoomRenderer;

namespace Managers
{
    public class Renderable : IRenderable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char DisplayGlyph { get; set; }
    }
}
