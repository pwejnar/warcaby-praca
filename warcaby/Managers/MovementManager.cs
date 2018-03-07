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
      if (GameManager.BoardGraphical.GraphicalPawns.Where(x => x.GraphicalPlayer == GameManager.ActualPlayer).ToList().Count == 0)
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
    }

    public void SelectControl(Control control)
    {

      if (GameManager.ActualPlayer.Ai)
        return;

      if (GameManager.GameHasEnded)
      {
        GameManager.BoardForm.ShowMessage("Game over.\nTo continue playing restart game.");
        return;
      }

      if (control is PawnGraphical)
      {
        PawnGraphical pawnGraphical = (PawnGraphical)control;

        if (pawnGraphical.GraphicalPlayer != GameManager.ActualPlayer)
        {
          GameManager.BoardForm.ShowMessage("It is not your turn.");
          return;
        }

        this.SelectPawn(pawnGraphical.Pawn);
      }
      else if (control is FieldGraphical)
      {
        if (SelectedPawn == null)
        {
          return;
        }

        this.SelectField(((FieldGraphical)control).Field);
      }
    }

    public void SelectPawn(Pawn pawn)
    {
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
      this.SelectedField = field;
      IMoveable selectedMove = GetMove(SelectedPawn.Position, SelectedField.Position);

      if (selectedMove == null)
      {
        GameManager.BoardForm.ShowMessage("This move in not allowed");
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
      if (move is IMakeBeat)
      {
        MultipleFightMove multipleMove = move as MultipleFightMove;

        if (multipleMove != null)
        {
          IMakeBeat nextMove = multipleMove.GetNextMove();
          MakeFormMove(nextMove);
          UpdatePlayerMoves();

          if (multipleMove.FightMoves.Count == 0)
          {
            ChangeTurn();
          }
        }
        else
        {
          MakeFormMove(move);
          ChangeTurn();
        }
      }
      else
      {
        MakeFormMove(move);
        ChangeTurn();
      }
    }

    void ChangeTurn()
    {
      UnhighlightControl();
      GameManager.ChangeTurn();
      ClearMoveData();
    }

    void MakeFormMove(IMoveable move)
    {
      bool kingState = SelectedPawn.KingState;
      PawnGraphical pawnGraphical = (PawnGraphical)GameManager.BoardGraphical.GetControl(move.PositionBeforeMove);
      FieldGraphical fieldGraphical = (FieldGraphical)GameManager.BoardGraphical.GetControl(move.PositionAfterMove);
      GameManager.BoardGraphical.ChangePosition(pawnGraphical, fieldGraphical);

      IGotPawnToBeat makeBeat = move as IGotPawnToBeat;

      if (makeBeat != null)
      {
        Position position = makeBeat.PawnToBeat.Position;
        GameManager.BoardGraphical.RemovePawn(makeBeat.PawnToBeat);
      }
    }

    void ClearMoveData()
    {
      SelectedPawn = null;
      SelectedField = null;
    }

    void HighlightControl(Control control)
    {
      if (control != null)
      {
        HighlitedControl = control;
        HighlitedControl.BackColor = Color.Blue; //highlit selected pawn
      }
    }
    void UnhighlightControl()
    {
      if (HighlitedControl != null)
      {
        HighlitedControl.BackColor = BoardForm.DarkFieldsColor;
      }
      HighlitedControl = null;
      SelectedPawn = null;
    }
  }
}
