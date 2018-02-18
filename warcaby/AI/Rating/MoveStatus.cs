using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warcaby.AI.Rating
{
    public enum GameRating
    {
        Lost, Losing, Drawing, Winning, Won
    }

    public class MoveStatus
    {
        public int Score { get; set; }
        public GameRating Rating { get; }

        public MoveStatus(int score, bool lost = false, bool won = false)
        {
            Score = score;

            if (lost)
            {
                Rating = GameRating.Lost;
            }

            else if (won)
            {
                Rating = GameRating.Won;
            }

            else if (score == 0)
            {
                Rating = GameRating.Drawing;
            }
            else if (score > 0)
            {
                Rating = GameRating.Winning;
            }
            else if (score < 0)
            {
                Rating = GameRating.Losing;
            }
        }
    }
}
