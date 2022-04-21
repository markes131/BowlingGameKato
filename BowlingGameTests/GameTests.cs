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


        [TestCase(new int[] { 10, 1, 1 }, 14, 2)]
        [TestCase(new int[] { 10, 2, 4 }, 22, 2)]
        [TestCase(new int[] { 5, 5, 4 }, 14, 1)]
        [TestCase(new int[] { 5, 5, 4, 3 }, 21, 2)]
        [TestCase(new int[] { 5, 5, 5 }, 15, 1)]
        [TestCase(new int[] { 5, 5, 5, 5, 5 }, 30, 2)]
        [TestCase(new int[] { 1, 1, 1 }, 3, 1)]
        [TestCase(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 150, 10)]
        [TestCase(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 145, 10)]
        [TestCase(new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }, 300, 12)]

        [Test]
        public void RolledTenPinsInFirstThrow_RecieveTenRolledPinsAndStrikeBonusForNextTwoThrows(int[] listOfRolledPinsInEveryThrow, int expectedScore, int expectedNumberOfFrames)
        {
            game.ManyThrowsSecond(listOfRolledPinsInEveryThrow.Length, listOfRolledPinsInEveryThrow);

            result = game.Score();

            Assert.AreEqual(expectedScore, result);
            Assert.AreEqual(expectedNumberOfFrames, game.FrameCounter);
        }
    }
}