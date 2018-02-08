using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using warcaby.Extensions;
using warcaby.Movements.Fight;

namespace Tests.Working
{
    [TestClass]
    public class LongestBeatPathDetectionTest
    {
        private Player p1;
        private Player p2;
        private Board board;
        private Scope scope;

        [TestInitialize]
        public void TestInitialize()
        {
            p1 = new Player("aa", GameDirection.Down);
            p2 = new Player("bb", GameDirection.Up);
            board = new Board(8);
            scope = new Scope(board);
        }

        [TestMethod]
        public async Task FindAllMoveasds6()
        {
            Pawn mainPawn0 = new Pawn(p1, new Position(3, 0));
            Pawn mainPawn1 = new Pawn(p2, new Position(4, 1));
            Pawn mainPawn2 = new Pawn(p2, new Position(4, 5));
            Pawn mainPawn3 = new Pawn(p2, new Position(1, 6));

            mainPawn0.KingState = true;

            board.PutOnBoard(mainPawn0, mainPawn1, mainPawn2, mainPawn3);
            List<MultipleFightMove> multipleFightMoves = (await scope.FindMoves(p1)).ConvertAll(obj => (MultipleFightMove)obj);
            Assert.IsTrue(multipleFightMoves.Count == 1 && multipleFightMoves.First().FightMoves.Count == 3);
        }
    }
}
