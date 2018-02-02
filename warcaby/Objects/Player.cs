using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class Player
    {
        private string nick;
        private GameDirection direction;

        public Player(string nick, GameDirection gd)
        {
            this.nick = nick;
            this.direction = gd;
        }//

        public void SetNick(string nick)
        {
            this.nick = nick;

        }

        public string GetNick()
        {
            return nick;
        }

        public GameDirection GetDirection()
        {
            return direction;
        }
    }
}
