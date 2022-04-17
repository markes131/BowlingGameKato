using BowlingGame;
using NUnit.Framework;

namespace BowlingGameTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        int result;

        [TestCase(1)]

        [Test]
        public void OneThrow_RecieveRolledOnePin(int expected)
        {
            Game game = new Game();

            game.Throw(1);

            result = game.Score();

            Assert.AreEqual(expected, result);
        }


        [TestCase(20)]

        [Test]
        public void EveryThrowRolledOnePin_RecievedSumOfRolledPins(int expected)
        {
            Game game = new Game();

            game.ManyThrows(20);

            result = game.Score();

            Assert.AreEqual(expected, result);

        }
    }
}