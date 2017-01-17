using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRenderer
{
    public class BaseFeature
    {
        public int Index { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public char DisplayGlyph { get; set; }

        public List<IRenderable> Locations { get; set; }

        public void Generator()
        {

        }

        public void AdjustX()
        {

        }

        public void AdjustY()
        {

        }

        public void AdjustWidth()
        {

        }

        public void AdjustHeight()
        {

        }
    }

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

        LocationsManager LocationsManager { get; set; }

        void AdjustX(int shiftX);
        void AdjustY(int shiftY);
        void AdjustWidth(int shiftWidth);
        void AdjustHeight(int shiftHeight);
    }

    public interface IAngled : IPlaceable
    {
        char DiagonalGlyphEarly { get; set; }
        char DiagonalGlyphLate { get; set; }
        char VerticalGlyph { get; set; }

        Angle Angle { get; set; }

        void AdjustAngle(Angle angle);
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

    public enum Angle
    {
        HorizontalRight = 0,
        DiagonalDownRight,
        VerticalDown,
        DiagonalDownLeft,
        HorizontalLeft,
        DiagonalUpLeft,
        VerticalUp,
        DiagonalUpRight
    }
}
