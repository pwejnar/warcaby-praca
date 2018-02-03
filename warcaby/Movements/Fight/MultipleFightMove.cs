using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers;
using Checkers.Movements;
using warcaby.Extensions;

namespace warcaby.Movements.Fight
{
    public class MultipleFightMove : IMoveable
    {
        public List<FightMoveNode> FightMoveNodes { get; set; }

        public MultipleFightMove(List<FightMoveNode> fightMoveNodes)
        {
            FightMoveNodes = fightMoveNodes;
        }

        public void PrepareMove(Board board)
        {
            foreach (FightMoveNode fightNode in FightMoveNodes)
            {
                fightNode.FightMove.PrepareMove(board);
            }
        }

        public Board Simulate(Board board)
        {
            Board cloneBoard = board.Clone();

            foreach (FightMoveNode fightNode in FightMoveNodes)
            {
                fightNode.FightMove.PrepareMove(cloneBoard);
            }
            return cloneBoard;
        }
    }
}
