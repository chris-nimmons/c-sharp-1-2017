using System.Collections.Generic;
using Managers;

namespace ContainerLib
{
    public class Border : IBorderType
    {
        public int ContainerWidth { get; set; }
        public int ContainerHeight { get; set; }
        public int ContainerOriginX { get; set; }
        public int ContainerOriginY { get; set; }

        public char CornerGlyph { get; set; }
        public char HorizontalGlyph { get; set; }
        public char VerticalGlyph { get; set; }

        public List<IRenderable> Locations { get; set; }

        public void BorderPopulator()
        {
            WipeBorder();

            var manager = new BorderManager(ContainerWidth,
                                            ContainerHeight,
                                            ContainerOriginX,
                                            ContainerOriginY,
                                            CornerGlyph,
                                            HorizontalGlyph,
                                            VerticalGlyph);

            Locations = manager.Populate();
        }

        public void WipeBorder()
        {
            Locations = new List<IRenderable>();
        }
    }
}
