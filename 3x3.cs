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
    public partial class _3x3 : Form
    {
        private Game3x3 game;
        private PictureBox[,] pbs = new PictureBox[3, 3];
        private Image Cross;
        private Image Nought;
        private CheckBox cbVersusPC;
        public _3x3()
        {

            InitializeComponent();

            Init();
            game = new Game3x3();
            Build(game);
        }
        void Init()
        {
            Nought = Image.FromStream(new WebClient().OpenRead("https://raw.github.com/christkv/tic-tac-toe/master/public/img/cross.png"));
            Cross = Image.FromStream(new WebClient().OpenRead("https://raw.github.com/christkv/tic-tac-toe/master/public/img/circle.png"));

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    pbs[i, j] = new PictureBox { Parent = this, Size = new Size(100, 100), Top = i * 100, Left = j * 100, BorderStyle = BorderStyle.FixedSingle, Tag = new Point(i, j), Cursor = Cursors.Hand, SizeMode = PictureBoxSizeMode.StretchImage };
                    pbs[i, j].Click += pb_Click;
                }

            new Button { Parent = this, Top = 320, Text = "Reset" }.Click += delegate { game = new Game3x3(); Build(game); };
            cbVersusPC = new CheckBox { Parent = this, Top = 320, Left = 200, Text = "Versus PC", Checked = true };

        }
        private void Build(Game3x3 game)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    pbs[i, j].Image = game.Items[i, j] == FieldState.Cross ? Cross : (game.Items[i, j] == FieldState.Nought ? Nought : null);
        }
        void pb_Click(object sender, EventArgs e)
        {
            game.MakeMove((Point)(sender as Control).Tag);
            //делаем ответный ход
            if (cbVersusPC.Checked && !game.Winned)
            {
                var m = new AI3x3().GetBestMove(game);
                if (m != null)
                    game.MakeMove(m.P);
            }

            Build(game);

            if (game.Winned)
                MessageBox.Show(string.Format("{0} is winner!", game.CurrentPlayer == 0 ? "Нолики" : "Крестики"));
        }


    }
}
