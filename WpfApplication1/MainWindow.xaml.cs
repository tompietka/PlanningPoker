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
                VerticalAlignment = VerticalAlignment.Top
            };
            var newPlayerLabel = new Label
            {
                Content = "Gracz",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
                
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

            foreach (var value in playerNames)
            {
                var newPlayerinGame = new Label
                {
                    Content = value,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 70,
                    Width = 60
            
                };

                var newEstimationCardBreak = new Button
                {
                    Content = "Przerwa",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 70,
                    Width = 60

                };

                var newEstimationCardTooBig = new Button
                {
                    Content = "Za duże",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 70,
                    Width = 60

                };

                var newEstimationCardUnknown = new Button
                {
                    Content = "?",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 70,
                    Width = 60
                };

                var newEstimationCardZero = new Button
                {
                    Content = "0",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 70,
                    Width = 60
                };

                var newEstimationCardOne = new Button
                {
                    Content = "1",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 70,
                    Width = 60
                };

                var newEstimationCardTwo = new Button
                {
                    Content = "2",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 70,
                    Width = 60
                };

                var newEstimationCardThree = new Button
                {
                    Content = "3",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 70,
                    Width = 60
                };

                var newEstimationCardFive = new Button
                {
                    Content = "5",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 70,
                    Width = 60
                };

                var newEstimationCardEight = new Button
                {
                    Content = "8",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 70,
                    Width = 60
                };

                var newEstimationCardThirteen = new Button
                {
                    Content = "13",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 70,
                    Width = 60
                };

                SplPlayersInGame.Children.Add(newPlayerinGame);
                SplBreak.Children.Add(newEstimationCardBreak);
                SplTooBig.Children.Add(newEstimationCardTooBig);
                SplUnknown.Children.Add(newEstimationCardUnknown);
                SplZero.Children.Add(newEstimationCardZero);
                SplOne.Children.Add(newEstimationCardOne);
                SplTwo.Children.Add(newEstimationCardTwo);
                SplThree.Children.Add(newEstimationCardThree);
                SplFive.Children.Add(newEstimationCardFive);
                SplEight.Children.Add(newEstimationCardEight);
                SplThirteen.Children.Add(newEstimationCardThirteen);

            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var StoryName = TxtStoryName.Text;
            try
            {
                var story = new Story(StoryName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd Aplikacji", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
