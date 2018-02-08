using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers;
using warcaby.Extensions;

namespace warcaby.AI
{
    public class SpeculationNode : IGotChildrens
    {
        public int Depth { get; set; }
        public Player Player { get; set; }
        public IMoveable Move { get; set; }
        public Board BoardState { get; set; }
        public List<SpeculationNode> NextNodes { get; set; }
        public static SpeculationTree Root { get; set; }

        public SpeculationNode(Player player, IMoveable move, Board boardState, int depth)
        {
            this.Player = player;
            this.Move = move;
            this.BoardState = boardState;
            this.Depth = depth;
            NextNodes = new List<SpeculationNode>();
            FindNextSpeculationNodes();
        }

        private async void FindNextSpeculationNodes()
        {
            if (Depth < Root.DeepthStepsRemaining)
            {
                Scope scope = new Scope(BoardState);
                Player other = Root.ChangePlayer(Player);
                List<IMoveable> moves = await scope.FindMoves(other);

                foreach (IMoveable move in moves)
                {
                    NextNodes.Add(new SpeculationNode(other, move, move.Simulate(BoardState), Depth + 1));
                }
            }
        }

        public IList GetChildrens()
        {
            return NextNodes;
        }
    }
}
