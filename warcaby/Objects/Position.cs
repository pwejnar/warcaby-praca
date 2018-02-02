using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public struct Position
    {
        private int row;
        private int column;

        public Position(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public int GetRow()
        {
            return row;
        }

        public int GetColumn()
        {
            return column;
        }

        public Position GetNextPosition(int x, int y)  // offset
        {
            return new Position(this.row + x, this.column + y);
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
