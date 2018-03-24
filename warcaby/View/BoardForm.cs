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
        private DateTime? gameStartedTime;

        //move to config 
        public static readonly int ControlSize = 60;
        public static readonly Color DarkFieldsColor = Color.FromArgb(90, 00, 00);
        public static readonly Color LightFieldsColor = Color.FromArgb(250, 200, 100);
        public MainMenuForm MenuForm { get; }

        public BoardForm(PlayerGraphical pg1, PlayerGraphical pg2, MainMenuForm menuFOrm)
        {
            InitializeComponent();
            this.MenuForm = menuFOrm;
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
            time_value.Text = actualPlayer.TimeLeft.ToString();
        }

        public void StartCountingTime()
        {
            timer1.Enabled = true;
        }

        public void AddToForm(Control control)
        {
            this.Controls.Add(control);
        }
        public void ShowMessage(string content)
        {
            MessageBox.Show(content);
        }
        public void StopTimer()
        {
            timer1.Enabled = false;
            timer1.Stop();
        }

        public void RestrtTimer()
        {
            timer1.Interval = 1000;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuForm.Close();
        }

        private void newGame_btn_Click(object sender, EventArgs e)
        {
            if (gameStartedTime != null)
            {
                TimeSpan timeDifference = (TimeSpan)(DateTime.Now - gameStartedTime);

                if (timeDifference.TotalSeconds < 5)
                {
                    return;
                }
            }

            newGame_btn.Text = "Restart";
            gameManager.SetUpGame();
            gameStartedTime = DateTime.Now;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gameManager.ActualPlayer.TimeLeft = gameManager.ActualPlayer.TimeLeft.Add(new TimeSpan(0, 0, -1));

            if (gameManager.ActualPlayer.TimeLeft <= TimeSpan.Zero)
            {
                gameManager.EndGame();
                return;
            }
            UpdateGameInfo();
        }

        private void backToMenu_btn_Click(object sender, EventArgs e)
        {
            MenuForm.Show();
            this.Hide();
            this.Dispose();
        }

        private void endGame_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

