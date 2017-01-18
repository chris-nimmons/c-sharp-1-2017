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

        public bool CharacterLooper(ConsoleKey key)
        {
            switch (key)
            {
                default:
                    return true;
                case ConsoleKey.UpArrow:
                    if (OkayMovement(key) == WhatsThere.Nothing)
                    {
                        MoveUp();
                    }
                    else if (OkayMovement(key) == WhatsThere.Door)
                    {
                        MoveUp();
                    }
                    return true;
                case ConsoleKey.DownArrow:
                    if (OkayMovement(key) == WhatsThere.Nothing)
                    {
                        MoveDown();
                    }
                    else if (OkayMovement(key) == WhatsThere.Door)
                    {
                        MoveDown();
                    }
                    return true;
                case ConsoleKey.RightArrow:
                    if (OkayMovement(key) == WhatsThere.Nothing)
                    {
                        MoveRight();
                    }
                    else if (OkayMovement(key) == WhatsThere.Door)
                    {
                        MoveRight();
                    }
                    return true;
                case ConsoleKey.LeftArrow:
                    if (OkayMovement(key) == WhatsThere.Nothing)
                    {
                        MoveLeft();
                    }
                    else if (OkayMovement(key) == WhatsThere.Door)
                    {
                        MoveLeft();
                    }
                    return true;
                case ConsoleKey.Escape:
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

        public WhatsThere OkayMovement(ConsoleKey key)
        {
            switch (key)
            {
                default:
                    return WhatsThere.Nothing;
                case ConsoleKey.UpArrow:
                    return TestUp();
                case ConsoleKey.DownArrow:
                    return TestDown();
                case ConsoleKey.RightArrow:
                    return TestRight();
                case ConsoleKey.LeftArrow:
                    return TestLeft();
            }
        }

        public WhatsThere TestUp()
        {
            foreach (var point in AllRenderPoints)
            {
                if (IsItVoid(ConsoleKey.UpArrow))
                {
                    return WhatsThere.TheVoid;
                }
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
                if (IsItVoid(ConsoleKey.DownArrow))
                {
                    return WhatsThere.TheVoid;
                }
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
                if (IsItVoid(ConsoleKey.RightArrow))
                {
                    return WhatsThere.TheVoid;
                }
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
                if (IsItVoid(ConsoleKey.LeftArrow))
                {
                    return WhatsThere.TheVoid;
                }
                if (point.X == Character.X - 1 && point.Y == Character.Y)
                {
                    return WhatIsIt(point.DisplayGlyph);
                }
            }
            return WhatsThere.Nothing;
        }

        public bool IsItVoid(ConsoleKey key)
        {
            switch (key)
            {
                default:
                    return false;
                case ConsoleKey.UpArrow:
                    if (Character.Y - 1 < 0)
                    {
                        return true;
                    }
                    return false;
                case ConsoleKey.DownArrow:
                    if (Character.Y + 1 == Console.BufferHeight)
                    {
                        return true;
                    }
                    return false;
                case ConsoleKey.RightArrow:
                    if (Character.X + 1 == Console.BufferWidth)
                    {
                        return true;
                    }
                    return false;
                case ConsoleKey.LeftArrow:
                    if (Character.X - 1 < 0)
                    {
                        return true;
                    }
                    return false;
            }
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
            Door,
            TheVoid
        }
    }
}
