using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using Checkers;

namespace Checkers
{
    public class PlayerGraphical
    {
        public Player Player { get; set; }
        public PawnColor PawnsColor { get; set; }

        public PlayerGraphical(Player player, PawnColor pawnsColor)
        {
            this.Player = player;
            this.PawnsColor = pawnsColor;
        }
    }
}
