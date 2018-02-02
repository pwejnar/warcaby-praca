//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms.VisualStyles;
//using Checkers;

//namespace warcaby.Engine
//{
//    public class ArtificialIntelligence
//    {
//        private Dictionary<KeyRating, SpeculationLists> newDictionary;

//        public ArtificialIntelligence(Speculation speculation)
//        {
//            newDictionary = GroupByFirstNode(speculation);
//        }

//        private Dictionary<KeyRating, SpeculationLists> GroupByFirstNode(Speculation speculation)
//        {
//            List<List<SpeculationNode>> allLists = speculation.GetLists();

//            Dictionary<SpeculationNode, List<List<SpeculationNode>>> dictionary =
//                new Dictionary<SpeculationNode, List<List<SpeculationNode>>>();

//            foreach (List<SpeculationNode> speculationList in allLists)
//            {
//                var firstElement = speculationList.First();

//                if (!dictionary.ContainsKey(firstElement))
//                {
//                    dictionary.Add(firstElement, new List<List<SpeculationNode>>());
//                }

//                dictionary[firstElement].Add(speculationList);
//            }

//            Dictionary<KeyRating, SpeculationLists> newDictionary =
//                new Dictionary<KeyRating, SpeculationLists>();

//            foreach (var obj in dictionary)
//            {

//                SpeculationLists sl = new SpeculationLists();

//                foreach (List<SpeculationNode> speculationList in obj.Value)
//                {
//                    SpeculationListRating slr = new SpeculationListRating(speculationList);
//                    sl.Add(slr);
//                }

//                KeyRating kr = new KeyRating(obj.Key.move, sl);
//                newDictionary.Add(kr, sl);
//            }

//            dictionary = null;
//            return newDictionary;
//        }


//        private List<Move> GetMaxInMinRating()
//        {
//            // in worse case i would have..
//            //szukasz maksa wsród minów 

//            int? max = null;
//            List<Move> best = null;

//            foreach (var obj in newDictionary)
//            {
//                int? temp = obj.Key.GetMin();

//                if (max == null || temp > max)
//                {
//                    best = obj.Key.GetMoves();
//                    max = temp;
//                }
//            }
//            return best;
//        }

//        private List<Move> GetMaxInMaxRating()
//        {
//            int? max = null;
//            List<Move> best = null;

//            foreach (var obj in newDictionary)
//            {
//                int? temp = obj.Key.GetMax();

//                if (max == null || temp > max)
//                {
//                    best = obj.Key.GetMoves();
//                    max = temp;
//                }
//            }
//            return best;
//        }

//        private List<Move> GetBestSum()
//        {
//            int sum = 0;
//            List<Move> best = null;

//            foreach (var obj in newDictionary)
//            {
//                int temp = obj.Key.GetSum();

//                if (temp > sum)
//                {
//                    best = obj.Key.GetMoves();
//                    sum = temp;
//                }
//            }
//            return best;
//        }

//        public List<Move> GetBestRatingTestOnly()
//        {
//            return GetMaxInMinRating();
//        }


//        public void MakeBestMove(Board board, Strategy strategy)
//        {
//            List<Move> bestMove = null;

//            switch (strategy)
//            {
//                case Strategy.MaxMin:
//                    {
//                        bestMove = GetMaxInMinRating();
//                        break;
//                    }

//                case Strategy.MaxMax:
//                    {
//                        bestMove = GetMaxInMaxRating();
//                        break;
//                    }

//                case Strategy.MaxSum:
//                    {
//                        bestMove = GetBestSum();
//                        break;
//                    }

//                default:
//                    bestMove = GetMaxInMinRating();
//                    break;
//            }

//            if (bestMove.Count == 1)
//            {
//                bestMove.First().PrepareMove(board);
//            }
//            else
//            {
//                //List<FightMove> fightMoves = Extension.ToFightMoves(bestMove);
//                //FightMove.PrepareMove(board, fightMoves);
//            }

//            newDictionary = null;
//        }
//    }
//}
