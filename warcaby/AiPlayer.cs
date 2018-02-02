using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers;
using warcaby.Engine;

namespace warcaby
{
    class AiPlayer : Player
    {
        private int inteligence;
        private Strategy strategy;

        public AiPlayer(string nick, GameDirection gd, int inteligence, Strategy strategy) : base(nick, gd)
        {
            this.inteligence = inteligence;
            this.strategy = strategy;
        }
        public int GetInteligence()
        {
            return inteligence;
        }
        public Strategy GetStrategy()
        {
            return strategy;
        }
    }
}
