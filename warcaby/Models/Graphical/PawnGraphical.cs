﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers;
using Checkers.Properties;

namespace Checkers
{
  public enum PawnColor
  {
    Dark, Light
  }

  public class PawnGraphical : PictureBox
  {
    public Pawn Pawn { get; set; }
    public PawnColor PawnColor { get; set; }
    public PlayerGraphical GraphicalPlayer { get; set; }

    public PawnGraphical(Pawn pawn, PlayerGraphical owner, PawnColor color)
    {
      this.Pawn = pawn;
      this.GraphicalPlayer = owner;
      this.PawnColor = color;
      this.Image = color == PawnColor.Dark ? Resources.darkPawn : Resources.lightPawn;
      this.SizeMode = PictureBoxSizeMode.StretchImage;
      this.BackColor = BoardForm.DarkFieldsColor;
      int controlSize = BoardForm.ControlSize;
      this.Size = new Size(controlSize, controlSize);
      this.Margin = new Padding(0);
    }
  }
}
