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
    public struct SpeculationNode : IGotChildrens
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

            //    SpeculationNode node = new SpeculationNode();

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Depth < Root.DeepthStepsRemaining)
                {
                    Scope scope = new Scope(nodes[i].BoardState);
                    Player other = Root.ChangePlayer(nodes[i].Player);
                    List<IMoveable> moves = await scope.FindMoves(other);

                    foreach (IMoveable move in moves)
                    {
                        SpeculationNode node2 = new SpeculationNode(other, move, move.Simulate(nodes[i].BoardState), nodes[i].Depth + 1);
                        node2.NextNodes.Add(node2);
                        // node.FindNextSpeculationNodes();
                    }

                } 
            }

           
        }

        public IList GetChildrens()
        {
            return NextNodes;
        }
    }
}
