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
        private PawnColor pawnColorLeft;
        private PawnColor pawnColorRight;

        public MainMenuForm()
        {
            InitializeComponent();
            pawnColorLeft = PawnColor.Dark;
            pawnColorRight = PawnColor.Light;
        }

        private void PlayButton_Click_1(object sender, EventArgs e)
        {
            string nickLeft = nickLeftValue.Text;
            string nickRight = nickRightValue.Text;

            if (nickLeft.Length < 3 || nickRight.Length < 3)
            {
                MessageBox.Show("Nick has to be longer than 3 characters.");
                return;
            }

            PlayerGraphical pg0 = new PlayerGraphical(nickLeft, aiLeft_checkbox.Checked, pawnColorLeft, GameDirection.Down);
            PlayerGraphical pg1 = new PlayerGraphical(nickRight, aiRight_checkbox.Checked, pawnColorRight, GameDirection.Up);
            BoardForm board = new BoardForm(pg0, pg1,this);

            this.Hide();
            board.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PawnColor0_Click(object sender, EventArgs e)
        {
            Image tempImage = PawnColor0.BackgroundImage;
            PawnColor0.BackgroundImage = PawnColor1.BackgroundImage;
            PawnColor1.BackgroundImage = tempImage;

            PawnColor tempPawnColor = pawnColorLeft;
            pawnColorLeft = pawnColorRight;
            pawnColorRight = tempPawnColor;
        }

        private void PawnColor1_Click(object sender, EventArgs e)
        {
            PawnColor0_Click(sender, e);
        }
    }
}
