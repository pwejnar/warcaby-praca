using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers;

namespace Checkers
{
  public class PlayerGraphical
  {
    public Player Player { get; set; }
    public PawnColor PawnsColor { get; set; }
    public bool Ai { get; set; }
    public TimeSpan TimeLeft { get; set; }

    public PlayerGraphical(string nick, bool aiMode, PawnColor pawnsColor, GameDirection gameDirection)
    {
      Player = new Player(nick, gameDirection);
      PawnsColor = pawnsColor;
      Ai = aiMode;
      TimeLeft = new TimeSpan(0, 10, 0);
    }

    public void RestartLeftTime()
    {
      TimeLeft = new TimeSpan(0, 10, 0);
    }
  }
}
