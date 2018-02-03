using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers;
using Checkers.Movements;
using warcaby.Extensions;

namespace Checkers
{
    public class Scope
    {
        public Board Board { get; set; }

        public Scope(Board board)
        {
            Board = board;
        }


        public async Task<List<IMoveable>> FindMoves(Player player)
        {
            List<Pawn> playerPawns = Board.GetPlayerPawns(player);
            List<IMoveable> allMoves = null;

            List<Task<List<IMoveable>>> allMovesTasks = new List<Task<List<IMoveable>>>();

            foreach (Pawn pawn in playerPawns)
            {
                allMovesTasks.Add(FindFightMoves(pawn));
                allMovesTasks.Add(FindMoves(pawn));
            }

            await Task.WhenAll(allMovesTasks.ToArray());

            foreach (Task<List<IMoveable>> task in allMovesTasks)
            {
                if (task.Result != null)
                {
                    if (allMoves == null)
                    {
                        allMoves = new List<IMoveable>();
                    }
                    allMoves.AddRange(task.Result);
                }
            }
            return allMoves;
        }

        public async Task<List<IMoveable>> FindMoves(Pawn pawn)
        {
            List<Task<List<Move>>> tasks = new List<Task<List<Move>>>();
            List<MoveDirection> directions = Movement.GetDirections(pawn.Player.Direction);

            foreach (MoveDirection direction in directions)
            {
                tasks.Add(FindMove(pawn, direction));
            }

            await Task.WhenAll(tasks.ToArray());

            List<IMoveable> moves = new List<IMoveable>();

            foreach (Task<List<Move>> task in tasks)
            {
                if (task.Result != null)
                {
                    moves.AddRange(task.Result);
                }
            }
            return moves;
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

        public async Task<List<IMoveable>> FindFightMoves(Pawn pawn, List<MoveDirection> directions = null)
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

            await Task.WhenAll(tasks.ToArray());

            List<IMoveable> fightMoves = new List<IMoveable>();

            foreach (Task<List<FightMove>> task in tasks)
            {
                if (task.Result != null)
                {
                    fightMoves.AddRange(task.Result);
                }
            }
            return fightMoves;
        }

        public async Task<List<FightMove>> FindFightMoves(Pawn pawn, MoveDirection direction)
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
