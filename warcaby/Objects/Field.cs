using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers
{
    public class Field : Shape
    {

        public Field(Position pos)
        {
            base.Position = pos;
        }

        public override Shape Clone()
        {
            return new Field(Position);
        }
    }
}
