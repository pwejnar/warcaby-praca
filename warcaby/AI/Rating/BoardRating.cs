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
    public static double Rate(Board start, Board end, Player player)
    {
      int startBoardPawnsCount = start.GetPawns().Count(x => x.Player == player);
      int startBoardEnemyPawnsCount = start.GetPawns().Count(x => x.Player != player);

      int endBoardPawnsCount = end.GetPawns().Count(x => x.Player == player);
      int endBoardEnemyPawnsCount = end.GetPawns().Count(x => x.Player != player);
      
      if (endBoardEnemyPawnsCount == 0)
      {
        return 1000;
      }

      if (endBoardPawnsCount == 0)
      {
        return -1000;
      }

      int myDifference = (startBoardPawnsCount - startBoardEnemyPawnsCount);
      int enemyDifference = (endBoardPawnsCount - endBoardEnemyPawnsCount);

      return enemyDifference - myDifference;
    }
  }
}
