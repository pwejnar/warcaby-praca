using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers;
using warcaby.Engine;

namespace warcaby
{
    public class GameManager
    {
        public Form1 GameForm { get; set; }
        public BoardGraphical BoardForm { get; set; }

        public PlayerGraphical Player1 { get; set; }
        public PlayerGraphical Player2 { get; set; }

        public static PlayerGraphical ActualPlayer { get; set; }
        public MovementManager GameMovementManager { get; set; }

        public GameManager(Form1 form, PlayerGraphical player1, PlayerGraphical player2)    // every time white pawns start game
        {
            GameForm = form;
            Player1 = player1;
            Player2 = player2;

            BuildBoardForm();
            GameMovementManager = new MovementManager(BoardForm.SourceBoard);
            ActualPlayer = player1.PawnsColor == PawnColor.Light ? player1 : player2;
        }

        void BuildBoardForm()
        {
            //other size not work yet
            BoardForm = new BoardGraphical(new Board(8), GameMovementManager);
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

        public void SetUpGame()
        {
            BoardForm.SetUpPawns(Player1, Player2);
            UpdateBoardState();
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
