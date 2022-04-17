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

        int[] RolledPinsInEveryThrow;

        public int ManyThrows(int numberOfThrows, int numberOfRolledPinsPerThrow)
        {
            RolledPinsInEveryThrow = new int[numberOfThrows];
            int rolledPins = 0;

            for (int i = 0; i < numberOfThrows; i++)
            {
                rolledPins = Throw(numberOfRolledPinsPerThrow);
                
                RolledPinsInEveryThrow[i] = rolledPins;

                //GameScore += rolledPins;

                if (i > 1 && (RolledPinsInEveryThrow[i - 2] + RolledPinsInEveryThrow[i - 1]) == 10)
                {
                    GameScore += rolledPins;
                }
            }

            return GameScore;
        }

        public int ManyThrows(int numberOfThrows, int[] listOfRolledPinsInEveryThrow)
        {
            RolledPinsInEveryThrow = new int[numberOfThrows];
            int rolledPins = 0;

            for (int i = 0; i < numberOfThrows; i++)
            {
                rolledPins = Throw(listOfRolledPinsInEveryThrow[i]);

                RolledPinsInEveryThrow[i] = rolledPins;

                //GameScore += rolledPins;

                if (i > 1 && (RolledPinsInEveryThrow[i - 2] + RolledPinsInEveryThrow[i - 1]) == 10)
                {
                    GameScore += rolledPins;
                }
                else if (i > 1 && RolledPinsInEveryThrow[i-2] == 10)
                {
                    GameScore += (listOfRolledPinsInEveryThrow[i-1] + listOfRolledPinsInEveryThrow[i]);
                }
            }

            return GameScore;
        }

    }

}
