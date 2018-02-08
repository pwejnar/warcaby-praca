using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using warcaby.Extensions;
using warcaby.Movements;

namespace Checkers
{
    public class Move : IMoveable
    {
        public Position PositionBeforeMove { get; set; }
        public Position PositionAfterMove { get; set; }
        public MoveDirection MoveDirection { get; set; }

        public Move(Position positionBeforeMove, Position positionAfterMove, MoveDirection moveDirection)
        {
            this.PositionBeforeMove = positionBeforeMove;
            this.PositionAfterMove = positionAfterMove;
            this.MoveDirection = moveDirection;
        }


        public Board Simulate(Board board)
        {
            Board clonedBoard = board.Clone();
            PrepareMove(clonedBoard);
            return clonedBoard;
        }

        public void PrepareMove(Board board)
        {
            Pawn pawn = (Pawn)board.GetControlInPosition(PositionBeforeMove);
            Field field = (Field)board.GetControlInPosition(PositionAfterMove);
            board.ChangePosition(pawn, field);
            board.CheckIfScoreKing(pawn);
        }
    }
}
