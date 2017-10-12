using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class MainPage : Form
    {
        internal const int MemoryItems = 16;
        internal int Sets = 0;
        internal MemoryButton[] ButtonArray = new MemoryButton[MemoryItems];
        internal MemoryButton FirstButton;
        internal MemoryButton SecondButton;
        
        internal MemoryType[] Types = new MemoryType[MemoryItems];

        public MainPage()
        {
            InitializeComponent();       

            StartGameButton.Click += new EventHandler(this.StartGame);
            BackButton.Click += new EventHandler(this.Back);

            for (int i =0; i < MemoryItems; i++)
            {
                
                Types[i] = (MemoryType)i;
                if (i >= 8)
                {
                    Types[i] = (MemoryType)i - MemoryItems/2;
                }
            }

            Random rnd = new Random();
            Types = Types.OrderBy(x => rnd.Next()).ToArray();

            for (int i = 0; i < ButtonArray.Length; i++)
            {
                ButtonArray[i] = new MemoryButton();
            }

            int num = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                  ButtonArray[num].Button = new Button() { Text = null,
                        BackColor = Color.Gray,
                        Width = 125, Height = 125, };
                        ButtonArray[num].Button.Click += new EventHandler(this.ClickedCard);
                        ButtonArray[num].Type = Types[num];

                    GridPanel.Controls.Add(ButtonArray[num].Button);
                    num++;
                }  
            }    
        }

        public void StartGame(object sender, EventArgs e)
        {
            MainPanel.Visible  = false;
            SetsLabel.Visible = true;
        }

        public void Back(object sender, EventArgs e)
        {
            MainPanel.Visible = true;
            SetsLabel.Visible = false;
        }
        
        public void ClickedCard(object sender, EventArgs e)
        {      
            for (int i = 0; i < MemoryItems; i++)
            {
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
                        SecondButton = ButtonArray[i];

                        var t = Task.Run(async delegate
                                {
                                    await Task.Delay(1000);
                                    FixCards();
                                });
                    }
                    SetsLabel.Text = ((Sets+1)/2).ToString();
                    Sets++;
                     break;
                }
            }            
        }

        void FixCards()
        {
            if (FirstButton.Type == SecondButton.Type)
            {
                FirstButton.Button.BackColor = Color.Yellow;
                SecondButton.Button.BackColor = Color.Yellow;
            }
            else
            {
                SecondButton.Button.BackColor = Color.Gray;
                SecondButton.Button.Text = string.Empty;
                FirstButton.Button.BackColor = Color.Gray;
                FirstButton.Button.Text = string.Empty;
            }
            FirstButton = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
