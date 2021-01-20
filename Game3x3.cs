using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp3
{
    class Game3x3
    {
        public FieldState[,] Items = new FieldState[3, 3];
        public int CurrentPlayer = 0;
        public bool Winned;

        public void MakeMove(Point p)
        {
            if (Items[p.X, p.Y] != FieldState.Empty)
                return;

            if (Winned)
                return;

            Items[p.X, p.Y] = CurrentPlayer == 0 ? FieldState.Cross : FieldState.Nought;
            if (CheckWinner(FieldState.Cross) || CheckWinner(FieldState.Nought))
            {
                Winned = true;
                return;
            }

            CurrentPlayer ^= 1;
        }

        private bool CheckWinner(FieldState state)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Items[i, 0] == state && Items[i, 1] == state && Items[i, 2] == state)
                    return true;
                if (Items[0, i] == state && Items[1, i] == state && Items[2, i] == state)
                    return true;
            }

            if (Items[0, 0] == state && Items[1, 1] == state && Items[2, 2] == state)
                return true;

            if (Items[0, 2] == state && Items[1, 1] == state && Items[2, 0] == state)
                return true;

            return false;
        }

        public Game3x3 Clone()
        {
            return new Game3x3 { Items = (FieldState[,])Items.Clone(), CurrentPlayer = CurrentPlayer, Winned = Winned };
        }
    }

    enum FieldState
    {
        Empty,
        Cross,
        Nought
    }
}
