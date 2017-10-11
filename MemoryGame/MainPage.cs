using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class MainPage : Form
    {
        private const int MemoryItems = 16;
        public int Sets = 0;
        MemoryButton[] ButtonArray = new MemoryButton[MemoryItems];
        MemoryButton FirstButton;
        
        MemoryType[] Types = new MemoryType[MemoryItems];

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
        }

        public void Back(object sender, EventArgs e)
        {
            MainPanel.Visible = true;
        }
        
        //bart
        public void ClickedCard(object sender, EventArgs e)
        {      
            for (int i = 0; i < MemoryItems; i++)
            {
                if (sender == ButtonArray[i].Button)
                {
                    ButtonArray[i].Button.BackColor = Color.Red;
                    ButtonArray[i].Button.Text = ButtonArray[i].Type.ToString();
                    
                    if (FirstButton == null)
                    {
                        FirstButton = ButtonArray[i];
                    }
                    else if(FirstButton != null)
                    {
                        MemoryButton secondButton = ButtonArray[i];
                        if(FirstButton.Type == secondButton.Type)
                        {
                            FirstButton.Button.BackColor = Color.Yellow;
                            secondButton.Button.BackColor = Color.Yellow;                            
                        }
                        else
                        {
                            FirstButton.Button.BackColor = Color.Gray;
                            FirstButton.Button.Text = ((Sets+1)/2).ToString();
                            secondButton.Button.BackColor = Color.Gray;
                            secondButton.Button.Text = null;
                        }
                        FirstButton = null;
                    }
                    Sets++;
                    return;
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
