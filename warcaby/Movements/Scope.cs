using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Castle.Components.DictionaryAdapter;
using NUnit.Framework;
using warcaby;
using warcaby.Movements;

namespace Checkers
{
    public class Scope
    {
        public Board Board { get; set; }

        public Scope(Board board)
        {
            Board = board;
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

        public async Task<List<FightMove>> FindFightMoves(Pawn pawn, List<MoveDirection> directions = null)
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

            List<FightMove> fightMoves = new List<FightMove>();

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
