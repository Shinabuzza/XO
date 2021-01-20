using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp3
{
    class AI3x3
    {
        public Move GetBestMove(Game3x3 game)
        {
            //ищем свободные ячейки
            if (!GetEmptyCells(game).Any())
                return null;//нет свободных ячеек

            //выбираем лучший ход из свободныйх ячеек
            return GetEmptyCells(game).Select(p => GetMoveFitness(game, p)).Max();
        }

        public Move GetMoveFitness(Game3x3 game, Point p)
        {
            var res = new Move() { P = p };
            //имитируем ход
            var g = game.Clone();
            g.MakeMove(p);

            //если выиграли - возвращаем 1
            if (g.Winned)
                res.Fitness = 1f;
            else
            {
                //выбираем лучший вариант для хода противника

                var best = GetBestMove(g);
                if (best != null)
                    res.Fitness = -best.Fitness; //возвращаем худшую для нас оценку
            }

            return res;
        }

        IEnumerable<Point> GetEmptyCells(Game3x3 game)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (game.Items[i, j] == FieldState.Empty)
                        yield return new Point(i, j);
        }


    }

    //ход
    class Move : IComparable<Move>
    {
        //координаты
        public Point P;
        //оценка
        public float Fitness;

        public int CompareTo(Move other)
        {
            var res = Fitness.CompareTo(other.Fitness);
            if (res == 0 && P.X == 1 && P.Y == 1) return 1;//даем преимущество ходу в центр
            return res;
        }
    }
}
