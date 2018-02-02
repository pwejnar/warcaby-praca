using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class Pawn : Shape
    {
        private bool king;
        private Player _player;

        public Pawn(Player player, Position pos)
        {
            _player = player;
            king = false;
            base.SetPosition(pos);
        }

        public void SetKing(bool kingState = true)
        {
            this.king = kingState;
        }

        public Player GetOwner()
        {
            return _player;
        }

        public bool GetKingState()
        {
            return king;
        }

        public override Shape Clone()
        {
            Pawn pawn = new Pawn(this._player, this.GetPosition());
            if (king)
                pawn.SetKing();
            return pawn;
        }
    }
}
