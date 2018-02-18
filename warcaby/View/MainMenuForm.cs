using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers;

namespace Checkers
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayButton_Click(object sender, EventArgs e)
        {
            PlayerGraphical p0;
            PlayerGraphical p1;
            PlayerGraphical starting;

            string nick0;
            string nick1;

            GameDirection g0Direction;
            GameDirection g1Direction;

            //if (startUp0.Checked)
            //{
            //    g0Direction = GameDirection.Up;
            //    g1Direction = GameDirection.Down;
            //}
            //else
            //{
            //    g0Direction = GameDirection.Down;
            //    g1Direction = GameDirection.Up;
            //}

            //if (Player0Name.Text == "")
            //    nick0 = "Player 1";
            //else
            //    nick0 = Player0Name.Text;

            //if (Player1Name.Text == "")
            //    nick1 = "Player 2";
            //else
            //    nick1 = Player1Name.Text;



            //if (ArtifficialInteligence0.Checked)
            //{
            //    int aiLevel = InteligenceLevel0.Value;
            //    p0 = new PlayerGraphical(new AiPlayer(nick0, g0Direction, aiLevel, Strategy.MaxMax), PawnColor.Dark);
            //}

            //else
            //    p0 = new PlayerGraphical(new Player(nick0, g0Direction), PawnColor.Dark);

            //if (ArtifficialInteligence1.Checked)
            //{
            //    int aiLevel = InteligenceLevel1.Value;
            //    p1 = new PlayerGraphical(new AiPlayer(nick1, g1Direction, aiLevel, Strategy.MaxMax), PawnColor.Light);
            //}

            //else
            //    p1 = new PlayerGraphical(new Player(nick1, g1Direction), PawnColor.Light);


            //if (isBegining0.Checked)
            //    starting = p0;
            //else
            //    starting = p1;

            //Form1 f1 = new Form1(p0, p1);
            //f1.Show();
            //this.Hide();
        }



        private void startUp0_Click(object sender, EventArgs e)
        {
            //if (startUp0.Checked)
            //{
            //    startUp1.Checked = false;
            //    startDown1.Checked = true;
            //}
            //else
            //{
            //    startUp1.Checked = true;
            //    startDown1.Checked = false;
            //}

        }

        private void startDown0_Click(object sender, EventArgs e)
        {
            //if (startDown0.Checked)
            //{
            //    startUp1.Checked = true;
            //    startDown1.Checked = false;
            //}
            //else
            //{
            //    startUp1.Checked = false;
            //    startDown1.Checked = true;
            //}
        }
        private void startUp1_Click(object sender, EventArgs e)
        {
            //if (startUp1.Checked)
            //{
            //    startUp0.Checked = false;
            //    startDown0.Checked = true;
            //}
            //else
            //{
            //    startUp0.Checked = true;
            //    startDown0.Checked = false;
            //}
        }
        private void startDown1_Click(object sender, EventArgs e)
        {
            //if (startDown1.Checked)
            //{
            //    startUp0.Checked = true;
            //    startDown0.Checked = false;
            //}
            //else
            //{
            //    startUp0.Checked = true;
            //    startDown0.Checked = false;
            //}
        }
    }
}
