using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Checkers;
using Checkers.Movements;
using warcaby.Extensions;
using warcaby.Movements;
using warcaby.Movements.Fight;

namespace Tests
{
    [TestClass]
    public class FightMoveTreeTest
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



        // dlugosc drzewa to pierwsza linia bicia!!

        [TestMethod]
        public async void case0() // get one list with 3 position 
        {
            Pawn ownerPawn = new Pawn(p1, new Position(1, 0));
            Pawn enemy0 = new Pawn(p2, new Position(2, 1));
            Pawn enemy1 = new Pawn(p2, new Position(2, 3));
            Pawn enemy2 = new Pawn(p2, new Position(2, 5));

            board.PutOnBoard(ownerPawn, enemy0, enemy1, enemy2);

            List<MoveBase> moves = await scope.FindMoves(p1);
            List<MultipleFightMove> beats = moves.Where(x => x is MultipleFightMove).ToList().ConvertAll(obj => (MultipleFightMove)obj);

            bool beatCount = beats.Count == 1;
            bool beatPathLength = beats.First().FightMoves.Count == 3;

            Assert.IsTrue(beatCount && beatPathLength);
        }


        [TestMethod]
        public async void case1()
        {
            Pawn ownerPawn = new Pawn(p1, new Position(6, 3));
            Pawn enemy0 = new Pawn(p2, new Position(5, 4));
            Pawn enemy1 = new Pawn(p2, new Position(5, 6));
            Pawn enemy2 = new Pawn(p2, new Position(3, 4));
            Pawn enemy3 = new Pawn(p2, new Position(1, 4));

            board.PutOnBoard(ownerPawn, enemy0, enemy1, enemy2, enemy3);

            List<MoveBase> moves = await scope.FindMoves(p1);
            List<MultipleFightMove> beats = moves.Where(x => x is MultipleFightMove).ToList().ConvertAll(obj => (MultipleFightMove)obj);

            bool beatCount = beats.Count == 2;
            bool beatPathLength = beats.First().FightMoves.Count == 3;
            Assert.IsTrue(beatCount && beatPathLength);
        }

        [TestMethod]
        public async void case2()
        {
            Pawn ownerPawn = new Pawn(p1, new Position(2, 3));
            Pawn enemy0 = new Pawn(p2, new Position(1, 2));
            Pawn enemy1 = new Pawn(p2, new Position(1, 4));
            Pawn enemy2 = new Pawn(p2, new Position(3, 2));
            Pawn enemy3 = new Pawn(p2, new Position(1, 6));
            Pawn enemy4 = new Pawn(p2, new Position(3, 6));

            board.PutOnBoard(ownerPawn, enemy0, enemy1, enemy2, enemy3, enemy4);

            List<MoveBase> moves = await scope.FindMoves(p1);
            List<MultipleFightMove> beats = moves.Where(x => x is MultipleFightMove).ToList().ConvertAll(obj => (MultipleFightMove)obj);

            bool beatCount = beats.Count == 3;
            MultipleFightMove longestPath = beats.First(obj => obj.FightMoves.Count == 3);
            
            Assert.IsTrue(beatCount && longestPath != null);
        }


        //[TestMethod]
        //public async Task case3King()
        //{
        //    Pawn ownerPawn = new Pawn(p1, new Position(1, 0));
        //    ownerPawn.KingState = true;

        //    Pawn enemy0 = new Pawn(p2, new Position(1, 4));
        //    Pawn enemy1 = new Pawn(p2, new Position(3, 2));
        //    Pawn enemy2 = new Pawn(p2, new Position(4, 5));

        //    board.PutOnBoard(ownerPawn, enemy0, enemy1, enemy2);

        //    FightMoveTree tree = new FightMoveTree(board, ownerPawn);
        //    TreeConverter<FightMoveNode> c = new TreeConverter<FightMoveNode>(tree.Nodes);
        //    var longestWay = c.ResultList.Where(x => x.Count == 3).ToList();
        //    Assert.IsTrue(longestWay != null);
        //}

        //[TestMethod]
        //public async void case4King()
        //{
        //    Pawn ownerPawn = new Pawn(p1, new Position(7, 2));
        //    ownerPawn.KingState = true;

        //    Pawn enemy0 = new Pawn(p2, new Position(6, 3));
        //    Pawn enemy1 = new Pawn(p2, new Position(6, 5));
        //    Pawn enemy2 = new Pawn(p2, new Position(3, 2));
        //    Pawn enemy3 = new Pawn(p2, new Position(1, 2));

        //    board.PutOnBoard(ownerPawn, enemy0, enemy1, enemy2, enemy3);

        //    FightMoveTree tree = new FightMoveTree(board, ownerPawn);
        //    TreeConverter<FightMoveNode> c = new TreeConverter<FightMoveNode>(tree.Nodes);
        //    var longestWay = c.ResultList.Where(x => x.Count == 3).ToList();
        //    Assert.IsTrue(longestWay != null);
        //}

        //[TestMethod]
        //public async void case5King()
        //{
        //    Pawn ownerPawn = new Pawn(p1, new Position(2, 3));
        //    ownerPawn.KingState = true;

        //    Pawn enemy0 = new Pawn(p2, new Position(1, 2));
        //    Pawn enemy1 = new Pawn(p2, new Position(1, 4));
        //    Pawn enemy2 = new Pawn(p2, new Position(3, 2));
        //    Pawn enemy3 = new Pawn(p2, new Position(1, 6));

        //    board.PutOnBoard(ownerPawn, enemy0, enemy1, enemy2, enemy3);

        //    FightMoveTree tree = new FightMoveTree(board, ownerPawn);
        //    TreeConverter<FightMoveNode> c = new TreeConverter<FightMoveNode>(tree.Nodes);
        //    bool listCountOk = c.ResultList.Count == 4;
        //    var longestWay = c.ResultList.Where(x => x.Count == 2).ToList();
        //    Assert.IsTrue(listCountOk && longestWay != null);
        //}


        //[TestMethod]
        //public async void case6AroundLoopTrap()
        //{
        //    Pawn ownerPawn = new Pawn(p1, new Position(2, 1));

        //    Pawn enemy0 = new Pawn(p2, new Position(3, 2));
        //    Pawn enemy1 = new Pawn(p2, new Position(3, 4));
        //    Pawn enemy2 = new Pawn(p2, new Position(1, 4));
        //    Pawn enemy3 = new Pawn(p2, new Position(1, 2));

        //    board.PutOnBoard(ownerPawn, enemy0, enemy1, enemy2, enemy3);

        //    FightMoveTree tree = new FightMoveTree(board, ownerPawn);
        //    TreeConverter<FightMoveNode> c = new TreeConverter<FightMoveNode>(tree.Nodes);
        //    bool listCountOk = c.ResultList.Count == 2;
        //    var longestWay = c.ResultList.Where(x => x.Count == 4).ToList();
        //    Assert.IsTrue(listCountOk && longestWay != null);
        //}


    }
}
