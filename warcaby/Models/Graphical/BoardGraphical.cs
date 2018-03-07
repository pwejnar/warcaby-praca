using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers;
using Checkers.Properties;

namespace Checkers
{
  public class BoardGraphical : TableLayoutPanel
  {
    public Board SourceBoard { get; set; }
    public List<FieldGraphical> GraphicalFields { get; set; }
    public List<PawnGraphical> GraphicalPawns { get; set; }
    public MovementManager MovementManager { get; set; }

    public BoardGraphical(Board board, MovementManager movementManager)
    {
      SourceBoard = board;
      this.MovementManager = movementManager;
      Location = new Point(100, 60);
      ColumnCount = board.GetSize();
      RowCount = board.GetSize();
      BorderStyle = BorderStyle.FixedSingle;
      this.AutoSize = true;
    }

    public Control GetControl(Position pos)
    {
      return this.GetControlFromPosition(pos.Column, pos.Row);
    }

    public void ChangePosition(PawnGraphical pawnGraphical, FieldGraphical fieldGraphical)
    {
      Extension.BeginControlUpdate(this);
      Control pawn = GetControl(pawnGraphical.Pawn.Position);
      Control field = GetControl(fieldGraphical.Field.Position);
      this.SetCellPosition(pawn, new TableLayoutPanelCellPosition(fieldGraphical.Field.Position.Column, fieldGraphical.Field.Position.Row));
      this.SetCellPosition(field, new TableLayoutPanelCellPosition(pawnGraphical.Pawn.Position.Column, pawnGraphical.Pawn.Position.Row));
      Extension.EndControlUpdate(this);

      bool oldKingState = pawnGraphical.Pawn.KingState;
      SourceBoard.ChangePosition(pawnGraphical.Pawn, fieldGraphical.Field);

      if (!oldKingState && pawnGraphical.Pawn.KingState)
      {
        ChangeToKingState(pawnGraphical);
      }
    }

    public void ChangeToKingState(PawnGraphical pawnGraphical)
    {
      pawnGraphical.Image = pawnGraphical.PawnColor == PawnColor.Dark ? Resources.darkKing : Resources.lightKing;
    }

    public void RemovePawn(Pawn pawn)
    {
      Extension.BeginControlUpdate(this);
      Position position = pawn.Position;
      Controls.Remove(GetControl(position));
      FieldGraphical fieldGraphical = new FieldGraphical(new Field(new Position(position.Row, position.Column)), BoardForm.DarkFieldsColor);
      fieldGraphical.Click += CellClicked;
      SetCellPosition(fieldGraphical, new TableLayoutPanelCellPosition(position.Column, position.Row));
      this.Controls.Add(fieldGraphical);
      Extension.EndControlUpdate(this);
    }

    public void ResetBoardState(PlayerGraphical p1, PlayerGraphical p2)
    {
      SourceBoard.SetUpBoardWithFields();
      SourceBoard.SetUpPlayerPawns(p1.Player);
      SourceBoard.SetUpPlayerPawns(p2.Player);
      SetBoardWithPawns(p1, p2);
    }

    void CellClicked(object sender, EventArgs e)
    {
      TableLayoutPanelCellPosition cellPosition = this.GetPositionFromControl((Control)sender);
      Control controlFromPostion = GetControl(new Position(cellPosition.Row, cellPosition.Column));
      MovementManager.SelectControl(controlFromPostion);
    }

    public void SetBoardWithPawns(PlayerGraphical p1, PlayerGraphical p2)
    {
      Extension.BeginControlUpdate(this);
      Controls.Clear();

      TableLayoutPanel tlp = new TableLayoutPanel();
      GraphicalFields = new List<FieldGraphical>();
      GraphicalPawns = new List<PawnGraphical>();

      for (int i = 0; i < RowCount; i++)
      {
        for (int j = 0; j < ColumnCount; j++)
        {
          Pawn pawn = SourceBoard.GetAllShapes()[i, j] as Pawn;
          Field field = SourceBoard.GetAllShapes()[i, j] as Field;

          if (pawn != null)
          {
            PawnGraphical pawnGraphical = null;

            if (pawn.Player == p1.Player)
            {
              PawnColor color = p1.PawnsColor;
              pawnGraphical = new PawnGraphical(pawn, p1, color);
            }
            else
            {
              PawnColor color = p2.PawnsColor;
              pawnGraphical = new PawnGraphical(pawn, p2, color);
            }

            pawnGraphical.Click += CellClicked;
            GraphicalPawns.Add(pawnGraphical);
            this.Controls.Add(pawnGraphical);
          }

          else
          {
            Color color = (i + j) % 2 == 0 ? BoardForm.LightFieldsColor : BoardForm.DarkFieldsColor;
            FieldGraphical fieldGraphical = new FieldGraphical(field, color);
            fieldGraphical.Click += CellClicked;
            GraphicalFields.Add(fieldGraphical);
            this.Controls.Add(fieldGraphical);
          }
        }
      }
      Extension.EndControlUpdate(this);
    }
  }
}
