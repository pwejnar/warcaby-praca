using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers;
using warcaby.Extensions;

namespace Checkers
{
    public class FightMove : Move, IMakeBeat, IGotPawnToBeat
    {
        public Pawn PawnToBeat { get; set; }

        public FightMove(Position positionBeforeMove, Position positionAfterMove, Pawn pawntoBeat,
            MoveDirection beatDirection)
            : base(positionBeforeMove, positionAfterMove, beatDirection)
        {
            this.PawnToBeat = pawntoBeat;
        }

        public new Board Simulate(Board board)
        {
            Board clonedBoard = board.Clone();
            PrepareMove(clonedBoard);
            return clonedBoard;
        }

        public new void PrepareMove(Board board)
        {
            base.PrepareMove(board);
            board.Remove(PawnToBeat);
        }

        public void MakeBeat(Board board)
        {
            PrepareMove(board);
        }
    }
}

