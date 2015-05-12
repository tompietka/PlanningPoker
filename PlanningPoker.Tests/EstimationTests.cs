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
    public class EstimationTests
    {

        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(0)]
        public void WhenPlayerAddsCorrectEstimation_EstimationValueIsStored(int a)
        {
            //Arrange & Act
            var estimation = new Estimation("Jan", "Story Name", a);
            //Assert
            estimation.PlayerName.Should().Be("Jan");
            estimation.StoryName.Should().Be("Story Name");
            estimation.EstimationValue.Should().Be(a);
        }

        [Test]
        public void WhenPlayerAddsIncorrectEstimation4_ExceptionIsThrown()
        {
            //Arrange & Act
            Action a = () => new Estimation("Jan", "Story Name", 4);
            //Assert
            a.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void WhenPlayerEditsCorrectEstimation_EstimationValueIsStored()
        {
            //Arrange
            var estimation = new Estimation("Jan", "Story Name", 2);
            //Act
            estimation.Edit(estimation, 3);
            //Assert
            estimation.PlayerName.Should().Be("Jan");
            estimation.StoryName.Should().Be("Story Name");
            estimation.EstimationValue.Should().Be(3);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenPlayerEditsIncorrectEstimation_ExceptionIsThrown()
        {
            //Arrange
            var estimation = new Estimation("Jan", "Story Name", 2);
            //Act & Assert
            estimation.Edit(estimation, 4);
        }
    }
}
