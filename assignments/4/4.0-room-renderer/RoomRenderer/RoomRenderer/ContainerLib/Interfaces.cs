using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerLib
{
    public interface IRenderable
    {
        int X { get; set; }
        int Y { get; set; }
        char DisplayGlyph { get; set; }
    }

    public interface IContainer
    {
        int X { get; set; }
        int Y { get; set; }
        int Width { get; set; }
        int Height { get; set; }
    }

    public interface IPlaceable : IRenderable
    {
        int Width { get; set; }
        int Height { get; set; }

        List<IRenderable> Locations { get; set; }

        void LocationsPopulater();
        void WipeLocations();
    }

    public interface IAngled : IPlaceable
    {
        int Angle { get; set; }
        char DiagonalGlyphEarly { get; set; }
        char DiagonalGlyphLate { get; set; }
        char VerticalGlyph { get; set; }
    }

    public interface IBorderType
    {
        int ContainerWidth { get; set; }
        int ContainerHeight { get; set; }
        int ContainerOriginX { get; set; }
        int ContainerOriginY { get; set; }

        List<IRenderable> Locations { get; set; }

        void BorderPopulator();
        void WipeBorder();
    }
}
