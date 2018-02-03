using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using warcaby.Extensions;

namespace Tests.Working
{
    [TestClass]
    public class ScopeFindAllTest
    {
        private Player p1;
        private Player p2;
        private Board board;
        private Scope scope;

        [TestInitialize]
        public void TestInitialize()
        {
            p1 = new Player("aa", GameDirection.Up);
            p2 = new Player("bb", GameDirection.Down);
            board = new Board(8);
            scope = new Scope(board);
        }


        [TestMethod]
        public async Task FindAllMoves() //no forced beat 
        {
            Pawn mainPawn0 = new Pawn(p1, new Position(3, 0));
            Pawn mainPawn1 = new Pawn(p1, new Position(6, 3));
            Pawn mainPawn2 = new Pawn(p1, new Position(6, 5));

            Pawn enemyPawn0 = new Pawn(p2, new Position(5, 2));
            Pawn enemyPawn1 = new Pawn(p2, new Position(2, 1));
            Pawn enemyPawn2 = new Pawn(p2, new Position(2, 3));

            board.PutOnBoard(mainPawn0, mainPawn1, mainPawn2, enemyPawn0, enemyPawn1, enemyPawn2);

            List<IMoveable> moves = await scope.FindMoves(board.GetPawns(p1));
            Assert.IsTrue(moves.Count == 5);

        }
    }
}
