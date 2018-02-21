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
using Checkers.Properties;

namespace Checkers
{
    public partial class BoardForm : Form
    {
        private GameManager gameManager;

        //move to config 
        public static readonly int ControlSize = 60;
        public static readonly Color DarkFieldsColor = Color.FromArgb(90, 00, 00);
        public static readonly Color LightFieldsColor = Color.FromArgb(250, 200, 100);
        private MainMenuForm ParentForm { get; set; }

        public BoardForm(PlayerGraphical pg1, PlayerGraphical pg2, MainMenuForm parentForm)
        {
            InitializeComponent();
            this.ParentForm = parentForm;
            gameManager = new GameManager(this, pg1, pg2);
            UpdateGameInfo();
        }

        public void UpdateGameInfo()
        {
            nick1_lbl.Text = gameManager.Player1.Player.Nick;
            nick2_lbl.Text = gameManager.Player2.Player.Nick;

            PlayerGraphical actualPlayer = gameManager.ActualPlayer;
            nick_value.Text = actualPlayer.Player.Nick;
            pawnCount_value.Text = gameManager.BoardGraphical.SourceBoard.GetPawns(actualPlayer.Player).Count.ToString();
        }

        public void AddToForm(Control control)
        {
            this.Controls.Add(control);
        }
        public void ShowMessage(string content)
        {
            MessageBox.Show(content);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ParentForm.Close();
        }
        
        private void newGame_btn_Click(object sender, EventArgs e)
        {
            gameManager.SetUpGame();
        }

        private void restart_btn_Click(object sender, EventArgs e)
        {
            newGame_btn_Click(sender, e);
        }
    }
}
