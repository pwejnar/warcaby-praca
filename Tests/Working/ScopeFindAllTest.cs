using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers;
using Checkers.Movements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using warcaby.Extensions;
using warcaby.Movements;
using warcaby.Movements.Fight;

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
        public async Task FindAllMovesA() //no forced beat 
        {
            Pawn mainPawn0 = new Pawn(p1, new Position(3, 0));
            Pawn mainPawn1 = new Pawn(p1, new Position(6, 3));
            Pawn mainPawn2 = new Pawn(p1, new Position(6, 5));

            Pawn enemyPawn0 = new Pawn(p2, new Position(5, 2));
            Pawn enemyPawn1 = new Pawn(p2, new Position(2, 1));
            Pawn enemyPawn2 = new Pawn(p2, new Position(2, 3));

            board.PutOnBoard(mainPawn0, mainPawn1, mainPawn2, enemyPawn0, enemyPawn1, enemyPawn2);

            List<IMoveable> moves = await scope.FindMoves(p1, false);
            Assert.IsTrue(moves.Count == 5);
        }

        [TestMethod]
        public async Task FindAllMovesB() // forced beats
        {
            Pawn mainPawn0 = new Pawn(p1, new Position(3, 0));
            Pawn mainPawn1 = new Pawn(p1, new Position(6, 3));
            Pawn mainPawn2 = new Pawn(p1, new Position(6, 5));

            Pawn enemyPawn0 = new Pawn(p2, new Position(5, 2));
            Pawn enemyPawn1 = new Pawn(p2, new Position(2, 1));
            Pawn enemyPawn2 = new Pawn(p2, new Position(2, 3));

            board.PutOnBoard(mainPawn0, mainPawn1, mainPawn2, enemyPawn0, enemyPawn1, enemyPawn2);

            List<IMoveable> moves = await scope.FindMoves(p1, true);
            Assert.IsTrue(moves.Count == 2);
        }


        [TestMethod]
        public async Task FindAllMoves2()
        {

            Pawn mainPawn0 = new Pawn(p1, new Position(3, 0));
            Pawn mainPawn1 = new Pawn(p2, new Position(4, 1));
            Pawn mainPawn2 = new Pawn(p2, new Position(4, 5));
            Pawn mainPawn3 = new Pawn(p2, new Position(1, 6));

            mainPawn0.KingState = true;
            mainPawn1.KingState = true;
            mainPawn2.KingState = true;
            mainPawn3.KingState = true;

            board.PutOnBoard(mainPawn0, mainPawn1, mainPawn2, mainPawn3);
            List<IMoveable> moves = await scope.FindMoves(p1);
            FightMoveNode aa = FightMoveNode.MainParent;
            var longest = (moves.Where(x => x is MultipleFightMove).ToList().ConvertAll(obj => (MultipleFightMove)obj)).Where(a => a.FightMoves.Count == 5);
            Assert.IsTrue(longest != null);
        }
    }
}
