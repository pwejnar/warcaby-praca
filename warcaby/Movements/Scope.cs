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

        public async Task<List<IMoveable>> FindMoves(Player player, bool beatRequired = true, bool longestBeatsRequired = true)
        {
            List<Pawn> playePawns = Board.GetPawns(player);
            return await FindMoves(playePawns, beatRequired, longestBeatsRequired);
        }

        public async Task<List<IMoveable>> FindMoves(List<Pawn> pawns, bool beatRequired = true, bool longestBeatsRequired = true)
        {
            List<Task<List<IMoveable>>> moveTasks = new List<Task<List<IMoveable>>>();
            List<Task<List<IMakeBeat>>> fightMoveTasks = new List<Task<List<IMakeBeat>>>();

            if (pawns == null || pawns.Count == 0)
            {
                return new List<IMoveable>();
            }

            foreach (Pawn pawn in pawns)
            {
                moveTasks.AddRange(FindMoves(pawn));
                fightMoveTasks.AddRange(FindFightMoves(pawn));
            }

            List<IMoveable> normalMoves = new List<IMoveable>();
            await Task.WhenAll(moveTasks.ToArray());

            foreach (Task<List<IMoveable>> task in moveTasks)
            {
                if (task.Result != null)
                {
                    normalMoves.AddRange(task.Result);
                }
            }

            List<IMakeBeat> fightMoves = new List<IMakeBeat>();
            await Task.WhenAll(fightMoveTasks.ToArray());

            foreach (Task<List<IMakeBeat>> task in fightMoveTasks)
            {
                if (task.Result != null)
                {
                    fightMoves.AddRange(task.Result);
                }
            }

            List<IMoveable> movesDetected = new List<IMoveable>();

            if (fightMoves.Count > 0)
            {

                FightMoveTree tree = new FightMoveTree(Board, fightMoves);
                List<IMakeBeat> beatLists = tree.GetBeatLists(longestBeatsRequired);

                if (beatLists.Count > 0) // is single beat multiple beat?
                {
                    movesDetected.AddRange(beatLists.ConvertAll(obj => (IMoveable)obj));

                    if (beatRequired)
                    {
                        return movesDetected;
                    }
                }
            }

            movesDetected.AddRange(normalMoves);
            return movesDetected;
        }



        public List<Task<List<IMakeBeat>>> FindFightMoves(Pawn pawn, List<MoveDirection> directions = null)
        {
            List<Task<List<IMakeBeat>>> tasks = new List<Task<List<IMakeBeat>>>();

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


        private List<Task<List<IMoveable>>> FindMoves(Pawn pawn)
        {
            List<Task<List<IMoveable>>> tasks = new List<Task<List<IMoveable>>>();
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


        private async Task<List<IMoveable>> FindMove(Pawn mainPawn, MoveDirection direction)
        {
            List<IMoveable> moves = new List<IMoveable>();
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

        private async Task<List<IMakeBeat>> FindFightMoves(Pawn pawn, MoveDirection direction)
        {
            List<IMakeBeat> fightMoves = new List<IMakeBeat>();
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
