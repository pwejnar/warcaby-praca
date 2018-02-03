using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Working
{
    [TestClass]
    public class ScopeFindAllTest
    {
        private Player p1;
        private Board board;
        private Scope scope;

        [TestInitialize]
        public void TestInitialize()
        {
            p1 = new Player("aa", GameDirection.Down);
            board = new Board(8);
            scope = new Scope(board);
        }


        [TestMethod]
        public async Task Center()
        {
            Pawn pawn = new Pawn(p1, new Position(3, 0));
            board.PutOnBoard(pawn);

            List<Move> listOfMoves = await scope.FindMoves(p1, forceBeat);


            Assert.IsTrue(listOfMoves.Count == 3);

             longestPath

        }
    }
}
