using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp3
{
    class AI5x5
    {


        public Move5x5 GetBestMove(G5x5 game)
        {

            if (!GetEmptyCells(game).Any())
                return null;


            return GetEmptyCells(game).Select(p => GetMoveFitness(game, p)).Max();
        }

        public Move5x5 GetMoveFitness(G5x5 game, Point p)
        {
            var res = new Move5x5() { P = p };

            var g = game.Clone();
            g.MakeMove(p);


            if (g.Winned)
                res.Fitness = 1f;
            else
            {

                var best = GetBestMove(g);
                if (best != null)
                    res.Fitness = -best.Fitness;
            }

            return res;
        }

        IEnumerable<Point> GetEmptyCells(G5x5 game)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (game.Items[i, j] == FieldState5x5.Empty)
                        yield return new Point(i, j);


        }
    }


    class Move5x5 : IComparable<Move5x5>
    {

        public Point P;

        public float Fitness;

        public int CompareTo(Move5x5 other)
        {
            var res = Fitness.CompareTo(other.Fitness);
            if (res == 0 && P.X == 2 && P.Y == 2) return 2;
            return res;
        }
    }


}