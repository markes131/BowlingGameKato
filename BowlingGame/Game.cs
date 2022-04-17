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

        public int ManyThrows(int numberOfThrows)
        {
            int sum = 0;
            for (int i=0; i < numberOfThrows; i++)
            {
                sum += Throw(1);
            }

            return sum;
        }

    }

}
