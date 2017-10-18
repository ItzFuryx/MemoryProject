using System;
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
using WMPLib;
using System.Security.Cryptography;

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
        
        private PlayerVars PlayerOne = new PlayerVars();
        private PlayerVars PlayerTwo = new PlayerVars();

        private int Sets = 0;
        private int WinCondition = 0;
        private int Num = 0;

        //sound variables
        private WindowsMediaPlayer BackgroundSound = null;
        private string path = String.Empty;
        private WindowsMediaPlayer MenuSound = null;
        private string pathMenu = String.Empty;
        private WindowsMediaPlayer Succes = null;
        private string pathSucces = String.Empty;
        private WindowsMediaPlayer Fail = null;
        private string pathFail = String.Empty;
        #endregion

        public MainPage()
        {
            InitializeComponent();
            //Sound settings
            path = Path.GetFullPath(@"..\..\Resources/BackgroundMusic.wav");
            pathMenu = Path.GetFullPath(@"..\..\Resources/MenuClick.wav");
            pathSucces = Path.GetFullPath(@"..\..\Resources/CorrectCardsCombined.wav");
            pathFail = Path.GetFullPath(@"..\..\Resources/Fail.wav");
            BackgroundSound = new WindowsMediaPlayer();
            MenuSound = new WindowsMediaPlayer();
            Succes = new WindowsMediaPlayer();
            Fail = new WindowsMediaPlayer();

            BackgroundSound.URL = path;
            BackgroundSound.settings.setMode("loop", true);            

            MainPanel.Location = new Point(0, 0);
            StartGameButton.Click += new EventHandler(this.StartGame);
            HighscoresButton.Click += new EventHandler(this.OpenHighScores);
            OptionsButton.Click += new EventHandler(this.OpenOptions);
            ExitButton.Click += new EventHandler(this.QuitGame);
            LoadGameButton.Click += new EventHandler(this.LoadGame);

            BackToMainButton01.Click += new EventHandler(this.Back);
            BackToMainButton02.Click += new EventHandler(this.Back);
            BackToMainButton03.Click += new EventHandler(this.Back);

            CreateCards(true);

            if (!File.Exists("memory.sav"))
            {
                var stream1 = File.Create("memory.sav");
                stream1.Close();
            }
        }

        #region CardFunctions
        private void CreateCards(bool shuffleCards)
        {
            if(shuffleCards) RandomizeCards();

            for (int i = 0; i < ButtonArray.Length; i++)
            {
                ButtonArray[i] = new MemoryButton();
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ButtonArray[Num].Button = new Button()
                    {
                        Text = null,
                        BackColor = Color.Gray,
                        BackgroundImage = Properties.Resources.BS,
                        Width = 100,
                        Height = 150
                    };
                    ButtonArray[Num].Button.Click += new EventHandler(this.ClickedCard);
                    ButtonArray[Num].Type = Types[Num];

                    GridPanel.Controls.Add(ButtonArray[Num].Button);
                    Num++;
                }
            }
        }

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
                            if(string.IsNullOrEmpty(SecondUsernameBox.Text))
                            {
                                FirstButton.Succes = true;
                                secondButton.Succes = true;
                                new SoundPlayer(Properties.Resources.CorrectCardsCombined).Play();
                            }
                            else
                            {
                                if(MultiplayerTurn.Text == PlayerOneNameLabel.Text)
                                {
                                    PlayerOne.Memories++;
                                }
                                else
                                {
                                    PlayerTwo.Memories++;
                                }
                                new SoundPlayer(Properties.Resources.CorrectCardsCombined).Play();
                                FirstButton.Succes = true;
                                secondButton.Succes = true;
                                LabelMemoriesPlayer1.Text = PlayerOne.Memories.ToString();
                                LabelMemoriesPlayer2.Text = PlayerTwo.Memories.ToString();  
                            }
                            WinCondition++;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(SecondUsernameBox.Text))
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
                                
                                if(MultiplayerTurn.Text == PlayerOneNameLabel.Text)
                                {
                                    PlayerOne.Sets++;
                                    MultiplayerTurn.Text = PlayerTwoNameLabel.Text;
                                    
                                }
                                else
                                {
                                    PlayerTwo.Sets++;
                                    MultiplayerTurn.Text = PlayerOneNameLabel.Text; 
                                }
                                LabelSetsPlayer1.Text = PlayerOne.Sets.ToString();
                                LabelSetsPlayer2.Text = PlayerTwo.Sets.ToString();
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
            string[] savelines = new string[50];

            foreach (MemoryButton but in ButtonArray)
            {
                savelines[count] = Convert.ToString(but.Succes);

                savelines[count+ 16] = Convert.ToString((int)but.Type);
                count++;
            }

            savelines[32] = PlayerOneNameLabel.Text;
            savelines[33] = PlayerTwoNameLabel.Text;
            savelines[34] = Convert.ToString(PlayerOne.Sets);
            savelines[35] = Convert.ToString(PlayerOne.Memories);
            savelines[36] = Convert.ToString(PlayerTwo.Sets);
            savelines[37] = Convert.ToString(PlayerTwo.Memories);
            savelines[38] = MultiplayerTurn.Text;

            count = 40;

            foreach(Score score in Scores)
            {
                savelines[count] = score.Name;

                savelines[count+5] = (score.Sets).ToString();
                count++;
            }

            for (int i = 0; i < savelines.Length; i++)
            {
               savelines[i] = Encryption.Encrypt(savelines[i], "MemGamePass");
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

            PlayerOne.Sets = 0;
            LabelSetsPlayer1.Text = "0";
            PlayerTwo.Sets = 0;
            LabelSetsPlayer2.Text = "0";
            PlayerOne.Memories = 0;
            LabelMemoriesPlayer1.Text = "0";
            PlayerTwo.Memories = 0;
            LabelMemoriesPlayer2.Text = "0";
            MultiplayerTurn.Text = PlayerOneNameLabel.Text;
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

        private void LoadGame(object sender, EventArgs e)
        {
            HideAll();
            StartGame(this, new EventArgs());

            string[] loadlines = File.ReadAllLines("memory.sav");

            for (int i = 0; i < loadlines.Length; i++)
            {
                loadlines[i] = Encryption.Decrypt(loadlines[i], "MemGamePass");
            }
            
            for (int i = 0; i < 16; i++)
            {
                ButtonArray[i].Type = (MemoryType)Convert.ToInt32(loadlines[i + 16]);
                ButtonArray[i].Succes = loadlines[i] == "True" ? true : false;
                if (ButtonArray[i].Succes)
                {
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
                }
            }
            PlayerOneNameLabel.Text = loadlines[32];
            PlayerTwoNameLabel.Text = loadlines[33];
            PlayerOne.Sets = Convert.ToInt32(loadlines[34]);
            LabelSetsPlayer1.Text = loadlines[34];
            PlayerOne.Memories = Convert.ToInt32(loadlines[35]);
            LabelMemoriesPlayer1.Text = loadlines[35];
            PlayerTwo.Sets = Convert.ToInt32(loadlines[36]);
            LabelSetsPlayer2.Text = loadlines[36];
            PlayerTwo.Memories = Convert.ToInt32(loadlines[37]);
            LabelMemoriesPlayer2.Text = loadlines[37];
            MultiplayerTurn.Text = loadlines[38];

            int count = 40;
            foreach (Score score in Scores)
            {
                score.Name = loadlines[count];
                score.Sets = Convert.ToInt32(loadlines[count + 5]);
                count++;
            }
            CreateHighscores();
        }

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
                    newScore.SetNewScore(PlayerOneNameLabel.Text, Sets);
                    SortHighscores();
                }
                return;
            }
            
            Score score = new Score(
                 new Panel() { Size = new Size(500, 50)},
                 new Label() { Text = "Name = " + PlayerOneNameLabel.Text, Location = new Point(0, 0) },
                 new Label() { Text = "Sets = " + Sets , Location = new Point(100, 0) },
                 PlayerOneNameLabel.Text,
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
            PlayerOneNameLabel.Visible = true;
            PlayerTwoNameLabel.Visible = true;
            MultiplayerTurn.Visible = true;
            ResetButton.Visible = true;

            if (PlayerTwoNameLabel.Text == string.Empty)
            {
                MultiplayerTurn.Visible = false;                
            }
            else
            {
                MultiplayerTurn.Text = PlayerOneNameLabel.Text;
                BeurtSpeler.Visible = true;
                SetsLabel.Visible = false;
                LabelSet1.Visible = true;
                LabelSet2.Visible = true;
                LabelMemories1.Visible = true;
                LabelMemories2.Visible = true;
                LabelSetsPlayer1.Visible = true;
                LabelSetsPlayer2.Visible = true;
                LabelMemoriesPlayer1.Visible = true;
                LabelMemoriesPlayer2.Visible = true;
            }
        }

        public void Back(object sender, EventArgs e)
        {
            HideAll();
            MainPanel.Visible = true;
            MainPanel.Location = new Point(0, 0);
        }

        private void HideAll()
        {
            MenuSound.URL = pathMenu;

            MainPanel.Visible = false;
            ResetButton.Visible = false;
            HighscoresPanel.Visible = false;
            SetsLabel.Visible = false;
            OptionsPanel.Visible = false;
            PlayerOneNameLabel.Visible = false;
            PlayerTwoNameLabel.Visible = false;
            MultiplayerTurn.Visible = false;
            BeurtSpeler.Visible = false;
            //lan
            LabelSet1.Visible = false;
            LabelSet2.Visible = false;
            LabelMemories1.Visible = false;
            LabelMemories2.Visible = false;
            LabelSetsPlayer1.Visible = false;
            LabelSetsPlayer2.Visible = false;
            LabelMemoriesPlayer1.Visible = false;
            LabelMemoriesPlayer2.Visible = false;
            
        }

        public void QuitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void SetUsernameTwo(object sender, EventArgs e)
        {
            PlayerTwoNameLabel.Text = SecondUsernameBox.Text;
        }

        public void SetUsername(object sender, EventArgs e)
        {
            PlayerOneNameLabel.Text = FirstUsernameBox.Text;
        }


        #endregion

        private void OnVolumeChanged(object sender, EventArgs e)
        {
            int volume = 0;
            Int32.TryParse(SoundComboBox.Text, out volume);
            Console.WriteLine(volume);
            BackgroundSound.settings.volume = volume;            
        }

        private void OnSFXVolumeChanged(object sender, EventArgs e)
        {
            int sfxVolume = 0;
            Int32.TryParse(SetSFXVolume.Text, out sfxVolume);
            Console.WriteLine(sfxVolume);
            MenuSound.settings.volume = sfxVolume;
            Succes.settings.volume = sfxVolume;
            Fail.settings.volume = sfxVolume;
        }
    }
}
