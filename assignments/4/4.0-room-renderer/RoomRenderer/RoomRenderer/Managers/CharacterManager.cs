using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRenderer
{
    public class CharacterManager
    {
        public List<IRenderable> AllRenderPoints { get; set; }
        public Character Character { get; set; }

        public CharacterManager(int x, int y, List<IRenderable> allRenderPoints)
        {
            Character = new Character(x, y);
            AllRenderPoints = allRenderPoints;
        }

        public bool CharacterLooper(int key)
        {
            switch (key)
            {
                default:
                    return true;
                case (int)ConsoleKey.UpArrow:
                    if (OkayMovement(key) == WhatsThere.Nothing)
                    {
                        MoveUp();
                    }
                    else if (OkayMovement(key) == WhatsThere.Door)
                    {
                        MoveUp();
                    }
                    return true;
                case (int)ConsoleKey.DownArrow:
                    if (OkayMovement(key) == WhatsThere.Nothing)
                    {
                        MoveDown();
                    }
                    else if (OkayMovement(key) == WhatsThere.Door)
                    {
                        MoveDown();
                    }
                    return true;
                case (int)ConsoleKey.RightArrow:
                    if (OkayMovement(key) == WhatsThere.Nothing)
                    {
                        MoveRight();
                    }
                    else if (OkayMovement(key) == WhatsThere.Door)
                    {
                        MoveRight();
                    }
                    return true;
                case (int)ConsoleKey.LeftArrow:
                    if (OkayMovement(key) == WhatsThere.Nothing)
                    {
                        MoveLeft();
                    }
                    else if (OkayMovement(key) == WhatsThere.Door)
                    {
                        MoveLeft();
                    }
                    return true;
                case (int)ConsoleKey.Escape:
                    return false;
            }
        }

        public void MoveLeft()
        {
            EraseCharacter();
            Character.Left();
            DrawCharacter();
        }

        public void MoveRight()
        {
            EraseCharacter();
            Character.Right();
            DrawCharacter();
        }

        public void MoveUp()
        {
            EraseCharacter();
            Character.Up();
            DrawCharacter();
        }

        public void MoveDown()
        {
            EraseCharacter();
            Character.Down();
            DrawCharacter();
        }

        public void EraseCharacter()
        {
            Console.SetCursorPosition(Character.X, Character.Y);
            Console.Write(' ');
        }

        public void DrawCharacter()
        {
            Console.SetCursorPosition(Character.X, Character.Y);
            Console.Write(Character.DisplayGlyph);
        }

        public WhatsThere OkayMovement(int key)
        {
            switch (key)
            {
                default:
                    return WhatsThere.Nothing;
                case (int)ConsoleKey.UpArrow:
                    return TestUp();
                case (int)ConsoleKey.DownArrow:
                    return TestDown();
                case (int)ConsoleKey.RightArrow:
                    return TestRight();
                case (int)ConsoleKey.LeftArrow:
                    return TestLeft();
            }
        }

        public WhatsThere TestUp()
        {
            foreach (var point in AllRenderPoints)
            {
                if (point.X == Character.X && point.Y == Character.Y - 1)
                {
                    return WhatIsIt(point.DisplayGlyph);
                }
            }
            return WhatsThere.Nothing;
        }

        public WhatsThere TestDown()
        {
            foreach (var point in AllRenderPoints)
            {
                if (point.X == Character.X && point.Y == Character.Y + 1)
                {
                    return WhatIsIt(point.DisplayGlyph);
                }
            }
            return WhatsThere.Nothing;
        }

        public WhatsThere TestRight()
        {
            foreach (var point in AllRenderPoints)
            {
                if (point.X == Character.X + 1 && point.Y == Character.Y)
                {
                    return WhatIsIt(point.DisplayGlyph);
                }
            }
            return WhatsThere.Nothing;
        }

        public WhatsThere TestLeft()
        {
            foreach (var point in AllRenderPoints)
            {
                if (point.X == Character.X - 1 && point.Y == Character.Y)
                {
                    return WhatIsIt(point.DisplayGlyph);
                }
            }
            return WhatsThere.Nothing;
        }

        public WhatsThere WhatIsIt(char glyph)
        {
            switch (glyph)
            {
                default:
                    return WhatsThere.Unknown;
                case 'T':
                case '|':
                case '/':
                case '\\':
                case '=':
                case 'C':
                    return WhatsThere.Feature;
                case 'D':
                    return WhatsThere.Door;
            }
        }

        public enum WhatsThere
        {
            Nothing,
            Unknown,
            Feature,
            Door
        }
    }
}
