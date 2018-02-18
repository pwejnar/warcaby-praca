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
            p1 = new Player("aa", GameDirection.Up);
            p2 = new Player("bb", GameDirection.Down);
            board = new Board(8);
        }


        [TestMethod]
        public async Task TestMethod1()
        {

            Pawn pawn0 = new Pawn(p1, new Position(6, 5));
            Pawn pawn1 = new Pawn(p1, new Position(7, 6));
            Pawn enemyPawn = new Pawn(p2, new Position(1, 0));

            board.PutOnBoard(pawn0);
            board.PutOnBoard(pawn1);
            board.PutOnBoard(enemyPawn);

            Speculation spec = new Speculation(p1, p2, board, 5);
            MoveAnalyze move = await spec.FindBestMove();

            Assert.IsTrue(move.Move.MoveDirection == MoveDirection.UpperLeft);
        }

        [TestMethod]
        public async Task TestMethod2()
        {

            Pawn pawn0 = new Pawn(p1, new Position(6, 5));
            Pawn pawn1 = new Pawn(p1, new Position(7, 6));
            Pawn enemyPawn0 = new Pawn(p2, new Position(1, 0));
            Pawn enemyPawn1 = new Pawn(p2, new Position(0, 5));

            pawn0.KingState = true;
            pawn1.KingState = true;
            enemyPawn0.KingState = true;
            enemyPawn1.KingState = true;

            board.PutOnBoard(pawn0);
            board.PutOnBoard(pawn1);
            board.PutOnBoard(enemyPawn0);
            board.PutOnBoard(enemyPawn1);

            Speculation spec = new Speculation(p1, p2, board, 5);
            MoveAnalyze move = await spec.FindBestMove();

            Assert.IsTrue(move.Move.MoveDirection == MoveDirection.UpperLeft);
        }


        [TestMethod]
        public async Task TestMethod3() // go in the middle and beat one pawn
        {
            Pawn pawn0 = new Pawn(p1, new Position(5, 2));

            Pawn enemyPawn0 = new Pawn(p2, new Position(2, 3));
            Pawn enemyPawn1 = new Pawn(p2, new Position(4, 5));

            pawn0.KingState = true;
            enemyPawn0.KingState = true;
            enemyPawn1.KingState = true;

            board.PutOnBoard(pawn0);
            board.PutOnBoard(enemyPawn0);
            board.PutOnBoard(enemyPawn1);

            Speculation spec = new Speculation(p1, p2, board, 5);
            MoveAnalyze bestMove = await spec.FindBestMove();

            Position newPosition = new Position(3, 4);
            Assert.IsTrue(bestMove.Move.PositionAfterMove.Equals(newPosition));
        }

        [TestMethod]
        public async Task TestMethod4()
        {
            Pawn pawn0 = new Pawn(p1, new Position(7, 2));
            Pawn enemyPawn0 = new Pawn(p2, new Position(4, 1));

            board.PutOnBoard(pawn0);
            board.PutOnBoard(enemyPawn0);

            Speculation spec = new Speculation(p1, p2, board, 5);
            MoveAnalyze bestMove = await spec.FindBestMove();
            Assert.IsTrue(bestMove.Move.MoveDirection == MoveDirection.UpperLeft);
        }

        [TestMethod]
        public async Task TestMethod5() //test wydajnosci
        {
            Pawn pawn0 = new Pawn(p1, new Position(7, 6));
            Pawn enemyPawn0 = new Pawn(p2, new Position(0, 1));

            board.PutOnBoard(pawn0);
            board.PutOnBoard(enemyPawn0);

            Speculation spec = new Speculation(p1, p2, board, 10);
            MoveAnalyze bestMove = await spec.FindBestMove();
            Assert.IsTrue(true);
        }


    }
}
