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
        public BoardForm BoardForm { get; set; }
        public BoardGraphical BoardGraphical { get; set; }

        public PlayerGraphical Player1 { get; set; }
        public PlayerGraphical Player2 { get; set; }

        public PlayerGraphical ActualPlayer { get; set; }
        public MovementManager MovementManager { get; set; }

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
            UpdateBoardState();
        }

        void BuildBoardForm()
        {
            MovementManager = new MovementManager(this);
            BoardGraphical = new BoardGraphical(new Board(8), MovementManager);
            MovementManager.SetUpBoard(BoardGraphical);
            BoardForm.AddToForm(BoardGraphical);

        }


        public void ChangeTurn()
        {
            ChangePlayer();
            UpdateBoardState();
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
            BoardGraphical.UpdateBoardState(Player1, Player2);
        }

        public void EndGame()
        {
            Player losePlayer = ActualPlayer.Player;
            string endText = string.Format("Game over Player {0} lose!", losePlayer.Nick);
            BoardForm.ShowMessage(endText);
            BoardGraphical.SourceBoard.ClearPawns();
            UpdateBoardState();
        }
    }
}
