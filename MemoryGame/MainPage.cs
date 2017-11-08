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
using System.Reflection;
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
        private List<Score> ScoresSingle = new List<Score>();
        private List<Multiscore> ScoresMulti = new List<Multiscore>();

        private System.Drawing.Image CardBackgroundImage = Properties.Resources.BS;
        
        PlayerVars PlayerOne = new PlayerVars();
        PlayerVars PlayerTwo = new PlayerVars();

        private string[] LoadLines;
        private int Sets, WinCondition, Num = 0;
        
        private WindowsMediaPlayer BackgroundSound, MenuSound, Succes, Fail = null;
        private string path, pathMenu, pathSucces, pathFail = String.Empty;

        #endregion
        /// <summary>
        /// Laad alle geluiden en initialiseer de bijbehorende WindowsMediaPlayers.
        /// Set de background muziek op looping.
        /// MainPanel op 0.0 setten.
        /// Alle menu knoppen aan een onclick eventhandler hangen.
        /// Daarna de kaarten maken en checken of er al een save file bestaat zo niet maakt hij er één.
        /// </summary>
        /// Gemaakt door Casper, Keanu en Pim.
        public MainPage()
        {
            InitializeComponent();

            path = Path.GetFullPath(@"Sounds/BackgroundMusic.wav");
            pathMenu = Path.GetFullPath(@"Sounds/MenuClick.wav");
            pathSucces = Path.GetFullPath(@"Sounds/CorrectCardsCombined.wav");
            pathFail = Path.GetFullPath(@"Sounds/Fail.wav");
            
            BackgroundSound = new WindowsMediaPlayer();
            MenuSound = new WindowsMediaPlayer();
            Succes = new WindowsMediaPlayer();
            Fail = new WindowsMediaPlayer();
            
            BackgroundSound.URL = path;
            BackgroundSound.settings.setMode("loop", true);            
            
            MainPanel.Location = new Point(0, 0);
                            
            NewGameButton.Click += new EventHandler(this.NewGame);
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
            else
            {
                LoadLines = File.ReadAllLines("memory.sav");
                if (LoadLines.Length <= 0)
                    return;

                for (int i = 0; i < LoadLines.Length; i++)
                {
                    LoadLines[i] = Encryption.Decrypt(LoadLines[i], "MemGamePass");
                }
                LoadHighScores(LoadLines);
            }
        }

        #region CardFunctions
        /// <summary>
        /// Wanneer shuffleCards true is alle kaarten randomizen.
        /// 16 memory buttons aanmaken zodat we daar de informatie van de kaarten in kunnen verwerken.
        /// Daarna maken we alle buttons en hangen we een eventhandler aan de onclick van de kaart zodat hij clickedcard aanroept wanneer erop geklikt is.
        /// Daarna adden we deze knop aan de grid panel.
        /// </summary>
        /// <param name="shuffleCards"></param>
        /// Gemaakt door Keanu.
        private void CreateCards(bool shuffleCards)
        {
            if(shuffleCards) RandomizeCards();
            
            for (int i = 0; i < MemoryItems; i++)
            {
                ButtonArray[i] = new MemoryButton();
            }

            for (int i = 0; i < MemoryItems; i++)
            {
                ButtonArray[Num].Button = new Button()
                {                    
                    Text = null,
                    BackColor = Color.Gray,
                    BackgroundImage = CardBackgroundImage,
                    Width = 100,
                    Height = 150
                };
                ButtonArray[Num].Button.Click += new EventHandler(this.ClickedCard);
                ButtonArray[Num].SetCardType(Types[Num]);
                GridPanel.Controls.Add(ButtonArray[Num].Button);
                Num++;            
            }
        }

        /// <summary>
        /// Wanneer er op een kaart gelikte word checken welke kaart het is wanneer het dezelfde kaart is als FirstButton niks doen.
        /// Wanneer er op een andere kaart geklikt word kijken of hij al een memory is,
        /// Ondertussen word de kaart gedraaid en word hij voor 1 seconden vertoond.
        /// zo niet dan kijken of het t zelfde type heeft als eerste geselecteerde kaart.
        /// Wanneer beide kaarten hetzelde type hebben maak het een memory en speel t memory geluidje af.
        /// Elke keer dat er een kaart omgedraaid word ook de hele game gesaved.
        /// Als alle kaarten een memory zijn Call function OnGameFinished.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Gemaakt door Bart en Keanu.
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
                    
                    ButtonArray[i].Button.BackgroundImage = ButtonArray[i].Image;
                    
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
                            if(!string.IsNullOrEmpty(SecondUsernameBox.Text))
                            {
                                if (MultiplayerTurn.Text == PlayerOneNameLabel.Text)
                                {
                                    PlayerOne.Memories++;
                                }
                                else
                                {
                                    PlayerTwo.Memories++;
                                }
                                LabelMemoriesPlayer1.Text = PlayerOne.Memories.ToString();
                                LabelMemoriesPlayer2.Text = PlayerTwo.Memories.ToString();
                            }
                            
                            FirstButton.Succes = true;
                            secondButton.Succes = true;
                            new SoundPlayer(Properties.Resources.CorrectCardsCombined).Play();
                            
                            WinCondition++;    
                        }
                        else
                        {
                            new SoundPlayer(Properties.Resources.Fail).Play();
                            secondButton.Button.BackgroundImage = FirstButton.Button.BackgroundImage = CardBackgroundImage;
                            
                            if (!string.IsNullOrEmpty(SecondUsernameBox.Text))
                            {
                                if (MultiplayerTurn.Text == PlayerOneNameLabel.Text)
                                {
                                    PlayerOne.Sets++;
                                    LabelSetsPlayer1.Text = PlayerOne.Sets.ToString();
                                    MultiplayerTurn.Text = PlayerTwoNameLabel.Text;
                                }
                                else
                                {
                                    PlayerTwo.Sets++;
                                    LabelSetsPlayer2.Text = PlayerTwo.Sets.ToString();
                                    MultiplayerTurn.Text = PlayerOneNameLabel.Text;
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

        /// <summary>
        /// Er worden 50 savelines gemaakt om de game data in op te slaan.
        /// Hier worden alle knoppen en highscores opgeslagen.
        /// Wanneer dat klaar is word alles encrypted.
        /// </summary>
        /// Gemaakt door Pim.
        private void Save()
        {
            string[] savelines = new string[100];

            for(int i = 0; i < MemoryItems; i++)
            {
                savelines[i] = Convert.ToString(ButtonArray[i].Succes);
                savelines[i + 16] = Convert.ToString((int)ButtonArray[i].Type);
            }
            savelines[32] = PlayerOneNameLabel.Text;
            savelines[33] = PlayerTwoNameLabel.Text;
            savelines[34] = Convert.ToString(PlayerOne.Sets);
            savelines[35] = Convert.ToString(PlayerOne.Memories);
            savelines[36] = Convert.ToString(PlayerTwo.Sets);
            savelines[37] = Convert.ToString(PlayerTwo.Memories);
            savelines[38] = MultiplayerTurn.Text;
            savelines[39] = Sets.ToString();

            int count = 40;

            foreach(Score score in ScoresSingle)
            {
                savelines[count] = score.Name;
                savelines[count+5] = (score.Sets).ToString();
                count++;
            }

            count = 55;

            foreach (Multiscore score in ScoresMulti)
            {
                savelines[count] = score.ScoreOne.Name;
                savelines[count + 10] = (score.ScoreOne.Sets).ToString();
                count++;
                savelines[count] = score.ScoreTwo.Name;
                savelines[count + 10] = (score.ScoreTwo.Sets).ToString();
                count++;
            }
            
            for(int i = 0; i < savelines.Length; i++)
            {
               savelines[i] = Encryption.Encrypt(savelines[i], "MemGamePass");
            }
            File.WriteAllLines("memory.sav", savelines);
        }

        /// <summary>
        /// de Type kaarten in random order zetten.(Deck shuffle idee)
        /// </summary>
        /// Gemaakt door Keanu.
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

        /// <summary>
        /// de kaarten randomize wanneer je op reset klikt.(Deck shuffle idee)
        /// alle game data resetten naar default settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Gemaakt door Pim.
        private void Reset(object sender, EventArgs e)
        {
            WinCondition = 0;
            RandomizeCards();
            for (int i = 0; i < MemoryItems; i++)
            {
                ButtonArray[i].Button.BackgroundImage = CardBackgroundImage;
                ButtonArray[i].Succes = false;
                ButtonArray[i].SetCardType(Types[i]);
                Sets = 0;
                SetsLabel.Text = "0";
            }
            WinCondition = PlayerOne.Sets = PlayerTwo.Sets = PlayerOne.Memories = PlayerTwo.Memories = 0;
            
            LabelSetsPlayer2.Text = LabelSetsPlayer1.Text = LabelMemoriesPlayer1.Text = LabelMemoriesPlayer2.Text = "0";

            MultiplayerTurn.Text = PlayerOneNameLabel.Text;
        }

        /// <summary>
        /// wanneer je alle memory's hebt naar highscores gaan en highscores maken
        /// </summary>
        /// Gemaakt door Bart.
        private void OnGameCompleted()
        {
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

        /// <summary>
        /// Hide alle menu's.
        /// Decrypt de save file, laad highscore en game data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Gemaakt door Pim.
        private void LoadGame(object sender, EventArgs e)
        {
            HideAll();

            SetsLabel.Visible = true;
            PlayerOneNameLabel.Visible = true;
            PlayerTwoNameLabel.Visible = true;
            ResetButton.Visible = true;
            
            for (int i = 0; i < 16; i++)
            {
                ButtonArray[i].SetCardType((MemoryType)Convert.ToInt32(LoadLines[i + 16]));
                ButtonArray[i].Succes = LoadLines[i] == "True" ? true : false;
                if (ButtonArray[i].Succes)
                {
                    ButtonArray[i].Button.BackgroundImage = ButtonArray[i].Image;
                }
            }

            PlayerOneNameLabel.Text = LoadLines[32];
            PlayerTwoNameLabel.Text = LoadLines[33];
            PlayerOne.Sets = Convert.ToInt32(LoadLines[34]);
            LabelSetsPlayer1.Text = LoadLines[34];
            PlayerOne.Memories = Convert.ToInt32(LoadLines[35]);
            LabelMemoriesPlayer1.Text = LoadLines[35];
            PlayerTwo.Sets = Convert.ToInt32(LoadLines[36]);
            LabelSetsPlayer2.Text = LoadLines[36];
            PlayerTwo.Memories = Convert.ToInt32(LoadLines[37]);
            LabelMemoriesPlayer2.Text = LoadLines[37];
            MultiplayerTurn.Text = LoadLines[38];
            int.TryParse(LoadLines[39], out Sets);
            SetsLabel.Text = (Sets/ 2).ToString();
        }

        /// <summary>
        /// Load highscores.
        /// </summary>
        private void LoadHighScores(string[] LoadLines)
        {
            int count = 40;

            if (ScoresSingle.Count >= 1)
            {
                for (int i = 0; i < 5; i++)
                {
                    Score newScore = CreateScorePanel(LoadLines[count], Convert.ToInt32(LoadLines[count + 5]), "Sets", 0);

                    ScoresSingle.Add(newScore);
                    count++;
                }
            }

            count = 55;

            for (int i = 0; i < 5; i++)
            {
                Multiscore newScore = new Multiscore
                {
                    ScoreOne = CreateScorePanel(LoadLines[count], Convert.ToInt32(LoadLines[count + 10]), "Memories", 0),
                    ScoreTwo = CreateScorePanel(LoadLines[count + 1], Convert.ToInt32(LoadLines[count + 11]), "Memories", 200)
                };
                newScore.SetPanel();
                ScoresMulti.Add(newScore);
                count += 2;
            }
            SortHighscores();
        }

        /// <summary>
        /// Het maken van de multiplayer en singleplayer highscores. 
        /// Wanneer er meer dan 5 highscores in de lijst zijn kijken of je beter hebt gescored dan de current highscores,
        /// Zo niet gebeurt er niks en zo wel override de laagste score.
        /// </summary>
        /// Gemaakt door Keanu.
        private void CreateHighscores()
        {
            if (string.IsNullOrEmpty(PlayerTwoNameLabel.Text))
            {
                if(ScoresSingle.Count >= 5)
                {
                    Score newScore = new Score();
                    for (int i = 0; i < ScoresSingle.Count; i++)
                    {
                        if (ScoresSingle[i].Sets >= Sets)
                        {
                            if (newScore.Name != string.Empty)
                            {
                                if (newScore.Sets >= ScoresSingle[i].Sets)
                                    newScore = ScoresSingle[i];
                            }
                            else
                            {
                                newScore = ScoresSingle[i];
                            }
                        }
                    }

                    if (newScore.Name != string.Empty)
                    {
                        newScore.SetNewScore(PlayerOneNameLabel.Text, Sets);                        
                    }
                }
                else
                {
                    Score score = CreateScorePanel(PlayerOneNameLabel.Text, Sets, "Sets", 0);
                    ScoresSingle.Add(score);
                }
            }
            else if (ScoresMulti.Count >= 5)
            {
                Score newScore = new Score();
                for (int i = 0; i < ScoresMulti.Count; i++)
                {
                    if (ScoresMulti[i].ScoreOne.Sets >= Sets)
                    {
                        if (newScore.Name != string.Empty)
                        {
                            if (newScore.Sets >= ScoresMulti[i].ScoreOne.Sets)
                                newScore = ScoresMulti[i].ScoreOne;
                        }
                        else
                        {
                            newScore = ScoresMulti[i].ScoreOne;
                        }
                    }
                }

                if (newScore.Name != string.Empty)
                {
                    newScore.SetNewScore(PlayerOneNameLabel.Text, Sets);                   
                }             
            }
            else
            {
                Multiscore newScore = new Multiscore
                {
                    ScoreOne = CreateScorePanel(PlayerOneNameLabel.Text, PlayerOne.Memories, "Memories", 0),
                    ScoreTwo = CreateScorePanel(PlayerTwoNameLabel.Text, PlayerTwo.Memories, "Memories", 200)
                };

                newScore.SetPanel();
                ScoresMulti.Add(newScore);
            }

            SortHighscores();
        }

        /// <summary>
        /// Het maken van een highcore paneel.
        /// en het returnen van de score class om het te kunnen opslaan of overriden.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="valueName"></param>
        /// <param name="addPos"></param>
        /// <returns></returns>
        /// Gemaakt door Keanu.
        private Score CreateScorePanel(string name, int value, string valueName ,int addPos)
        {
            Score score = new Score(
                     new Panel() { Size = new Size(500, 50) },
                     new Label() { Text = "Name = " + name, Location = new Point(0+ addPos, 0) },
                     new Label() { Text = valueName+" = " + value, Location = new Point(100 + addPos, 0) },
                     name,
                     value);

            return score;
        }

        /// <summary>
        /// Hier gooi je het paneel leeg en vult hem met een gesorteerde lijst.
        /// </summary>
        /// Gemaakt door Keanu.
        public void SortHighscores()
        {
            MultiplayerHighscoresButton_Click(this, new EventArgs());
            MultiplayerHighscorePanel.Controls.Clear();
            ScoresMulti = ScoresMulti.OrderBy(p => p.GetHighest().Sets).ToList();

            foreach (Multiscore setScore in ScoresMulti)
            {
                MultiplayerHighscorePanel.Controls.Add(setScore.ScoreOne.ScorePanel);
                if(setScore.ScoreTwo != null)
                    MultiplayerHighscorePanel.Controls.Add(setScore.ScoreTwo.ScorePanel);
            }

            SingleplayerHighscoresButton_Click(this, new EventArgs());
            SingleHighscorePanel.Controls.Clear();
            ScoresSingle = ScoresSingle.OrderBy(p => p.Sets).ToList();

            foreach (Score setScore in ScoresSingle)
            {
                SingleHighscorePanel.Controls.Add(setScore.ScorePanel);
            }
        }

        /// <summary>
        /// Het openen van de highscores.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Gemaakt door Keanu.
        public void OpenHighScores(object sender, EventArgs e)
        {
            //open de highscores.
            HideAll();
            HighscoresPanel.Visible = true;
            HighscoresPanel.Location = new Point(0, 0);
        }

        /// <summary>
        /// Singleplayer highscores zichtbaar maken.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Gemaakt door Keanu.
        private void SingleplayerHighscoresButton_Click(object sender, EventArgs e)
        {
            SingleHighscorePanel.Visible = true;
            MultiplayerHighscorePanel.Visible = false;
        }

        /// <summary>
        /// Multiplayer highscores zichtbaar maken.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Gemaakt door Keanu.
        private void MultiplayerHighscoresButton_Click(object sender, EventArgs e)
        {
            SingleHighscorePanel.Visible = false;
            MultiplayerHighscorePanel.Visible = true;
        }

        /// <summary>
        /// Hide alle andere menu's en laat options menu zien.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Gemaakt door Keanu.
        public void OpenOptions(object sender, EventArgs e)
        {
            HideAll();
            MainPanel.Visible = false;
            OptionsPanel.Visible = true;
            OptionsPanel.Location = new Point(0, 0);
        }

        /// <summary>
        /// Hide alle menu's en reset alle labels.
        /// zodra het multiplayer is alle multiplayer labels vertonen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Gemaakt door Keanu en Bart.
        public void NewGame(object sender, EventArgs e)
        {
            HideAll();

            WinCondition = PlayerOne.Sets = PlayerTwo.Sets = PlayerOne.Memories = PlayerTwo.Memories = 0;
            LabelSetsPlayer1.Text = LabelSetsPlayer2.Text = LabelMemoriesPlayer1.Text = LabelMemoriesPlayer2.Text = "0";

            MultiplayerTurn.Text = PlayerOneNameLabel.Text;
            SetsLabel.Visible = PlayerOneNameLabel.Visible = PlayerTwoNameLabel.Visible = MultiplayerTurn.Visible = ResetButton.Visible = true;

            if (PlayerTwoNameLabel.Text == string.Empty)
            {
                MultiplayerTurn.Visible = false;                
            }
            else
            {
                MultiplayerTurn.Text = PlayerOneNameLabel.Text;

                BeurtSpeler.Visible = LabelSet1.Visible = LabelSet2.Visible = LabelMemories1.Visible = LabelMemories2.Visible = 
                    LabelSetsPlayer1.Visible = LabelSetsPlayer2.Visible = LabelMemoriesPlayer1.Visible = LabelMemoriesPlayer2.Visible = true;

                SetsLabel.Visible = false;    
            }
        }

        /// <summary>
        /// Hide alle panelen en ga terug naar main menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Gemaakt door Keanu.
        public void Back(object sender, EventArgs e)
        {
            HideAll();
            MainPanel.Visible = true;
            MainPanel.Location = new Point(0, 0);
        }

        /// <summary>
        /// Hide alle ui elementen
        /// </summary>
        /// Gemaakt door Keanu.
        private void HideAll()
        {
            MenuSound.URL = pathMenu;

            MainPanel.Visible = ResetButton.Visible = HighscoresPanel.Visible = SetsLabel.Visible = 
                OptionsPanel.Visible = PlayerOneNameLabel.Visible = PlayerTwoNameLabel.Visible =
                MultiplayerTurn.Visible = BeurtSpeler.Visible = LabelSet1.Visible = 
                LabelSet2.Visible = LabelMemories1.Visible = LabelMemories2.Visible =
                LabelSetsPlayer1.Visible = LabelSetsPlayer2.Visible = LabelMemoriesPlayer1.Visible = 
                LabelMemoriesPlayer2.Visible = false;
        }

        /// <summary>
        /// Het spel afsluiten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Gemaakt door Keanu.
        public void QuitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Set de naam van de eerste speler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Gemaakt door Bart.
        public void SetUsername(object sender, EventArgs e)
        {
            PlayerOneNameLabel.Text = FirstUsernameBox.Text;
        }

        /// <summary>
        /// Set de naam van de tweede speler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Gemaakt door Bart.
        public void SetUsernameTwo(object sender, EventArgs e)
        {
            PlayerTwoNameLabel.Text = SecondUsernameBox.Text;
        }

        /// <summary>
        /// Volume van de muziek veranderen naar het getal dat in de Music combobox geset is.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Gemaakt door Casper.
        private void OnVolumeChanged(object sender, EventArgs e)
        {
            int volume = 0;
            Int32.TryParse(SoundComboBox.Text, out volume);
            Console.WriteLine(volume);
            BackgroundSound.settings.volume = volume;
        }

        /// <summary>
        /// Volume van de SFX veranderen naar het getal dat in de SFX combobox geset is.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Gemaakt door Casper.
        private void OnSFXVolumeChanged(object sender, EventArgs e)
        {
            int sfxVolume = 0;
            Int32.TryParse(SetSFXVolume.Text, out sfxVolume);
            Console.WriteLine(sfxVolume);
            MenuSound.settings.volume = sfxVolume;
            Succes.settings.volume = sfxVolume;
            Fail.settings.volume = sfxVolume;
        }

        #endregion
    }
    
}