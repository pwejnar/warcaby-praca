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

        public static double Rate(Board start, Board end, Player player)
        {
            int startBoardPawnsCount = start.GetPawns().Count(x => x.KingState == false && x.Player == player);
            int startBoardKingsCount = start.GetPawns().Count(x => x.KingState && x.Player == player);
            int startBoardEnemyPawnsCount = start.GetPawns().Count(x => x.KingState == false && x.Player != player);
            int startBoardEnemyKingsCount = start.GetPawns().Count(x => x.KingState && x.Player != player);

            int endBoardPawnsCount = end.GetPawns().Count(x => x.KingState == false && x.Player == player);
            int endBoardKingsCount = end.GetPawns().Count(x => x.KingState && x.Player == player);
            int endBoardEnemyPawnsCount = end.GetPawns().Count(x => x.KingState == false && x.Player != player);
            int endBoardEnemyKingsCount = end.GetPawns().Count(x => x.KingState && x.Player != player);

            if (endBoardEnemyPawnsCount + endBoardEnemyKingsCount == 0)
            {
                return 1000;
            }

            if (endBoardPawnsCount + endBoardKingsCount == 0)
            {
                return -1000;
            }

            int myDifference = (startBoardPawnsCount + startBoardKingsCount) - (startBoardEnemyPawnsCount + startBoardEnemyKingsCount);
            int enemyDifference = (endBoardPawnsCount + endBoardKingsCount) - (endBoardEnemyPawnsCount + endBoardEnemyKingsCount);

            return enemyDifference - myDifference;
        }
    }
}
