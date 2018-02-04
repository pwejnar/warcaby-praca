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
    public class MultipleFightMove : MoveBase
    {
        public List<FightMove> FightMoves { get; set; }

        public MultipleFightMove(List<FightMove> fightMoves)
        {
            FightMoves = fightMoves;
        }

        public override void PrepareMove(Board board)
        {
            foreach (FightMove fightMove in FightMoves)
            {
                fightMove.PrepareMove(board);
            }
        }

        public override Board Simulate(Board board)
        {
            Board cloneBoard = board.Clone();

            foreach (FightMove fightMove in FightMoves)
            {
                fightMove.PrepareMove(cloneBoard);
            }
            return cloneBoard;
        }
    }
}
