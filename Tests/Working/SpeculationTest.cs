using System;
using System.Threading.Tasks;
using Checkers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using warcaby.AI;

namespace Tests.Working
{
    [TestClass]
    public class SpeculationTest
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
        public async Task TestMethod1()
        {
            board.SetUpPawns(p1);
            board.SetUpPawns(p2);

            SpeculationTree tree = new SpeculationTree(board, p1, p2, 10);
            var speculationLists = tree.GetSpeculationLists();

            Assert.IsTrue(true);
        }
    }
}
