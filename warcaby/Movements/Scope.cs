using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using warcaby;

namespace Checkers
{
    public class Scope
    {
        private Board board;
        public Scope(Board board)
        {
            this.board = board;
        }

        public List<Move> GetAvailableMoves(Pawn pawn, bool forceBeat = true)
        {
            List<Move> moves = new List<Move>();
            moves.AddRange(FindEnemies(pawn));

            if (forceBeat && moves.Count > 0)
                return moves;

            moves.AddRange(FindMoves(pawn));
            return moves;
        }

        public List<Move> GetAvailableMoves(Player player, bool forceBeat = true)
        {
            List<Pawn> pawns = board.GetPlayerPawns(player);
            List<Move> allMoves = new List<Move>();

            foreach (Pawn pawn in pawns)
            {
                var fightMoves = FindEnemies(pawn);
                allMoves.AddRange(fightMoves);
            }

            if (forceBeat && allMoves.Count > 0)
                return allMoves;

            foreach (Pawn pawn in pawns)
            {
                var normalMoves = FindMoves(pawn);
                allMoves.AddRange(normalMoves);
            }

            return allMoves;
        }

        private List<Move> FindMoves(Pawn mainPawn)
        {
            if (mainPawn == null)
                throw new Exception("pawn cannot be null");

            List<Move> moves = new List<Move>();
            List<MoveDirection> availableDirections = mainPawn.GetKingState() ?
                Movement.GetDirections()
                : Movement.GetDirections(mainPawn.GetOwner().GetDirection());

            foreach (var direction in availableDirections)
            {
                var availableField = board.GetControlInDirection(mainPawn.GetPosition(), direction) as Field;

                while (availableField != null)
                {
                    moves.Add(new Move(mainPawn.GetPosition(), availableField.GetPosition(), direction));
                    if (!mainPawn.GetKingState()) break;
                    availableField = board.GetControlInDirection(availableField.GetPosition(), direction) as Field;
                }
            }
            return moves;
        }


        private List<FightMove> FindEnemies(Pawn mainPawn, Position afterMove, List<MoveDirection> directions)
        {
            bool kingStatus = mainPawn.GetKingState();
            List<FightMove> fightmoves = new List<FightMove>();

            foreach (var beatDirection in directions)
            {
                Pawn enemy = null;
                Shape shape = board.GetControlInDirection(afterMove, beatDirection);

                while (shape != null)
                {
                    if (enemy == null)
                    {
                        enemy = shape as Pawn;

                        if (enemy == null && !kingStatus || enemy != null && enemy.GetOwner() == mainPawn.GetOwner())
                            break;
                    }

                    else if (shape is Pawn)
                        break;

                    else
                    {
                        Field availableField = shape as Field;

                        if (availableField != null)
                        {
                            FightMove fm = new FightMove(afterMove, availableField.GetPosition(), enemy, beatDirection);
                            fm.NextMoves = GetNextBeats(fm, mainPawn);
                            fightmoves.Add(fm);
                        }

                        if (!kingStatus) break;
                    }

                    shape = board.GetControlInDirection(shape.GetPosition(), beatDirection);
                }
            }
            return fightmoves;
        }

        private List<FightMove> GetNextBeats(FightMove move, Pawn mainPawn)
        {
            List<MoveDirection> availableDirections = Movement.GetDirections();
            MoveDirection opositteDirection = Movement.GetOpositteDirection(move.MoveDirection);
            availableDirections.Remove(opositteDirection);

            List<FightMove> nextBeats = FindEnemies(mainPawn, move.PositionAfterMove, availableDirections);
            return nextBeats;
        }

        private List<FightMove> FindEnemies(Pawn mainPawn)
        {
            List<FightMove> enemies = FindEnemies(mainPawn, mainPawn.GetPosition(), Movement.GetDirections());

            foreach (FightMove fm in enemies)
            {
                TreeConverter<FightMove> converter = new TreeConverter<FightMove>(fm);
                List<List<FightMove>> fightMovesList = converter.GetGeneratedLists();
                fm.SetPossibleWays(fightMovesList);
            }

            return enemies;
        }
    }
}
