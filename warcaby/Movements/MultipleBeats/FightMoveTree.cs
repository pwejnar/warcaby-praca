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

        public List<IMakeBeat> GetBeatLists(bool onlyLongestBeats)
        {
            List<IMakeBeat> beats = new List<IMakeBeat>();

            if (Nodes.Count > 0)
            {
                TreeConverter<FightMoveNode> converter = new TreeConverter<FightMoveNode>(Nodes);

                List<MultipleFightMove> multipleBeats = new List<MultipleFightMove>();

                foreach (List<FightMoveNode> nodes in converter.ResultList)
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

                if (onlyLongestBeats && multipleBeats.Count > 0)
                {
                    multipleBeats.Sort((obj1, obj2) => obj1.FightMoves.Count.CompareTo(obj2.FightMoves.Count));
                    int longestListCount = multipleBeats.Last().FightMoves.Count;
                    List<MultipleFightMove> shorterBeats = multipleBeats.Where(x => x.FightMoves.Count < longestListCount).ToList();
                    multipleBeats = multipleBeats.Except(shorterBeats).ToList();
                    return multipleBeats.ConvertAll(obj => (IMakeBeat)obj);
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
