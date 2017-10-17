﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;
using System.Windows.Forms;
using System.IO;

namespace MemoryGame
{
    public partial class MainPage : Form
    {
        internal const int MemoryItems = 16;

        #region private VARS
        private MemoryButton[] ButtonArray = new MemoryButton[MemoryItems];       
        private MemoryType[] Types = new MemoryType[MemoryItems];
        private MemoryButton FirstButton;
        private List<Score> Scores = new List<Score>();

        //lan multiplayer
        private int BeurtPlayer1 = 0;
        private int Beurtplayer2 = 0;
         
        private int MemoriesPlayer1 = 0;
        private int MemoriesPlayer2 = 0;
        private int SetsPlayer1 = 0;
        private int SetsPlayer2 = 0;
        
        private int Sets = 0;
        private int WinCondition = 0;
        private int Num = 0;
        
#endregion

        public MainPage()
        {
            InitializeComponent();

            new SoundPlayer(Properties.Resources.BackgroundMusic).PlayLooping();
            MainPanel.Location = new Point(0, 0);
            StartGameButton.Click += new EventHandler(this.StartGame);
            HighscoresButton.Click += new EventHandler(this.OpenHighScores);
            OptionsButton.Click += new EventHandler(this.OpenOptions);
            ExitButton.Click += new EventHandler(this.QuitGame);

            BackToMainButton01.Click += new EventHandler(this.Back);
            BackToMainButton02.Click += new EventHandler(this.Back);
            BackToMainButton03.Click += new EventHandler(this.Back);

            RandomizeCards();
                        
            for (int i = 0; i < ButtonArray.Length; i++)
            {
                ButtonArray[i] = new MemoryButton();
            }
           
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ButtonArray[Num].Button = new Button() { Text = null,
                        BackColor = Color.Gray,
                        BackgroundImage = Properties.Resources.BS,
                        Width = 100, Height = 150 };
                        ButtonArray[Num].Button.Click += new EventHandler(this.ClickedCard);
                        ButtonArray[Num].Type = Types[Num];

                    GridPanel.Controls.Add(ButtonArray[Num].Button);
                    Num++;
                }  
            }
            if(!File.Exists("memory.sav"))
            {
                var stream1 = File.Create("memory.sav");
                stream1.Close();
            }
        }

        #region CardFunctions
        public void ClickedCard(object sender, EventArgs e)
        {
        

            for (int i = 0; i < MemoryItems; i++)
            {
                if(FirstButton != null)
                    if(sender == FirstButton.Button)
                        break;

                if (sender == ButtonArray[i].Button)
                {
                    if (ButtonArray[i].Succes) return;

                    switch (ButtonArray[i].Type)
                    {
                        case MemoryType.Bart:
                            ButtonArray[i].Button.BackgroundImage = Properties.Resources.KA;
                            break;
                        case MemoryType.Casper:
                            ButtonArray[i].Button.BackgroundImage = Properties.Resources.KJ;
                            break;
                        case MemoryType.DieEneGozer:
                            ButtonArray[i].Button.BackgroundImage = Properties.Resources.KQ;
                            break;
                        case MemoryType.Harro:
                            ButtonArray[i].Button.BackgroundImage = Properties.Resources.KK;
                            break;
                        case MemoryType.Keanu:
                            ButtonArray[i].Button.BackgroundImage = Properties.Resources.SA;
                            break;
                        case MemoryType.Kevin:
                            ButtonArray[i].Button.BackgroundImage = Properties.Resources.SJ;
                            break;
                        case MemoryType.Pim:
                            ButtonArray[i].Button.BackgroundImage = Properties.Resources.SQ;
                            break;
                        case MemoryType.StarWars:
                            ButtonArray[i].Button.BackgroundImage = Properties.Resources.SK;
                            break;
                    }
                    
                    if (FirstButton == null)
                    {
                        FirstButton = ButtonArray[i];
                    }
                    else if(FirstButton != null)
                    {
                        MemoryButton secondButton = ButtonArray[i];
                        var t = Task.Run(async delegate
                        {
                            await Task.Delay(TimeSpan.FromSeconds(1));
                        });
                        t.Wait();

                        if (FirstButton.Type == secondButton.Type)
                        {
                            //lan
                            if(SecondUsernameBox == null)
                            {
                                FirstButton.Succes = true;
                                secondButton.Succes = true;
                                WinCondition++;
                                new SoundPlayer(Properties.Resources.CorrectCardsCombined).Play();
                            }
                            else {
                                if(MultiplayerBeurt.Text == UsernameLabel.Text)
                                {
                                    MemoriesPlayer1++;
                                }
                                else
                                {
                                    MemoriesPlayer2++;
                                }
                                new SoundPlayer(Properties.Resources.CorrectCardsCombined).Play();
                            }
                        }
                        else
                        {
                            if (SecondUsernameBox == null)
                            {
                                new SoundPlayer(Properties.Resources.Fail).Play();
                                secondButton.Button.BackgroundImage = Properties.Resources.BS;
                                FirstButton.Button.BackgroundImage = Properties.Resources.BS;
                            }
                            else
                            {
                                new SoundPlayer(Properties.Resources.Fail).Play();
                                secondButton.Button.BackgroundImage = Properties.Resources.BS;
                                FirstButton.Button.BackgroundImage = Properties.Resources.BS;
                                
                                if(MultiplayerBeurt.Text == UsernameLabel.Text)
                                {
                                    MultiplayerBeurt.Text = PlayerLabel.Text;
                                }
                                else
                                {
                                    MultiplayerBeurt.Text = UsernameLabel.Text;
                                }
                            }
                        }
                        FirstButton = null;
                    }
                    SetsLabel.Text = ((Sets+1)/2).ToString();
                    Sets++;
                    if (WinCondition == 8)
                    {
                        OnGameCompleted();
                    }
                    break;
                }
            }
            Save();
        }

        private void Save()
        {
            int count = 0;
            string[] savelines = new string[32];
            foreach (MemoryButton but in ButtonArray)
            {
                savelines[count] = Convert.ToString(but.Succes);
                count++;
            }
            savelines[16] = UsernameLabel.Text;
            savelines[18] = SetsLabel.Text;
            int count1 = 22;
            foreach(Score score in Scores)
            {
                savelines[count1] = score.Name;
                count1++;
            }
            count1 = 27;
            foreach(Score score in Scores)
            {
                savelines[count1] = (score.Sets / 2).ToString();
                count1++;
            }
            File.WriteAllLines("memory.sav", savelines);
        }

        private void RandomizeCards()
        {
            for (int i = 0; i < MemoryItems; i++)
            {
                if (i < 8)
                {
                    Types[i] = (MemoryType)i;
                }
                else
                {
                    Types[i] = (MemoryType)i - MemoryItems / 2;
                }
            }

            Random rnd = new Random();
            Types = Types.OrderBy(x => rnd.Next()).ToArray();
        }

        private void Reset(object sender, EventArgs e)
        {
            RandomizeCards();
            for (int i = 0; i < MemoryItems; i++)
            {
                ButtonArray[i].Button.BackgroundImage = Properties.Resources.BS;
                ButtonArray[i].Succes = false;
                ButtonArray[i].Type = Types[i];
                Sets = 0;
                SetsLabel.Text = "0";
            }
        }

        private void OnGameCompleted()
        {
            WinCondition = 0;

            Sets = Sets / 2;
            CreateHighscores();
            OpenHighScores(this, new EventArgs());
            Reset(this, new EventArgs());
        }
