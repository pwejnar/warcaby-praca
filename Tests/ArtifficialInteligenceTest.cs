//using System;
//using System.Collections.Generic;
//using Checkers;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using warcaby;
//using warcaby.Engine;

//namespace Tests
//{
//    [TestClass]
//    public class UnitTest1
//    {

//        private Player p1;
//        private Player p2;
//        private Board board;
//        private Scope scope;

//        [TestInitialize]
//        public void TestInitialize()
//        {
//            p1 = new Player("aa", GameDirection.Up);
//            p2 = new Player("bb", GameDirection.Down);
//            board = new Board(8);
//            scope = new Scope(board);
//        }


//        [TestMethod]
//        public void case0()
//        {
//            Pawn ownerPawn = new Pawn(p1, new Position(7, 4));
//            Pawn enemy = new Pawn(p2, new Position(5, 2));

//            board.PutOnBoard(ownerPawn, enemy);

//            Speculation speculation = new Speculation(p1, p2, board, 3);
//            ArtificialIntelligence ai = new ArtificialIntelligence(speculation);
//            List<Move> bestMove = ai.GetBestRatingTestOnly();

//            Assert.IsTrue(bestMove[0].GetMoveDirection() == MoveDirection.UpperRight);
//        }


//        [TestMethod]
//        public void case1()
//        {
//            Pawn ownerPawn = new Pawn(p1, new Position(5, 4));
//            Pawn enemy = new Pawn(p2, new Position(2, 3));

//            board.PutOnBoard(ownerPawn, enemy);

//            Speculation speculation = new Speculation(p1, p2, board, 3);
//            ArtificialIntelligence ai = new ArtificialIntelligence(speculation);

//            List<Move> bestMove = ai.GetBestRatingTestOnly();
//            Assert.IsTrue(bestMove[0].GetMoveDirection() == MoveDirection.UpperLeft);
//        }

//        [TestMethod]
//        public void case2()
//        {
//            Pawn ownerPawn = new Pawn(p1, new Position(7, 2));
//            Pawn enemy = new Pawn(p2, new Position(4, 1));

//            board.PutOnBoard(ownerPawn, enemy);

//            Speculation speculation = new Speculation(p1, p2, board, 5);
//            ArtificialIntelligence ai = new ArtificialIntelligence(speculation);

//            List<Move> bestMove = ai.GetBestRatingTestOnly();
//            Assert.IsTrue(bestMove[0].GetMoveDirection() == MoveDirection.UpperLeft);
//        }


//        [TestMethod]
//        public void case3()
//        {
//            Pawn ownerPawn = new Pawn(p1, new Position(5, 2));
//            ownerPawn.SetKing();

//            Pawn enemy0 = new Pawn(p2, new Position(2, 3));
//            Pawn enemy1 = new Pawn(p2, new Position(4, 5));

//            board.PutOnBoard(ownerPawn, enemy0, enemy1);

//            Speculation speculation = new Speculation(p1, p2, board, 3);
//            ArtificialIntelligence ai = new ArtificialIntelligence(speculation);

//            List<Move> bestMove = ai.GetBestRatingTestOnly();

//            bool rowOk = bestMove[0].PositionAfterMove.GetRow() == 3;
//            bool columnOk = bestMove[0].PositionAfterMove.GetColumn() == 4;
//            Assert.IsTrue(rowOk && columnOk);
//        }


//        [TestMethod]
//        public void case4()
//        {
//            Pawn ownerPawn = new Pawn(p1, new Position(0, 5));
//            ownerPawn.SetKing();

//            Pawn enemy0 = new Pawn(p2, new Position(2, 5));
//            Pawn enemy1 = new Pawn(p2, new Position(2, 7));

//            board.PutOnBoard(ownerPawn, enemy0, enemy1);

//            Speculation speculation = new Speculation(p1, p2, board, 3);
//            ArtificialIntelligence ai = new ArtificialIntelligence(speculation);

//            List<Move> bestMove = ai.GetBestRatingTestOnly();

//            bool rowOk = bestMove[0].PositionAfterMove.GetRow() == 2;
//            bool columnOk = bestMove[0].PositionAfterMove.GetColumn() == 3;
//            Assert.IsTrue(rowOk && columnOk);
//        }

//        [TestMethod]
//        public void case5() // oplacalnosc wymiany 
//        {
//            Pawn ownerPawn0 = new Pawn(p1, new Position(5, 4));
//            Pawn ownerPawn1 = new Pawn(p1, new Position(6, 5));
//            Pawn ownerPawn2 = new Pawn(p1, new Position(7, 6));

