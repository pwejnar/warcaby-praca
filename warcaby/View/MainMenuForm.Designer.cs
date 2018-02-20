namespace Checkers
{
    partial class MainMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.MainTable = new System.Windows.Forms.TableLayoutPanel();
            this.closeButton = new System.Windows.Forms.Button();
            this.PlayerRight = new System.Windows.Forms.TableLayoutPanel();
            this.AiTable1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.nickRightValue = new System.Windows.Forms.TextBox();
            this.PawnColor1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.aiRight_checkbox = new System.Windows.Forms.CheckBox();
            this.PlayerLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.aiLeft_checkbox = new System.Windows.Forms.CheckBox();
            this.PawnColor0 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nickLeftValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PlayButton = new System.Windows.Forms.Button();
            this.MainTable.SuspendLayout();
            this.PlayerRight.SuspendLayout();
            this.AiTable1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PawnColor1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.PlayerLeft.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PawnColor0)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTable
            // 
            this.MainTable.BackColor = System.Drawing.Color.Transparent;
            this.MainTable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MainTable.BackgroundImage")));
            this.MainTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MainTable.ColumnCount = 2;
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTable.Controls.Add(this.closeButton, 0, 3);
            this.MainTable.Controls.Add(this.PlayerRight, 0, 1);
            this.MainTable.Controls.Add(this.PlayerLeft, 0, 1);
            this.MainTable.Controls.Add(this.PlayButton, 1, 3);
            this.MainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTable.Location = new System.Drawing.Point(0, 0);
            this.MainTable.Name = "MainTable";
            this.MainTable.RowCount = 3;
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.680017F));
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.49273F));
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.77179F));
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.05546F));
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MainTable.Size = new System.Drawing.Size(859, 527);
            this.MainTable.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.closeButton.Location = new System.Drawing.Point(3, 487);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(152, 26);
            this.closeButton.TabIndex = 10;
            this.closeButton.Text = "Exit";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // PlayerRight
            // 
            this.PlayerRight.BackColor = System.Drawing.Color.Transparent;
            this.PlayerRight.ColumnCount = 2;
            this.PlayerRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.40566F));
            this.PlayerRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.59434F));
            this.PlayerRight.Controls.Add(this.AiTable1, 1, 1);
            this.PlayerRight.Controls.Add(this.PawnColor1, 1, 0);
            this.PlayerRight.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.PlayerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerRight.Location = new System.Drawing.Point(432, 22);
            this.PlayerRight.Name = "PlayerRight";
            this.PlayerRight.RowCount = 2;
            this.PlayerRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PlayerRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PlayerRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.PlayerRight.Size = new System.Drawing.Size(424, 402);
            this.PlayerRight.TabIndex = 6;
            // 
            // AiTable1
            // 
            this.AiTable1.ColumnCount = 1;
            this.AiTable1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AiTable1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.AiTable1.Controls.Add(this.label2, 0, 0);
            this.AiTable1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.AiTable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AiTable1.Location = new System.Drawing.Point(203, 204);
            this.AiTable1.Name = "AiTable1";
            this.AiTable1.RowCount = 2;
            this.AiTable1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AiTable1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AiTable1.Size = new System.Drawing.Size(218, 195);
            this.AiTable1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bodoni MT Poster Compressed", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(50, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 42);
            this.label2.TabIndex = 5;
            this.label2.Text = "Enter nick:";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.nickRightValue, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 100);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(212, 92);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // nickRightValue
            // 
            this.nickRightValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nickRightValue.Location = new System.Drawing.Point(62, 3);
            this.nickRightValue.Name = "nickRightValue";
            this.nickRightValue.Size = new System.Drawing.Size(87, 20);
            this.nickRightValue.TabIndex = 1;
            this.nickRightValue.Text = "Player2";
            // 
            // PawnColor1
            // 
            this.PawnColor1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PawnColor1.BackgroundImage")));
            this.PawnColor1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PawnColor1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PawnColor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PawnColor1.Location = new System.Drawing.Point(203, 3);
            this.PawnColor1.Name = "PawnColor1";
            this.PawnColor1.Size = new System.Drawing.Size(218, 195);
            this.PawnColor1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PawnColor1.TabIndex = 9;
            this.PawnColor1.TabStop = false;
            this.PawnColor1.Click += new System.EventHandler(this.PawnColor1_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.aiRight_checkbox, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 204);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.48718F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.41026F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(194, 195);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // aiRight_checkbox
            // 
            this.aiRight_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aiRight_checkbox.AutoSize = true;
            this.aiRight_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.aiRight_checkbox.Font = new System.Drawing.Font("Bodoni MT Poster Compressed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aiRight_checkbox.ForeColor = System.Drawing.Color.White;
            this.aiRight_checkbox.Location = new System.Drawing.Point(141, 118);
            this.aiRight_checkbox.Name = "aiRight_checkbox";
            this.aiRight_checkbox.Size = new System.Drawing.Size(50, 41);
            this.aiRight_checkbox.TabIndex = 13;
            this.aiRight_checkbox.Text = "Ai";
            this.aiRight_checkbox.UseVisualStyleBackColor = true;
            // 
            // PlayerLeft
            // 
            this.PlayerLeft.BackColor = System.Drawing.Color.Transparent;
            this.PlayerLeft.ColumnCount = 2;
            this.PlayerLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.93617F));
            this.PlayerLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.06383F));
            this.PlayerLeft.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.PlayerLeft.Controls.Add(this.PawnColor0, 0, 0);
            this.PlayerLeft.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.PlayerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerLeft.Location = new System.Drawing.Point(3, 22);
            this.PlayerLeft.Name = "PlayerLeft";
            this.PlayerLeft.RowCount = 2;
            this.PlayerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PlayerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PlayerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.PlayerLeft.Size = new System.Drawing.Size(423, 402);
            this.PlayerLeft.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.aiLeft_checkbox, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(209, 204);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.39914F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.60087F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(194, 165);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // aiLeft_checkbox
            // 
            this.aiLeft_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.aiLeft_checkbox.AutoSize = true;
            this.aiLeft_checkbox.Font = new System.Drawing.Font("Bodoni MT Poster Compressed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aiLeft_checkbox.ForeColor = System.Drawing.Color.White;
            this.aiLeft_checkbox.Location = new System.Drawing.Point(3, 121);
            this.aiLeft_checkbox.Name = "aiLeft_checkbox";
            this.aiLeft_checkbox.Size = new System.Drawing.Size(50, 41);
            this.aiLeft_checkbox.TabIndex = 12;
            this.aiLeft_checkbox.Text = "Ai";
            this.aiLeft_checkbox.UseVisualStyleBackColor = true;
            // 
            // PawnColor0
            // 
            this.PawnColor0.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PawnColor0.BackgroundImage")));
            this.PawnColor0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PawnColor0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PawnColor0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PawnColor0.Location = new System.Drawing.Point(3, 3);
            this.PawnColor0.Name = "PawnColor0";
            this.PawnColor0.Size = new System.Drawing.Size(200, 195);
            this.PawnColor0.TabIndex = 0;
            this.PawnColor0.TabStop = false;
            this.PawnColor0.Click += new System.EventHandler(this.PawnColor0_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.nickLeftValue, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 204);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 195);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // nickLeftValue
            // 
            this.nickLeftValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nickLeftValue.Location = new System.Drawing.Point(56, 100);
            this.nickLeftValue.Name = "nickLeftValue";
            this.nickLeftValue.Size = new System.Drawing.Size(87, 20);
            this.nickLeftValue.TabIndex = 4;
            this.nickLeftValue.Text = "Player1";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bodoni MT Poster Compressed", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(41, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter nick:";
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PlayButton.Location = new System.Drawing.Point(704, 487);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(152, 26);
            this.PlayButton.TabIndex = 9;
            this.PlayButton.Text = "Play!";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click_1);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(859, 527);
            this.Controls.Add(this.MainTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.MainTable.ResumeLayout(false);
            this.PlayerRight.ResumeLayout(false);
            this.AiTable1.ResumeLayout(false);
            this.AiTable1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PawnColor1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.PlayerLeft.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PawnColor0)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTable;
        private System.Windows.Forms.TableLayoutPanel PlayerRight;
        private System.Windows.Forms.TableLayoutPanel AiTable1;
        private System.Windows.Forms.PictureBox PawnColor1;
        private System.Windows.Forms.TableLayoutPanel PlayerLeft;
        private System.Windows.Forms.PictureBox PawnColor0;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox nickRightValue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox nickLeftValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox aiLeft_checkbox;
        private System.Windows.Forms.CheckBox aiRight_checkbox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button PlayButton;
    }
}