#endregion

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        #region Menu Functions

        private void CreateHighscores()
        {
            if (Scores.Count >= 5)
            {
                Score newScore = new Score();
                for(int i =0; i < Scores.Count; i++)
                {
                    if(Scores[i].Sets >= Sets)
                    {
                        if(newScore.Name != string.Empty)
                        {
                            if (newScore.Sets >= Scores[i].Sets)
                                newScore = Scores[i];
                        }
                        else
                        {
                            newScore = Scores[i];
                        }
                    }
                }

                if(newScore.Name != string.Empty)
                {
                    newScore.SetNewScore(UsernameLabel.Text, Sets);

                    SortHighscores();
                }
                return;
            }
            
            Score score = new Score(
                 new Panel() { Size = new Size(500, 50)},
                 new Label() { Text = "Name = " + UsernameLabel.Text, Location = new Point(0, 0) },
                 new Label() { Text = "Sets = " + Sets , Location = new Point(100, 0) },
                 UsernameLabel.Text,
                 Sets);
            
            Scores.Add(score);
            SortHighscores();
        }

        public void SortHighscores()
        {
            HighscorePanel.Controls.Clear();
            Scores = Scores.OrderBy(p => p.Sets).ToList();

            foreach (Score setScore in Scores)
            {
                HighscorePanel.Controls.Add(setScore.ScorePanel);
            }
        }

        public void OpenHighScores(object sender, EventArgs e)
        {
            HideAll();
            new SoundPlayer(Properties.Resources.Highscore).Play();
            HighscoresPanel.Visible = true;
            HighscoresPanel.Location = new Point(0, 0);
        }

        public void OpenOptions(object sender, EventArgs e)
        {
            HideAll();
            MainPanel.Visible = false;
            OptionsPanel.Visible = true;
            OptionsPanel.Location = new Point(0, 0);
        }

        public void StartGame(object sender, EventArgs e)
        {
            HideAll();
            SetsLabel.Visible = true;
            UsernameLabel.Visible = true;
            PlayerLabel.Visible = true;
            MultiplayerBeurt.Visible = true;
            ResetButton.Visible = true;
        }

        public void Back(object sender, EventArgs e)
        {
            HideAll();
            MainPanel.Visible = true;
            MainPanel.Location = new Point(0, 0);
        }

        private void HideAll()
        {
            new SoundPlayer(Properties.Resources.MenuClick).Play();
            MainPanel.Visible = false;
            ResetButton.Visible = false;
            HighscoresPanel.Visible = false;
            SetsLabel.Visible = false;
            OptionsPanel.Visible = false;
            UsernameLabel.Visible = false;
            PlayerLabel.Visible = false;
            MultiplayerBeurt.Visible = false;
        }

        public void QuitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void SetUsernameTwo(object sender, EventArgs e)
        {
            PlayerLabel.Text = SecondUsernameBox.Text;
        }

        public void SetUsername(object sender, EventArgs e)
        {
            UsernameLabel.Text = FirstUsernameBox.Text;
            if(PlayerLabel.Text != string.Empty)
            {
                MultiplayerBeurt.Text = UsernameLabel.Text;
            }
            else
            {
                MultiplayerBeurt.Visible = false;
            }
        }

       
        #endregion
    }
}
