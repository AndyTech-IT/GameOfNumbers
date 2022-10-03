
namespace GameOfNumbers
{
    partial class Training_Form
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            this.GamesCount_NUD = new System.Windows.Forms.NumericUpDown();
            this.BeginTraining_B = new System.Windows.Forms.Button();
            this.GameRepiats_NUD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.UpcommingGames_L = new System.Windows.Forms.Label();
            this.ScoreBoard_RTB = new System.Windows.Forms.RichTextBox();
            this.AbortTraining_B = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GamesCount_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameRepiats_NUD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(75, 13);
            label1.TabIndex = 1;
            label1.Text = "Parallel games";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(9, 197);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(89, 13);
            label3.TabIndex = 5;
            label3.Text = "Games upcoming";
            // 
            // GamesCount_NUD
            // 
            this.GamesCount_NUD.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.GamesCount_NUD.Location = new System.Drawing.Point(12, 28);
            this.GamesCount_NUD.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.GamesCount_NUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GamesCount_NUD.Name = "GamesCount_NUD";
            this.GamesCount_NUD.Size = new System.Drawing.Size(120, 20);
            this.GamesCount_NUD.TabIndex = 0;
            this.GamesCount_NUD.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // BeginTraining_B
            // 
            this.BeginTraining_B.Location = new System.Drawing.Point(18, 405);
            this.BeginTraining_B.Name = "BeginTraining_B";
            this.BeginTraining_B.Size = new System.Drawing.Size(94, 33);
            this.BeginTraining_B.TabIndex = 2;
            this.BeginTraining_B.Text = "Begin training";
            this.BeginTraining_B.UseVisualStyleBackColor = true;
            this.BeginTraining_B.Click += new System.EventHandler(this.BeginTraining_B_Click);
            // 
            // GameRepiats_NUD
            // 
            this.GameRepiats_NUD.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.GameRepiats_NUD.Location = new System.Drawing.Point(162, 28);
            this.GameRepiats_NUD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.GameRepiats_NUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GameRepiats_NUD.Name = "GameRepiats_NUD";
            this.GameRepiats_NUD.Size = new System.Drawing.Size(120, 20);
            this.GameRepiats_NUD.TabIndex = 3;
            this.GameRepiats_NUD.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Train games count";
            // 
            // UpcommingGames_L
            // 
            this.UpcommingGames_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.UpcommingGames_L.Location = new System.Drawing.Point(12, 221);
            this.UpcommingGames_L.Name = "UpcommingGames_L";
            this.UpcommingGames_L.Size = new System.Drawing.Size(100, 28);
            this.UpcommingGames_L.TabIndex = 6;
            this.UpcommingGames_L.Text = "1";
            this.UpcommingGames_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScoreBoard_RTB
            // 
            this.ScoreBoard_RTB.Dock = System.Windows.Forms.DockStyle.Right;
            this.ScoreBoard_RTB.Location = new System.Drawing.Point(596, 0);
            this.ScoreBoard_RTB.Name = "ScoreBoard_RTB";
            this.ScoreBoard_RTB.Size = new System.Drawing.Size(204, 450);
            this.ScoreBoard_RTB.TabIndex = 7;
            this.ScoreBoard_RTB.Text = "";
            // 
            // AbortTraining_B
            // 
            this.AbortTraining_B.Location = new System.Drawing.Point(138, 405);
            this.AbortTraining_B.Name = "AbortTraining_B";
            this.AbortTraining_B.Size = new System.Drawing.Size(75, 33);
            this.AbortTraining_B.TabIndex = 8;
            this.AbortTraining_B.Text = "Abort";
            this.AbortTraining_B.UseVisualStyleBackColor = true;
            this.AbortTraining_B.Click += new System.EventHandler(this.AbortTraining_B_Click);
            // 
            // Training_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AbortTraining_B);
            this.Controls.Add(this.ScoreBoard_RTB);
            this.Controls.Add(this.UpcommingGames_L);
            this.Controls.Add(label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GameRepiats_NUD);
            this.Controls.Add(this.BeginTraining_B);
            this.Controls.Add(label1);
            this.Controls.Add(this.GamesCount_NUD);
            this.Name = "Training_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Training_Form";
            ((System.ComponentModel.ISupportInitialize)(this.GamesCount_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameRepiats_NUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown GamesCount_NUD;
        private System.Windows.Forms.Button BeginTraining_B;
        private System.Windows.Forms.NumericUpDown GameRepiats_NUD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label UpcommingGames_L;
        private System.Windows.Forms.RichTextBox ScoreBoard_RTB;
        private System.Windows.Forms.Button AbortTraining_B;
    }
}