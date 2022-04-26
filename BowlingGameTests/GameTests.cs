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


        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 20, 10)]

        [Test]
        public void RollingOnePinInEachThrow_ShouldReturnTheScoreEqualToNumberOfThrowsWhichIs20(int[] listOfRolledPinsInEveryThrow, int expectedScore, int expectedNumberOfFrames)
        {
            RunTestCaseWithDefaultAssertScheme(listOfRolledPinsInEveryThrow, expectedScore, expectedNumberOfFrames);
        }

        // ALL CASES SHOULD HAVE 10 FRAMES (AT LEAST 12 THROWS (when all of them are strikes) AND MAX 21 THROWS (when last frame gave / 19th throw, gave STRIKE so we get 2 bonus throws))


        [TestCase(new int[] { 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0 }, 90, 10)]

        [Test]
        public void Rolling9PinsInEveryFrameAs9PinsInEveryFirstThrowAndZeroPinsInSecondThrow_ShouldReturnScoreEqualTo90RolledPins(int[] listOfRolledPinsInEveryThrow, int expectedScore, int expectedNumberOfFrames)
        {
            RunTestCaseWithDefaultAssertScheme(listOfRolledPinsInEveryThrow, expectedScore, expectedNumberOfFrames);
        }


        #region STRIKE TEST CASES

        [TestCase(new int[] { 10, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 30, 10)]

        [Test]
        public void RollingStrikeInFirstFrameAndOnePinEachInOtherThrows_ShouldMultiplyRolledPinsInNextTwoThrowsAfterFirstFrameAndAddTheRestPinsToScore_AndReturnFinalScoreEqualTo30(int[] listOfRolledPinsInEveryThrow, int expectedScore, int expectedNumberOfFrames)
        {
            RunTestCaseWithDefaultAssertScheme(listOfRolledPinsInEveryThrow, expectedScore, expectedNumberOfFrames);
        }


        // IN EACH OF 18 THROWS WE ROLL ONE PIN AND IN THE LAST FRAME WE GET STRIKE SO WE'RE GETTING TWO ADDITIONAL THROWS (and ROLL ONE PIN IN EACH) - GAME SCORE SHOULD RETURN = 30
        // SECOND STRIKE LAW -> GETTING STRIKE IN LAST FRAME GIVING ONLY TWO ADDITIONAL THROWS WITHOUT ADDING TO THE SCORE THE BONUSES PINS LIKE IN FIRST STRIKE LAW
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1, 1 }, 30, 10)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 2, 4 }, 34, 10)]

        [Test]
        public void Rolling18TimesOnePinFor9FramesAndStrikeInLastFrame_ShouldGiveUsTwoAdditionalThrowsWithoutMultiplyBonusForTheseThrows(int[] listOfRolledPinsInEveryThrow, int expectedScore, int expectedNumberOfFrames)
        {
            RunTestCaseWithDefaultAssertScheme(listOfRolledPinsInEveryThrow, expectedScore, expectedNumberOfFrames);
        }


        // STRIKE TEST FOR FIRST AND SECOND STRIKE LAW -> Method should calculate bonuses pins like in First Law from 1st to 9th Frame.
        // Second Law Says that Strike in last frame change bonus behavior -> normally we end throwing at 10 frame (last one or two throws) but If we get strike in the last frame, we get two additional throws
        // we adding pins rolled in those throws to Score.
        // There is one important thing! in the 9th frame, we've got strike and this gives us base strike bonus which is "multiply rolled pins in next two throws" 
        // so in view of 9th frame we have to multiply rolled pins in the next throw which is a throw in last frame but this last frame also is a Strike, and this bonus do not give us "multiply pins for the next two throws"
        // Because it is "the last throw in the game" It gives us bonus as two additional throws
        // so we can use strike bonus guaranted by 9th frame second time (cuz we just used it only for the first "next" throw). So we multiply pins rolled in first additional throw and add them to Score.
        [TestCase(new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }, 300, 10)]

        [Test]
        public void RollingStrikeInEveryFrameAndTenPinsInEachOfTwoLastAdditionalThrows_ShouldReturnScoreEqualTo300RolledPins(int[] listOfRolledPinsInEveryThrow, int expectedScore, int expectedNumberOfFrames)
        {
            RunTestCaseWithDefaultAssertScheme(listOfRolledPinsInEveryThrow, expectedScore, expectedNumberOfFrames);
        }

        #endregion


        #region SPARE TEST CASES

        // FIRST LAW OF SPARE -> IF WE ROLL TEN PINS IN TWO THROWS UNDER THE SAME FRAME WE MULTIPLY ROLLED PINS IN THE NEXT THROW
        [TestCase(new int[] { 5, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 29, 10)]

        [Test]
        public void RollingSpareInFirstFrameAndOnePinEachInOtherThrows_ShouldMultiplyRolledPinsInNextThrowAfterFirstFrameAndReturnFinalScoreEqualTo29(int[] listOfRolledPinsInEveryThrow, int expectedScore, int expectedNumberOfFrames)
        {
            RunTestCaseWithDefaultAssertScheme(listOfRolledPinsInEveryThrow, expectedScore, expectedNumberOfFrames);
        }


        // SECOND SPARE LAW -> GETTING SPARE IN LAST FRAME GIVES ONLY ONE ADDITIONAL THROW WITHOUT MULTIPLYING THE BONUSES PINS LIKE IN FIRST SPARE LAW
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 4 }, 32, 10)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 5 }, 33, 10)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 5, 5, 5 }, 46, 10)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 1 }, 29, 10)]

        [Test]
        public void RollingSpareInLastFrame_ShouldGiveUsOneAdditionalThrowWithoutMultiplyingTheBonusPinForThisRoll(int[] listOfRolledPinsInEveryThrow, int expectedScore, int expectedNumberOfFrames)
        {
            RunTestCaseWithDefaultAssertScheme(listOfRolledPinsInEveryThrow, expectedScore, expectedNumberOfFrames);
        }


        // FIRST AND SECOND SPARE LAW TOGETHER
        [TestCase(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 150, 10)]

        [Test]
        public void RollingSpareInEveryFrameBy5PinsInEachThrow_ShouldGiveOneAdditionalThrowInLastFrameAndShouldReturnFinalScoreEqualTo150(int[] listOfRolledPinsInEveryThrow, int expectedScore, int expectedNumberOfFrames)
        {
            RunTestCaseWithDefaultAssertScheme(listOfRolledPinsInEveryThrow, expectedScore, expectedNumberOfFrames);
        }


        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 4, 3 }, 37, 10)]
        [TestCase(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4 }, 144, 10)]

        [Test]
        public void RollingSpareInRandomFramesButNotInTheLastFrame_ShouldNotGivesAdditionalThrowInTheLastFrame(int[] listOfRolledPinsInEveryThrow, int expectedScore, int expectedNumberOfFrames)
        {
            RunTestCaseWithDefaultAssertScheme(listOfRolledPinsInEveryThrow, expectedScore, expectedNumberOfFrames);
        }

        #endregion


        // SUPPORTING METHOD FOR RUNNING TEST CASES WITH DEFINED ASSERT SCHEME
        public void RunTestCaseWithDefaultAssertScheme(int[] listOfRolledPinsInEveryThrow, int expectedScore, int expectedNumberOfFrames)
        {
            game.ManyThrowsSecond(listOfRolledPinsInEveryThrow.Length, listOfRolledPinsInEveryThrow);

            result = game.Score();

            Assert.AreEqual(expectedScore, result);
            Assert.AreEqual(expectedNumberOfFrames, game.FrameCounter);
        }
    }
}