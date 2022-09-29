
namespace GameOfNumbers
{
    partial class Game_Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
            this.NewGame_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.RestartGame_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Card1 = new System.Windows.Forms.Label();
            this.Card2 = new System.Windows.Forms.Label();
            this.Card3 = new System.Windows.Forms.Label();
            this.Card4 = new System.Windows.Forms.Label();
            this.Name_Label1 = new System.Windows.Forms.Label();
            this.Name_Label2 = new System.Windows.Forms.Label();
            this.Name_Label3 = new System.Windows.Forms.Label();
            this.Name_Label4 = new System.Windows.Forms.Label();
            this.Score_Label1 = new System.Windows.Forms.Label();
            this.Score_Label2 = new System.Windows.Forms.Label();
            this.Score_Label3 = new System.Windows.Forms.Label();
            this.Score_Label4 = new System.Windows.Forms.Label();
            this.Round_Label = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGame_TSMI,
            this.RestartGame_TSMI});
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            gameToolStripMenuItem.Text = "Game";
            // 
            // NewGame_TSMI
            // 
            this.NewGame_TSMI.Name = "NewGame_TSMI";
            this.NewGame_TSMI.Size = new System.Drawing.Size(180, 22);
            this.NewGame_TSMI.Text = "New...";
            this.NewGame_TSMI.Click += new System.EventHandler(this.NewGame_TSMI_Click);
            // 
            // RestartGame_TSMI
            // 
            this.RestartGame_TSMI.Name = "RestartGame_TSMI";
            this.RestartGame_TSMI.Size = new System.Drawing.Size(180, 22);
            this.RestartGame_TSMI.Text = "Restart";
            this.RestartGame_TSMI.Click += new System.EventHandler(this.RestartGame_TSMI_Click);
            // 
            // Card1
            // 
            this.Card1.BackColor = System.Drawing.Color.White;
            this.Card1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Card1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Card1.Location = new System.Drawing.Point(120, 203);
            this.Card1.Name = "Card1";
            this.Card1.Size = new System.Drawing.Size(100, 150);
            this.Card1.TabIndex = 0;
            this.Card1.Text = "10";
            this.Card1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Card2
            // 
            this.Card2.BackColor = System.Drawing.Color.White;
            this.Card2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Card2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Card2.Location = new System.Drawing.Point(272, 203);
            this.Card2.Name = "Card2";
            this.Card2.Size = new System.Drawing.Size(100, 150);
            this.Card2.TabIndex = 1;
            this.Card2.Text = "10";
            this.Card2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Card3
            // 
            this.Card3.BackColor = System.Drawing.Color.White;
            this.Card3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Card3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Card3.Location = new System.Drawing.Point(424, 203);
            this.Card3.Name = "Card3";
            this.Card3.Size = new System.Drawing.Size(100, 150);
            this.Card3.TabIndex = 2;
            this.Card3.Text = "10";
            this.Card3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Card4
            // 
            this.Card4.BackColor = System.Drawing.Color.White;
            this.Card4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Card4.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Card4.Location = new System.Drawing.Point(576, 203);
            this.Card4.Name = "Card4";
            this.Card4.Size = new System.Drawing.Size(100, 150);
            this.Card4.TabIndex = 3;
            this.Card4.Text = "10";
            this.Card4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Name_Label1
            // 
            this.Name_Label1.Location = new System.Drawing.Point(120, 167);
            this.Name_Label1.Name = "Name_Label1";
            this.Name_Label1.Size = new System.Drawing.Size(100, 23);
            this.Name_Label1.TabIndex = 4;
            this.Name_Label1.Text = "Name";
            this.Name_Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Name_Label2
            // 
            this.Name_Label2.Location = new System.Drawing.Point(272, 167);
            this.Name_Label2.Name = "Name_Label2";
            this.Name_Label2.Size = new System.Drawing.Size(100, 23);
            this.Name_Label2.TabIndex = 5;
            this.Name_Label2.Text = "Name";
            this.Name_Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Name_Label3
            // 
            this.Name_Label3.Location = new System.Drawing.Point(424, 167);
            this.Name_Label3.Name = "Name_Label3";
            this.Name_Label3.Size = new System.Drawing.Size(100, 23);
            this.Name_Label3.TabIndex = 6;
            this.Name_Label3.Text = "Name";
            this.Name_Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Name_Label4
            // 
            this.Name_Label4.Location = new System.Drawing.Point(576, 167);
            this.Name_Label4.Name = "Name_Label4";
            this.Name_Label4.Size = new System.Drawing.Size(100, 23);
            this.Name_Label4.TabIndex = 7;
            this.Name_Label4.Text = "Name";
            this.Name_Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Score_Label1
            // 
            this.Score_Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Score_Label1.Location = new System.Drawing.Point(120, 371);
            this.Score_Label1.Name = "Score_Label1";
            this.Score_Label1.Size = new System.Drawing.Size(100, 23);
            this.Score_Label1.TabIndex = 8;
            this.Score_Label1.Text = "9";
            this.Score_Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Score_Label2
            // 
            this.Score_Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Score_Label2.Location = new System.Drawing.Point(272, 371);
            this.Score_Label2.Name = "Score_Label2";
            this.Score_Label2.Size = new System.Drawing.Size(100, 23);
            this.Score_Label2.TabIndex = 9;
            this.Score_Label2.Text = "9";
            this.Score_Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Score_Label3
            // 
            this.Score_Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Score_Label3.Location = new System.Drawing.Point(424, 371);
            this.Score_Label3.Name = "Score_Label3";
            this.Score_Label3.Size = new System.Drawing.Size(100, 23);
            this.Score_Label3.TabIndex = 10;
            this.Score_Label3.Text = "9";
            this.Score_Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Score_Label4
            // 
            this.Score_Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Score_Label4.Location = new System.Drawing.Point(576, 371);
            this.Score_Label4.Name = "Score_Label4";
            this.Score_Label4.Size = new System.Drawing.Size(100, 23);
            this.Score_Label4.TabIndex = 11;
            this.Score_Label4.Text = "9";
            this.Score_Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Round_Label
            // 
            this.Round_Label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Round_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Round_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Round_Label.Location = new System.Drawing.Point(350, 66);
            this.Round_Label.Name = "Round_Label";
            this.Round_Label.Size = new System.Drawing.Size(100, 50);
            this.Round_Label.TabIndex = 12;
            this.Round_Label.Text = "8 / 8";
            this.Round_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            gameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Game_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Round_Label);
            this.Controls.Add(this.Score_Label4);
            this.Controls.Add(this.Score_Label3);
            this.Controls.Add(this.Score_Label2);
            this.Controls.Add(this.Score_Label1);
            this.Controls.Add(this.Name_Label4);
            this.Controls.Add(this.Name_Label3);
            this.Controls.Add(this.Name_Label2);
            this.Controls.Add(this.Name_Label1);
            this.Controls.Add(this.Card4);
            this.Controls.Add(this.Card3);
            this.Controls.Add(this.Card2);
            this.Controls.Add(this.Card1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Game_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Card1;
        private System.Windows.Forms.Label Card2;
        private System.Windows.Forms.Label Card3;
        private System.Windows.Forms.Label Card4;
        private System.Windows.Forms.Label Name_Label1;
        private System.Windows.Forms.Label Name_Label2;
        private System.Windows.Forms.Label Name_Label3;
        private System.Windows.Forms.Label Name_Label4;
        private System.Windows.Forms.Label Score_Label1;
        private System.Windows.Forms.Label Score_Label2;
        private System.Windows.Forms.Label Score_Label3;
        private System.Windows.Forms.Label Score_Label4;
        private System.Windows.Forms.Label Round_Label;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem NewGame_TSMI;
        private System.Windows.Forms.ToolStripMenuItem RestartGame_TSMI;
    }
}

