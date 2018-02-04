using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers;
using Checkers.Movements;
using warcaby.Extensions;
using warcaby.Movements;
using warcaby.Movements.Fight;

namespace Checkers
{
    public class Scope
    {
        public Board Board { get; set; }

        public Scope(Board board)
        {
            Board = board;
        }

        public async Task<List<MoveBase>> FindMoves(Player player)
        {
            List<MoveBase> moves = new List<MoveBase>();
            List<Task<List<Move>>> moveTasks = new List<Task<List<Move>>>();
            List<Task<List<FightMove>>> fightMoveTasks = new List<Task<List<FightMove>>>();
            List<Pawn> playePawns = Board.GetPawns(player);

            foreach (Pawn pawn in playePawns)
            {
                moveTasks.AddRange(FindMoves(pawn));
                fightMoveTasks.AddRange(FindFightMoves(pawn));
            }

            await Task.WhenAll(moveTasks.ToArray());
            await Task.WhenAll(fightMoveTasks.ToArray());

            foreach (Task<List<Move>> task in moveTasks)
            {
                if (task.Result != null)
                {
                    moves.AddRange(task.Result);
                }
            }

            List<FightMove> fightMoves = new List<FightMove>();

            foreach (Task<List<FightMove>> task in fightMoveTasks)
            {
                if (task.Result != null)
                {
                    fightMoves.AddRange(task.Result);
                }
            }

            FightMoveTree tree = new FightMoveTree(Board, fightMoves);
            moves.AddRange(tree.MultipleBeats);
            return moves;
        }


        private List<Task<List<Move>>> FindMoves(Pawn pawn)
        {
            List<Task<List<Move>>> tasks = new List<Task<List<Move>>>();
            List<MoveDirection> directions;
            if (pawn.KingState)
            {
                directions = Movement.GetDirections();
            }
            else
            {
                directions = Movement.GetDirections(pawn.Player.Direction);
            }

            foreach (MoveDirection direction in directions)
            {
                tasks.Add(FindMove(pawn, direction));
            }
            return tasks;
        }


        public List<Task<List<FightMove>>> FindFightMoves(Pawn pawn, List<MoveDirection> directions = null)
        {
            List<Task<List<FightMove>>> tasks = new List<Task<List<FightMove>>>();

            if (directions == null)
            {
                directions = Movement.GetDirections();
            }

            foreach (MoveDirection direction in directions)
            {
                tasks.Add(FindFightMoves(pawn, direction));
            }
            return tasks;
        }

        private async Task<List<Move>> FindMove(Pawn mainPawn, MoveDirection direction)
        {
            List<Move> moves = new List<Move>();
            Shape shape = Board.GetControlInDirection(mainPawn.Position, direction);

            if (!(shape is Field))
            {
                return null;
            }

            do
            {
                moves.Add(new Move(mainPawn.Position, shape.Position, direction));
                shape = Board.GetControlInDirection(shape.Position, direction);

            } while (shape is Field && mainPawn.KingState);

            return moves;
        }

        private async Task<List<FightMove>> FindFightMoves(Pawn pawn, MoveDirection direction)
        {
            List<FightMove> fightMoves = null;
            Shape shape = Board.GetControlInDirection(pawn.Position, direction);
            Pawn enemy = null;

            while (shape != null)
            {
                if (enemy == null)
                {
                    Pawn tempPawn = shape as Pawn;

                    if (tempPawn == null && !pawn.KingState) // normal 
                    {
                        return null;
                    }

                    if (tempPawn != null) //you cannot beat your pawn
                    {
                        if (tempPawn.Player == pawn.Player)
                        {
                            return null;
                        }

                        fightMoves = new List<FightMove>();
                        enemy = tempPawn;
                    }
                }

                else if (enemy != null)
                {
                    if (shape is Field)
                    {
                        fightMoves.Add(new FightMove(pawn.Position, shape.Position, enemy, direction));

                        if (!pawn.KingState)
                        {
                            return fightMoves;
                        }
                    }

                    else if (shape is Pawn)
                    {
                        return fightMoves;
                    }
                }
                shape = Board.GetControlInDirection(shape.Position, direction);
            }
            return fightMoves;
        }
    }
}
