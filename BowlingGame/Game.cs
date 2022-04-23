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

        int[] ListWithNumberOfRolledPinsInThrowWithIndex;

        public int ManyThrows(int numberOfThrows, int numberOfRolledPinsPerThrow)
        {
            ListWithNumberOfRolledPinsInThrowWithIndex = new int[numberOfThrows];
            int rolledPins = 0;

            for (int i = 0; i < numberOfThrows; i++)
            {
                rolledPins = Throw(numberOfRolledPinsPerThrow);

                ListWithNumberOfRolledPinsInThrowWithIndex[i] = rolledPins;

                if (i > 1 && (ListWithNumberOfRolledPinsInThrowWithIndex[i - 2] + ListWithNumberOfRolledPinsInThrowWithIndex[i - 1]) == 10)
                {
                    GameScore += rolledPins;
                }
            }

            return GameScore;
        }


        int[] ListOfThrowsWithPunctation;

        public int ManyThrows(int numberOfThrows, int[] listOfRolledPinsInEveryThrow)
        {
            ListWithNumberOfRolledPinsInThrowWithIndex = new int[numberOfThrows];
            ListOfThrowsWithPunctation = new int[numberOfThrows];

            int rolledPins = 0;
            //Boolean didLastThrowGiveStrike = false;
            //Boolean thisThrowGiveStrike = false;
            //Boolean nextThrowIsInNewFrame = false;
            int frameThrowsCounter = 1;

            for (int i = 0; i < numberOfThrows; i++)
            {
                rolledPins = Throw(listOfRolledPinsInEveryThrow[i]);

                ListWithNumberOfRolledPinsInThrowWithIndex[i] = rolledPins;

                /*                if (lastThrowGaveStrike == true)
                                {
                                    nextThrowIsInNewFrame = true;
                                }*/

                // SPARE
                //if (i > 1 && ((ListOfThrowsWithRolledPins[i - 2] + ListOfThrowsWithRolledPins[i - 1]) == 10) && nextThrowIsInNewFrame)
                //if (frameThrowsCounter == 2 && nextThrowIsInNewFrame == true && ((ListOfThrowsWithRolledPins[i - 2] + ListOfThrowsWithRolledPins[i - 1]) == 10))
                if (frameThrowsCounter == 1 && i > 0 && ((ListWithNumberOfRolledPinsInThrowWithIndex[i - 1] + ListWithNumberOfRolledPinsInThrowWithIndex[i]) == 10))
                {
                    GameScore += rolledPins;
                }

                // STRIKE
                //if (i > 1 && RolledPinsInEveryThrow[i-2] == 10)
                if (frameThrowsCounter == 1 && ListWithNumberOfRolledPinsInThrowWithIndex[i] == 10)
                {
                    //thisThrowGiveStrike = true;
                    //didLastThrowGiveStrike = true;
                    //nextThrowIsInNewFrame = true;
                    GameScore += (listOfRolledPinsInEveryThrow[i - 1] + listOfRolledPinsInEveryThrow[i]);
                    frameThrowsCounter = 2;
                }

                ListOfThrowsWithPunctation[i] = GameScore;
                //nextThrowIsInNewFrame = false;

                if (frameThrowsCounter == 2)
                {
                    frameThrowsCounter = 1;
                }
                else
                {
                    frameThrowsCounter++;
                }
            }

            return GameScore;
        }

        // pointing the index of frame
        public int FrameCounter {get; set;}

        public int ManyThrowsSecond(int numberOfThrows, int[] listOfRolledPinsInEveryThrow)
        {
            ListWithNumberOfRolledPinsInThrowWithIndex = new int[numberOfThrows];
            int rolledPins = 0;
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

                // SPARE sprawdzamy czy aktualny rzut jest ostatnim rzutem, jeśli tak to porzucamy multiplaying strąconych pinów w tym rzucie
                if (i == numberOfThrows - 1)
                {
                    lastFrameUnlockedSpare = false;
                }
                // SPARE sprawdzamy czy ostatnia ramka dała nam bonus 
                //if (lastFrameUnlockedSpare == true)
                //if (lastFrameUnlockedSpare == true && frameThrowsCounter == 1)
                //if (lastFrameUnlockedSpare == true && (i <= numberOfThrows - 1) && frameThrowsCounter == 1)
                //if (lastFrameUnlockedSpare == true && ((i + 1) <= numberOfThrows))
                if (lastFrameUnlockedSpare == true)
                {
                    GameScore += rolledPins;
                    lastFrameUnlockedSpare = false;
                } 

                // SPARE sprawdzamy czy po drugim rzucie odblokowujemy bonus
                if (frameThrowsCounter == 2 && i > 0 && ((ListWithNumberOfRolledPinsInThrowWithIndex[i - 1] + ListWithNumberOfRolledPinsInThrowWithIndex[i]) == 10))
                {
                        lastFrameUnlockedSpare = true;
                }


                //STRIKE sprawdzamy czy aktualny rzut jest jednym z dwóch ostatnich, jeśli tak to porzucamy multiplaying strąconych pinów w tych rzutach
                //if (frameCounter >= 10 && (i == numberOfThrows - 2 || i == numberOfThrows - 1))

                //STRIKE sprawdzamy czy aktualny rzut jest ostatnim, jeśli tak to porzucamy multiplaying strąconych pinów dla tego rzutu
                if (frameCounter >= 10 && (i == numberOfThrows - 1))
                {
                    lastFrameUnlockedStrike = false;
                }
                // STRIKE sprawdzamy czy ostatnia ramka dała nam bonus jeśli tak to go liczymy
                if (lastFrameUnlockedStrike == true && usedStrikeBonusCounter <= 2 && frameCounter < 10)
                {
                    Console.WriteLine($"Strike bonus for THIS throw = {lastFrameUnlockedStrike}");
                    Console.WriteLine($"BONUS +{listOfRolledPinsInEveryThrow[i]} #{i - usedStrikeBonusCounter}");

                    //GameScore += (listOfRolledPinsInEveryThrow[i - 1] + listOfRolledPinsInEveryThrow[i]);
                    GameScore += listOfRolledPinsInEveryThrow[i];
                    usedStrikeBonusCounter++;
                }
                else
                {
                    usedStrikeBonusCounter = 0;
                }

                // sprawdzamy czy przed wcześniejszą ramką (ramka przed wcześniejszą ramką -> wcześniejsza ramka -> obecna ramka) też mieliśmy strike'a,
                // jeśli tak to robimy drugie multiplaying
                if (frameCounter >= 2 && (listOfRolledPinsInEveryThrow[i - 2] == 10))
                {
                    if ((i != numberOfThrows - 1))
                    {
                        GameScore += listOfRolledPinsInEveryThrow[i];
                        Console.WriteLine($"BONUS +{listOfRolledPinsInEveryThrow[i]} #{(i - 1)}");
                    }
                }

                // STRIKE sprawdzamy czy aktualny rzut dał nam bonus
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

                if (frameThrowsCounter >= 3 && frameCounter < 10)
                {
                    frameCounter++;
                }
                //if (frameThrowsCounter == 2)
                //{
                //    frameThrowsCounter = 1;
                //}
                //else
                //{
                //    frameThrowsCounter++;
                //}
                Console.WriteLine($"Score = {GameScore}");
                Console.WriteLine();
            }

            FrameCounter = frameCounter;
            Console.WriteLine($"Score = {GameScore}");

            return GameScore;
        }

    }

}
