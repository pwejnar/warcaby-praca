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
        public Position GetPosition(Control control)
        {
            TableLayoutPanelCellPosition position = this.GetPositionFromControl(control);
            return new Position(position.Row, position.Column);
        }

        public void ChangePosition(PawnGraphical pawnGraphical, FieldGraphical fieldGraphical)
        {
            Position pawnPosition = pawnGraphical.Pawn.Position;
            Position fieldPosition = fieldGraphical.Field.Position;

            Control pawn = GetControl(pawnPosition);
            Control field = GetControl(fieldPosition);

            Extension.BeginControlUpdate(this);
            this.SetCellPosition(pawn, new TableLayoutPanelCellPosition(fieldPosition.Column, fieldPosition.Row));
            this.SetCellPosition(field, new TableLayoutPanelCellPosition(pawnPosition.Column, pawnPosition.Row));
            Extension.EndControlUpdate(this);
        }

        public void ChangeToKingState(PawnGraphical pawnGraphical)
        {
            pawnGraphical.Image = pawnGraphical.PawnColor == PawnColor.Dark ? Resources.darkKing : Resources.lightKing;
        }

        public void RemovePawn(Position pawnToBeatPosition)
        {
            Extension.BeginControlUpdate(this);
            Controls.Remove(GetControl(pawnToBeatPosition));
            FieldGraphical fieldGraphical = new FieldGraphical(new Field(pawnToBeatPosition), BoardForm.DarkFieldsColor);
            SetCellPosition(fieldGraphical, new TableLayoutPanelCellPosition(pawnToBeatPosition.Column, pawnToBeatPosition.Row));
            this.Controls.Add(fieldGraphical);
            fieldGraphical.Click += CellClicked;
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
            Position position = GetPosition((Control)sender);
            Control controlFromPostion = GetControl(position);
            MovementManager.SelectControl(controlFromPostion);
        }

        public void SetBoardWithPawns(PlayerGraphical p1, PlayerGraphical p2)
        {
            Extension.BeginControlUpdate(this);
            Controls.Clear();

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
                        this.Controls.Add(pawnGraphical);
                    }
                    else
                    {
                        Color color = (i + j) % 2 == 0 ? BoardForm.LightFieldsColor : BoardForm.DarkFieldsColor;
                        FieldGraphical fieldGraphical = new FieldGraphical(field, color);
                        fieldGraphical.Click += CellClicked;
                        this.Controls.Add(fieldGraphical);
                    }
                }
            }
            Extension.EndControlUpdate(this);
        }
    }
}
