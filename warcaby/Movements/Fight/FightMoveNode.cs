using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers;

namespace Checkers.Movements
{
    public class FightMoveNode : IGotChildrens
    {
        public FightMove FightMove { get; set; }
        public List<FightMoveNode> NextElements { get; set; }

        public FightMoveNode(FightMove fightMove, Board board)
        {
            FightMove = fightMove;
            NextElements = new List<FightMoveNode>();
            FindNextNodes(board);
        }

        private async void FindNextNodes(Board board)
        {
            Board boardNewState = FightMove.Simulate(board);
            Scope scope = new Scope(boardNewState);
            Pawn pawnNewState = boardNewState.GetControlInPosition(FightMove.PositionAfterMove) as Pawn;
            List<MoveDirection> moveDirections = Movement.GetDirections();
            moveDirections.Remove(Movement.GetOpositteDirection(FightMove.MoveDirection));

            List<Task<List<FightMove>>> tasks = scope.FindFightMoves(pawnNewState, moveDirections);
            await Task.WhenAll(tasks.ToArray());

            List<FightMove> fightMoves = new List<FightMove>();

            foreach (Task<List<FightMove>> task in tasks)
            {
                if (task.Result != null)
                {
                    fightMoves.AddRange(task.Result);
                }
            }

            foreach (FightMove fightMove in fightMoves)
            {
                NextElements.Add(new FightMoveNode(fightMove, boardNewState));
            }
        }


        public IList GetChildrens()
        {
            return NextElements;
        }
    }
}
