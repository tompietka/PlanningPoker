using System;
using System.Collections;
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
    public class IntegrationTests
    {
        [TestCase(-1)]
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

        [TestCase(-1, 0, 0)]
        [TestCase(2, 0, -1)]
        [TestCase(2, 2, 1)]
        [ExpectedException(typeof(ArgumentException))]
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
            story.EstimateAllEqualMode(estimation1, estimation2, estimation3);
            //Assert
        }

    }
}
