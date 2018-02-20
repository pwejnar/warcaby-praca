﻿namespace Checkers
{
    partial class BoardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoardForm));
            this.newGame_btn = new System.Windows.Forms.Button();
            this.nick2_lbl = new System.Windows.Forms.Label();
            this.nick1_lbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.nick_lbl = new System.Windows.Forms.Label();
            this.nick_value = new System.Windows.Forms.Label();
            this.pawnCount_value = new System.Windows.Forms.Label();
            this.pawnCount_lbl = new System.Windows.Forms.Label();
            this.time_value = new System.Windows.Forms.Label();
            this.time_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // newGame_btn
            // 
            this.newGame_btn.BackColor = System.Drawing.Color.Transparent;
            this.newGame_btn.Location = new System.Drawing.Point(669, 389);
            this.newGame_btn.Name = "newGame_btn";
            this.newGame_btn.Size = new System.Drawing.Size(98, 23);
            this.newGame_btn.TabIndex = 0;
            this.newGame_btn.Text = "New Game";
            this.newGame_btn.UseVisualStyleBackColor = false;
            this.newGame_btn.Click += new System.EventHandler(this.newGame_btn_Click);
            // 
            // nick2_lbl
            // 
            this.nick2_lbl.AutoSize = true;
            this.nick2_lbl.BackColor = System.Drawing.Color.Transparent;
            this.nick2_lbl.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nick2_lbl.ForeColor = System.Drawing.Color.Black;
            this.nick2_lbl.Location = new System.Drawing.Point(559, 542);
            this.nick2_lbl.Name = "nick2_lbl";
            this.nick2_lbl.Size = new System.Drawing.Size(94, 33);
            this.nick2_lbl.TabIndex = 1;
            this.nick2_lbl.Text = "Player2";
            // 
            // nick1_lbl
            // 
            this.nick1_lbl.AutoSize = true;
            this.nick1_lbl.BackColor = System.Drawing.Color.Transparent;
            this.nick1_lbl.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nick1_lbl.ForeColor = System.Drawing.Color.Black;
            this.nick1_lbl.Location = new System.Drawing.Point(99, 27);
            this.nick1_lbl.Name = "nick1_lbl";
            this.nick1_lbl.Size = new System.Drawing.Size(94, 33);
            this.nick1_lbl.TabIndex = 2;
            this.nick1_lbl.Text = "Player1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(669, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Restart";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // nick_lbl
            // 
            this.nick_lbl.AutoSize = true;
            this.nick_lbl.BackColor = System.Drawing.Color.Transparent;
            this.nick_lbl.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nick_lbl.Location = new System.Drawing.Point(616, 236);
            this.nick_lbl.Name = "nick_lbl";
            this.nick_lbl.Size = new System.Drawing.Size(99, 25);
            this.nick_lbl.TabIndex = 4;
            this.nick_lbl.Text = "Your nick:";
            this.nick_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nick_value
            // 
            this.nick_value.AutoSize = true;
            this.nick_value.BackColor = System.Drawing.Color.Transparent;
            this.nick_value.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nick_value.Location = new System.Drawing.Point(721, 236);
            this.nick_value.Name = "nick_value";
            this.nick_value.Size = new System.Drawing.Size(82, 25);
            this.nick_value.TabIndex = 5;
            this.nick_value.Text = "Kopytko";
            // 
            // pawnCount_value
            // 
            this.pawnCount_value.AutoSize = true;
            this.pawnCount_value.BackColor = System.Drawing.Color.Transparent;
            this.pawnCount_value.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pawnCount_value.Location = new System.Drawing.Point(755, 271);
            this.pawnCount_value.Name = "pawnCount_value";
            this.pawnCount_value.Size = new System.Drawing.Size(32, 25);
            this.pawnCount_value.TabIndex = 7;
            this.pawnCount_value.Text = "12";
            // 
            // pawnCount_lbl
            // 
            this.pawnCount_lbl.AutoSize = true;
            this.pawnCount_lbl.BackColor = System.Drawing.Color.Transparent;
            this.pawnCount_lbl.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pawnCount_lbl.Location = new System.Drawing.Point(621, 271);
            this.pawnCount_lbl.Name = "pawnCount_lbl";
            this.pawnCount_lbl.Size = new System.Drawing.Size(128, 25);
            this.pawnCount_lbl.TabIndex = 6;
            this.pawnCount_lbl.Text = "Pawns count:";
            this.pawnCount_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // time_value
            // 
            this.time_value.AutoSize = true;
            this.time_value.BackColor = System.Drawing.Color.Transparent;
            this.time_value.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.time_value.Location = new System.Drawing.Point(755, 307);
            this.time_value.Name = "time_value";
            this.time_value.Size = new System.Drawing.Size(48, 25);
            this.time_value.TabIndex = 9;
            this.time_value.Text = "0:00";
            // 
            // time_lbl
            // 
            this.time_lbl.AutoSize = true;
            this.time_lbl.BackColor = System.Drawing.Color.Transparent;
            this.time_lbl.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.time_lbl.Location = new System.Drawing.Point(639, 307);
            this.time_lbl.Name = "time_lbl";
            this.time_lbl.Size = new System.Drawing.Size(106, 25);
            this.time_lbl.TabIndex = 8;
            this.time_lbl.Text = "Game time:";
            this.time_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::warcaby.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(864, 609);
            this.Controls.Add(this.time_value);
            this.Controls.Add(this.time_lbl);
            this.Controls.Add(this.pawnCount_value);
            this.Controls.Add(this.pawnCount_lbl);
            this.Controls.Add(this.nick_value);
            this.Controls.Add(this.nick_lbl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nick1_lbl);
            this.Controls.Add(this.nick2_lbl);
            this.Controls.Add(this.newGame_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Board";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newGame_btn;
        private System.Windows.Forms.Label nick2_lbl;
        private System.Windows.Forms.Label nick1_lbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label nick_lbl;
        private System.Windows.Forms.Label nick_value;
        private System.Windows.Forms.Label pawnCount_value;
        private System.Windows.Forms.Label pawnCount_lbl;
        private System.Windows.Forms.Label time_value;
        private System.Windows.Forms.Label time_lbl;
    }
}

