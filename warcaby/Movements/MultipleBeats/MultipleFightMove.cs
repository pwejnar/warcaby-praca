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
    public class MultipleFightMove : IMakeBeat
    {
        public List<IMakeBeat> FightMoves { get; set; }
        public MoveDirection MoveDirection { get; set; }
        public Position PositionBeforeMove { get; set; }
        public Position PositionAfterMove { get; set; }


        public MultipleFightMove(List<IMakeBeat> fightMoves)
        {
            FightMoves = fightMoves;
            PositionBeforeMove = fightMoves.First().PositionBeforeMove;
            PositionAfterMove = fightMoves.Last().PositionAfterMove;
            MoveDirection = FightMoves.Last().MoveDirection;
        }
        public Board Simulate(Board board)
        {
            Board cloneBoard = board.Clone();

            foreach (IMakeBeat fightMove in FightMoves)
            {
                fightMove.PrepareMove(cloneBoard);
            }
            return cloneBoard;
        }


        public bool IsMove(IMoveable move)
        {
            var x = FightMoves.Where(obj => obj.IsMove(move)).ToList();
            if (x.Count > 0)
                return true;
            return false;
        }

        public void PrepareMove(Board board)
        {
            foreach (IMakeBeat fightMove in FightMoves)
            {
                fightMove.PrepareMove(board);
            }
        }

        public IMakeBeat GetNextMove()
        {
            IMakeBeat makeBeat = FightMoves.First();
            FightMoves.Remove(makeBeat);
            return makeBeat;
        }

        public void MakeBeat(Board board)
        {
            PrepareMove(board);
        }
    }
}
