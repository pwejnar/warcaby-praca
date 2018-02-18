using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers;

namespace Checkers
{
    public class GameManager
    {
        public BoardForm GameForm { get; set; }
        public BoardGraphical BoardForm { get; set; }

        public PlayerGraphical Player1 { get; set; }
        public PlayerGraphical Player2 { get; set; }

        public static PlayerGraphical ActualPlayer { get; set; }
        public MovementManager GameMovementManager { get; set; }

        public GameManager(BoardForm form, PlayerGraphical player1, PlayerGraphical player2)    // every time white pawns start game
        {
            GameForm = form;
            Player1 = player1;
            Player2 = player2;

            BuildBoardForm();
            ActualPlayer = player1.PawnsColor == PawnColor.Light ? player1 : player2;
        }

        public void SetUpGame()
        {
            BoardForm.SetUpPawns(Player1, Player2);
            UpdateBoardState();
        }

        void BuildBoardForm()
        {
            //other size not work yet
            BoardForm = new BoardGraphical(new Board(8), GameMovementManager);
            GameMovementManager = new MovementManager(BoardForm.SourceBoard);

            GameForm.AddToForm(BoardForm);
            UpdateBoardState();
        }


        public void ChangeTurn()
        {
            ChangePlayer();
            //show info about player
            //show info about pawn color 
            //check if game has ended

            //AI move???
        }

        void ChangePlayer()
        {
            if (ActualPlayer == Player1)
            {
                ActualPlayer = Player2;
            }
            else
            {
                ActualPlayer = Player1;
            }
        }



        public void UpdateBoardState()
        {
            BoardForm.UpdateBoardState(Player1, Player2);
        }

        public void EndGame()
        {
            Player losePlayer = ActualPlayer.Player;
            string endText = string.Format("Game over Player {0} lose!", losePlayer.Nick);
            GameForm.ShowMessage(endText);
            BoardForm.SourceBoard.ClearPawns();
            UpdateBoardState();
        }
    }
}
