using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using warcaby;

namespace Checkers
{
    public class FightMove : Move
    {
        public Pawn PawntoBeat { get; set; }

        public FightMove(Position positionBeforeMove, Position positionAfterMove, Pawn pawntoBeat,
            MoveDirection beatDirection)
            : base(positionBeforeMove, positionAfterMove, beatDirection)
        {
            this.PawntoBeat = pawntoBeat;
        }


        public override Board Simulate(Board board)
        {
            Board clonedBoard = board.Clone();
            PrepareMove(clonedBoard);
            return clonedBoard;
        }

        public override void PrepareMove(Board board)
        {
            base.PrepareMove(board);
            board.Remove(PawntoBeat);
        }
    }
}

