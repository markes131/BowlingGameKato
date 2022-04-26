using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Game
    {
        public int GameScore { get; set; }

        public int Pins { get; set; }


        public Game()
        {
            GameScore = 0;
        }

        public int Score()
        {
            return GameScore;
        }

        public int Throw(int rolledPins)
        {
            Pins = rolledPins;
            GameScore += Pins;

            return Pins;
        }

        // pointing the index of frame
        public int FrameCounter {get; set;}

        // 2.0 VERSION OF MANYTHROWS IMPLEMENTATION (1.0 DELETED)
        public int ManyThrowsSecond(int numberOfThrows, int[] listOfRolledPinsInEveryThrow)
        {
            int rolledPins;
            int[] ListWithNumberOfRolledPinsInThrowWithIndex = new int[numberOfThrows];
            // iteration variable for countering throws in current frame
            int frameThrowsCounter = 1;
            // pointing the index of frame
            int frameCounter = 0;
            Boolean lastFrameUnlockedSpare = false;
            Boolean lastFrameUnlockedStrike = false;
            // iteration variable for countering of usage of Strike bonuses
            int usedStrikeBonusCounter = 0;

            for (int i = 0; i < numberOfThrows; i++)
            {
                if (frameThrowsCounter > 2)
                {
                    frameThrowsCounter = 1;
                }

                rolledPins = Throw(listOfRolledPinsInEveryThrow[i]);

                ListWithNumberOfRolledPinsInThrowWithIndex[i] = rolledPins;

                Console.WriteLine($"#{i+1} PINS: {listOfRolledPinsInEveryThrow[i]}");


                #region START OF SPARE
                // SPARE ENG checking does actual throw is a last throw in the game?, if true -> we abandone adding bonuses pins for this throw to GameScore
                // SPARE PL sprawdzamy czy aktualny rzut jest ostatnim w grze, jeśli tak to blokujemy dodanie bonusu za strącone piny w tym rzucie
                if (i == numberOfThrows - 1)
                {
                    lastFrameUnlockedSpare = false;
                }

                // SPARE ENG checking did last frame gave us a bonus?
                // SPARE PL sprawdzamy czy ostatnia ramka dała nam bonus 
                if (lastFrameUnlockedSpare is true)
                {
                    GameScore += rolledPins;
                    lastFrameUnlockedSpare = false;
                }

                // SPARE ENG checking does after second throw in a frame we unlocking a spare bonus
                // SPARE PL sprawdzamy czy po drugim rzucie w ramce odblokowujemy bonus spare
                if (frameThrowsCounter == 2 && i > 0 && ((ListWithNumberOfRolledPinsInThrowWithIndex[i - 1] + ListWithNumberOfRolledPinsInThrowWithIndex[i]) == 10))
                {
                        lastFrameUnlockedSpare = true;
                }

                #endregion END OF SPARE


                #region START OF STRIKE

                // STRIKE ENG checking -> Is actual throw a last in the game?, if true -> we abandone adding bonuses pins for this throw to GameScore
                // STRIKE PL sprawdzamy czy aktualny rzut jest ostatnim w grze, jeśli tak to blokujemy dodanie bonusu za strącone piny w tym rzucie
                if (frameCounter >= 10 && (i == numberOfThrows - 1))
                {
                    lastFrameUnlockedStrike = false;
                }

                // STRIKE ENG checking -> Did last frame gave us a strike bonus?, if true -> we adding bonuses pins rolled in this throw to GameScore
                // STRIKE PL sprawdzamy czy ostatnia ramka dała nam bonus, jeśli tak to dodajemy bonusowe piny do wyniku
                if (lastFrameUnlockedStrike is true && usedStrikeBonusCounter <= 2 && frameCounter < 10)
                {
                    Console.WriteLine($"Strike bonus for THIS throw = {lastFrameUnlockedStrike}");
                    Console.WriteLine($"BONUS +{listOfRolledPinsInEveryThrow[i]} #{i - usedStrikeBonusCounter}");

                    GameScore += listOfRolledPinsInEveryThrow[i];
                    usedStrikeBonusCounter++;
                }
                else
                {
                    usedStrikeBonusCounter = 0;
                }

                // STRIKE ENG checking -> Did we have a strike two frames earlier?, if true -> we adding a rolled pins in this throw as bonuses pins to GameScore
                // STRIKE PL sprawdzamy czy dwie ramki temu dostaliśmyt strike'a, jesli tak to -> dodajemy strącone piny w danym rzucie jako bonusowe do wyniku
                if (frameCounter >= 2 && (listOfRolledPinsInEveryThrow[i - 2] == 10))
                {
                    if ((i != numberOfThrows - 1))
                    {
                        GameScore += listOfRolledPinsInEveryThrow[i];
                        Console.WriteLine($"BONUS +{listOfRolledPinsInEveryThrow[i]} #{(i - 1)}");
                    }
                }


                // STRIKE ENG checking, Did actual throw give us a bonus?
                // STRIKE PL sprawdzamy, czy aktualny rzut dał nam bonus?
                if (frameThrowsCounter == 1 && rolledPins == 10 && frameCounter < 10)
                {
                    lastFrameUnlockedStrike = true;
                    frameThrowsCounter = 3;
                    usedStrikeBonusCounter = 0;
                    Console.WriteLine("STRIKE");
                    Console.WriteLine($"Strike counter = {usedStrikeBonusCounter}");
                    Console.WriteLine($"Strike unlocked for next two throws? = {lastFrameUnlockedStrike}");
                }
                else
                {
                    frameThrowsCounter++;
                    if (usedStrikeBonusCounter != 1)
                    {
                        lastFrameUnlockedStrike = false;
                    }
                }

                #endregion END OF STRIKE

                // ENG checking, Did we get to the end of the current frame?
                if (frameThrowsCounter >= 3 && frameCounter < 10)
                {
                    frameCounter++;
                }

                Console.WriteLine($"Score = {GameScore}");
                Console.WriteLine();
            }

            FrameCounter = frameCounter;
            Console.WriteLine($"Score = {GameScore}");

            return GameScore;
        }

    }

}
