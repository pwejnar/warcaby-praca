using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers;
using warcaby.Properties;

namespace warcaby
{
    public enum PawnColor
    {
        Dark, Light
    }

    class PawnGraphical : PictureBox
    {
        private Pawn pawn;

        public PawnGraphical(Pawn pawn, PawnColor color)
        {
            this.pawn = pawn;

            if (pawn.GetKingState())
            {
                this.Image = color == PawnColor.Dark ? Resources.darkKing : Resources.lightKinggg;
            }
            else
            {
                this.Image = color == PawnColor.Dark ? Resources.darkPawn : Resources.lightPawn;
            }

            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackColor = Form1.darkColor;
            int controlSize = Form1.ControlSize;
            this.Size = new Size(controlSize, controlSize);
            this.Margin = new Padding(0);
        }

        public Pawn GetPawn()
        {
            return pawn;
        }
    }
}
