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
        public FightMoveNode Parent { get; set; }

        public static FightMoveNode MainParent;

        public FightMoveNode(FightMoveNode parent, IMakeBeat beatMove, Board board)
        {
            if (MainParent == null)
            { MainParent = this; }

            Parent = parent;
            BeatMove = beatMove;
            NextElements = new List<FightMoveNode>();
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

            foreach (IMakeBeat fightMove in nextFightMoves)
            {
                NextElements.Add(new FightMoveNode(this, fightMove, boardNewState));
            }
        }

        public IList GetChildrens()
        {
            return NextElements;
        }
    }
}
