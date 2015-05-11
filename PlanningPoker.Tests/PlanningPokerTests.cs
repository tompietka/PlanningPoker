using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace PlanningPoker.Tests
{
    [TestFixture]
    public class PlanningPokerTests
    {
        [Test]
        public void WhenGameAddedWith3Players_ThenEveryPlayerHaveName()
        {
            //Arrange & Act - konstructor robi arrange & Act
            var game = new PlanningPoker("Jan", "Andrzej", "Zdzisław");
            //Assert
            game.Players.Should().HaveCount(3);
            game.Players.Should().ContainSingle(x => x.Name == "Jan"); //Lambda functional
            game.Players.Should().ContainSingle(x => x.Name == "Andrzej");
            game.Players.Should().ContainSingle(x => x.Name == "Zdzisław");
        }

        [Test]
        public void WhenGameAddedWith1Player_ThenExceptionIsThrown()
        {
            //Arrange & Act - konstructor robi arrange & Act
            Action a = () => new PlanningPoker("Jan");
            //Assert
            a.ShouldThrow<ArgumentException>();
        }
        [Test]
        public void WhenGameAddedWith0Player_ThenExceptionIsThrown()
        {
            //Arrange & Act - konstructor robi arrange & Act
            Action a = () => new PlanningPoker();
            //Assert
            a.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void WhenGameAddedWithNULLPlayer_ThenExceptionIsThrown()
        {
            //Arrange & Act - konstructor robi arrange & Act
            Action a = () => new PlanningPoker(null);
            //Assert
            a.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void WhenGameAddedWith2IdenticalPlayers_ThenExceptionIsThrown()
        {
            //Arrange & Act - konstructor robi arrange & Act
            Action a = () => new PlanningPoker("Jan", "Jan", "Zdzisław");
            //Assert
            a.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void WhenGameAddedWithAPlayerWithNoName_ThenExceptionIsThrown()
        {
            //Arrange & Act - konstructor robi arrange & Act
            Action a = () => new PlanningPoker("Jan", "", "Zdzisław");
            //Assert
            a.ShouldThrow<ArgumentException>();
        }

        //[TestCase(3, 3)]
        //[TestCase(1, 0)]
        //[TestCase(0, 0)]
        //public void DealPlayers_AddGame_CreatesGame(int noPlayers, int PlayersInGame)
        //{
        //    // Arrange:
        //    var game = new PlanningPoker(noPlayers);
        //    // Act:
        //    int playersInGame = game.AddGame(noPlayers);
        //    // Assert:
        //    Assert.AreEqual(playersInGame, PlayersInGame);
        //}

        //[Test]
        //public void StoryEstimation_4PlayerGameAvgRoundDown_Estimated()
        //{
        //    // Arrange:
        //    int i = 4;
        //    var game = new PlanningPoker(i);
        //    var story = new Story();
        //    // Act:

        //    List<int> playerEstimations = story.CreateList();

        //    story.AddPlayerEstimation(8, playerEstimations);
        //    story.AddPlayerEstimation(2, playerEstimations);
        //    story.AddPlayerEstimation(8, playerEstimations);
        //    story.AddPlayerEstimation(2, playerEstimations);

        //    int result = story.CalculateEstimationAvgRoundDown(i, playerEstimations);

        //    // Assert:
        //    Assert.AreEqual(result, 5);
        //}

        //[Test]
        //public void StoryEstimation_3PlayerGameAvgRoundDown_Estimated()
        //{
        //    // Arrange:
        //    int i = 3;
        //    var game = new PlanningPoker(i);
        //    var story = new Story();
        //    // Act:
        //    List<int> playerEstimations = story.CreateList();

        //    story.AddPlayerEstimation(8, playerEstimations);
        //    story.AddPlayerEstimation(2, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);

        //    int result = story.CalculateEstimationAvgRoundDown(i, playerEstimations);

        //    // Assert:
        //    Assert.AreEqual(result, 3);
        //}


        //[Test]
        //public void StoryEstimation_4PlayerGameAvgRoundUp_Estimated()
        //{
        //    // Arrange:
        //    int i = 4;
        //    var game = new PlanningPoker(i);
        //    var story = new Story();
        //    // Act:
        //    List<int> playerEstimations = story.CreateList();

        //    story.AddPlayerEstimation(8, playerEstimations);
        //    story.AddPlayerEstimation(2, playerEstimations);
        //    story.AddPlayerEstimation(8, playerEstimations);
        //    story.AddPlayerEstimation(2, playerEstimations);

        //    int result = story.CalculateEstimationAvgRoundUp(i, playerEstimations);

        //    // Assert:
        //    Assert.AreEqual(result, 5);
        //}

        //[Test]
        //public void StoryEstimation_3PlayerGameAvgRoundUp_Estimated()
        //{
        //    // Arrange:
        //    int i = 3;
        //    var game = new PlanningPoker(i);
        //    var story = new Story();
        //    // Act:
        //    List<int> playerEstimations = story.CreateList();

        //    story.AddPlayerEstimation(8, playerEstimations);
        //    story.AddPlayerEstimation(2, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);

        //    int result = story.CalculateEstimationAvgRoundUp(i, playerEstimations);

        //    // Assert:
        //    Assert.AreEqual(result, 4);
        //}

        //[Test]
        //public void StoryEstimation_17PlayerGameAvgRoundUp_Estimated()
        //{
        //    // Arrange:
        //    int i = 17;
        //    var game = new PlanningPoker(i);
        //    var story = new Story();
        //    // Act:
        //    List<int> playerEstimations = story.CreateList();

        //    story.AddPlayerEstimation(1, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);
        //    story.AddPlayerEstimation(3, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);
        //    story.AddPlayerEstimation(3, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);
        //    story.AddPlayerEstimation(2, playerEstimations);
        //    int result = story.CalculateEstimationAvgRoundUp(i, playerEstimations);

        //    // Assert:
        //    Assert.AreEqual(result, 2);
        //}

        //[Test]
        //public void StoryEstimation_3PlayerGameAllEqual_Estimated()
        //{
        //    // Arrange:
        //    int i = 3;
        //    var game = new PlanningPoker(i);
        //    var story = new Story();
        //    // Act:
        //    List<int> playerEstimations = story.CreateList();

        //    story.AddPlayerEstimation(3, playerEstimations);
        //    story.AddPlayerEstimation(3, playerEstimations);
        //    story.AddPlayerEstimation(3, playerEstimations);

        //    int result = story.CalculateEstimationAllEqual(i, playerEstimations);

        //    // Assert:
        //    Assert.AreEqual(result, 3);
        //}
        //[Test]
        //public void StoryEstimation_3PlayerGameAllEqual_NotEstimated()
        //{
        //    // Arrange:
        //    int i = 3;
        //    var game = new PlanningPoker(i);
        //    var story = new Story();
        //    // Act:
        //    List<int> playerEstimations = story.CreateList();

        //    story.AddPlayerEstimation(3, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);
        //    story.AddPlayerEstimation(3, playerEstimations);

        //    int result = story.CalculateEstimationAllEqual(i, playerEstimations);

        //    // Assert:
        //    Assert.AreEqual(result, 0);
        //}

        //[Test]
        //public void StoryEstimation_5PlayerGameAllEqualRemoveExtreme_Estimated()
        //{
        //    // Arrange:
        //    int i = 5;
        //    var game = new PlanningPoker(i);
        //    var story = new Story();
        //    // Act:
        //    List<int> playerEstimations = story.CreateList();

        //    story.AddPlayerEstimation(3, playerEstimations);
        //    story.AddPlayerEstimation(3, playerEstimations);
        //    story.AddPlayerEstimation(3, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);
        //    story.AddPlayerEstimation(5, playerEstimations);

        //    List<int> playerEstimationsNormalized = story.NormalizeList(playerEstimations);

        //    int result = story.CalculateEstimationAllEqual(i - 2, playerEstimationsNormalized);

        //    // Assert:
        //    Assert.AreEqual(result, 3);
        //}

        //[Test]
        //public void StoryEstimation_5PlayerGameAllEqualRemoveExtreme_NotEstimated()
        //{
        //    // Arrange:
        //    int i = 5;
        //    var game = new PlanningPoker(i);
        //    var story = new Story();
        //    // Act:
        //    List<int> playerEstimations = story.CreateList();

        //    story.AddPlayerEstimation(3, playerEstimations);
        //    story.AddPlayerEstimation(2, playerEstimations);
        //    story.AddPlayerEstimation(3, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);
        //    story.AddPlayerEstimation(5, playerEstimations);

        //    List<int> playerEstimationsNormalized = story.NormalizeList(playerEstimations);

        //    int result = story.CalculateEstimationAllEqual(i - 2, playerEstimationsNormalized);

        //    // Assert:
        //    Assert.AreEqual(result, 0);
        //}

        //[Test]
        //public void StoryEstimation_5PlayerGameAvgRoundUpRemoveExtreme_Estimated()
        //{
        //    // Arrange:
        //    int i = 5;
        //    var game = new PlanningPoker(i);
        //    var story = new Story();
        //    // Act:
        //    List<int> playerEstimations = story.CreateList();

        //    story.AddPlayerEstimation(3, playerEstimations);
        //    story.AddPlayerEstimation(2, playerEstimations);
        //    story.AddPlayerEstimation(3, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);
        //    story.AddPlayerEstimation(5, playerEstimations);

        //    List<int> playerEstimationsNormalized = story.NormalizeList(playerEstimations);

        //    int result = story.CalculateEstimationAvgRoundUp(i - 2, playerEstimationsNormalized);

        //    // Assert:
        //    Assert.AreEqual(result, 3);
        //}

        //[Test]
        //public void StoryEstimation_10PlayerGameMedianRoundDown_Estimated()
        //{
        //    // Arrange:
        //    int i = 10;
        //    var game = new PlanningPoker(i);
        //    var story = new Story();
        //    // Act:
        //    List<int> playerEstimations = story.CreateList();

        //    story.AddPlayerEstimation(2, playerEstimations);
        //    story.AddPlayerEstimation(2, playerEstimations);
        //    story.AddPlayerEstimation(3, playerEstimations);
        //    story.AddPlayerEstimation(2, playerEstimations);
        //    story.AddPlayerEstimation(3, playerEstimations);
        //    story.AddPlayerEstimation(3, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);
        //    story.AddPlayerEstimation(8, playerEstimations);
        //    story.AddPlayerEstimation(8, playerEstimations);
        //    story.AddPlayerEstimation(1, playerEstimations);

        //    int result = story.CalculateEstimationMedianRoundDown(i, playerEstimations);

        //    // Assert:
        //    Assert.AreEqual(result, 2);
        //}
    }

}
