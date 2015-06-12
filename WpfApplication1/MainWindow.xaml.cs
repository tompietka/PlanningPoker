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
                Content = "Gracz",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                
            };

            SplLabels.Children.Add(newPlayerLabel);
            SplPlayerNames.Children.Add(newPlayerBox);

        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var playerNames = (from TextBox txtBox in SplPlayerNames.Children select txtBox.Text).ToList();

            var _playerNames = playerNames.ToArray();

            try
                    {
                        var game = new PlanningPoker.PlanningPoker(_playerNames);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Błąd Aplikacji", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

            planningPokerTabControl.SelectedIndex = 1;



        }
    }
}
