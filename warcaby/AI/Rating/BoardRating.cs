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
    public static int Rate(Board start, Board end, Player player)
    {
      int startBoardPawnsCount = start.GetPawns().Count(x => x.Player == player);
      int startBoardEnemyPawnsCount = start.GetPawns().Count(x => x.Player != player);

      int endBoardPawnsCount = end.GetPawns().Count(x => x.Player == player);
      int endBoardEnemyPawnsCount = end.GetPawns().Count(x => x.Player != player);
      
      int myDifference = (startBoardPawnsCount - startBoardEnemyPawnsCount);
      int enemyDifference = (endBoardPawnsCount - endBoardEnemyPawnsCount);

      return enemyDifference - myDifference;
    }
  }
}
