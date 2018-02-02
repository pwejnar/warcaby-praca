namespace Checkers
{
    partial class Form1
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
            this.newGame_btn = new System.Windows.Forms.Button();
            this.Player2 = new System.Windows.Forms.Label();
            this.Player1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // newGame_btn
            // 
            this.newGame_btn.Location = new System.Drawing.Point(676, 393);
            this.newGame_btn.Name = "newGame_btn";
            this.newGame_btn.Size = new System.Drawing.Size(75, 23);
            this.newGame_btn.TabIndex = 0;
            this.newGame_btn.Text = "New Game";
            this.newGame_btn.UseVisualStyleBackColor = true;
            this.newGame_btn.Click += new System.EventHandler(this.newGame_btn_Click);
            // 
            // Player2
            // 
            this.Player2.AutoSize = true;
            this.Player2.BackColor = System.Drawing.Color.Transparent;
            this.Player2.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2.ForeColor = System.Drawing.Color.DarkRed;
            this.Player2.Location = new System.Drawing.Point(538, 552);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(88, 25);
            this.Player2.TabIndex = 1;
            this.Player2.Text = "Player2";
            // 
            // Player1
            // 
            this.Player1.AutoSize = true;
            this.Player1.BackColor = System.Drawing.Color.Transparent;
            this.Player1.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1.ForeColor = System.Drawing.Color.DarkRed;
            this.Player1.Location = new System.Drawing.Point(92, 30);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(84, 25);
            this.Player1.TabIndex = 2;
            this.Player1.Text = "Player1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Checkers.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(864, 609);
            this.Controls.Add(this.Player1);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.newGame_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newGame_btn;
        private System.Windows.Forms.Label Player2;
        private System.Windows.Forms.Label Player1;
    }
}

