using System.Collections;
using System.Collections.Generic;
using Checkers;
using Checkers.Movements;

namespace warcaby.Movements.Fight
{
    public class FightMoveTree :IGotChildrens
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

        public IList GetChildrens()
        {
            return Nodes;
        }
    }
}
