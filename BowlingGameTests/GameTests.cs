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


        [TestCase(20, 1, 20)]

        [Test]
        public void EveryThrowRolledOnePin_RecieveSumOfRolledPins(int throws, int numberOfRolledPinsPerThrow, int expected)
        {
            game = new Game();

            game.ManyThrows(throws, numberOfRolledPinsPerThrow);

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


        [TestCase(new int[] { 10, 1, 1 }, 14)]
        [TestCase(new int[] { 10, 2, 4 }, 22)]
        [TestCase(new int[] { 5, 5, 4 }, 18)]
        [TestCase(new int[] { 5, 5, 4, 3 }, 21)]
        [TestCase(new int[] { 5, 5, 5 }, 20)]
        [TestCase(new int[] { 1, 1, 1 }, 3)]
        [TestCase(new int[] { 1, 1, 1 }, 3)]
        //[TestCase(new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10}, 300)]

        [Test]
        public void RolledTenPinsInFirstThrow_RecieveTenRolledPinsAndStrikeBonusForNextTwoThrows(int[] listOfRolledPinsInEveryThrow, int expected)
        {
            game.ManyThrows(listOfRolledPinsInEveryThrow.Length, listOfRolledPinsInEveryThrow);

            result = game.Score();

            Assert.AreEqual(expected, result);
        }
    }
}