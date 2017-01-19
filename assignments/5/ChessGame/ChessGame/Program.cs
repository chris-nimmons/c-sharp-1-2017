using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Program
    {
        class ChessBoard
        {
            public interface IRenderable
            {
                void Render();
            }
            static void Main(string[] args)
            {

            }
            public void Start()
            {
                List<IRenderable> renderables = new List<IRenderable>();
            }
        }

    }
}

