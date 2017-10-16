namespace MemoryGame
{
    partial class MainPage
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
            this.GridPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.BackToMainButton03 = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MainLabelText = new System.Windows.Forms.Label();
            this.LoadGameButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.HighscoresButton = new System.Windows.Forms.Button();
            this.SetsLabel = new System.Windows.Forms.Label();
            this.HighscoresPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BackToMainButton01 = new System.Windows.Forms.Button();
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.OptionsLabel = new System.Windows.Forms.Label();
            this.BackToMainButton02 = new System.Windows.Forms.Button();
            this.resetbutton = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.HighscoresPanel.SuspendLayout();
            this.OptionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridPanel
            // 
            this.GridPanel.Location = new System.Drawing.Point(396, 12);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(495, 657);
            this.GridPanel.TabIndex = 0;
            // 
            // StartGameButton
            // 
            this.StartGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartGameButton.Location = new System.Drawing.Point(538, 124);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(148, 58);
            this.StartGameButton.TabIndex = 1;
            this.StartGameButton.Text = "Start Game";
            this.StartGameButton.UseVisualStyleBackColor = true;
            // 
            // BackToMainButton03
            // 
            this.BackToMainButton03.Location = new System.Drawing.Point(184, 65);
            this.BackToMainButton03.Name = "BackToMainButton03";
            this.BackToMainButton03.Size = new System.Drawing.Size(148, 58);
            this.BackToMainButton03.TabIndex = 2;
            this.BackToMainButton03.Text = "Back";
            this.BackToMainButton03.UseVisualStyleBackColor = true;
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.DimGray;
            this.MainPanel.BackgroundImage = global::MemoryGame.Properties.Resources.StarWars_Background;
            this.MainPanel.Controls.Add(this.MainLabelText);
            this.MainPanel.Controls.Add(this.LoadGameButton);
            this.MainPanel.Controls.Add(this.ExitButton);
            this.MainPanel.Controls.Add(this.OptionsButton);
            this.MainPanel.Controls.Add(this.HighscoresButton);
            this.MainPanel.Controls.Add(this.StartGameButton);
            this.MainPanel.Location = new System.Drawing.Point(1045, 46);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1267, 720);
            this.MainPanel.TabIndex = 9;
            // 
            // MainLabelText
            // 
            this.MainLabelText.AutoSize = true;
            this.MainLabelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainLabelText.Location = new System.Drawing.Point(522, 50);
            this.MainLabelText.Name = "MainLabelText";
            this.MainLabelText.Size = new System.Drawing.Size(191, 31);
            this.MainLabelText.TabIndex = 6;
            this.MainLabelText.Text = "Memory Game";
            // 
            // LoadGameButton
            // 
            this.LoadGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadGameButton.Location = new System.Drawing.Point(538, 188);
            this.LoadGameButton.Name = "LoadGameButton";
            this.LoadGameButton.Size = new System.Drawing.Size(148, 58);
            this.LoadGameButton.TabIndex = 5;
            this.LoadGameButton.Text = "Load Game";
            this.LoadGameButton.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(538, 380);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(148, 58);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // OptionsButton
            // 
            this.OptionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsButton.Location = new System.Drawing.Point(538, 316);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(148, 58);
            this.OptionsButton.TabIndex = 3;
            this.OptionsButton.Text = "Options";
            this.OptionsButton.UseVisualStyleBackColor = true;
            // 
            // HighscoresButton
            // 
            this.HighscoresButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HighscoresButton.Location = new System.Drawing.Point(538, 252);
            this.HighscoresButton.Name = "HighscoresButton";
            this.HighscoresButton.Size = new System.Drawing.Size(148, 58);
            this.HighscoresButton.TabIndex = 2;
            this.HighscoresButton.Text = "Highscores";
            this.HighscoresButton.UseVisualStyleBackColor = true;
            // 
            // SetsLabel
            // 
            this.SetsLabel.AutoSize = true;
            this.SetsLabel.Location = new System.Drawing.Point(269, 153);
            this.SetsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SetsLabel.Name = "SetsLabel";
            this.SetsLabel.Size = new System.Drawing.Size(13, 13);
            this.SetsLabel.TabIndex = 5;
            this.SetsLabel.Text = "0";
            this.SetsLabel.Visible = false;
            // 
            // HighscoresPanel
            // 
            this.HighscoresPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.HighscoresPanel.BackgroundImage = global::MemoryGame.Properties.Resources.StarWars_Background;
            this.HighscoresPanel.Controls.Add(this.label1);
            this.HighscoresPanel.Controls.Add(this.BackToMainButton01);
            this.HighscoresPanel.Location = new System.Drawing.Point(272, 292);
            this.HighscoresPanel.Name = "HighscoresPanel";
            this.HighscoresPanel.Size = new System.Drawing.Size(1267, 720);
            this.HighscoresPanel.TabIndex = 10;
            this.HighscoresPanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(527, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Highscores";
            // 
            // BackToMainButton01
            // 
            this.BackToMainButton01.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackToMainButton01.Location = new System.Drawing.Point(18, 17);
            this.BackToMainButton01.Name = "BackToMainButton01";
            this.BackToMainButton01.Size = new System.Drawing.Size(148, 58);
            this.BackToMainButton01.TabIndex = 3;
            this.BackToMainButton01.Text = "Back";
            this.BackToMainButton01.UseVisualStyleBackColor = true;
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.OptionsPanel.BackgroundImage = global::MemoryGame.Properties.Resources.StarWars_Background;
            this.OptionsPanel.Controls.Add(this.OptionsLabel);
            this.OptionsPanel.Controls.Add(this.BackToMainButton02);
            this.OptionsPanel.Location = new System.Drawing.Point(164, 433);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(1267, 720);
            this.OptionsPanel.TabIndex = 11;
            this.OptionsPanel.Visible = false;
            // 
            // OptionsLabel
            // 
            this.OptionsLabel.AutoSize = true;
            this.OptionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsLabel.Location = new System.Drawing.Point(527, 31);
            this.OptionsLabel.Name = "OptionsLabel";
            this.OptionsLabel.Size = new System.Drawing.Size(87, 26);
            this.OptionsLabel.TabIndex = 4;
            this.OptionsLabel.Text = "Options";
            // 
            // BackToMainButton02
            // 
            this.BackToMainButton02.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackToMainButton02.Location = new System.Drawing.Point(18, 17);
            this.BackToMainButton02.Name = "BackToMainButton02";
            this.BackToMainButton02.Size = new System.Drawing.Size(148, 58);
            this.BackToMainButton02.TabIndex = 3;
            this.BackToMainButton02.Text = "Back";
            this.BackToMainButton02.UseVisualStyleBackColor = true;
            // 
            // resetbutton
            // 
            this.resetbutton.Location = new System.Drawing.Point(184, 189);
            this.resetbutton.Name = "resetbutton";
            this.resetbutton.Size = new System.Drawing.Size(148, 58);
            this.resetbutton.TabIndex = 12;
            this.resetbutton.Text = "Reset";
            this.resetbutton.UseVisualStyleBackColor = true;
            this.resetbutton.Visible = false;
            this.resetbutton.Click += new System.EventHandler(this.resetbutton_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.resetbutton);
            this.Controls.Add(this.OptionsPanel);
            this.Controls.Add(this.HighscoresPanel);
            this.Controls.Add(this.SetsLabel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.BackToMainButton03);
            this.Controls.Add(this.GridPanel);
            this.Name = "MainPage";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.HighscoresPanel.ResumeLayout(false);
            this.HighscoresPanel.PerformLayout();
            this.OptionsPanel.ResumeLayout(false);
            this.OptionsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel GridPanel;
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.Button BackToMainButton03;
        private System.Windows.Forms.Label SetsLabel;
        public System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button LoadGameButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button OptionsButton;
        private System.Windows.Forms.Button HighscoresButton;
        public System.Windows.Forms.Panel HighscoresPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BackToMainButton01;
        public System.Windows.Forms.Panel OptionsPanel;
        private System.Windows.Forms.Label OptionsLabel;
        private System.Windows.Forms.Button BackToMainButton02;
        private System.Windows.Forms.Label MainLabelText;
        private System.Windows.Forms.Button resetbutton;
    }
}

