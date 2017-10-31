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

        //lan multiplayer.
        PlayerVars PlayerOne = new PlayerVars();
        PlayerVars PlayerTwo = new PlayerVars();

        private int Sets, WinCondition, Num = 0;

        //sound variables.
        private WindowsMediaPlayer BackgroundSound, MenuSound, Succes, Fail = null;
        private string path, pathMenu, pathSucces, pathFail = String.Empty;

        #endregion

        public MainPage()
        {
            InitializeComponent();
            //alle URLS van de geluiden ophalen.
            path = Path.GetFullPath(@"..\..\Resources/BackgroundMusic.wav");
            pathMenu = Path.GetFullPath(@"..\..\Resources/MenuClick.wav");
            pathSucces = Path.GetFullPath(@"..\..\Resources/CorrectCardsCombined.wav");
            pathFail = Path.GetFullPath(@"..\..\Resources/Fail.wav");

            //de windows media players initialiseren voor de geluiden.
            BackgroundSound = new WindowsMediaPlayer();
            MenuSound = new WindowsMediaPlayer();
            Succes = new WindowsMediaPlayer();
            Fail = new WindowsMediaPlayer();

            //de path van de backgroundsound setten en loopend maken.
            BackgroundSound.URL = path;
            BackgroundSound.settings.setMode("loop", true);            

            //de locatie van de main panel setten.
            MainPanel.Location = new Point(0, 0);

            //wanneer je op een knop drukt wordt wat hierin staat aanroepen ().                                  
            NewGameButton.Click += new EventHandler(this.NewGame);
            HighscoresButton.Click += new EventHandler(this.OpenHighScores);
            OptionsButton.Click += new EventHandler(this.OpenOptions);
            ExitButton.Click += new EventHandler(this.QuitGame);
            LoadGameButton.Click += new EventHandler(this.LoadGame);
            BackToMainButton01.Click += new EventHandler(this.Back);
            BackToMainButton02.Click += new EventHandler(this.Back);
            BackToMainButton03.Click += new EventHandler(this.Back);

            //de functie aanroepen om de kaarten te maken.
            CreateCards(true);

            //het save bestand maken als hij nog niet bestaat.
            if (!File.Exists("memory.sav"))
            {
                var stream1 = File.Create("memory.sav");
                stream1.Close();
            }
        }

        #region CardFunctions
        private void CreateCards(bool shuffleCards)
        {
            //Als shufflecards true is de kaarten randomizen.
            if(shuffleCards) RandomizeCards();

            //16 memory buttons aanmaken zodat we daar de kaarten in kunnen verwerken.
            for (int i = 0; i < MemoryItems; i++)
            {
                ButtonArray[i] = new MemoryButton();
            }

            for (int i = 0; i < MemoryItems; i++)
            {
                //Een button aanmaken zodat je op de kaarten kan klikken.
                ButtonArray[Num].Button = new Button()
                {                    
                    Text = null,
                    BackColor = Color.Gray,
                    //de background image van de kaart setten.
                    BackgroundImage = CardBackgroundImage,
                    //de grote setten van de kaart.
                    Width = 100,
                    Height = 150
                };
                //Wanneer er op de kaart geklikt word de functie clicked kaart aanroepen.
                ButtonArray[Num].Button.Click += new EventHandler(this.ClickedCard);
                //de type van de kaart setten en de image.
                ButtonArray[Num].SetCardType(Types[Num]);
                //de kaarten toevoegen aan de grid.
                GridPanel.Controls.Add(ButtonArray[Num].Button);
                Num++;            
            }
        }       

        public void ClickedCard(object sender, EventArgs e)
        {                   
            for (int i = 0; i < MemoryItems; i++)
            {
                //checken of je niet op de al geklikte knop drukt.
                if(FirstButton != null)
                    if(sender == FirstButton.Button)
                        break;

                //Als je de knop gevonden hebt waar je op geklikt hebt.
                if (sender == ButtonArray[i].Button)
                {
                    //Als hij al een memory is, niks doen.
                    if (ButtonArray[i].Succes) return;

                    //De kaart omdraaien/ het plaatje laten zien.
                    ButtonArray[i].Button.BackgroundImage = ButtonArray[i].Image;
                    
                    if (FirstButton == null)//check of er al een eerste kaart is geselecteerd.
                    {
                        FirstButton = ButtonArray[i];//set de kaart als eerst geklikte button.
                    }
                    else if(FirstButton != null)
                    {
                        //set de kaart als tweede geklikte button.
                        MemoryButton secondButton = ButtonArray[i];

                        //1 seconden wachten om te laten zien welke kaart er geklikt is.
                        var t = Task.Run(async delegate
                        {
                            await Task.Delay(TimeSpan.FromSeconds(1));
                        });
                        t.Wait();

                        //als de beide kaarten hetzelfde type hebben.
                        if (FirstButton.Type == secondButton.Type)
                        {                            
                            if(!string.IsNullOrEmpty(SecondUsernameBox.Text))//als het multiplayer.
                            {
                                if (MultiplayerTurn.Text == PlayerOneNameLabel.Text)//Als het player 1 is verhoog zijn memories met 1.
                                {
                                    PlayerOne.Memories++;
                                }
                                else//Als het player 2 is verhoog zijn memories met 1.
                                {
                                    PlayerTwo.Memories++;
                                }
                                //Als het player 1 is verhoog zijn memories met 1.
                                LabelMemoriesPlayer1.Text = PlayerOne.Memories.ToString();
                                LabelMemoriesPlayer2.Text = PlayerTwo.Memories.ToString();
                            }

                            //de kaarten op succes zetten zodat we weten dat het een memory is.
                            FirstButton.Succes = true;
                            secondButton.Succes = true;
                            //het succes geluid afspelen.
                            new SoundPlayer(Properties.Resources.CorrectCardsCombined).Play();
                            
                            WinCondition++;    
                        }
                        else//als de type van de kaarten niet gelijk zijn.
                        {
                            //Speel de fail sound
                            new SoundPlayer(Properties.Resources.Fail).Play();
                            //de image van de kaarten terug zetten naar de achterkant van de kaart.
                            secondButton.Button.BackgroundImage = FirstButton.Button.BackgroundImage = CardBackgroundImage;

                            //als het multiplayer is.
                            if (!string.IsNullOrEmpty(SecondUsernameBox.Text))
                            {
                                if (MultiplayerTurn.Text == PlayerOneNameLabel.Text)// als het player 1 is zijn set verhogen en de turn overgeven aan player2.
                                {
                                    PlayerOne.Sets++;
                                    LabelSetsPlayer1.Text = PlayerOne.Sets.ToString();
                                    MultiplayerTurn.Text = PlayerTwoNameLabel.Text;
                                }
                                else// als het player 2 is zijn set verhogen en de turn overgeven aan player1.
                                {
                                    PlayerTwo.Sets++;
                                    LabelSetsPlayer2.Text = PlayerTwo.Sets.ToString();
                                    MultiplayerTurn.Text = PlayerOneNameLabel.Text;
                                }
                            }
                        }
                        //first button null maken zodat je kan proberen de volgende memory te maken.
                        FirstButton = null;
                    }
                    //De sets label setten en de set verhogen
                    SetsLabel.Text = ((Sets+1)/2).ToString();
                    Sets++;
                    if (WinCondition == 8)// als je alle kaarten als memory hebt de game complete functie callen.
                    {
                        OnGameCompleted();
                    }
                    break;
                }
            }
            Save(); // de kaarten saven. Dit gebeurd elke keer als laatste in de ClickedCard functie.
        }

        private void Save()
        {
            //50 lines maken om data in op te slaan.
            string[] savelines = new string[50];

            for(int i = 0; i < MemoryItems; i++)
            {//MemoryButton data setten.
                savelines[i] = Convert.ToString(ButtonArray[i].Succes);
                savelines[i + 16] = Convert.ToString((int)ButtonArray[i].Type);
            }
            //ingame data setten.
            savelines[32] = PlayerOneNameLabel.Text;
            savelines[33] = PlayerTwoNameLabel.Text;
            savelines[34] = Convert.ToString(PlayerOne.Sets);
            savelines[35] = Convert.ToString(PlayerOne.Memories);
            savelines[36] = Convert.ToString(PlayerTwo.Sets);
            savelines[37] = Convert.ToString(PlayerTwo.Memories);
            savelines[38] = MultiplayerTurn.Text;

            int count = 40;

            foreach(Score score in ScoresSingle)//highscore data setten.
            {
                savelines[count] = score.Name;
                savelines[count+5] = (score.Sets).ToString();
                count++;
            }

            //alle save data encrypten.
            for(int i = 0; i < savelines.Length; i++)
            {
               savelines[i] = Encryption.Encrypt(savelines[i], "MemGamePass");
            }
            //de Data opslaan in een .sav bestand.
            File.WriteAllLines("memory.sav", savelines);
        }

        private void RandomizeCards() //de Type kaarten in random order zetten.(Deck shuffle idee)
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

            //random rnd word hier aangemaakt.
            Random rnd = new Random();
            Types = Types.OrderBy(x => rnd.Next()).ToArray();
        }

        private void Reset(object sender, EventArgs e)
        {
            CreateHighscores();
            //de kaarten randomize wanneer op reset klikt.(Deck shuffle idee)
            RandomizeCards();
            for (int i = 0; i < MemoryItems; i++)
            {
                ButtonArray[i].Button.BackgroundImage = CardBackgroundImage;
                ButtonArray[i].Succes = false;
                ButtonArray[i].SetCardType(Types[i]);
                Sets = 0;
                SetsLabel.Text = "0";
            }
            //alle game data resetten naar default settings.
            WinCondition = PlayerOne.Sets = PlayerTwo.Sets = PlayerOne.Memories = PlayerTwo.Memories = 0;


            LabelSetsPlayer2.Text = LabelSetsPlayer1.Text = LabelMemoriesPlayer1.Text = LabelMemoriesPlayer2.Text = "0";

            MultiplayerTurn.Text = PlayerOneNameLabel.Text;
        }

        /// <summary>
        /// wanneer je alle memory's hebt naar highscores gaan en highscores maken
        /// </summary>
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
            //hide alle menu's en de juiste menu openen.
            HideAll();

            SetsLabel.Visible = true;
            PlayerOneNameLabel.Visible = true;
            PlayerTwoNameLabel.Visible = true;
            ResetButton.Visible = true;
            string[] loadlines = File.ReadAllLines("memory.sav");
            
            //alle data decrypten.
            for (int i = 0; i < loadlines.Length; i++)
            {
                loadlines[i] = Encryption.Decrypt(loadlines[i], "MemGamePass");
            }

            //alle data laden.
            for (int i = 0; i < 16; i++)
            {
                ButtonArray[i].SetCardType((MemoryType)Convert.ToInt32(loadlines[i + 16]));
                ButtonArray[i].Succes = loadlines[i] == "True" ? true : false;
                if (ButtonArray[i].Succes)
                {
                    ButtonArray[i].Button.BackgroundImage = ButtonArray[i].Image;
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

            int count1 = 40;

            foreach (Score score in ScoresSingle)
            {
                score.Name = loadlines[count1];
                count1++;
            }
            foreach (Score score in ScoresSingle)
            {
                score.Sets = Convert.ToInt32(loadlines[count1]);
                count1++;
            }
        }

        private void CreateHighscores()
        {
            if (string.IsNullOrEmpty(PlayerTwoNameLabel.Text) && ScoresSingle.Count >= 5)
            {
                //overschrijf laagste score en vervang deze met een nieuwe score.
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

                    SortHighscores();
                }
                return;
            }
            else if (ScoresMulti.Count >= 5)
            {
                //overschrijf laagste score en vervang deze met een nieuwe score.
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

                    SortHighscores();
                }
                return;                
            }

            if (!string.IsNullOrEmpty(PlayerTwoNameLabel.Text))
            {
                Multiscore newScore = new Multiscore
                {
                    ScoreOne = new Score(
                        new Panel() { Size = new Size(500, 50) },
                        new Label() { Text = "Name = " + PlayerOneNameLabel.Text, Location = new Point(0, 0) },
                        new Label() { Text = "Memories = " + PlayerOne.Memories, Location = new Point(100, 0) },
                        PlayerOneNameLabel.Text,
                        PlayerOne.Memories),
                    ScoreTwo = new Score(
                        new Panel() { Size = new Size(500, 50) },
                        new Label() { Text = "Name = " + PlayerTwoNameLabel.Text, Location = new Point(200, 0) },
                        new Label() { Text = "Memories = " + PlayerTwo.Memories, Location = new Point(300, 0) },
                        PlayerTwoNameLabel.Text,
                        PlayerTwo.Memories)
                };

                newScore.SetPanel();
                ScoresMulti.Add(newScore);
            }
            else
            {
                //adds new highscore.
                Score score = new Score(
                     new Panel() { Size = new Size(500, 50) },
                     new Label() { Text = "Name = " + PlayerOneNameLabel.Text, Location = new Point(0, 0) },
                     new Label() { Text = "Sets = " + Sets, Location = new Point(100, 0) },
                     PlayerOneNameLabel.Text,
                     Sets);

                ScoresSingle.Add(score);
            }
            SortHighscores(); //sorteert de highscores zodat de hoogste score bovenaan staat en de laagste onderaan.
        }

        public void SortHighscores() // sorteer de highscores op score.
        {
            if (!string.IsNullOrEmpty(PlayerTwoNameLabel.Text))
            {
                MultiplayerHighscoresButton_Click(this, new EventArgs());
                MultiplayerHighscorePanel.Controls.Clear();
                ScoresMulti = ScoresMulti.OrderBy(p => p.ScoreOne.Sets).ToList();//sorteert de highscore op minst aantal sets(score).

                foreach (Multiscore setScore in ScoresMulti)
                {
                    MultiplayerHighscorePanel.Controls.Add(setScore.ScoreOne.ScorePanel);//de UI van de highscores toevoegen.
                    if(setScore.ScoreTwo != null)
                        MultiplayerHighscorePanel.Controls.Add(setScore.ScoreTwo.ScorePanel);//de UI van de highscores toevoegen.
                }
                return;
            }

            SingleplayerHighscoresButton_Click(this, new EventArgs());
            SingleHighscorePanel.Controls.Clear();
            ScoresSingle = ScoresSingle.OrderBy(p => p.Sets).ToList();//sorteert de highscore op minst aantal sets(score).

            foreach (Score setScore in ScoresSingle)
            {
                SingleHighscorePanel.Controls.Add(setScore.ScorePanel);//de UI van de highscores toevoegen.
            }
        }

        public void OpenHighScores(object sender, EventArgs e)
        {
            //open de highscores.
            HideAll();
            HighscoresPanel.Visible = true;
            HighscoresPanel.Location = new Point(0, 0);
        }

        private void SingleplayerHighscoresButton_Click(object sender, EventArgs e)
        {
            SingleHighscorePanel.Visible = true;
            MultiplayerHighscorePanel.Visible = false;
        }

        private void MultiplayerHighscoresButton_Click(object sender, EventArgs e)
        {
            SingleHighscorePanel.Visible = false;
            MultiplayerHighscorePanel.Visible = true;
        }

        public void OpenOptions(object sender, EventArgs e)
        {
            // open de options menu.
            HideAll();
            MainPanel.Visible = false;
            OptionsPanel.Visible = true;
            OptionsPanel.Location = new Point(0, 0);
        }

        public void NewGame(object sender, EventArgs e)
        {
            //alle menu's hiden.
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

        public void Back(object sender, EventArgs e)
        {
            HideAll();
            MainPanel.Visible = true;
            MainPanel.Location = new Point(0, 0);
        }

        /// <summary>
        /// Hide alle ui elementen
        /// </summary>
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

        private void OnVolumeChanged(object sender, EventArgs e)
        {
            //standart the volume starts at 100%.
            int volume = 0;
            Int32.TryParse(SoundComboBox.Text, out volume); //here we set the volume to the selected volume by the player.
            Console.WriteLine(volume);
            BackgroundSound.settings.volume = volume;

        }

        private void OnSFXVolumeChanged(object sender, EventArgs e)
        {
            //standart the sfxvolume starts at 100%.
            int sfxVolume = 0;
            Int32.TryParse(SetSFXVolume.Text, out sfxVolume);//here we set the sfxvolume to the selected volume by the player.
            Console.WriteLine(sfxVolume);
            MenuSound.settings.volume = sfxVolume;
            Succes.settings.volume = sfxVolume;
            Fail.settings.volume = sfxVolume;
        }

        #endregion
    }
}
