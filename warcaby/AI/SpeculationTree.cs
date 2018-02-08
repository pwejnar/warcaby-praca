using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Checkers;
using Checkers.Movements;
using warcaby.Extensions;

namespace warcaby.AI
{
    public class SpeculationTree : IGotChildrens
    {
        public Board StartBoard { get; set; }
        public Player Player { get; set; }
        public Player Oponent { get; set; }
        public List<SpeculationNode> Nodes { get; set; }
        public int DeepthStepsRemaining { get; set; }

        public SpeculationTree(Board board, Player player, Player oponent, int deepth)
        {
            this.StartBoard = board;
            this.Player = player;
            this.Oponent = oponent;
            Nodes = new List<SpeculationNode>();
            SpeculationNode.Root = this;
            DeepthStepsRemaining = deepth;
            FindPlayerMoves(board, player);
        }

        private async void FindPlayerMoves(Board board, Player player)
        {
            Scope scope = new Scope(board);
            List<IMoveable> moves = await scope.FindMoves(player);

            foreach (var move in moves)
            {
                Nodes.Add(new SpeculationNode(player, move, move.Simulate(board), 0));
            }
        }

        public List<List<SpeculationNode>> GetSpeculationLists()
        {
            List<List<SpeculationNode>> speculations = new List<List<SpeculationNode>>();

            if (Nodes.Count > 0)
            {
                TreeConverter<SpeculationNode> converter = new TreeConverter<SpeculationNode>(Nodes);
                speculations = converter.ResultList;
            }
            return speculations;
        }

        public Player ChangePlayer(Player player)
        {
            if (player == this.Player)
                return Oponent;
            return player;
        }

        public IList GetChildrens()
        {
            return Nodes;
        }
    }
}
