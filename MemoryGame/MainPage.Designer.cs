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
            this.label3 = new System.Windows.Forms.Label();
            this.SecondUsernameBox = new System.Windows.Forms.TextBox();
            this.FirstUsernameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MainLabelText = new System.Windows.Forms.Label();
            this.LoadGameButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.HighscoresButton = new System.Windows.Forms.Button();
            this.SetsLabel = new System.Windows.Forms.Label();
            this.HighscoresPanel = new System.Windows.Forms.Panel();
            this.HighscorePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.BackToMainButton01 = new System.Windows.Forms.Button();
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.OptionsLabel = new System.Windows.Forms.Label();
            this.BackToMainButton02 = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.PlayerOneNameLabel = new System.Windows.Forms.Label();
            this.PlayerTwoNameLabel = new System.Windows.Forms.Label();
            this.MultiplayerBeurt = new System.Windows.Forms.Label();
            this.BeurtSpeler = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.HighscoresPanel.SuspendLayout();
            this.OptionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridPanel
            // 
            this.GridPanel.Location = new System.Drawing.Point(594, 18);
            this.GridPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(742, 1011);
            this.GridPanel.TabIndex = 0;
            // 
            // StartGameButton
            // 
            this.StartGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartGameButton.Location = new System.Drawing.Point(807, 191);
            this.StartGameButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(222, 89);
            this.StartGameButton.TabIndex = 1;
            this.StartGameButton.Text = "Start Game";
            this.StartGameButton.UseVisualStyleBackColor = true;
            // 
            // BackToMainButton03
            // 
            this.BackToMainButton03.Location = new System.Drawing.Point(276, 100);
            this.BackToMainButton03.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BackToMainButton03.Name = "BackToMainButton03";
            this.BackToMainButton03.Size = new System.Drawing.Size(222, 89);
            this.BackToMainButton03.TabIndex = 2;
            this.BackToMainButton03.Text = "Back";
            this.BackToMainButton03.UseVisualStyleBackColor = true;
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.BackgroundImage = global::MemoryGame.Properties.Resources.StarWars_Background;
            this.MainPanel.Controls.Add(this.label3);
            this.MainPanel.Controls.Add(this.SecondUsernameBox);
            this.MainPanel.Controls.Add(this.FirstUsernameBox);
            this.MainPanel.Controls.Add(this.label2);
            this.MainPanel.Controls.Add(this.MainLabelText);
            this.MainPanel.Controls.Add(this.LoadGameButton);
            this.MainPanel.Controls.Add(this.ExitButton);
            this.MainPanel.Controls.Add(this.OptionsButton);
            this.MainPanel.Controls.Add(this.HighscoresButton);
            this.MainPanel.Controls.Add(this.StartGameButton);
            this.MainPanel.Location = new System.Drawing.Point(1638, 18);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1900, 1108);
            this.MainPanel.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(260, 212);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 38);
            this.label3.TabIndex = 16;
            this.label3.Text = "Username Two:";
            // 
            // SecondUsernameBox
            // 
            this.SecondUsernameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecondUsernameBox.Location = new System.Drawing.Point(260, 266);
            this.SecondUsernameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SecondUsernameBox.Name = "SecondUsernameBox";
            this.SecondUsernameBox.Size = new System.Drawing.Size(234, 44);
            this.SecondUsernameBox.TabIndex = 15;
            this.SecondUsernameBox.TextChanged += new System.EventHandler(this.SetUsernameTwo);
            // 
            // FirstUsernameBox
            // 
            this.FirstUsernameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstUsernameBox.Location = new System.Drawing.Point(260, 128);
            this.FirstUsernameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FirstUsernameBox.Name = "FirstUsernameBox";
            this.FirstUsernameBox.Size = new System.Drawing.Size(234, 44);
            this.FirstUsernameBox.TabIndex = 14;
            this.FirstUsernameBox.TextChanged += new System.EventHandler(this.SetUsername);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(260, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 38);
            this.label2.TabIndex = 8;
            this.label2.Text = "Username One:";
            // 
            // MainLabelText
            // 
            this.MainLabelText.AutoSize = true;
            this.MainLabelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainLabelText.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MainLabelText.Location = new System.Drawing.Point(783, 77);
            this.MainLabelText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MainLabelText.Name = "MainLabelText";
            this.MainLabelText.Size = new System.Drawing.Size(292, 47);
            this.MainLabelText.TabIndex = 6;
            this.MainLabelText.Text = "Memory Game";
            // 
            // LoadGameButton
            // 
            this.LoadGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadGameButton.Location = new System.Drawing.Point(807, 289);
            this.LoadGameButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LoadGameButton.Name = "LoadGameButton";
            this.LoadGameButton.Size = new System.Drawing.Size(222, 89);
            this.LoadGameButton.TabIndex = 5;
            this.LoadGameButton.Text = "Load Game";
            this.LoadGameButton.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(807, 585);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(222, 89);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // OptionsButton
            // 
            this.OptionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsButton.Location = new System.Drawing.Point(807, 486);
            this.OptionsButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(222, 89);
            this.OptionsButton.TabIndex = 3;
            this.OptionsButton.Text = "Options";
            this.OptionsButton.UseVisualStyleBackColor = true;
            // 
            // HighscoresButton
            // 
            this.HighscoresButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HighscoresButton.Location = new System.Drawing.Point(807, 388);
            this.HighscoresButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HighscoresButton.Name = "HighscoresButton";
            this.HighscoresButton.Size = new System.Drawing.Size(222, 89);
            this.HighscoresButton.TabIndex = 2;
            this.HighscoresButton.Text = "Highscores";
            this.HighscoresButton.UseVisualStyleBackColor = true;
            // 
            // SetsLabel
            // 
            this.SetsLabel.AutoSize = true;
            this.SetsLabel.Location = new System.Drawing.Point(272, 220);
            this.SetsLabel.Name = "SetsLabel";
            this.SetsLabel.Size = new System.Drawing.Size(18, 20);
            this.SetsLabel.TabIndex = 5;
            this.SetsLabel.Text = "0";
            this.SetsLabel.Visible = false;
            // 
            // HighscoresPanel
            // 
            this.HighscoresPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.HighscoresPanel.BackgroundImage = global::MemoryGame.Properties.Resources.StarWars_Background;
            this.HighscoresPanel.Controls.Add(this.HighscorePanel);
            this.HighscoresPanel.Controls.Add(this.label1);
            this.HighscoresPanel.Controls.Add(this.BackToMainButton01);
            this.HighscoresPanel.Location = new System.Drawing.Point(536, 445);
            this.HighscoresPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HighscoresPanel.Name = "HighscoresPanel";
            this.HighscoresPanel.Size = new System.Drawing.Size(1900, 1108);
            this.HighscoresPanel.TabIndex = 10;
            this.HighscoresPanel.Visible = false;
            // 
            // HighscorePanel
            // 
            this.HighscorePanel.Location = new System.Drawing.Point(490, 163);
            this.HighscorePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HighscorePanel.Name = "HighscorePanel";
            this.HighscorePanel.Size = new System.Drawing.Size(1202, 852);
            this.HighscorePanel.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(790, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 38);
            this.label1.TabIndex = 4;
            this.label1.Text = "Highscores";
            // 
            // BackToMainButton01
            // 
            this.BackToMainButton01.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackToMainButton01.Location = new System.Drawing.Point(27, 26);
            this.BackToMainButton01.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BackToMainButton01.Name = "BackToMainButton01";
            this.BackToMainButton01.Size = new System.Drawing.Size(222, 89);
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
            this.OptionsPanel.Location = new System.Drawing.Point(246, 666);
            this.OptionsPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(1900, 1108);
            this.OptionsPanel.TabIndex = 11;
            this.OptionsPanel.Visible = false;
            // 
            // OptionsLabel
            // 
            this.OptionsLabel.AutoSize = true;
            this.OptionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsLabel.Location = new System.Drawing.Point(790, 48);
            this.OptionsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OptionsLabel.Name = "OptionsLabel";
            this.OptionsLabel.Size = new System.Drawing.Size(130, 38);
            this.OptionsLabel.TabIndex = 4;
            this.OptionsLabel.Text = "Options";
            // 
            // BackToMainButton02
            // 
            this.BackToMainButton02.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackToMainButton02.Location = new System.Drawing.Point(27, 26);
            this.BackToMainButton02.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BackToMainButton02.Name = "BackToMainButton02";
            this.BackToMainButton02.Size = new System.Drawing.Size(222, 89);
            this.BackToMainButton02.TabIndex = 3;
            this.BackToMainButton02.Text = "Back";
            this.BackToMainButton02.UseVisualStyleBackColor = true;
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(276, 291);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(222, 89);
            this.ResetButton.TabIndex = 12;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Visible = false;
            this.ResetButton.Click += new System.EventHandler(this.Reset);
            // 
            // PlayerOneNameLabel
            // 
            this.PlayerOneNameLabel.AutoSize = true;
            this.PlayerOneNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerOneNameLabel.Location = new System.Drawing.Point(268, 18);
            this.PlayerOneNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PlayerOneNameLabel.Name = "PlayerOneNameLabel";
            this.PlayerOneNameLabel.Size = new System.Drawing.Size(122, 38);
            this.PlayerOneNameLabel.TabIndex = 13;
            this.PlayerOneNameLabel.Text = "Name1";
            this.PlayerOneNameLabel.Visible = false;
            // 
            // PlayerTwoNameLabel
            // 
            this.PlayerTwoNameLabel.AutoSize = true;
            this.PlayerTwoNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerTwoNameLabel.Location = new System.Drawing.Point(1377, 18);
            this.PlayerTwoNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PlayerTwoNameLabel.Name = "PlayerTwoNameLabel";
            this.PlayerTwoNameLabel.Size = new System.Drawing.Size(0, 38);
            this.PlayerTwoNameLabel.TabIndex = 13;
            this.PlayerTwoNameLabel.Visible = false;
            // 
            // MultiplayerBeurt
            // 
            this.MultiplayerBeurt.AutoSize = true;
            this.MultiplayerBeurt.Location = new System.Drawing.Point(272, 456);
            this.MultiplayerBeurt.Name = "MultiplayerBeurt";
            this.MultiplayerBeurt.Size = new System.Drawing.Size(36, 20);
            this.MultiplayerBeurt.TabIndex = 14;
            this.MultiplayerBeurt.Text = "123";
            this.MultiplayerBeurt.Visible = false;
            // 
            // BeurtSpeler
            // 
            this.BeurtSpeler.AutoSize = true;
            this.BeurtSpeler.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeurtSpeler.Location = new System.Drawing.Point(269, 406);
            this.BeurtSpeler.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BeurtSpeler.Name = "BeurtSpeler";
            this.BeurtSpeler.Size = new System.Drawing.Size(104, 38);
            this.BeurtSpeler.TabIndex = 15;
            this.BeurtSpeler.Text = "Beurt:";
            this.BeurtSpeler.Visible = false;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1896, 1038);
            this.Controls.Add(this.BeurtSpeler);
            this.Controls.Add(this.MultiplayerBeurt);
            this.Controls.Add(this.PlayerTwoNameLabel);
            this.Controls.Add(this.PlayerOneNameLabel);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.OptionsPanel);
            this.Controls.Add(this.HighscoresPanel);
            this.Controls.Add(this.SetsLabel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.BackToMainButton03);
            this.Controls.Add(this.GridPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainPage";
            this.Text = "Form1";
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
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label PlayerOneNameLabel;
        private System.Windows.Forms.FlowLayoutPanel HighscorePanel;
        private System.Windows.Forms.TextBox FirstUsernameBox;
        private System.Windows.Forms.Label PlayerTwoNameLabel;
        private System.Windows.Forms.TextBox SecondUsernameBox;
        private System.Windows.Forms.Label MultiplayerBeurt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label BeurtSpeler;
    }
}

