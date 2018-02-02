using System;
using System.Collections.Generic;
using Checkers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using warcaby;

namespace Tests
{
    [TestClass]
    public class ScopeFindEnemiesTest
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
        public async void TestNoBeat()
        {
            Pawn ownerPawn = new Pawn(p1, new Position(3, 4));
            board.PutOnBoard(ownerPawn);

            List<FightMove> availableMoves = await scope.FindFightMoves(ownerPawn);
            Assert.IsTrue(availableMoves.Count == 0);
        }

        [TestMethod]
        public async void TestOneBeat()
        {
            Pawn ownerPawn = new Pawn(p1, new Position(3, 4));
            Pawn enemy = new Pawn(p2, new Position(4, 3));

            board.PutOnBoard(ownerPawn, enemy);

            List<FightMove> availableMoves = await scope.FindFightMoves(ownerPawn);
            Assert.IsTrue(availableMoves.Count == 1);
        }

        [TestMethod]
        public async void TestTwoBeat() //2 enemies in different way
        {
            Pawn ownerPawn = new Pawn(p1, new Position(3, 4));
            Pawn enemy0 = new Pawn(p2, new Position(4, 3));
            Pawn enemy1 = new Pawn(p2, new Position(2, 3));

            board.PutOnBoard(ownerPawn, enemy0, enemy1);

            List<FightMove> availableMoves = await scope.FindFightMoves(ownerPawn);
            Assert.IsTrue(availableMoves.Count == 2);
        }

        [TestMethod]
        public async void TestBeatOnYouOwn()
        {
            Pawn ownerPawn = new Pawn(p1, new Position(3, 4));
            Pawn enemy0 = new Pawn(p1, new Position(4, 3));

            board.PutOnBoard(ownerPawn, enemy0);

            List<FightMove> availableMoves = await scope.FindFightMoves(ownerPawn);
            Assert.IsTrue(availableMoves.Count == 0);
        }

        [TestMethod]
        async void TestBeatBlocked()
        {
            Pawn ownerPawn = new Pawn(p1, new Position(3, 4));
            Pawn enemy0 = new Pawn(p2, new Position(4, 3));
            Pawn enemy1 = new Pawn(p2, new Position(5, 2));

            board.PutOnBoard(ownerPawn, enemy0, enemy1);

            List<FightMove> availableMoves = await scope.FindFightMoves(ownerPawn);
            Assert.IsTrue(availableMoves.Count == 0);
        }


        [TestMethod]
        public async void EnemyArround() //enemies in ea direction
        {
            Pawn ownerPawn = new Pawn(p1, new Position(3, 4));

            Pawn enemy0 = new Pawn(p2, new Position(4, 3));
            Pawn enemy1 = new Pawn(p2, new Position(2, 3));
            Pawn enemy2 = new Pawn(p2, new Position(2, 5));
            Pawn enemy3 = new Pawn(p2, new Position(4, 5));

            board.PutOnBoard(ownerPawn, enemy0, enemy1, enemy2, enemy3);

            List<FightMove> availableMoves = await scope.FindFightMoves(ownerPawn);
            Assert.IsTrue(availableMoves.Count == 4);
        }


        /// 
        /// 
        ///    [King beat]
        /// 

        //#region kingBeat


        ////Remember!
        ////Each free field after fight move is another fight move!


        //[TestMethod]
        //public void TestBeatOnYouOwnKing()
        //{
        //    Pawn ownerPawn0 = new Pawn(p1, new Position(2, 5));
        //    Pawn ownerPawn1 = new Pawn(p1, new Position(5, 2));

        //    ownerPawn0.SetKing();
        //    ownerPawn1.SetKing();

        //    board.PutOnBoard(ownerPawn0, ownerPawn1);

        //    List<Move> availableMoves = scope.GetAvailableMoves(p1);
        //    int enemiesFound = Extension.CountFightMoves(availableMoves);
        //    Assert.IsTrue(enemiesFound == 0);
        //}

        //[TestMethod]
        //public void TestBeatBlockedKing()
        //{
        //    Pawn ownerPawn = new Pawn(p1, new Position(2, 5));
        //    Pawn enemyPawn0 = new Pawn(p2, new Position(5, 2));
        //    Pawn enemyPawn1 = new Pawn(p2, new Position(6, 1));

        //    ownerPawn.SetKing();
        //    enemyPawn0.SetKing();
        //    enemyPawn1.SetKing();

        //    board.PutOnBoard(ownerPawn, enemyPawn0, enemyPawn1);

        //    List<Move> availableMoves = scope.GetAvailableMoves(p1);
        //    int enemiesFound = Extension.CountFightMoves(availableMoves);
        //    Assert.IsTrue(enemiesFound == 0);
        //}

        //[TestMethod]
        //public void TestOneBeatKing()
        //{
        //    Pawn ownerPawn = new Pawn(p1, new Position(2, 5));
        //    Pawn enemyPawn = new Pawn(p2, new Position(5, 2));

        //    ownerPawn.SetKing();
        //    enemyPawn.SetKing();

        //    board.PutOnBoard(ownerPawn, enemyPawn);

        //    List<Move> availableMoves = scope.GetAvailableMoves(p1);
        //    Assert.IsTrue(availableMoves.Count == 2);
        //}

        //[TestMethod]
        //public void TestTwoBeatKing()
        //{
        //    Pawn ownerPawn = new Pawn(p1, new Position(3, 4));
        //    Pawn enemyPawn0 = new Pawn(p2, new Position(5, 2));
        //    Pawn enemyPawn1 = new Pawn(p2, new Position(1, 6));

        //    ownerPawn.SetKing();
        //    enemyPawn0.SetKing();

        //    board.PutOnBoard(ownerPawn, enemyPawn0, enemyPawn1);

        //    List<Move> availableMoves = scope.GetAvailableMoves(p1);
        //    Assert.IsTrue(availableMoves.Count == 3);
        //}

        //#endregion
    }
}

