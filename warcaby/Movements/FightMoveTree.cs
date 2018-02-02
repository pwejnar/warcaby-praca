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

        public FightMoveTree(Board sourceBoard, Pawn pawn)
        {
            Nodes = new List<FightMoveNode>();
            GenerateTree(sourceBoard, pawn);
        }

        private async void GenerateTree(Board sourceBoard, Pawn pawn)
        {
            Scope scope = new Scope(sourceBoard);
            List<FightMove> fightMoves = await scope.FindFightMoves(pawn, Movement.GetDirections());

            if (fightMoves != null)
            {
                foreach (var fightMove in fightMoves)
                {
                    Nodes.Add(new FightMoveNode(sourceBoard, fightMove));
                }
            }
        }
    }
}
