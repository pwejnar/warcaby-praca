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
        public PawnGraphical SelectedPawn { get; set; }
        public List<IMoveable> AvailablePlayerMoves { get; set; }
        public FieldGraphical SelectedField { get; set; }
        public GameManager GameManager { get; set; }

        public MovementManager(GameManager gameManager)
        {
            this.GameManager = gameManager;
            SelectedField = null;
            SelectedPawn = null;
        }

        public async void UpdatePlayerMoves()
        {
            Player actualPlayer = GameManager.ActualPlayer.Player;
            List<Pawn> playerPawns = GameManager.BoardGraphical.SourceBoard.GetPawns(actualPlayer);

            Scope scope = new Scope(GameManager.BoardGraphical.SourceBoard);
            this.AvailablePlayerMoves = await scope.FindMoves(actualPlayer);

            if (playerPawns.Count == 0 || AvailablePlayerMoves.Count == 0)
            {
                GameManager.EndGame();
                return;
            }
        }

        public void SelectControl(Control control)
        {
            if (GameManager.ActualPlayer.Ai)
                return;

            if (GameManager.GameHasEnded)
            {
                GameManager.FormWithBoard.ShowMessage("Game over.\nTo continue playing restart game.");
                return;
            }

            if (control is PawnGraphical)
            {
                PawnGraphical pawnGraphical = (PawnGraphical)control;

                if (pawnGraphical.GraphicalPlayer != GameManager.ActualPlayer)
                {
                    GameManager.FormWithBoard.ShowMessage("It is not your turn.");
                    return;
                }

                this.SelectPawn(pawnGraphical);
            }
            else if (control is FieldGraphical)
            {
                if (SelectedPawn == null)
                {
                    return;
                }

                this.SelectField(((FieldGraphical)control));
            }
        }

        public void SelectPawn(PawnGraphical pawn)
        {
            if (SelectedPawn != null)
            {
                UnhighlightSelectedPawn();
                if (SelectedPawn == pawn)
                {
                    SelectedPawn = null;
                    return;
                }
            }

            this.SelectedPawn = pawn;
            HighlightSelectedPawn();
        }

        public void SelectField(FieldGraphical field)
        {
            this.SelectedField = field;
            FindMove();
        }

        void FindMove()
        {
            Position pawnPosition = GameManager.BoardGraphical.GetPosition(SelectedPawn);
            Position fielPosition = GameManager.BoardGraphical.GetPosition(SelectedField);
            IMoveable selectedMove = GetMove(pawnPosition, fielPosition);

            if (selectedMove == null)
            {
                GameManager.FormWithBoard.ShowMessage("This move in not allowed.");
                return;
            }
            MakeMove(selectedMove);
        }

        IMoveable GetMove(Position pos1, Position pos2)
        {
            MoveDirection direction = Movement.GetDirection(pos1, pos2);
            if (direction == MoveDirection.Undefined)
                return null;

            Move move = new Move(pos1, pos2, direction);
            return AvailablePlayerMoves.FirstOrDefault(obj => obj.IsMove(move));
        }

        void MakeMove(IMoveable move)
        {
            if (move is MultipleFightMove)
            {
                MultipleFightMove multipleMove = move as MultipleFightMove;
                IMakeBeat nextMove = multipleMove.GetNextMove();
                PrepareMove(nextMove);

                if (multipleMove.FightMoves.Count > 0)
                {
                    AvailablePlayerMoves.Clear();
                    AvailablePlayerMoves.Add(multipleMove);
                }
                else
                {
                    ChangeTurn();
                }
            }
            else
            {
                PrepareMove(move);
                ChangeTurn();
            }
        }

        void PrepareMove(IMoveable move)
        {
            BoardGraphical board = GameManager.BoardGraphical;
            PawnGraphical pawnGraphical = (PawnGraphical)board.GetControl(move.PositionBeforeMove);
            FieldGraphical fieldGraphical = (FieldGraphical)board.GetControl(move.PositionAfterMove);

            if (move is FightMove)
            {
                FightMove fightMove = move as FightMove;
                board.ChangePosition(pawnGraphical, fieldGraphical);
                GameManager.BoardGraphical.RemovePawn(fightMove.PawnToBeat.Position);
                fightMove.MakeBeat(board.SourceBoard);
            }
            else
            {
                board.ChangePosition(pawnGraphical, fieldGraphical);
                move.PrepareMove(board.SourceBoard);
            }
        }

        void ChangeTurn()
        {
            UnhighlightSelectedPawn();
            ClearMoveData();
            GameManager.ChangeTurn();
        }

        void ClearMoveData()
        {
            SelectedPawn = null;
            SelectedField = null;
            AvailablePlayerMoves.Clear();
        }

        void HighlightSelectedPawn()
        {
            SelectedPawn.BackColor = Color.Blue;
        }
        void UnhighlightSelectedPawn()
        {
            SelectedPawn.BackColor = BoardForm.DarkFieldsColor;
        }
    }
}
