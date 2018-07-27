using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGameLibrary;


// TDD Criteria:
namespace BowlingGameTests
{
    [TestClass]
    public class GameTests
    {
        private BowlingGame game;

        [TestInitialize]
        // Does the game initialize
        public void Initialize()
        {
            game = new BowlingGame();
        }

        [TestMethod]
        // Can the player miss all throws
        public void CanRollAllGutter()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, game.Score);
        }

        [TestMethod]
        // Is the score incrementing correctly
        public void CanRollAllOnes()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, game.Score);
        }

        [TestMethod]
        // Can the player roll spare
        public void CanRollSpare()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            RollMany(17, 0);
            Assert.AreEqual(16, game.Score);
        }

        [TestMethod]
        // Can the player roll a strike
        public void CanRollStrike()
        {
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);
            RollMany(16, 0);
            Assert.AreEqual(24, game.Score);
        }

        [TestMethod]
        // Can the player Roll a perfect 300 game
        public void CanRollPerfect()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, game.Score);
        }

        // [Helper Methods]
        public void RollMany(int rollCt, int pinCt) // (number of rolls, total pins knocked down)
        {
            for (var i = 0; i < rollCt; i++)
                game.Roll(pinCt);
           
        }
    }
}
