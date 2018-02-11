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
        public LinkedList<SpeculationNode> NextNodes { get; set; }
        public static SpeculationTree Root { get; set; }

        public SpeculationNode(Player player, IMoveable move, Board boardState, int depth)
        {
            this.Player = player;
            this.Move = move;
            this.BoardState = boardState;
            this.Depth = depth;
            NextNodes = new LinkedList<SpeculationNode>();
        }

        private async void FindSpeculationNodes()
        {
            if (Depth < Root.DeepthStepsRemaining)
            {
                Scope scope = new Scope(BoardState);
                Player other = Root.ChangePlayer(Player);
                List<IMoveable> moves = await scope.FindMoves(other);
                NextNodes = GenerateChildrens(moves, other, BoardState, Depth + 1);
                //BoardState = null;
            }
        }

        public static LinkedList<SpeculationNode> GenerateChildrens(List<IMoveable> moves, Player player, Board board, int depth)
        {
            LinkedList<SpeculationNode> nodes = new LinkedList<SpeculationNode>();

            foreach (IMoveable move in moves)
            {
                SpeculationNode child = new SpeculationNode(player, move, move.Simulate(board), depth);
                nodes.AddLast(child);
                child.FindSpeculationNodes();
                //    yield return child;
            }
            return nodes;
        }

        public IList GetChildrens()
        {
            return null;
        }
    }
}
