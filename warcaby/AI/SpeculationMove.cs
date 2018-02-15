using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using warcaby.Extensions;

namespace warcaby.AI
{
    public class SpeculationMove
    {
        public IMoveable Move;
        public List<IMoveable> NextMoves { get; set; }

        public SpeculationMove(IMoveable move, List<IMoveable> nextMoves)
        {
            Move = move;
            NextMoves = nextMoves;
        }

    }
}
