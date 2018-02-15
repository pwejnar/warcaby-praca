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
        public List<SpeculationNode> Nodes { get; set; }
        public static SpeculationTree Root { get; set; }

        public SpeculationNode(Player player, IMoveable move, Board boardState, int depth)
        {
            this.Player = player;
            this.Move = move;
            this.BoardState = boardState;
            this.Depth = depth;
            Nodes = new List<SpeculationNode>();
        }

        private SpeculationNode()
        {

        }

        public IList GetChildrens()
        {
            return Nodes;
        }

        public static void Initialize(List<IMoveable> moves, Player player, Board board)
        {
            SpeculationNode sn = new SpeculationNode();

            List<SpeculationNode> childrens = sn.GenerateChildrens(moves, player, board, 0);
            sn.FindSpeculationNodes(childrens);
        }

        public List<SpeculationNode> GenerateChildrens(List<IMoveable> moves, Player player, Board board, int depth)
        {
            List<SpeculationNode> nodes = new List<SpeculationNode>();

            foreach (IMoveable move in moves)
            {
                SpeculationNode child = new SpeculationNode(player, move, move.Simulate(board), depth);
                nodes.Add(child);
            }

            return nodes;
        }

        private async void FindSpeculationNodes(List<SpeculationNode> nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                SpeculationNode n = nodes[i];

                if (n.Depth >= Root.DeepthStepsRemaining)
                    break;

                Scope scope = new Scope(n.BoardState);
                Player other = Root.ChangePlayer(n.Player);
                List<IMoveable> moves = await scope.FindMoves(other);
                List<SpeculationNode> childrens = n.GenerateChildrens(moves, other, n.BoardState, n.Depth + 1);
                n.Nodes = childrens;
                n.BoardState = null;

                if (n.Depth < Root.DeepthStepsRemaining)
                {
                    n.FindSpeculationNodes(childrens);
                }
            }
        }

        //nastepny obiekt opiera sie na planszy poprzedniego
        //po wykonaniu petli moge pousuwac wszystkie plansze, ale to juz bedzie na samym koncu
    }
}
