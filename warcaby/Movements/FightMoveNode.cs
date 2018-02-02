using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers;

namespace warcaby.Movements
{
    public class FightMoveNode
    {
        public FightMove FightMove { get; set; }
        public List<FightMoveNode> NextElements { get; set; }

        public FightMoveNode(Board board, FightMove fightMove)
        {
            FightMove = fightMove;
            FindNextNodes(board);
        }

        private async void FindNextNodes(Board board)
        {
            Board boardNewState = FightMove.Simulate(board);
            Scope scope = new Scope(boardNewState);
            Pawn pawnNewState = boardNewState.GetControlInPosition(FightMove.PositionAfterMove) as Pawn;
            List<MoveDirection> moveDirections = Movement.GetDirections();
            moveDirections.Remove(Movement.GetOpositteDirection(FightMove.MoveDirection));
            List<FightMove> fightMoves = await scope.FindFightMoves(pawnNewState, moveDirections);

            if (fightMoves == null)
                return;

            foreach (FightMove fightMove in fightMoves)
            {
                NextElements.Add(new FightMoveNode(boardNewState, fightMove));
            }

        }
    }
}
