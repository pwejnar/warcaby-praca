using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using warcaby;

namespace Checkers
{
    public class BoardRating
    {
        private static readonly int rateForPawn = 2;
        private static readonly int rateForKing = 10;

        //private static readonly int rateForDraw = 1;
        //private static readonly int rateForWinGame = 100;
        //private static readonly int rateForLoseGame = -100;

        //zbicie damki przecwinika bardziej oplacalne niz zdobycie damki 

        private Board board;
        private Player player;

        public BoardRating(Board board, Player player)
        {
            this.board = board;
            this.player = player;
        }

        public int Rate()
        {

            int mainPawnsCount = board.GetPawns().Count(x => x.GetKingState() == false && x.GetOwner() == player);
            int enemyPawnsCount = board.GetPawns().Count(x => x.GetKingState() == false && x.GetOwner() != player);

            int mainKingsCount = board.GetPawns().Count(x => x.GetKingState() && x.GetOwner() == player);
            int enemyKingsCount = board.GetPawns().Count(x => x.GetKingState() && x.GetOwner() != player);

            if (enemyPawnsCount + enemyKingsCount == 0)
                return 1000;

            int result = (mainKingsCount - enemyKingsCount) * rateForKing + (mainPawnsCount - enemyPawnsCount) * rateForPawn;


            return result;
        }
    }
}
