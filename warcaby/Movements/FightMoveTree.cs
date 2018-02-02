using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using Checkers;

namespace warcaby.Movements
{
    public class FightMoveTree
    {
        public List<FightMoveNode> Nodes { get; set; }

        public FightMoveTree(Board sourceBoard)
        {
            Nodes = new List<FightMoveNode>();
            GenerateTree(sourceBoard);
        }

        private async void GenerateTree(Board sourceBoard)
        {
            Scope scope = new Scope(sourceBoard);
            Pawn p = null;
            List<FightMove> fightMoves = await scope.FindFightMoves(p, Movement.GetDirections());

            foreach (var fightMove in fightMoves)
            {
                Nodes.Add(new FightMoveNode(sourceBoard, fightMove));
            }
        }
    }
}
