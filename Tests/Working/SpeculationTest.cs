using System;
using System.Threading.Tasks;
using Checkers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using warcaby.AI;
using warcaby.AI.Rating;
using warcaby.Extensions;

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

            Speculation spec = new Speculation(p1, p2, board, 5);
            MoveAnalyze move = await spec.FindBestMove();

            Assert.IsTrue(true);
        }


    }
}
