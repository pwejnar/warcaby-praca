using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Checkers;
using warcaby;
using warcaby.Engine;

namespace Tests
{
    [TestClass]
    public class SpeculationTest
    {
        private Player p1;
        private Player p2;
        private Board board;

        // check situation when there is only one move 

        //check situation whe enemy has no move  or has no pawn

        [TestInitialize]
        public void TestInitialize()
        {
            p1 = new Player("aa", GameDirection.Down);
            p2 = new Player("bb", GameDirection.Up);
            board = new Board(8);

            Pawn pawn = new Pawn(p1, new Position(0, 3));
            Pawn enemy = new Pawn(p2, new Position(7, 4));

            board.PutOnBoard(pawn);
            board.PutOnBoard(enemy);
        }


        [TestMethod]
        public void SpeculationTest0()
        {
            int inteligenceLevel = 3;
            Speculation s = new Speculation(p1, p2, board, inteligenceLevel);
            List<List<SpeculationNode>> movesList = s.GetLists();
            Assert.IsTrue(movesList[0].Count == inteligenceLevel);
        }

        [TestMethod]
        public void SpeculationTest1()
        {
            int inteligenceLevel = 3;
            Speculation s = new Speculation(p1, p2, board, inteligenceLevel);
            List<List<SpeculationNode>> movesList = s.GetLists();
            Assert.IsTrue(movesList[0].Count == inteligenceLevel);
        }

        [TestMethod]
        public void SpeculationTest2()
        {
            int inteligenceLevel = 7;
            Speculation s = new Speculation(p1, p2, board, inteligenceLevel);
            List<List<SpeculationNode>> movesList = s.GetLists();
            Assert.IsTrue(movesList[0].Count == inteligenceLevel);
        }

    }
}
