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

namespace MemoryGame
{
    public partial class MainPage : Form
    {
        internal const int MemoryItems = 16;
        internal int Sets = 0;
        internal MemoryButton[] ButtonArray = new MemoryButton[MemoryItems];
        internal MemoryButton FirstButton;
        
        internal MemoryType[] Types = new MemoryType[MemoryItems];
        internal SoundPlayer SoundPlayer;

        int num = 0;

        public MainPage()
        {
            InitializeComponent();
            
            SoundPlayer = new SoundPlayer(Properties.Resources.ClickButton);
            //SoundPlayer.Load();
            //SoundPlayer.Play();
            MainPanel.Location = new Point(0, 0);
            StartGameButton.Click += new EventHandler(this.StartGame);
            HighscoresButton.Click += new EventHandler(this.OpenHighScores);
            OptionsButton.Click += new EventHandler(this.OpenOptions);
            ExitButton.Click += new EventHandler(this.QuitGame);

            BackToMainButton01.Click += new EventHandler(this.Back);
            BackToMainButton02.Click += new EventHandler(this.Back);
            BackToMainButton03.Click += new EventHandler(this.Back);

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

            for (int i = 0; i < ButtonArray.Length; i++)
            {
                ButtonArray[i] = new MemoryButton();
            }
           
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ButtonArray[num].Button = new Button() { Text = null,
                        BackColor = Color.Gray,
                        BackgroundImage = Properties.Resources.BS,
                        Width = 125, Height = 125, };
                        ButtonArray[num].Button.Click += new EventHandler(this.ClickedCard);
                        ButtonArray[num].Type = Types[num];

                    GridPanel.Controls.Add(ButtonArray[num].Button);
                    num++;
                }  
            }    
        }

        public void OpenHighScores(object sender, EventArgs e)
        {
            SoundPlayer.Play();
            MainPanel.Visible = false;
            HighscoresPanel.Visible = true;
            HighscoresPanel.Location = new Point(0, 0);
        }

        public void OpenOptions(object sender, EventArgs e)
        {
            SoundPlayer.Play();
            MainPanel.Visible = false;
            OptionsPanel.Visible = true;
            OptionsPanel.Location = new Point(0, 0);
        }

        public void StartGame(object sender, EventArgs e)
        {
            MainPanel.Visible  = false;
            SetsLabel.Visible = true;
        }

        public void Back(object sender, EventArgs e)
        {
            SoundPlayer = new SoundPlayer(Properties.Resources.ClickButton);
            //SoundPlayer.Load();
            SoundPlayer.Play();

            HighscoresPanel.Visible = false;
            SetsLabel.Visible = false;
            OptionsPanel.Visible = false;
            MainPanel.Visible = true;
            MainPanel.Location = new Point(0, 0);
        }

        public void QuitGame(object sender, EventArgs e)
        {
            Application.Exit();
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
                    ButtonArray[i].Button.BackColor = Color.MediumVioletRed;
                    ButtonArray[i].Button.Text = ButtonArray[i].Type.ToString();

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
                            FirstButton.Button.BackColor = Color.Yellow;
                            FirstButton.Button = null;
                            secondButton.Button.BackColor = Color.Yellow;
                            secondButton.Button = null;
                        }
                        else
                        {
                            secondButton.Button.BackColor = Color.Gray;
                            secondButton.Button.Text = string.Empty;
                            FirstButton.Button.BackColor = Color.Gray;
                            FirstButton.Button.Text = string.Empty;
                        }
                        FirstButton = null;
                    }
                    SetsLabel.Text = ((Sets+1)/2).ToString();
                    Sets++;
                    break;
                }
            }            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {

        }
       
    }
}
