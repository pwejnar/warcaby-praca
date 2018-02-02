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
        public string Nick { get; set; }
        public GameDirection Direction { get; set; }

        public Player(string nick, GameDirection gd)
        {
            this.Nick = nick;
            this.Direction = gd;
        }
    }
}
