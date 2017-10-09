using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace Memory
{
    public sealed partial class MainPage : Page
    {
        private const int MemoryItems = 12;
        MemoryButton[] ButtonArray = new MemoryButton[MemoryItems];
        MemoryType[] Types = new MemoryType[MemoryItems];

        public MainPage()
        {
            this.InitializeComponent();

            for(int i =0; i < MemoryItems; i++)
            {
                Types[i] = (MemoryType)i;
                if (i >= 6)
                {
                    Types[i] = (MemoryType)i - MemoryItems/2;
                }
                System.Diagnostics.Debug.WriteLine(Types[i]);
            }

            for(int i = 0; i < ButtonArray.Length; i++)
            {
                ButtonArray[i] = new MemoryButton();
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ButtonArray[i].Button = new Button() { Content = i + j, Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255,155,155,155)),  Width = 125, Height = 125, };
                    
                    ButtonArray[i].Type = Types[i + j];
                    ButtonArray[i].Button.Content = i;
                    Memory_Grid.Children.Add(ButtonArray[i].Button);

                    Grid.SetRow(ButtonArray[i].Button, i);
                    Grid.SetColumn(ButtonArray[i].Button, j);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Memory_Grid.Width = 1920;
        }
    }
}
