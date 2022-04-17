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

        public int ManyThrows(int numberOfThrows, int numberOfRolledPins)
        {
            //for (int i = 0; i < numberOfThrows; i++)
            //{
            //    GameScore += Throw(1);
            //}

            GameScore = numberOfRolledPins;

            return GameScore;
        }

    }

}
