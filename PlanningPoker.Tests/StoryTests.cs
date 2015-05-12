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
    }
}
