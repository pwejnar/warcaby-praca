using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers;

namespace warcaby.Extensions
{
    public interface IMoveable
    {
        void PrepareMove(Board board);
        Board Simulate(Board board);
        Position PositionBeforeMove { get; set; }
        Position PositionAfterMove { get; set; }
        MoveDirection MoveDirection { get; set; }
    }
}
