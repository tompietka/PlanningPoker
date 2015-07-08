using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Converters;
using MahApps.Metro.Controls;
using PlanningPoker;

namespace WpfApplication1
{

    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            EstimationsInGame = new List<Estimation>();
            StoriesInGame = new List<Story>();
        }

        public IList<string> PlayersInGame { get; set; }
        public IList<Estimation> EstimationsInGame { get; set; }
        public IList<Story> StoriesInGame { get; set; }

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

                newEstimationCardOne.Click += newEstimationCardOne_Click;

                var newEstimationCardTwo = new Button
                {
                    Content = "2",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 70,
                    Width = 60
                };

                newEstimationCardTwo.Click += newEstimationCardTwo_Click;

                var newEstimationCardThree = new Button
                {
                    Content = "3",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 70,
                    Width = 60
                };

                newEstimationCardThree.Click += newEstimationCardThree_Click;

                var newEstimationCardFive = new Button
                {
                    Content = "5",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 70,
                    Width = 60
                };

                newEstimationCardFive.Click += newEstimationCardFive_Click;

                var newEstimationCardEight = new Button
                {
                    Content = "8",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 70,
                    Width = 60
                };

                newEstimationCardEight.Click += newEstimationCardEight_Click;

                var newEstimationCardThirteen = new Button
                {
                    Content = "13",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 70,
                    Width = 60
                };
                newEstimationCardThirteen.Click += newEstimationCardThirteen_Click;

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

        void newEstimationCardOne_Click(object sender, RoutedEventArgs e)
        {
            var EstimationOne = new Estimation("player", "TxtStoryName.Text", 1);
            EstimationsInGame.Add(EstimationOne);
        }

                void newEstimationCardTwo_Click(object sender, RoutedEventArgs e)
                {
                    var EstimationTwo = new Estimation("player", "TxtStoryName.Text", 2);
            EstimationsInGame.Add(EstimationTwo);
        }

                void newEstimationCardThree_Click(object sender, RoutedEventArgs e)
                {
                    var EstimationThree = new Estimation("player", "TxtStoryName.Text", 3);
            EstimationsInGame.Add(EstimationThree);
        }

                void newEstimationCardFive_Click(object sender, RoutedEventArgs e)
                {
                    var EstimationFive = new Estimation("player", "TxtStoryName.Text", 5);
            EstimationsInGame.Add(EstimationFive);
        }

                void newEstimationCardEight_Click(object sender, RoutedEventArgs e)
                {
                    var EstimationEight = new Estimation("player", "TxtStoryName.Text", 8);
            EstimationsInGame.Add(EstimationEight);
        }

                void newEstimationCardThirteen_Click(object sender, RoutedEventArgs e)
                {
                    var EstimationThirteen = new Estimation("player", "TxtStoryName.Text", 13);
            EstimationsInGame.Add(EstimationThirteen);
        }

          

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var StoryName = TxtStoryName.Text;
            try
            {
                var story = new Story(StoryName);
                StoriesInGame.Add(story);
            }

            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd Aplikacji", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            var estimationsInGame = EstimationsInGame.ToList();

            var result = StoriesInGame.First();

        }
    }
}

