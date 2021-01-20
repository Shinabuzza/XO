using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace WindowsFormsApp3
{
    public partial class game5x5 : Form
    {

        private G5x5 game;
        private PictureBox[,] pbs = new PictureBox[5, 5];
        private Image Cross;
        private Image Nought;
        public game5x5()
        {

            InitializeComponent();

            Init();
            game = new G5x5();
            Build(game);
        }
        void Init()
        {
            Nought = Image.FromStream(new WebClient().OpenRead("https://raw.github.com/christkv/tic-tac-toe/master/public/img/cross.png"));
            Cross = Image.FromStream(new WebClient().OpenRead("https://raw.github.com/christkv/tic-tac-toe/master/public/img/circle.png"));

            for (int i = 0; i < 5; i++)

                for (int j = 0; j < 5; j++)
                {
                    pbs[i, j] = new PictureBox { Parent = this, Size = new Size(100, 100), Top = i * 100, Left = j * 100, BorderStyle = BorderStyle.FixedSingle, Tag = new Point(i, j), Cursor = Cursors.Hand, SizeMode = PictureBoxSizeMode.StretchImage };
                    pbs[i, j].Click += pb_Click;
                }


        }
        private void Build(G5x5 game)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    pbs[i, j].Image = game.Items[i, j] == FieldState5x5.Cross ? Cross : (game.Items[i, j] == FieldState5x5.Nought ? Nought : null);
        }
        void pb_Click(object sender, EventArgs e)
        {
            game.MakeMove((Point)(sender as Control).Tag);
            //делаем ответный ход
            if (cbVersusPC.Checked && !game.Winned)
            {
                var m = new AI5x5().GetBestMove(game);
                if (m != null)
                    game.MakeMove(m.P);
            }

            Build(game);

            if (game.Winned)
                MessageBox.Show(string.Format("{0} is winner!", game.CurrentPlayer == 0 ? "Нолики" : "Крестики"));
        }

    }
}
