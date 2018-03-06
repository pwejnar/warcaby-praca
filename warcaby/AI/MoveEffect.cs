using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers;
using warcaby.Extensions;

namespace warcaby.AI
{
    public class MoveEffect
    {
        public IMoveable InitMove { get; set; }
        public Board EffectOfMove { get; set; }

        public MoveEffect(IMoveable initMove, Board boardState)
        {
            this.InitMove = initMove;
            this.EffectOfMove = boardState;
        }
    }
}
