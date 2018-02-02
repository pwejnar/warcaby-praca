using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public struct Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }


        public Position GetNextPosition(int x, int y)  // offset
        {
            return new Position(this.Row + x, this.Column + y);
        }

        public Position GetPositionlInDirection(MoveDirection md)
        {
            Position position = this;

            if (md == MoveDirection.DownLeft)
            {
                return position.GetNextPosition(+1, -1);
            }

            if (md == MoveDirection.DownRight)
            {
                return position.GetNextPosition(+1, +1);
            }

            if (md == MoveDirection.UpperLeft)
            {
                return position.GetNextPosition(-1, -1);
            }

            if (md == MoveDirection.UpperRight)
            {
                return position.GetNextPosition(-1, +1);
            }

            throw new Exception();
        }
    }
}
