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
            List<Pawn> pawnToCheckBeatFor = new List<Pawn>();
            pawnToCheckBeatFor.Add(pawnNewState);

            List<IMoveable> moves = await scope.FindMoves(pawnToCheckBeatFor);
            List<IMakeBeat> nextFightMoves = moves.Where(obj => obj is IMakeBeat).ToList().ConvertAll(x => (IMakeBeat)x);
            MoveDirection notAllowedDirection = Movement.GetOpositteDirection(BeatMove.MoveDirection);
            nextFightMoves = FightMoveTree.ReduceNotAllowedMoveDirection(nextFightMoves, notAllowedDirection);

            if (nextFightMoves.Count > 0)
            {
                NextElements = new List<FightMoveNode>();
                foreach (IMakeBeat fightMove in nextFightMoves)
                {
                    if (fightMove is MultipleFightMove)
                    {
                        var x = 3;
                    }
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
