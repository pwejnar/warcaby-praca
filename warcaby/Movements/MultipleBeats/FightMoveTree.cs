using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Checkers;
using Checkers.Movements;
using warcaby.Extensions;

namespace warcaby.Movements.Fight
{
    public class FightMoveTree : IGotChildrens
    {
        public List<FightMoveNode> Nodes { get; set; }

        public FightMoveTree(Board sourceBoard, List<IMakeBeat> fightMoves)
        {
            Nodes = new List<FightMoveNode>();
            GenerateTree(sourceBoard, fightMoves);
        }

        private void GenerateTree(Board sourceBoard, List<IMakeBeat> fightMoves)
        {
            if (fightMoves == null || fightMoves.Count == 0)
            {
                throw new Exception("List has to contain one or more fightMove");
            }
            foreach (var fightMove in fightMoves)
            {
                Nodes.Add(new FightMoveNode(fightMove, sourceBoard));
            }
        }

        public List<IMakeBeat> GetBeatLists()
        {
            List<IMakeBeat> beats = new List<IMakeBeat>();

            if (Nodes.Count > 0)
            {
                TreeConverter<FightMoveNode> converter = new TreeConverter<FightMoveNode>(Nodes);
                List<List<FightMoveNode>> fightMoveNodesList = converter.ResultList;
                List<IMakeBeat> multipleBeats = new List<IMakeBeat>();

                foreach (List<FightMoveNode> nodes in fightMoveNodesList)
                {
                    if (nodes.Count == 1)
                    {
                        beats.Add(nodes.First().BeatMove);
                    }

                    else
                    {
                        List<IMakeBeat> fightMoves = new List<IMakeBeat>();

                        foreach (FightMoveNode node in nodes)
                        {
                            fightMoves.Add(node.BeatMove);
                        }

                        multipleBeats.Add(new MultipleFightMove(fightMoves));
                    }
                }
                beats.AddRange(multipleBeats);
            }
            return beats;
        }

        public IList GetChildrens()
        {
            return Nodes;
        }
    }
}
