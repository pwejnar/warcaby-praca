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


        //[TestMethod]
        //public async Task FindAllMoves() //no forced beat 
        //{
        //    Pawn mainPawn0 = new Pawn(p1, new Position(3, 0));
        //    Pawn mainPawn1 = new Pawn(p1, new Position(6, 3));
        //    Pawn mainPawn2 = new Pawn(p1, new Position(6, 5));

        //    Pawn enemyPawn0 = new Pawn(p2, new Position(5, 2));
        //    Pawn enemyPawn1 = new Pawn(p2, new Position(2, 1));
        //    Pawn enemyPawn2 = new Pawn(p2, new Position(2, 3));

        //    board.PutOnBoard(mainPawn0, mainPawn1, mainPawn2, enemyPawn0, enemyPawn1, enemyPawn2);

        //    List<IMoveable> moves = await scope.FindMoves(board.GetPawns(p1));
        //    Assert.IsTrue(moves.Count == 5);

        //}


        //[TestMethod]
        //public async Task FindAllMoves2() //no forced beat 
        //{
        //    var watch = System.Diagnostics.Stopwatch.StartNew();

        //    Pawn mainPawn0 = new Pawn(p1, new Position(3, 0));
        //    Pawn mainPawn1 = new Pawn(p1, new Position(1, 4));
        //    Pawn mainPawn2 = new Pawn(p1, new Position(1, 6));
        //    Pawn mainPawn3 = new Pawn(p1, new Position(3, 4));
        //    Pawn mainPawn4 = new Pawn(p1, new Position(5, 4));
        //    Pawn mainPawn5 = new Pawn(p1, new Position(6, 1));
        //    Pawn mainPawn6 = new Pawn(p1, new Position(7, 4));

        //    mainPawn0.KingState = true;
        //    mainPawn1.KingState = true;
        //    mainPawn2.KingState = true;
        //    mainPawn3.KingState = true;
        //    mainPawn4.KingState = true;
        //    mainPawn5.KingState = true;
        //    mainPawn6.KingState = true;


        //    board.PutOnBoard(mainPawn0, mainPawn1, mainPawn2, mainPawn3, mainPawn4, mainPawn5, mainPawn6);
        //    List<IMoveable> moves = await scope.FindMoves(p1);

        //    watch.Stop();
        //    var elapsedMs = watch.ElapsedMilliseconds;

        //    Assert.IsTrue(moves.Count == 5);

        //}
    }
}
