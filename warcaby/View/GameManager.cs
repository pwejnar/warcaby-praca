using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers;
using warcaby.AI;
using warcaby.AI.Rating;
using warcaby.Extensions;
using warcaby.Movements.Fight;

namespace Checkers
{
    public class GameManager
    {
        public BoardForm BoardForm { get; set; }
        public BoardGraphical BoardGraphical { get; set; }

        public PlayerGraphical Player1 { get; set; }
        public PlayerGraphical Player2 { get; set; }

        public PlayerGraphical ActualPlayer { get; set; }
        public MovementManager MovementManager { get; set; }
        public bool GameHasEnded { get; set; }

        public GameManager(BoardForm form, PlayerGraphical player1, PlayerGraphical player2)    // every time white pawns start game
        {
            BoardForm = form;
            Player1 = player1;
            Player2 = player2;

            BuildBoardForm();
            ActualPlayer = player1.PawnsColor == PawnColor.Light ? player1 : player2;
        }

        public void SetUpGame()
        {
            BoardGraphical.SetUpPawns(Player1, Player2);
            MovementManager.UpdatePlayerMoves();
            BoardGraphical.BuildBoard(Player1, Player2);
        }

        void BuildBoardForm()
        {
            MovementManager = new MovementManager(this);
            BoardGraphical = new BoardGraphical(new Board(8), MovementManager);
            BoardForm.AddToForm(BoardGraphical);
        }


        public async void ChangeTurn()
        {
            ChangePlayer();
            MovementManager.UpdatePlayerMoves();
            if (!GameHasEnded)
            {
                BoardForm.UpdateGameInfo();

                if (ActualPlayer.Ai)
                {
                    Speculation spec = new Speculation(ActualPlayer.Player, GetOponent(ActualPlayer).Player, BoardGraphical.SourceBoard, 5);
                    MoveAnalyze move = await spec.FindBestMove();

                    MultipleFightMove multipleFightMove = move.Move as MultipleFightMove;

                    if (multipleFightMove != null)
                    {
                        while (multipleFightMove.FightMoves.Count != 0)
                        {
                            MovementManager.MakeFormMove(multipleFightMove.GetNextMove());
                        }
                    }
                
                else
                {
                    MovementManager.MakeFormMove(move.Move);
                }
                ChangeTurn();
            }
            //show info about pawn color 
        }
    }

    PlayerGraphical GetOponent(PlayerGraphical playerGraphical)
    {
        if (playerGraphical == Player1)
            return Player2;
        return Player1;
    }

    void ChangePlayer()
    {
        ActualPlayer = GetOponent(ActualPlayer);
    }

    public void EndGame()
    {
        Player losePlayer = ActualPlayer.Player;
        string endText = string.Format("Game over Player {0} lose!", losePlayer.Nick);
        GameHasEnded = true;
        BoardForm.ShowMessage(endText);
        BoardGraphical.SourceBoard.ClearPawns();
    }
}
}
