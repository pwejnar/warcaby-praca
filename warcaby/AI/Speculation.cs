﻿using System;
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

            Board currentBoard = Board;
            List<MoveEffect> latestNodes = null;

            for (int i = 0; i < Depth; i++)
            {
                Scope scope = new Scope(currentBoard);

                if (i == 0)
                {
                    List<IMoveable> roots = await scope.FindMoves(Player);
                    latestNodes = new List<MoveEffect>();

                    foreach (var root in roots)
                    {
                        latestNodes.Add(new MoveEffect(root, root, root.Simulate(currentBoard)));
                    }
                }

                else
                {
                    List<MoveEffect> newMoves = new List<MoveEffect>();

                    foreach (var root in latestNodes)
                    {
                        newMoves.Add(new MoveEffect(root.InitMove, root.Move, root.Move.Simulate(root.EffectOfMove)));
                    }

                    latestNodes = newMoves;
                }
            }

            MoveAnalyze best = FindBestMove(latestNodes);
            return best;
        }



        private MoveAnalyze FindBestMove(List<MoveEffect> moves)
        {
            MoveStatus bestStatus = null;
            IMoveable bestMove = null;

            foreach (var root in moves)
            {
                MoveStatus status = BoardRating.Rate(root.EffectOfMove, Player);
                if (bestStatus == null || status.Score > bestStatus.Score)
                {
                    bestStatus = status;
                    bestMove = root.InitMove;
                }
            }
            return new MoveAnalyze(bestMove, bestStatus);
        }


        private Player ChangePlayer(Player player)
        {
            if (player == Player)
                return Enemy;
            return Player;


        }

    }
}