//            Pawn enemy0 = new Pawn(p2, new Position(3, 2));
//            Pawn enemy1 = new Pawn(p2, new Position(3, 4));
//            Pawn enemy2 = new Pawn(p2, new Position(5, 2));

//            board.PutOnBoard(ownerPawn0, ownerPawn1, ownerPawn2, enemy0, enemy1, enemy2);

//            Speculation speculation = new Speculation(p1, p2, board, 3);
//            ArtificialIntelligence ai = new ArtificialIntelligence(speculation);

//            List<Move> bestMove = ai.GetBestRatingTestOnly();

//            bool rowOk = bestMove[0].PositionAfterMove.GetRow() == 4;
//            bool columnOk = bestMove[0].PositionAfterMove.GetColumn() == 3;
//            Assert.IsTrue(rowOk && columnOk);
//        }



//        [TestMethod]
//        public void case6()
//        {
//            Pawn ownerPawn0 = new Pawn(p1, new Position(7, 4));
//            Pawn ownerPawn1 = new Pawn(p1, new Position(6, 5));
//            Pawn enemy0 = new Pawn(p2, new Position(4, 7));

//            board.PutOnBoard(ownerPawn0, ownerPawn1, enemy0);

//            Speculation speculation = new Speculation(p1, p2, board, 6);
//            ArtificialIntelligence ai = new ArtificialIntelligence(speculation);

//            List<Move> bestMove = ai.GetBestRatingTestOnly();

//            bool rowOk = bestMove[0].PositionAfterMove.GetRow() == 5;
//            bool columnOk = bestMove[0].PositionAfterMove.GetColumn() == 6;
//            Assert.IsTrue(rowOk && columnOk);
//        }

//        [TestMethod]
//        public void case8()
//        {
//            Pawn ownerPawn0 = new Pawn(p1, new Position(6, 1));

//            Pawn enemy0 = new Pawn(p2, new Position(5, 2));
//            Pawn enemy1 = new Pawn(p2, new Position(3, 4));
//            Pawn enemy2 = new Pawn(p2, new Position(1, 6));

//            board.PutOnBoard(ownerPawn0, enemy0, enemy1, enemy2);

//            Speculation speculation = new Speculation(p1, p2, board, 3);
//            ArtificialIntelligence ai = new ArtificialIntelligence(speculation);

//            List<Move> bestMove = ai.GetBestRatingTestOnly();
//            List<FightMove> fmoves = Extension.ToFightMoves(bestMove);
//            FightMove.PrepareMove(board, fmoves);

//            Pawn afterMove = board.GetControlInPosition(new Position(0, 7)) as Pawn;
//            Assert.IsTrue(afterMove != null);
//        }


//        [TestMethod]
//        public void case9()
//        {
//            Pawn ownerPawn0 = new Pawn(p2, new Position(3, 4));

//            Pawn enemy0 = new Pawn(p1, new Position(7, 0));
//            Pawn enemy1 = new Pawn(p1, new Position(5, 2));
//            Pawn enemy2 = new Pawn(p1, new Position(2, 1));
//            Pawn enemy3 = new Pawn(p1, new Position(2, 7));

//            board.PutOnBoard(ownerPawn0, enemy0, enemy1, enemy2, enemy3);

//            Speculation speculation = new Speculation(p2, p1, board, 3);
//            ArtificialIntelligence ai = new ArtificialIntelligence(speculation);

//            List<Move> bestMove = ai.GetBestRatingTestOnly();

//            bool rowOk = bestMove[0].PositionAfterMove.GetRow() == 4;
//            bool columnOk = bestMove[0].PositionAfterMove.GetColumn() == 5;
//            Assert.IsTrue(rowOk && columnOk);
//        }

//        [TestMethod]
//        public void case10()
//        {
//            Pawn ownerPawn0 = new Pawn(p2, new Position(3, 4));

//            Pawn enemy0 = new Pawn(p1, new Position(7, 0));
//            Pawn enemy1 = new Pawn(p1, new Position(5, 2));
//            Pawn enemy2 = new Pawn(p1, new Position(2, 1));
//            Pawn enemy3 = new Pawn(p1, new Position(2, 7));

//            board.PutOnBoard(ownerPawn0, enemy0, enemy1, enemy2, enemy3);

//            Speculation speculation = new Speculation(p2, p1, board, 5);
//            ArtificialIntelligence ai = new ArtificialIntelligence(speculation);

//            List<Move> bestMove = ai.GetBestRatingTestOnly();

//            bool rowOk = bestMove[0].PositionAfterMove.GetRow() == 4;
//            bool columnOk = bestMove[0].PositionAfterMove.GetColumn() == 3;
//            Assert.IsTrue(rowOk && columnOk);
//        }



//    }
//}
