using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public abstract class Shape
    {
        public Position Position { get; set; }

        public abstract Shape Clone();
    }
}
