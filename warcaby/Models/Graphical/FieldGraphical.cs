using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers;

namespace Checkers
{
  public class FieldGraphical : PictureBox
  {
    public Field Field;

    public FieldGraphical(Field field, Color fieldColor)
    {
      this.Field = field;
      BackColor = fieldColor;
      int controlSize = BoardForm.ControlSize;
      Size = new Size(controlSize, controlSize);
      this.Margin = new Padding(0);
    }
  }
}
