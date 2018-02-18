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

        private void PlayButton_Click_1(object sender, EventArgs e)
        {
            string nickLeft = nickLeftValue.Text;
            string nickRight = nickRightValue.Text;

            if (nickLeft.Length < 3 || nickRight.Length < 3)
            {
                MessageBox.Show("Enter correct values.");
                return;
            }

            PlayerGraphical pg0 = new PlayerGraphical(nickLeft, aiLeft_checkbox.Checked, PawnColor.Dark, GameDirection.Down);
            PlayerGraphical pg1 = new PlayerGraphical(nickRight, aiRight_checkbox.Checked, PawnColor.Light, GameDirection.Up);
            BoardForm board = new BoardForm(pg0, pg1);

            this.Hide();
            board.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
