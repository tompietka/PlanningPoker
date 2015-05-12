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
    public class StoryTests
    {
        [Test]
        public void WhenStoryAddedWithNoName_ThenExceptionIsThrown()
        {
            //Arrange & Act
            Action a = () => new Story("");
            //Assert
            a.ShouldThrow<ArgumentException>();

        }

        [Test]
        public void WhenStoryAddedWithNameTooShort_ThenExceptionIsThrown()
        {
            //Arrange & Act
            Action a = () => new Story("St");
            //Assert
            a.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void WhenStoryAddedWithName_TheStoryHasProperName()
        {
            //Arrange & Act
            var story = new Story("As a user I want so that");

            //Assert
            story.Name.Should().Be("As a user I want so that");
        }

        [Test]
        public void WhenPlayerAddsCorrectEstimation23_EstimationValueIsStored()
        {
            //Arrange
            var story = new Story("As A User I want so that");
            //Act
            story.AddEstimation("Jan", 2);
            story.AddEstimation("Tomek", 3);
            //Assert
            story.Estimations.Should().HaveCount(2);
            story.Estimations.Sum().Should().Be(5);
            story.PlayerNames.Should().HaveCount(2);
        }

        [Test]
        public void WhenPlayerAddsCorrectEstimation_12_EstimationValueIsStored()
        {
            //Arrange
            var story = new Story("As A User I want so that");
            //Act
            story.AddEstimation("Jan", -1);
            story.AddEstimation("Tomek", 3);
            //Assert
            story.Estimations.Should().HaveCount(2);
            story.PlayerNames.Should().HaveCount(2);
        }

    }

}
