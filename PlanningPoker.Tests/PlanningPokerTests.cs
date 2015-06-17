using System;
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
            //Arrange & Act 
            var game = new PlanningPoker("Jan", "Andrzej", "Zdzisław");
            //Assert
            game.Players.Should().HaveCount(3);
            game.Players.Should().ContainSingle(x => x.Name == "Jan");
            game.Players.Should().ContainSingle(x => x.Name == "Andrzej");
            game.Players.Should().ContainSingle(x => x.Name == "Zdzisław");
        }

        [Test]
        public void WhenGameAddedWith1Player_ThenExceptionIsThrown()
        {
            //Arrange & Act
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

        [Test]
        public void WhenGameAddedWithAPlayerWithNameTooShort_ThenExceptionIsThrown()
        {
            //Arrange & Act
            Action a = () => new PlanningPoker("Jan", "A", "Zdzisław");
            //Assert
            a.ShouldThrow<ArgumentException>();
        }
    }

}
