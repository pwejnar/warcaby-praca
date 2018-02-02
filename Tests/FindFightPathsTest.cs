using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Components.DictionaryAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Checkers;
using warcaby;

namespace Tests
{
    [TestClass]
    public class FindFightPathsTest
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
            scope=new Scope(board);
        }


        #region normalPawn

        // dlugosc drzewa to pierwsza linia bicia!!

        [TestMethod]
        public void case0()
        {
            Pawn ownerPawn = new Pawn(p1, new Position(1, 0));
            Pawn enemy0 = new Pawn(p2, new Position(2, 1));
            Pawn enemy1 = new Pawn(p2, new Position(2, 3));
            Pawn enemy2 = new Pawn(p2, new Position(2, 5));

            board.PutOnBoard(ownerPawn, enemy0, enemy1, enemy2);

            List<Move> tree = scope.GetAvailableMoves(p1);
            List<FightMove> fmoves = Extension.ToFightMoves(tree);

            bool pathCount = fmoves.Count == 1;
            bool pathLength = fmoves[0].GetPossibleWays()[0].Count == 3;
            Assert.IsTrue(pathCount && pathLength);
        }

        [TestMethod]
        public void case1()
        {
            Pawn ownerPawn = new Pawn(p1, new Position(6, 3));
            Pawn enemy0 = new Pawn(p2, new Position(5, 4));
            Pawn enemy1 = new Pawn(p2, new Position(5, 6));
            Pawn enemy2 = new Pawn(p2, new Position(3, 4));
            Pawn enemy3 = new Pawn(p2, new Position(1, 4));

            board.PutOnBoard(ownerPawn, enemy0, enemy1, enemy2, enemy3);

            List<Move> tree = scope.GetAvailableMoves(p1);
            List<FightMove> fmoves = Extension.ToFightMoves(tree);

            bool path0Length = fmoves[0].GetPossibleWays().Count == 2;
            bool path1Length = fmoves[0].GetPossibleWays()[0].Count == 3;
            Assert.IsTrue(tree.Count == 1 && path0Length && path1Length);
        }

        [TestMethod]
        public void case2()
        {
            Pawn ownerPawn = new Pawn(p1, new Position(2, 3));
            Pawn enemy0 = new Pawn(p2, new Position(1, 2));
            Pawn enemy1 = new Pawn(p2, new Position(1, 4));
            Pawn enemy2 = new Pawn(p2, new Position(3, 2));
            Pawn enemy3 = new Pawn(p2, new Position(1, 6));
            Pawn enemy4 = new Pawn(p2, new Position(3, 6));

            board.PutOnBoard(ownerPawn, enemy0, enemy1, enemy2, enemy3, enemy4);

            List<Move> tree = scope.GetAvailableMoves(p1);
            List<FightMove> fmoves = Extension.ToFightMoves(tree);

            bool pathCount = fmoves[1].GetPossibleWays().Count == 1;
            bool pathLength = fmoves[1].GetPossibleWays()[0].Count == 3;
            Assert.IsTrue(tree.Count == 3 && tree.Count == 3 && pathCount && pathLength);
        }

        #endregion

        [TestMethod]
        public void case3King()
        {
            Pawn ownerPawn = new Pawn(p1, new Position(1, 0));
            ownerPawn.SetKing();

            Pawn enemy0 = new Pawn(p2, new Position(1, 4));
            Pawn enemy1 = new Pawn(p2, new Position(3, 2));
            Pawn enemy2 = new Pawn(p2, new Position(4, 5));

            board.PutOnBoard(ownerPawn, enemy0, enemy1, enemy2);

       

            List<Move> tree = scope.GetAvailableMoves(p1);
            List<FightMove> fmoves = Extension.ToFightMoves(tree);

            List<FightMove> filtered = Extension.ToFightMoves(tree);
            List<List<FightMove>> longest = Extension.GetlongestWays(filtered);

            Assert.IsTrue(longest[0].Count == 3 && tree.Count == 4);
        }

        [TestMethod]
        public void case4King()
        {
            Pawn ownerPawn = new Pawn(p1, new Position(7, 2));
            ownerPawn.SetKing();

            Pawn enemy0 = new Pawn(p2, new Position(6, 3));
            Pawn enemy1 = new Pawn(p2, new Position(6, 5));
            Pawn enemy2 = new Pawn(p2, new Position(3, 2));
            Pawn enemy3 = new Pawn(p2, new Position(1, 2));

            board.PutOnBoard(ownerPawn, enemy0, enemy1, enemy2, enemy3);


            List<Move> tree = scope.GetAvailableMoves(p1);
            List<FightMove> fmoves = Extension.ToFightMoves(tree);
            List<List<FightMove>> longest = Extension.GetlongestWays(fmoves);

            Assert.IsTrue(longest[0].Count == 3 && tree.Count == 4);
        }

        [TestMethod]
        public void case5King()
        {
            Pawn ownerPawn = new Pawn(p1, new Position(2, 3));
            ownerPawn.SetKing();

            Pawn enemy0 = new Pawn(p2, new Position(1, 2));
            Pawn enemy1 = new Pawn(p2, new Position(1, 4));
            Pawn enemy2 = new Pawn(p2, new Position(3, 2));
            Pawn enemy3 = new Pawn(p2, new Position(1, 6));

            board.PutOnBoard(ownerPawn, enemy0, enemy1, enemy2, enemy3);

            List<Move> tree = scope.GetAvailableMoves(p1);
            List<FightMove> fmoves = Extension.ToFightMoves(tree);
            List<List<FightMove>> longest = Extension.GetlongestWays(fmoves);

            Assert.IsTrue(longest[0].Count == 2 && tree.Count == 4);
        }

        [TestMethod]
        public void case6()         // brak damki
        {
            Pawn ownerPawn0 = new Pawn(p1, new Position(2, 1));
            Pawn ownerPawn1 = new Pawn(p1, new Position(2, 3));
            Pawn ownerPawn2 = new Pawn(p1, new Position(2, 5));

            Pawn enemy0 = new Pawn(p2, new Position(1, 2));
            Pawn enemy1 = new Pawn(p2, new Position(1, 4));
            Pawn enemy2 = new Pawn(p2, new Position(1, 6));
            Pawn enemy3 = new Pawn(p2, new Position(3, 2));
            Pawn enemy4 = new Pawn(p2, new Position(3, 6));

            board.PutOnBoard(ownerPawn0, ownerPawn1, ownerPawn2, enemy0, enemy1, enemy2, enemy3, enemy4);

            List<Move> tree = scope.GetAvailableMoves(p1);
            List<FightMove> fmoves = Extension.ToFightMoves(tree);
            List<List<FightMove>> longest = Extension.GetlongestWays(fmoves);

            Assert.IsTrue(longest[0].Count == 3 && tree.Count == 8);
        }
    }
}
