using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    public class Node : State
    {
        public Move Move { get; set; }
        private int Points { get; set; }
        public int CurrentDepth { get; set; }

        public Node(int turn, Piece[] pieces, Move move, int currentDepth, int finalDepth, ref int totalCurrentNodes, int threadPoints) : base (turn, pieces)
        {
            Points = threadPoints;
            PopulateBoard();
            CurrentDepth = currentDepth;
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Move, Move>());
            Move = AutoMapper.Mapper.Map<Move, Move>(move);

            if (Move.Takeable)
            {
                var goner = Pieces.FirstOrDefault(p => p.X == Move.X && p.Y == Move.Y && p.ID != Move.ID);
                CalculatePoints(goner);
                goner.Taken = true;
            }

            Pieces.First(p => p.ID == Move.ID).MoveTo(Move.X, Move.Y);

            var renderer = new Renderer(0, 0);
            //Console.Clear();
            //renderer.Render(Pieces);
            //Console.ReadKey(true);

            if (CurrentDepth <= finalDepth)
            {
                BranchNode(CurrentDepth, finalDepth, ref totalCurrentNodes, Points);
                totalCurrentNodes += Nodes.Length;
            }
            else
            {
                //renderer.RenderMoves(GetAllMoves());
                //Console.ReadKey(true);
            }
        }

        public void CalculatePoints(Piece goner)
        {
            switch (goner.Type)
            {
                case PieceType.Pawn:
                    Points += 100;
                    break;
                case PieceType.Rook:
                    Points += 300;
                    break;
                case PieceType.Night:
                    Points += 400;
                    break;
                case PieceType.Bishop:
                    Points += 300;
                    break;
                case PieceType.Queen:
                    Points += 500;
                    break;
                case PieceType.King:
                    Points += 800;
                    break;
            }
        }
    }
}
