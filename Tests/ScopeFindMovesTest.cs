using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ScopeFindMovesTest
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
            Pawn pawn = new Pawn(p1, new Position(0, 3));
            board.PutOnBoard(pawn);

            List<Move> listOfMoves = await scope.FindMoves(pawn);
            Assert.IsTrue(listOfMoves.Count == 2);
        }

        [TestMethod]
        public async Task LeftBorder()
        {
            Pawn pawn = new Pawn(p1, new Position(1, 0));
            board.PutOnBoard(pawn);

            List<Move> listOfMoves = await scope.FindMoves(pawn);
            Assert.IsTrue(listOfMoves.Count == 1);
        }
        [TestMethod]
        public async Task RightBorder()
        {
            Pawn pawn = new Pawn(p1, new Position(1, 0));
            board.PutOnBoard(pawn);

            List<Move> listOfMoves = await scope.FindMoves(pawn);
            Assert.IsTrue(listOfMoves.Count == 1);
        }

        [TestMethod]
        public async Task NoMove()
        {
            Pawn pawn = new Pawn(p1, new Position(7, 4));
            board.PutOnBoard(pawn);

            List<Move> listOfMoves = await scope.FindMoves(pawn);
            Assert.IsTrue(listOfMoves.Count == 0);
        }
    }
}
