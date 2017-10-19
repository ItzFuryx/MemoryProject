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
            this.NewGameButton = new System.Windows.Forms.Button();
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
            this.SFXLabel = new System.Windows.Forms.Label();
            this.SetSFXVolume = new System.Windows.Forms.ComboBox();
            this.SetVolumeLabel = new System.Windows.Forms.Label();
            this.SoundComboBox = new System.Windows.Forms.ComboBox();
            this.OptionsLabel = new System.Windows.Forms.Label();
            this.BackToMainButton02 = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.PlayerOneNameLabel = new System.Windows.Forms.Label();
            this.PlayerTwoNameLabel = new System.Windows.Forms.Label();
            this.MultiplayerTurn = new System.Windows.Forms.Label();
            this.BeurtSpeler = new System.Windows.Forms.Label();
            this.LabelSet1 = new System.Windows.Forms.Label();
            this.LabelSetsPlayer1 = new System.Windows.Forms.Label();
            this.LabelMemories1 = new System.Windows.Forms.Label();
            this.LabelMemoriesPlayer1 = new System.Windows.Forms.Label();
            this.LabelSet2 = new System.Windows.Forms.Label();
            this.LabelSetsPlayer2 = new System.Windows.Forms.Label();
            this.LabelMemories2 = new System.Windows.Forms.Label();
            this.LabelMemoriesPlayer2 = new System.Windows.Forms.Label();
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
            // NewGameButton
            // 
            this.NewGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewGameButton.Location = new System.Drawing.Point(538, 124);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(148, 58);
            this.NewGameButton.TabIndex = 1;
            this.NewGameButton.Text = "New Game";
            this.NewGameButton.UseVisualStyleBackColor = true;
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
            this.MainPanel.Controls.Add(this.NewGameButton);
            this.MainPanel.Location = new System.Drawing.Point(1092, 12);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1267, 720);
            this.MainPanel.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(173, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 26);
            this.label3.TabIndex = 16;
            this.label3.Text = "Username Two:";
            // 
            // SecondUsernameBox
            // 
            this.SecondUsernameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecondUsernameBox.Location = new System.Drawing.Point(173, 173);
            this.SecondUsernameBox.Name = "SecondUsernameBox";
            this.SecondUsernameBox.Size = new System.Drawing.Size(157, 32);
            this.SecondUsernameBox.TabIndex = 15;
            this.SecondUsernameBox.TextChanged += new System.EventHandler(this.SetUsernameTwo);
            // 
            // FirstUsernameBox
            // 
            this.FirstUsernameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstUsernameBox.Location = new System.Drawing.Point(173, 83);
            this.FirstUsernameBox.Name = "FirstUsernameBox";
            this.FirstUsernameBox.Size = new System.Drawing.Size(157, 32);
            this.FirstUsernameBox.TabIndex = 14;
            this.FirstUsernameBox.TextChanged += new System.EventHandler(this.SetUsername);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(173, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Username One:";
            // 
            // MainLabelText
            // 
            this.MainLabelText.AutoSize = true;
            this.MainLabelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainLabelText.ForeColor = System.Drawing.SystemColors.ButtonFace;
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
            this.SetsLabel.Location = new System.Drawing.Point(181, 143);
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
            this.HighscoresPanel.Controls.Add(this.HighscorePanel);
            this.HighscoresPanel.Controls.Add(this.label1);
            this.HighscoresPanel.Controls.Add(this.BackToMainButton01);
            this.HighscoresPanel.Location = new System.Drawing.Point(357, 289);
            this.HighscoresPanel.Name = "HighscoresPanel";
            this.HighscoresPanel.Size = new System.Drawing.Size(1267, 720);
            this.HighscoresPanel.TabIndex = 10;
            this.HighscoresPanel.Visible = false;
            // 
            // HighscorePanel
            // 
            this.HighscorePanel.Location = new System.Drawing.Point(327, 106);
            this.HighscorePanel.Name = "HighscorePanel";
            this.HighscorePanel.Size = new System.Drawing.Size(801, 554);
            this.HighscorePanel.TabIndex = 5;
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
            this.OptionsPanel.Controls.Add(this.SFXLabel);
            this.OptionsPanel.Controls.Add(this.SetSFXVolume);
            this.OptionsPanel.Controls.Add(this.SetVolumeLabel);
            this.OptionsPanel.Controls.Add(this.SoundComboBox);
            this.OptionsPanel.Controls.Add(this.OptionsLabel);
            this.OptionsPanel.Controls.Add(this.BackToMainButton02);
            this.OptionsPanel.Location = new System.Drawing.Point(50, 42);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(1267, 720);
            this.OptionsPanel.TabIndex = 11;
            this.OptionsPanel.Visible = false;
            // 
            // SFXLabel
            // 
            this.SFXLabel.AutoSize = true;
            this.SFXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SFXLabel.Location = new System.Drawing.Point(527, 331);
            this.SFXLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SFXLabel.Name = "SFXLabel";
            this.SFXLabel.Size = new System.Drawing.Size(94, 26);
            this.SFXLabel.TabIndex = 8;
            this.SFXLabel.Text = "Set SFX";
            // 
            // SetSFXVolume
            // 
            this.SetSFXVolume.FormattingEnabled = true;
            this.SetSFXVolume.Items.AddRange(new object[] {
            "100",
            "90",
            "80",
            "70",
            "60",
            "50",
            "40",
            "30",
            "20",
            "10",
            "0"});
            this.SetSFXVolume.Location = new System.Drawing.Point(532, 359);
            this.SetSFXVolume.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SetSFXVolume.Name = "SetSFXVolume";
            this.SetSFXVolume.Size = new System.Drawing.Size(87, 21);
            this.SetSFXVolume.TabIndex = 7;
            this.SetSFXVolume.SelectedIndexChanged += new System.EventHandler(this.OnSFXVolumeChanged);
            // 
            // SetVolumeLabel
            // 
            this.SetVolumeLabel.AutoSize = true;
            this.SetVolumeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetVolumeLabel.Location = new System.Drawing.Point(527, 172);
            this.SetVolumeLabel.Name = "SetVolumeLabel";
            this.SetVolumeLabel.Size = new System.Drawing.Size(126, 26);
            this.SetVolumeLabel.TabIndex = 6;
            this.SetVolumeLabel.Text = "Set Volume";
            // 
            // SoundComboBox
            // 
            this.SoundComboBox.FormattingEnabled = true;
            this.SoundComboBox.Items.AddRange(new object[] {
            "100",
            "90",
            "80",
            "70",
            "60",
            "50",
            "40",
            "30",
            "20",
            "10",
            "0"});
            this.SoundComboBox.Location = new System.Drawing.Point(532, 201);
            this.SoundComboBox.Name = "SoundComboBox";
            this.SoundComboBox.Size = new System.Drawing.Size(129, 21);
            this.SoundComboBox.TabIndex = 5;
            this.SoundComboBox.SelectedIndexChanged += new System.EventHandler(this.OnVolumeChanged);
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
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(184, 189);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(148, 58);
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
            this.PlayerOneNameLabel.Location = new System.Drawing.Point(179, 12);
            this.PlayerOneNameLabel.Name = "PlayerOneNameLabel";
            this.PlayerOneNameLabel.Size = new System.Drawing.Size(74, 26);
            this.PlayerOneNameLabel.TabIndex = 13;
            this.PlayerOneNameLabel.Text = "Player";
            this.PlayerOneNameLabel.Visible = false;
            // 
            // PlayerTwoNameLabel
            // 
            this.PlayerTwoNameLabel.AutoSize = true;
            this.PlayerTwoNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerTwoNameLabel.Location = new System.Drawing.Point(918, 12);
            this.PlayerTwoNameLabel.Name = "PlayerTwoNameLabel";
            this.PlayerTwoNameLabel.Size = new System.Drawing.Size(0, 26);
            this.PlayerTwoNameLabel.TabIndex = 13;
            this.PlayerTwoNameLabel.Visible = false;
            // 
            // MultiplayerTurn
            // 
            this.MultiplayerTurn.AutoSize = true;
            this.MultiplayerTurn.Location = new System.Drawing.Point(181, 296);
            this.MultiplayerTurn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MultiplayerTurn.Name = "MultiplayerTurn";
            this.MultiplayerTurn.Size = new System.Drawing.Size(25, 13);
            this.MultiplayerTurn.TabIndex = 14;
            this.MultiplayerTurn.Text = "123";
            this.MultiplayerTurn.Visible = false;
            // 
            // BeurtSpeler
            // 
            this.BeurtSpeler.AutoSize = true;
            this.BeurtSpeler.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeurtSpeler.Location = new System.Drawing.Point(179, 264);
            this.BeurtSpeler.Name = "BeurtSpeler";
            this.BeurtSpeler.Size = new System.Drawing.Size(70, 26);
            this.BeurtSpeler.TabIndex = 15;
            this.BeurtSpeler.Text = "Beurt:";
            this.BeurtSpeler.Visible = false;
            // 
            // LabelSet1
            // 
            this.LabelSet1.AutoSize = true;
            this.LabelSet1.Location = new System.Drawing.Point(181, 42);
            this.LabelSet1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelSet1.Name = "LabelSet1";
            this.LabelSet1.Size = new System.Drawing.Size(34, 13);
            this.LabelSet1.TabIndex = 16;
            this.LabelSet1.Text = "Sets: ";
            this.LabelSet1.Visible = false;
            // 
            // LabelSetsPlayer1
            // 
            this.LabelSetsPlayer1.AutoSize = true;
            this.LabelSetsPlayer1.Location = new System.Drawing.Point(230, 42);
            this.LabelSetsPlayer1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelSetsPlayer1.Name = "LabelSetsPlayer1";
            this.LabelSetsPlayer1.Size = new System.Drawing.Size(13, 13);
            this.LabelSetsPlayer1.TabIndex = 17;
            this.LabelSetsPlayer1.Text = "0";
            this.LabelSetsPlayer1.Visible = false;
            // 
            // LabelMemories1
            // 
            this.LabelMemories1.AutoSize = true;
            this.LabelMemories1.Location = new System.Drawing.Point(278, 42);
            this.LabelMemories1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelMemories1.Name = "LabelMemories1";
            this.LabelMemories1.Size = new System.Drawing.Size(58, 13);
            this.LabelMemories1.TabIndex = 18;
            this.LabelMemories1.Text = "Memories: ";
            this.LabelMemories1.Visible = false;
            // 
            // LabelMemoriesPlayer1
            // 
            this.LabelMemoriesPlayer1.AutoSize = true;
            this.LabelMemoriesPlayer1.Location = new System.Drawing.Point(352, 42);
            this.LabelMemoriesPlayer1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelMemoriesPlayer1.Name = "LabelMemoriesPlayer1";
            this.LabelMemoriesPlayer1.Size = new System.Drawing.Size(13, 13);
            this.LabelMemoriesPlayer1.TabIndex = 19;
            this.LabelMemoriesPlayer1.Text = "0";
            this.LabelMemoriesPlayer1.Visible = false;
            // 
            // LabelSet2
            // 
            this.LabelSet2.AutoSize = true;
            this.LabelSet2.Location = new System.Drawing.Point(905, 53);
            this.LabelSet2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelSet2.Name = "LabelSet2";
            this.LabelSet2.Size = new System.Drawing.Size(34, 13);
            this.LabelSet2.TabIndex = 20;
            this.LabelSet2.Text = "Sets: ";
            this.LabelSet2.Visible = false;
            // 
            // LabelSetsPlayer2
            // 
            this.LabelSetsPlayer2.AutoSize = true;
            this.LabelSetsPlayer2.Location = new System.Drawing.Point(953, 53);
            this.LabelSetsPlayer2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelSetsPlayer2.Name = "LabelSetsPlayer2";
            this.LabelSetsPlayer2.Size = new System.Drawing.Size(13, 13);
            this.LabelSetsPlayer2.TabIndex = 21;
            this.LabelSetsPlayer2.Text = "0";
            this.LabelSetsPlayer2.Visible = false;
            // 
            // LabelMemories2
            // 
            this.LabelMemories2.AutoSize = true;
            this.LabelMemories2.Location = new System.Drawing.Point(983, 53);
            this.LabelMemories2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelMemories2.Name = "LabelMemories2";
            this.LabelMemories2.Size = new System.Drawing.Size(58, 13);
            this.LabelMemories2.TabIndex = 22;
            this.LabelMemories2.Text = "Memories: ";
            this.LabelMemories2.Visible = false;
            // 
            // LabelMemoriesPlayer2
            // 
            this.LabelMemoriesPlayer2.AutoSize = true;
            this.LabelMemoriesPlayer2.Location = new System.Drawing.Point(1053, 54);
            this.LabelMemoriesPlayer2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelMemoriesPlayer2.Name = "LabelMemoriesPlayer2";
            this.LabelMemoriesPlayer2.Size = new System.Drawing.Size(13, 13);
            this.LabelMemoriesPlayer2.TabIndex = 23;
            this.LabelMemoriesPlayer2.Text = "0";
            this.LabelMemoriesPlayer2.Visible = false;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 675);
            this.Controls.Add(this.OptionsPanel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.LabelMemoriesPlayer2);
            this.Controls.Add(this.LabelMemories2);
            this.Controls.Add(this.LabelSetsPlayer2);
            this.Controls.Add(this.LabelSet2);
            this.Controls.Add(this.LabelMemoriesPlayer1);
            this.Controls.Add(this.LabelMemories1);
            this.Controls.Add(this.LabelSetsPlayer1);
            this.Controls.Add(this.LabelSet1);
            this.Controls.Add(this.BeurtSpeler);
            this.Controls.Add(this.MultiplayerTurn);
            this.Controls.Add(this.PlayerTwoNameLabel);
            this.Controls.Add(this.PlayerOneNameLabel);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.HighscoresPanel);
            this.Controls.Add(this.SetsLabel);
            this.Controls.Add(this.BackToMainButton03);
            this.Controls.Add(this.GridPanel);
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
        private System.Windows.Forms.Button NewGameButton;
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
        private System.Windows.Forms.Label MultiplayerTurn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label BeurtSpeler;
        private System.Windows.Forms.Label LabelSet1;
        private System.Windows.Forms.Label LabelSetsPlayer1;
        private System.Windows.Forms.Label LabelMemories1;
        private System.Windows.Forms.Label LabelMemoriesPlayer1;
        private System.Windows.Forms.Label LabelSet2;
        private System.Windows.Forms.Label LabelSetsPlayer2;
        private System.Windows.Forms.Label LabelMemories2;
        private System.Windows.Forms.Label LabelMemoriesPlayer2;
        private System.Windows.Forms.ComboBox SoundComboBox;
        private System.Windows.Forms.Label SetVolumeLabel;
        private System.Windows.Forms.Label SFXLabel;
        private System.Windows.Forms.ComboBox SetSFXVolume;
    }
}

