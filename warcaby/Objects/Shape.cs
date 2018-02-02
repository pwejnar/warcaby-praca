using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public abstract class Shape
    {
        private Position position;

        public abstract Shape Clone();

        public void SetPosition(Position position)
        {
            this.position= position;
        }

        public Position GetPosition()
        {
            return position;
        }
    }
}
