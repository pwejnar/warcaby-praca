using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers;
using warcaby.Extensions;
using warcaby.Movements;
using warcaby.Movements.Fight;

namespace Checkers.Movements
{
    public class FightMoveNode : IGotChildrens
    {
        public IMakeBeat BeatMove { get; set; }
        public List<FightMoveNode> NextElements { get; set; }

        public static List<FightMoveNode> allNodes = new List<FightMoveNode>();

        public FightMoveNode(IMakeBeat beatMove, Board board)
        {
            allNodes.Add(this);
            BeatMove = beatMove;
            FindNextNodes(board);
        }


        private async void FindNextNodes(Board board)
        {
            Board boardNewState = BeatMove.Simulate(board);
            Scope scope = new Scope(boardNewState);

            Pawn pawnNewState = boardNewState.GetControlInPosition(BeatMove.PositionAfterMove) as Pawn;
            MoveDirection notAllowedDirection = Movement.GetOpositteDirection(BeatMove.MoveDirection);
            List<MoveDirection> directions = Movement.GetDirections();
            directions.Remove(notAllowedDirection);

            List<IMakeBeat> nextFightMoves = new List<IMakeBeat>();
            var detectedMoves = scope.FindFightMoves(pawnNewState, directions);
            await Task.WhenAll(detectedMoves.ToArray());

            foreach (Task<List<IMakeBeat>> task in detectedMoves)
            {
                if (task.Result != null)
                {
                    nextFightMoves.AddRange(task.Result);
                }
            }

            if (nextFightMoves.Count > 0)
            {
                NextElements = new List<FightMoveNode>();
                foreach (IMakeBeat fightMove in nextFightMoves)
                {
                    NextElements.Add(new FightMoveNode(fightMove, boardNewState));
                }
            }
        }

        public IList GetChildrens()
        {
            return NextElements;
        }
    }
}
