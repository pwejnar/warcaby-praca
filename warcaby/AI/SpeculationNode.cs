using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using warcaby;
using warcaby.Engine;

namespace Checkers
{
    public class SpeculationNode : IGotChildrens
    {
        public List<Move> move { get; set; }
        public Board effect { get; set; }
        public Player player { get; set; }
        public int deepLevel { get; set; }
        public List<SpeculationNode> speculationChildren { get; set; }


        public SpeculationNode(List<Move> move, Board effect, Player player, int deepLevel)
        {
            this.effect = effect;
            this.move = move;
            this.player = player;
            this.deepLevel = deepLevel;
            this.speculationChildren= new List<SpeculationNode>();
        }

        public IList GetChildrens()
        {
            return speculationChildren;
        }
    }
}
