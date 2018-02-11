using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        }

        public static async void FindNextSpeculationNodes(List<SpeculationNode> nodes)
        {

            while (nodes.Count > 0)
            {
                List<SpeculationNode> newNodes = new List<SpeculationNode>();

                foreach (SpeculationNode node in nodes)
                {
                    if (node.Depth < Root.DeepthStepsRemaining)
                    {
                        Scope scope = new Scope(node.BoardState);
                        Player other = Root.ChangePlayer(node.Player);
                        List<IMoveable> moves = await scope.FindMoves(other);

                        foreach (IMoveable move in moves)
                        {
                            SpeculationNode child = new SpeculationNode(other, move, move.Simulate(node.BoardState), node.Depth + 1);
                            node.NextNodes.Add(child);
                            newNodes.Add(child);
                        }
                    }
                }

                for (int i = 0; i < nodes.Count; i++)
                {
                    nodes[i].BoardState = null;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();

                nodes = newNodes;
            }
            

        }

        public IList GetChildrens()
        {
            return NextNodes;
        }
    }
}
