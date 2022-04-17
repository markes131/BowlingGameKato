using BowlingGame;
using NUnit.Framework;

namespace BowlingGameTests
{
    public class Tests
    {

        Game game;
        int result;

        [SetUp]
        public void Setup()
        {
            game = new Game();
        }


        [TestCase(1)]

        [Test]
        public void OneThrow_RecieveRolledOnePin(int expected)
        {

            game = new Game();

            game.Throw(1);

            result = game.Score();

            Assert.AreEqual(expected, result);
        }


        [TestCase(20, 0)]

        [Test]
        public void EveryThrowRolledOnePin_RecieveSumOfRolledPins(int throws, int expected)
        {
            game = new Game();

            game.ManyThrows(throws, expected);

            result = game.Score();

            Assert.AreEqual(expected, result);
        }


        [TestCase(0)]

        [Test]
        public void EveryThrowRolledZeroPins_RecieveSumOfRolledPinsEqualZero(int expected)
        {
            game = new Game();

            game.ManyThrows(20, expected);

            result = game.Score();

            Assert.AreEqual(expected, result);
        }

        [TestCase(2, 5, 10)]

        [Test]
        public void RolledTenPinsInTwoThrows_RecieveTenRolledPins(int throws, int rolledPinsPerThrow, int expected)
        {
            game.ManyThrows(throws, rolledPinsPerThrow);
            result = game.Score();
            Assert.AreEqual(expected, result);
        }

        [TestCase(3, 5, 20)]

        [Test]
        public void RolledTenPinsInTwoThrows_RecieveTenRolledPinsAndSpareBonusInNextThrow(int throws, int rolledPinsPerThrow, int expected)
        {
            game.ManyThrows(throws, rolledPinsPerThrow);
            
            result = game.Score();

            Assert.AreEqual(expected, result);
        }

        
        [TestCase(new int[] { 10, 1, 1 }, 14)]
        [TestCase(new int[] { 10, 2, 4 }, 22)]
        [TestCase(new int[] { 5, 5, 4 }, 18)]
        [TestCase(new int[] { 5, 5, 4, 3 }, 21)]

        [Test]
        public void RolledTenPinsInFirstThrow_RecieveTenRolledPinsAndStrikeBonusForNextTwoThrows(int[] listOfRolledPinsInEveryThrow, int expected)
        {
            game.ManyThrows(listOfRolledPinsInEveryThrow.Length, listOfRolledPinsInEveryThrow);

            result = game.Score();

            Assert.AreEqual(expected, result);
        }
    }
}