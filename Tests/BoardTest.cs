using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Checkers;

namespace Tests
{
    [TestClass]
    public class BoardTest
    {

        private Player p1;
        private Player p2;
        private Board board;

        [TestInitialize]
        public void TestInitialize()
        {
            p1 = new Player("aa", GameDirection.Down);
            p2 = new Player("bb", GameDirection.Up);
            board = new Board(8);
        }

        [TestMethod]
        public void SetUpPawnsOnBoard()
        {
            var shapes = board.GetAllShapes();

            board.SetUpPawns(p1);
            bool Fields = shapes[0, 0] is Field && shapes[2, 0] is Field && shapes[4, 0] is Field && shapes[5, 0] is Field;
            bool Pawns = shapes[0, 1] is Pawn && shapes[1, 2] is Pawn && shapes[2,3] is Pawn && shapes[0, 7] is Pawn;

            board.SetUpPawns(p2);
            bool Fields1 = shapes[6, 0] is Field && shapes[6, 2] is Field && shapes[7, 1] is Field;
            bool Pawns1 = shapes[5, 0] is Pawn && shapes[6, 1] is Pawn && shapes[7, 2] is Pawn && shapes[6, 7] is Pawn;

            Assert.IsTrue(Fields && Pawns && Fields1 && Pawns1);
        }

    }
}
