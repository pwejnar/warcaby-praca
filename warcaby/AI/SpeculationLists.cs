//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Castle.Components.DictionaryAdapter;

//namespace warcaby.Engine
//{
//    public class SpeculationLists
//    {
//        private List<SpeculationListRating> speculationListsRating;

//        public SpeculationLists()
//        {
//            speculationListsRating = new List<SpeculationListRating>();
//        }

//        public void Add(SpeculationListRating slr)
//        {
//            speculationListsRating.Add(slr);
//        }

//        public int? FindMinimum()   //use after adding all items
//        {
//            int? min = null;

//            foreach (SpeculationListRating slr in speculationListsRating)
//            {
//                int curr = slr.GetRate();

//                if (min == null || curr < min)
//                    min = curr;
//            }
//            return min;
//        }

//        public int? FindMaximum()
//        {
//            int? max = null;

//            foreach (SpeculationListRating slr in speculationListsRating)
//            {
//                int curr = slr.GetRate();

//                if (max == null || curr > max)
//                    max = curr;
//            }
//            return max;
//        }

//        public int CalculateSum()
//        {
//            int sum = 0;

//            foreach (SpeculationListRating slr in speculationListsRating)
//            {
//                sum += slr.GetRate();
//            }
//            return sum;
//        }
//    }
//}
