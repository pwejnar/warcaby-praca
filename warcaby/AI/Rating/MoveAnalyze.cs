using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using warcaby.Extensions;

namespace warcaby.AI.Rating
{
    public class MoveAnalyze
    {
        public IMoveable Move { get; set; }
        public MoveStatus Status { get; set; }

        public MoveAnalyze(IMoveable move, MoveStatus status)
        {
            this.Move = move;
            this.Status = status;
        }
    }
}
