using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers;
using warcaby.Extensions;

namespace Checkers
{
    public class MovementManager
    {
        public Pawn SelectedPawn { get; set; }
        public List<IMoveable> AvailablePlayerMoves { get; set; }
        public Field SelectedField { get; set; }
        public BoardGraphical Board { get; set; }
        public GameManager GameManager { get; set; }
        public Control HighlitedControl { get; set; }

        public MovementManager(GameManager gameManager)
        {
            this.GameManager = gameManager;
            SelectedField = null;
            SelectedPawn = null;
        }

        public void SetUpBoard(BoardGraphical board)
        {
            Board = board;
        }

        async void ChangeTurn()
        {
            if (Board.SourceBoard.GetPawns(GameManager.ActualPlayer.Player).Count == 0)
            {
                GameManager.EndGame();
                return;
            }

            Scope scope = new Scope(Board.SourceBoard);
            this.AvailablePlayerMoves = await scope.FindMoves(GameManager.ActualPlayer.Player);

            if (AvailablePlayerMoves.Count == 0)
            {
                GameManager.EndGame();
                return;
            }

            //GameManager.BoardForm.ShowMessage("Found " + AvailablePlayerMoves.Count + " moves");
        }

        public void SelectPawn(Pawn pawn)
        {
            PlayerGraphical actualPlayer = GameManager.ActualPlayer;

            if (pawn.Player != actualPlayer.Player)
            {
                GameManager.BoardForm.ShowMessage("It is not your turn");
                return;
            }

            if (SelectedPawn != null && SelectedPawn == pawn)
            {
                Board.GetControl(pawn.Position).BackColor = BoardForm.DarkFieldsColor; //unhighlit selected pawn
                SelectedPawn = null;
                return;
            }

            if (HighlitedControl != null)
            {
                HighlitedControl.BackColor = BoardForm.DarkFieldsColor;
                HighlitedControl = null;
            }

            this.SelectedPawn = pawn;
            HighlitedControl = Board.GetControl(pawn.Position);
            HighlitedControl.BackColor = Color.Blue; //highlit selected pawn
        }

        public void SelectField(Field field)
        {
            if (SelectedPawn != null)
            {
                this.SelectedField = field;
                if (!CheckIfValidMove(SelectedPawn.Position, SelectedField.Position))
                {
                    GameManager.BoardForm.ShowMessage("This move in not allowed");
                    return;
                }
                MakeMove();
            }
        }

        bool CheckIfValidMove(Position pos1, Position pos2)
        {
            MoveDirection direction = Movement.GetDirection(pos1, pos2);
            if (direction == MoveDirection.Undefined)
                return false;

            Move move = new Move(pos1, pos2, direction);
            return AvailablePlayerMoves.Exists(obj => obj.IsMove(move));
        }

        private void MakeMove()
        {
            Board.SourceBoard.ChangePosition(SelectedPawn, SelectedField);
            ClearMoveData();
            GameManager.ChangeTurn();
        }

        private void ClearMoveData()
        {
            SelectedPawn = null;
            SelectedField = null;
        }

    }
}
