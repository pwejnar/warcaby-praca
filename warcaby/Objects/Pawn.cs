using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class Pawn : Shape
    {
        public bool KingState { get; set; }
        public Player Player { get; set; }

        public Pawn(Player player, Position pos)
        {
            Player = player;
            KingState = false;
            Position = pos;
        }

        public override Shape Clone()
        {
            Pawn pawn = new Pawn(this.Player, this.Position);

            if (KingState)
            {
                pawn.KingState = true;
            }
            return pawn;
        }
    }
}
