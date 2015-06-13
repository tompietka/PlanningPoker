using System;
using FluentAssertions;
using NUnit.Framework;

namespace PlanningPoker.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        public void WhenAtLeastOnePlayerPlaysBreak_ApplicationIsInBreakMode()
        {

            //Arrange
            const string player1 = "Jan";
            const string player2 = "Tomasz";
            const string player3 = "Józek";
            const string storyName = "As a user I want so that";
            //Act
            Action a = () => new Estimation(player1, storyName, -3);
            Action b = () => new Estimation(player2, storyName, -3);
            Action c = () => new Estimation(player3, storyName, 13);
            //Assert
            a.ShouldThrow<ArgumentException>();
            b.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void WhenAtLeastOnePlayerPlaysTooBigInAllEqualMode_ThenStoryIsTooBig()
        {
            //Arrange
            const string player1 = "Jan";
            const string player2 = "Tomasz";
            const string player3 = "Józek";
            const string storyName = "As a user I want so that";
            //Act
            var story = new Story(storyName);

            var estimation1 = new Estimation(player1, storyName, -2);
            var estimation2 = new Estimation(player2, storyName, 13);
            var estimation3 = new Estimation(player3, storyName, 13);
            story.EstimateAllEqualMode(estimation1, estimation2, estimation3);
            //Assert
            story.Estimation.Should().Be(-2);

        }

        [Test]
        public void WhenAtLeastOnePlayerPlaysUnknownInAllEqualMode_ThenStoryIsUnknown()
        {
            //Arrange
            const string player1 = "Jan";
            const string player2 = "Tomasz";
            const string player3 = "Józek";
            const string storyName = "As a user I want so that";
            //Act
            var story = new Story(storyName);

            var estimation1 = new Estimation(player1, storyName, -1);
            var estimation2 = new Estimation(player2, storyName, -1);
            var estimation3 = new Estimation(player3, storyName, 13);
            story.EstimateAllEqualMode(estimation1, estimation2, estimation3);
            //Assert
            story.Estimation.Should().Be(-1);

        }




        [Test]
        public void WhenAtLeastOnePlayerPlaysTooBigInAverageMode_ThenStoryIsTooBig()
        {
            //Arrange
            const string player1 = "Jan";
            const string player2 = "Tomasz";
            const string player3 = "Józek";
            const string storyName = "As a user I want so that";
            //Act
            var story = new Story(storyName);

            var estimation1 = new Estimation(player1, storyName, -2);
            var estimation2 = new Estimation(player2, storyName, 13);
            var estimation3 = new Estimation(player3, storyName, 13);
            story.EstimateAverageMode(estimation1, estimation2, estimation3);
            //Assert
            story.Estimation.Should().Be(-2);

        }

        [Test]
        public void WhenAtLeastOnePlayerPlaysUnknownInAverageMode_ThenStoryIsUnknown()
        {
            //Arrange
            const string player1 = "Jan";
            const string player2 = "Tomasz";
            const string player3 = "Józek";
            const string storyName = "As a user I want so that";
            //Act
            var story = new Story(storyName);

            var estimation1 = new Estimation(player1, storyName, -1);
            var estimation2 = new Estimation(player2, storyName, -1);
            var estimation3 = new Estimation(player3, storyName, 13);
            story.EstimateAverageMode(estimation1, estimation2, estimation3);
            //Assert
            story.Estimation.Should().Be(-1);

        }


        [Test]
        public void WhenAtLeastOnePlayerPlaysTooBigInAverageRemoveMinMaxMode_ThenStoryIsTooBig()
        {
            //Arrange
            const string player1 = "Jan";
            const string player2 = "Tomasz";
            const string player3 = "Józek";
            const string storyName = "As a user I want so that";
            //Act
            var story = new Story(storyName);

            var estimation1 = new Estimation(player1, storyName, -2);
            var estimation2 = new Estimation(player2, storyName, 13);
            var estimation3 = new Estimation(player3, storyName, 13);
            story.EstimateAverageRemoveMinMaxMode(estimation1, estimation2, estimation3);
            //Assert
            story.Estimation.Should().Be(-2);

        }

        [Test]
        public void WhenAtLeastOnePlayerPlaysUnknownInAverageRemoveMinMaxMode_ThenStoryIsUnknown()
        {
            //Arrange
            const string player1 = "Jan";
            const string player2 = "Tomasz";
            const string player3 = "Józek";
            const string storyName = "As a user I want so that";
            //Act
            var story = new Story(storyName);

            var estimation1 = new Estimation(player1, storyName, -1);
            var estimation2 = new Estimation(player2, storyName, -1);
            var estimation3 = new Estimation(player3, storyName, 13);
            story.EstimateAverageRemoveMinMaxMode(estimation1, estimation2, estimation3);
            //Assert
            story.Estimation.Should().Be(-1);

        }



        [TestCase(3)]
        [TestCase(2)]
        [TestCase(0)]
        public void WhenApplicationInAllEqualModeEachEstimationIsEqual_ThenStoryHasEstimation(int a)
        {
            //Arrange
            const string player1 = "Jan";
            const string player2 = "Tomasz";
            const string player3 = "Józek";
            const string storyName = "As a user I want so that";

            //Act
            var story = new Story(storyName);

            var estimation1 = new Estimation(player1, storyName, a);
            var estimation2 = new Estimation(player2, storyName, a);
            var estimation3 = new Estimation(player3, storyName, a);
            story.EstimateAllEqualMode(estimation1, estimation2, estimation3);
            //Assert
            story.Estimation.Should().Be(a);
        }

        [TestCase(3, 0, 0)]
        [TestCase(2, 0, 3)]
        [TestCase(2, 2, 1)]
        public void WhenApplicationInAllEqualModeEachEstimationIsNotEqual_ThenThrowException(int a, int b, int c)
        {
            //Arrange
            
            const string player1 = "Jan";
            const string player2 = "Tomasz";
            const string player3 = "Józek";
            const string storyName = "As a user I want so that";

            //Act

            var story = new Story(storyName);

            var estimation1 = new Estimation(player1, storyName, a);
            var estimation2 = new Estimation(player2, storyName, b);
            var estimation3 = new Estimation(player3, storyName, c);
            Action d = () => story.EstimateAllEqualMode(estimation1, estimation2, estimation3);
            //Assert
            d.ShouldThrow<ArgumentException>();
        }
        [TestCase(3, 0, 5, 2)]
        [TestCase(3, 3, 3, 3)]
        [TestCase(13, 5, 1, 6)]
        public void WhenApplicationInAverageMode_ThenCalculateAverage(int a, int b, int c, int d)
        {
            //Arrange

            const string player1 = "Jan";
            const string player2 = "Tomasz";
            const string player3 = "Józek";
            const string storyName = "As a user I want so that";

            //Act

            var story = new Story(storyName);

            var estimation1 = new Estimation(player1, storyName, a);
            var estimation2 = new Estimation(player2, storyName, b);
            var estimation3 = new Estimation(player3, storyName, c);
            story.EstimateAverageMode(estimation1, estimation2, estimation3);
            //Assert
            story.Estimation.Should().Be(d);
        }

        [TestCase(1, 2, 2, 3, 8, 3)]
        [TestCase(3, 3, 3, 1, 1, 2)]
        [TestCase(13, 5, 1, 2, 8, 5)]
        [TestCase(1, 1, 2, 2, 2, 1)]
        [TestCase(0, 0, 5, 5, 8, 3)]
        [TestCase(0, 0, 0, 0, 0, 0)]
        [TestCase(0, 1, 1, 1, 2, 1)]
        public void WhenApplicationInAverageRemoveMinMaxMode_ThenCalculateAverage(int a, int b, int c, int d, int e, int f)
        {
            //Arrange

            const string player1 = "Jan";
            const string player2 = "Tomasz";
            const string player3 = "Józek";
            const string player4 = "Jacek";
            const string player5 = "Andrzej";
            const string storyName = "As a user I want so that";

            //Act

            var story = new Story(storyName);

            var estimation1 = new Estimation(player1, storyName, a);
            var estimation2 = new Estimation(player2, storyName, b);
            var estimation3 = new Estimation(player3, storyName, c);
            var estimation4 = new Estimation(player4, storyName, d);
            var estimation5 = new Estimation(player5, storyName, e);
            story.EstimateAverageMode(estimation1, estimation2, estimation3, estimation4, estimation5);
            //Assert
            story.Estimation.Should().Be(f);
        }



    }
}
