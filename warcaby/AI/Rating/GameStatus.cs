using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warcaby.AI.Rating
{
    public enum GameRating
    {
        lost, losing, drawing, winning, won
    }

    public class GameStatus
    {
        public int Score { get; set; }
        public GameRating Rating { get; }

        public GameStatus(int score, bool lost = false, bool won = false)
        {
            Score = score;

            if (lost)
            {
                Rating = GameRating.lost;
            }

            else if (won)
            {
                Rating = GameRating.won;
            }

            else if (score == 0)
            {
                Rating = GameRating.drawing;
            }
            else if (score > 0)
            {
                Rating = GameRating.winning;
            }
            else if (score < 0)
            {
                Rating = GameRating.losing;
            }
        }
    }
}
