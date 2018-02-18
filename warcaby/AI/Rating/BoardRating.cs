using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using warcaby.AI.Rating;

namespace Checkers
{
    public class BoardRating
    {
        private static readonly int rateForPawn = 1;
        private static readonly int rateForKing = 3;



        public static MoveStatus Rate(Board board, Player player)
        {
            int mainPawnsCount = board.GetPawns().Count(x => x.KingState == false && x.Player == player);
            int enemyPawnsCount = board.GetPawns().Count(x => x.KingState == false && x.Player != player);

            int mainKingsCount = board.GetPawns().Count(x => x.KingState && x.Player == player);
            int enemyKingsCount = board.GetPawns().Count(x => x.KingState && x.Player != player);

            int score = (mainPawnsCount - enemyPawnsCount) * rateForPawn + (mainKingsCount - enemyKingsCount) * rateForKing;

            if (enemyPawnsCount + enemyKingsCount == 0)
            {
                return new MoveStatus(score, false, true);
            }

            else if (mainPawnsCount + mainKingsCount == 0)
            {
                return new MoveStatus(score, true, false);
            }

            return new MoveStatus(score);
        }
    }
}
