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

        // ALL CASES SHOULD HAVE 10 FRAMES (AT LEAST 12 THROWS (when all of them are strikes) AND MAX 21 THROWS (when last frame gave / 19th throw, gave STRIKE so we get 2 bonus throws))
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1, 1 }, 30, 10)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 2, 4 }, 34, 10)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 4 }, 32, 10)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 4, 3 }, 37, 10)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 5 }, 33, 10)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 5, 5, 5 }, 46, 10)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 20, 10)]
        [TestCase(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 150, 10)]
        [TestCase(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 145, 10)]
        [TestCase(new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }, 300, 10)]
        [TestCase(new int[] { 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0}, 90, 10)]
        // KataBowlingByAndreasLarsson codingdojo.org cases
        [TestCase(new int[] { 5, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 29, 10)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 1}, 29, 10)]
        [TestCase(new int[] { 10, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 30, 10)] // 19 rzutow i 10 ramek
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1, 1}, 30, 10)]


        [Test]
        public void RolledDifferentNumbersOfPins_RecieveTheRightGameScoreForEachTestCase(int[] listOfRolledPinsInEveryThrow, int expectedScore, int expectedNumberOfFrames)
        {
            game.ManyThrowsSecond(listOfRolledPinsInEveryThrow.Length, listOfRolledPinsInEveryThrow);

            result = game.Score();

            Assert.AreEqual(expectedScore, result);
            Assert.AreEqual(expectedNumberOfFrames, game.FrameCounter);
        }
    }
}