using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers;

namespace warcaby
{
    class FieldGraphical : PictureBox
    {
        private Field field;

        public FieldGraphical(Field field, Color fieldColor)
        {
            this.field = field;
            BackColor = fieldColor;
            int controlSize = Form1.ControlSize;
            Size = new Size(controlSize, controlSize);
            this.Margin = new Padding(0);
        }

        public Field GetField()
        {
            return field;
        }
    }
}
