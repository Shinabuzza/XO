using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp3
{
    class G5x5
    {
        public FieldState5x5[,] Items = new FieldState5x5[5, 5];
        public int CurrentPlayer = 1;
        public bool Winned;

        public void MakeMove(Point p)
        {
            if (Items[p.X, p.Y] != FieldState5x5.Empty)
                return;

            if (Winned)
                return;

            Items[p.X, p.Y] = CurrentPlayer == 0 ? FieldState5x5.Cross : FieldState5x5.Nought;
            if (CheckWinner(FieldState5x5.Cross) || CheckWinner(FieldState5x5.Nought))
            {
                Winned = true;
                return;
            }

            CurrentPlayer ^= 1;
        }

        private bool CheckWinner(FieldState5x5 state)
        {
            for (int i = 0; i < 5; i++)
            {
                if (Items[i, 0] == state && Items[i, 1] == state && Items[i, 2] == state && Items[i, 3] == state && Items[i, 4] == state)
                    return true;
                if (Items[0, i] == state && Items[1, i] == state && Items[2, i] == state && Items[3, i] == state && Items[4, i] == state)
                    return true;

            }

            if (Items[0, 0] == state && Items[1, 1] == state && Items[2, 2] == state && Items[3, 3] == state && Items[4, 4] == state)
                return true;

            if (Items[4, 0] == state && Items[3, 1] == state && Items[2, 2] == state && Items[2, 3] == state && Items[0, 4] == state)
                return true;

            return false;
        }

        public G5x5 Clone()
        {
            return new G5x5 { Items = (FieldState5x5[,])Items.Clone(), CurrentPlayer = CurrentPlayer, Winned = Winned };
        }
    }

    enum FieldState5x5
    {
        Empty,
        Cross,
        Nought
    }
}

