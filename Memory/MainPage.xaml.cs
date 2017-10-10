using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;


namespace Memory
{
    public sealed partial class MainPage : Page
    {
        private const int MemoryItems = 16;
        MemoryButton[] ButtonArray = new MemoryButton[MemoryItems];
       
        MemoryType[] Types = new MemoryType[MemoryItems];
       
        public MainPage()
        {

            this.InitializeComponent();
 
            StartGameButton.Click += new RoutedEventHandler(this.StartGame);
            BackButton.Click += new RoutedEventHandler(this.Back);


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
                  
                    ButtonArray[num].Button = new Button() { Content = num,
                        Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255,155,155,155)),
                        Width = 125, Height = 125, };

                    ButtonArray[num].Button.Click += new RoutedEventHandler(this.ClickedCard);

                     // maak het type nog nog ff random
                    
                    ButtonArray[num].Type = Types[num];
                    Memory_Grid.Children.Add(ButtonArray[num].Button);

                    Grid.SetRow(ButtonArray[num].Button, i);
                    Grid.SetColumn(ButtonArray[num].Button, j);
                    num++;
                }
                
            }
        }

        public void StartGame(object sender, RoutedEventArgs e)
        {
            MainPanel.Visibility = Visibility.Collapsed;
        }

        public void Back(object sender, RoutedEventArgs e)
        {
            MainPanel.Visibility = Visibility.Visible;
        }

        public void ClickedCard(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < MemoryItems; i++)
            {
                if (sender == ButtonArray[i].Button)
                {
                    ButtonArray[i].Button.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 76, 103));
                    ButtonArray[i].Button.Content = ButtonArray[i].Type;
                    return;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Memory_Grid.Width = 1920;
        }
    }
}
