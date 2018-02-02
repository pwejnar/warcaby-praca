using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers;

namespace warcaby.Engine
{
    public class KeyRating
    {
        private List<Move> moves;

        private int? min;
        private int? max;
        private int sum;

        public KeyRating(List<Move> move, SpeculationLists lists)
        {
            this.moves = move;
            this.min = lists.FindMinimum();
            this.max= lists.FindMaximum();
            this.sum = lists.CalculateSum();
        }

        public List<Move> GetMoves()
        {
            return moves;
        }

        public int? GetMin()
        {
            return min;
        }

        public int? GetMax()
        {
            return max;
        }

        public int GetSum()
        {
            return sum;
        }
    }
}
