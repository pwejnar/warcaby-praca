using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers;

namespace Checkers
{
    class AiPlayer : Player
    {
        public int Inteligence { get; set; }

        public AiPlayer(string nick, GameDirection gd, int inteligence) : base(nick, gd)
        {
            this.Inteligence = inteligence;
        }
    }
}
