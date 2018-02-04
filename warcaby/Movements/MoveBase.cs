using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Checkers;

namespace warcaby.Movements
{
    public abstract class MoveBase
    {
        public abstract Board Simulate(Board board);
        public abstract void PrepareMove(Board board);
    }
}
