using System.Collections;
using System.Collections.Generic;
using Checkers;
using Checkers.Movements;
using warcaby.Extensions;

namespace warcaby.Movements.Fight
{
    public class FightMoveTree : IGotChildrens
    {
        public List<FightMoveNode> Nodes { get; set; }
        public List<MultipleFightMove> MultipleBeats { get; set; }

        public FightMoveTree(Board sourceBoard, List<FightMove> fightMoves)
        {
            Nodes = new List<FightMoveNode>();
            GenerateTree(sourceBoard, fightMoves);
        }

        private void GenerateTree(Board sourceBoard, List<FightMove> fightMoves)
        {
            if (fightMoves != null)
            {
                foreach (var fightMove in fightMoves)
                {
                    Nodes.Add(new FightMoveNode(fightMove, sourceBoard));
                }

                TreeConverter<FightMoveNode> converter = new TreeConverter<FightMoveNode>(Nodes);
                List<List<FightMoveNode>> fightMoveNodesList = converter.ResultList;
                MultipleBeats= new List<MultipleFightMove>();

                foreach (List<FightMoveNode> nodes in fightMoveNodesList)
                {
                    MultipleBeats.Add(new MultipleFightMove(nodes));
                }
            }
        }

        public IList GetChildrens()
        {
            return Nodes;
        }
    }
}
