using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers;
using warcaby.AI.Rating;
using warcaby.Extensions;

namespace warcaby.AI
{
    public class Speculation
    {
        public Player Player { get; set; }
        public Player Enemy { get; set; }
        public Board Board { get; set; }
        public int Depth { get; set; }



        public Speculation(Player player, Player enemy, Board board, int depth)
        {
            this.Player = player;
            this.Enemy = enemy;
            this.Board = board;
            this.Depth = depth;
        }

        public async Task<MoveAnalyze> FindBestMove()
        {

            if (Depth < 2)
            { throw new Exception("Deepth must be be value at least 2"); }

            Player actual = Player;
            Board currentBoard = Board;
            List<MoveEffect> latestNodes = null;

            for (int i = 0; i < Depth; i++)
            {
                if (i == 0)
                {
                    Scope scope = new Scope(currentBoard);
                    List<IMoveable> roots = await scope.FindMoves(Player);
                    latestNodes = new List<MoveEffect>();

                    foreach (var root in roots)
                    {
                        latestNodes.Add(new MoveEffect(root, root.Simulate(currentBoard)));
                    }
                }

                else
                {
                    List<MoveEffect> newMoves = new List<MoveEffect>();
                    actual = ChangePlayer(actual);

                    foreach (var root in latestNodes)
                    {
                        Scope scope1 = new Scope(root.EffectOfMove);
                        List<IMoveable> moves = await scope1.FindMoves(actual);

                        foreach (var move in moves)
                        {
                            newMoves.Add(new MoveEffect(root.InitMove, move.Simulate(root.EffectOfMove)));
                        }
                    }

                    if (newMoves.Count == 0)
                    {
                        break;
                    }
                    latestNodes = newMoves;
                }
            }
            MoveAnalyze best = FindBestMove(latestNodes);
            return best;
        }



        private MoveAnalyze FindBestMove(List<MoveEffect> moves)
        {
            double? worseRate = null;
            IMoveable bestMove = null;

            var group = moves.GroupBy(obj => obj.InitMove).ToDictionary(a => a.Key, b => b.ToList());

            foreach (var grp in group)
            {

                double? worseGroupRate = null;

                foreach (MoveEffect moveEffect in grp.Value)
                {
                    double tempRate = BoardRating.Rate(Board, moveEffect.EffectOfMove, Player);
                    if (worseGroupRate == null || (tempRate < worseGroupRate))
                    {
                        worseGroupRate = tempRate;
                    }
                }

                if (worseRate == null || worseGroupRate > worseRate)
                {
                    worseRate = worseGroupRate;
                    bestMove = grp.Key;
                }
            }

            if (worseRate == null)
            {
                return null;
            }

            return new MoveAnalyze(bestMove, (double)worseRate);
        }


        private Player ChangePlayer(Player player)
        {
            if (player == Player)
                return Enemy;
            return Player;


        }

    }
}
