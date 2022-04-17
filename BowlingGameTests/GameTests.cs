using BowlingGame;
using NUnit.Framework;

namespace BowlingGameTests
{
    public class Tests
    {

        Game game;

        [SetUp]
        public void Setup()
        {
            game = new Game();
        }

        int result;

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
            game.ManyThrows(20);

            result = game.Score();

            Assert.AreEqual(expected, result);
        }
    }
}