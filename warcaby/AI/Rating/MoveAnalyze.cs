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
        public double Rate { get; set; }

        public MoveAnalyze(IMoveable move, double rate)
        {
            this.Move = move;
            this.Rate = rate;
        }
    }
}
