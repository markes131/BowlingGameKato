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
            game.Throw(1);

            result = game.Score();

            Assert.AreEqual(expected, result);
        }


        [TestCase(20)]

        [Test]
        public void EveryThrowRolledOnePin_RecievedSumOfRolledPins(int expected)
        {
            game.ManyThrows(20, expected);

            result = game.Score();

            Assert.AreEqual(expected, result);
        }


        [TestCase(0)]

        [Test]
        public void EveryThrowRolledZeroPins_RecievedSumOfRolledPinsEqualZero(int expected)
        {

            game.ManyThrows(20, expected);

            result = game.Score();

            Assert.AreEqual(expected, result);
        }
    }
}