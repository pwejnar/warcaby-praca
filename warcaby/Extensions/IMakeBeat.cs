using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers;

namespace warcaby.Extensions
{
    public interface IMakeBeat : IMoveable
    {
        void MakeBeat(Board board);
    }
}
