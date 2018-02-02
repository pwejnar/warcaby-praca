//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Checkers;

//namespace warcaby.Engine
//{
//    public class SpeculationListRating
//    {
//        private List<SpeculationNode> speculationList;
//        private int rate;

//        public SpeculationListRating(List<SpeculationNode> speculationList)
//        {
//            this.speculationList = speculationList;
//            rate = RateList(speculationList);
//        }

//        private int RateList(List<SpeculationNode> list)
//        {
//            SpeculationNode first = list.First();
//            SpeculationNode last = list.Last();

//            Player mainPlayer = first.player;

//            BoardRating rating0 = new BoardRating(first.effect, mainPlayer);
//            BoardRating rating1 = new BoardRating(last.effect, mainPlayer);

//            return rating1.Rate() - rating0.Rate();
//        }

//        public int GetRate()
//        {
//            return rate;
//        }
//    }
//}
