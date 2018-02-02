using System;
using System.Collections.Generic;
using System.Linq;
using Checkers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using warcaby;

namespace Tests
{
    [TestClass]
    public class ScopeFindMovesTest
    {
        private Player p1;
        private Board board;
        private Scope scope;

        [TestInitialize]
        public void TestInitialize()
        {
            p1 = new Player("aa", GameDirection.Down);
            board = new Board(8);
            scope = new Scope(board);
        }


        [TestMethod]
        public void Center()
        {
            Pawn pawn = new Pawn(p1, new Position(0, 3));
            board.PutOnBoard(pawn);

            List<Move> listOfMoves = scope.GetAvailableMoves(p1);
            Assert.IsTrue(listOfMoves.Count == 2);
        }

        [TestMethod]
        public void LeftBorder()
        {
            Pawn pawn = new Pawn(p1, new Position(1, 0));
            board.PutOnBoard(pawn);

            List<Move> listOfMoves = scope.GetAvailableMoves(p1);
            Assert.IsTrue(listOfMoves.Count == 1);
        }
        [TestMethod]
        public void RightBorder()
        {
            Pawn pawn = new Pawn(p1, new Position(1, 0));
            board.PutOnBoard(pawn);

            List<Move> listOfMoves = scope.GetAvailableMoves(p1);
            Assert.IsTrue(listOfMoves.Count == 1);
        }

        [TestMethod]
        public void NoMove()
        {
            Pawn pawn = new Pawn(p1, new Position(7, 4));
            board.PutOnBoard(pawn);

            List<Move> listOfMoves = scope.GetAvailableMoves(p1);
            Assert.IsTrue(listOfMoves.Count == 0);
        }

        [TestMethod]
        public void Simulate()
        {
            Pawn pawn = new Pawn(p1, new Position(0, 3));
            board.PutOnBoard(pawn);

            List<Move> listOfMoves = scope.GetAvailableMoves(p1);
            Move rightMove = listOfMoves.First(move => move.MoveDirection == MoveDirection.DownRight);
            Board stateAfterSimulation = rightMove.Simulate(board);

            Position beforeMove = rightMove.PositionBeforeMove;
            Position afterMove = rightMove.PositionAfterMove;

            bool positionOfSourceNotChanged = pawn.GetPosition().GetRow() == 0 && pawn.GetPosition().GetColumn() == 3; // source pawn state not changed
            bool positionOfPawnInBoardNotChanged = board.GetControlInPosition(beforeMove) is Pawn;             // board state not changed

            bool fieldAtOldPawnPosition = stateAfterSimulation.GetControlInPosition(beforeMove) is Field;
            bool pawnAtNewPosition = stateAfterSimulation.GetControlInPosition(afterMove) is Pawn;

            Assert.IsTrue(positionOfSourceNotChanged && positionOfPawnInBoardNotChanged && fieldAtOldPawnPosition && pawnAtNewPosition);
        }
    }
}
