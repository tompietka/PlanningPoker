using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using PlanningPoker;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public IList<string> PlayersInGame { get; set; }
   

        private void BtnAddPlayerName(object sender, RoutedEventArgs e)
        {
            var newPlayerBox = new TextBox
            {
                Width = 396,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Top,
            };
            var newPlayerLabel = new Label
            {
                Content = "Player",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                
            };

            SplLabels.Children.Add(newPlayerLabel);
            SplPlayerNames.Children.Add(newPlayerBox);
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
                    try
                    {
                        var game = new PlanningPoker.PlanningPoker("Jan");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Błąd Aplikacji", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

        }
    }
}
