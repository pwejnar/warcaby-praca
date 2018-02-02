using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using warcaby;
using warcaby.Properties;

namespace Checkers
{
    public partial class Form1 : Form
    {
        private GameManager gameManager;

        //move to config 
        public static readonly int ControlSize = 60;
        public static readonly Color darkColor = Color.FromArgb(90, 00, 00);
        public static readonly Color lightColor = Color.FromArgb(250, 200, 100);

        public Form1(PlayerGraphical p1, PlayerGraphical p2)
        {
            InitializeComponent();
            gameManager = new GameManager(this, p1, p2);
        }

        public void AddToForm(Control control)
        {
            this.Controls.Add(control);
        }

        private void newGame_btn_Click(object sender, EventArgs e)
        {
            gameManager.SetUpGame();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        public void ShowMessage(string content)
        {
            MessageBox.Show(content);
        }
    }
}
