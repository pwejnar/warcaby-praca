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
using warcaby.Movements.Fight;

namespace Checkers
{
    public class MovementManager
    {
        public Pawn SelectedPawn { get; set; }
        public List<IMoveable> AvailablePlayerMoves { get; set; }
        public Field SelectedField { get; set; }
        public GameManager GameManager { get; set; }
        public Control HighlitedControl { get; set; }

        public MovementManager(GameManager gameManager)
        {
            this.GameManager = gameManager;
            SelectedField = null;
            SelectedPawn = null;
        }

        public async void UpdatePlayerMoves()
        {
            if (GameManager.BoardGraphical.SourceBoard.GetPawns(GameManager.ActualPlayer.Player).Count == 0)
            {
                GameManager.EndGame();
                return;
            }

            Scope scope = new Scope(GameManager.BoardGraphical.SourceBoard);
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
                UnhighlightControl();
                return;
            }

            if (HighlitedControl != null)
            {
                HighlitedControl.BackColor = BoardForm.DarkFieldsColor;
                HighlitedControl = null;
            }

            this.SelectedPawn = pawn;
            HighlightControl(GameManager.BoardGraphical.GetControl(pawn.Position));
        }

        public void SelectField(Field field)
        {
            if (SelectedPawn != null)
            {
                this.SelectedField = field;
                IMoveable selectedMove = GetMove(SelectedPawn.Position, SelectedField.Position);

                if (selectedMove == null)
                {
                    GameManager.BoardForm.ShowMessage("This move in not allowed");
                    return;
                }
                MakeMove(selectedMove);
            }
        }

        IMoveable GetMove(Position pos1, Position pos2)
        {
            MoveDirection direction = Movement.GetDirection(pos1, pos2);
            if (direction == MoveDirection.Undefined)
                return null;

            Move move = new Move(pos1, pos2, direction);
            return AvailablePlayerMoves.FirstOrDefault(obj => obj.IsMove(move));
        }

        private void MakeMove(IMoveable selectedMove)
        {
            UnhighlightControl();

            if (selectedMove is IMakeBeat)
            {
                MultipleFightMove multipleMove = selectedMove as MultipleFightMove;

                if (multipleMove != null)
                {
                    MakeFormMove(multipleMove.GetNextMove());
                    if (multipleMove.FightMoves.Count == 0)
                    {
                        GameManager.ChangeTurn();
                    }
                }

                else
                {
                    MakeFormMove(selectedMove);
                    GameManager.ChangeTurn();
                }
            }
            else
            {
                MakeFormMove(selectedMove);
                GameManager.ChangeTurn();
            }

            //if (selectedMove is imak)
            //{
            //    selectedMove.PrepareMove(GameManager.BoardGraphical.SourceBoard);
            //    GameManager.BoardGraphical.SwapControls(selectedMove.PositionBeforeMove, selectedMove.PositionAfterMove);
            //    GameManager.ChangeTurn();
            //}

            ClearMoveData();
        }

        void MakeFormMove(IMoveable move)
        {
            move.PrepareMove(GameManager.BoardGraphical.SourceBoard);
            GameManager.BoardGraphical.SwapControls(move.PositionBeforeMove,
                move.PositionAfterMove);

            IMakeBeat makeBeat = move as IMakeBeat;

            if (makeBeat != null)
            {
                GameManager.BoardGraphical.RemovePawn(makeBeat.PawnToBeat);
            }
        }

        private void ClearMoveData()
        {
            SelectedPawn = null;
            SelectedField = null;
        }
        void HighlightControl(Control control)
        {
            HighlitedControl = control;
            HighlitedControl.BackColor = Color.Blue; //highlit selected pawn

        }
        void UnhighlightControl()
        {
            HighlitedControl.BackColor = BoardForm.DarkFieldsColor;
            HighlitedControl = null;
            SelectedPawn = null;
        }
    }
}
