﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers;
using warcaby.Properties;

namespace Checkers
{
    public class BoardGraphical : TableLayoutPanel
    {
        public Board SourceBoard { get; set; }
        public MovementManager MoveManager { get; set; }

        public BoardGraphical(Board board, MovementManager moveManager)
        {
            SourceBoard = board;
            this.MoveManager = moveManager;
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

        public void SwapControls(Position position1, Position position2)
        {
            Extension.BeginControlUpdate(this);
            Control ctrl1 = GetControl(position1);
            Control ctrl2 = GetControl(position2);
            this.SetCellPosition(ctrl1, new TableLayoutPanelCellPosition(position2.Column, position2.Row));
            this.SetCellPosition(ctrl2, new TableLayoutPanelCellPosition(position1.Column, position1.Row));
            Extension.EndControlUpdate(this);
        }

        public void ChangeToKingState(Position position)
        {
            PawnGraphical pawn = GetControl(position) as PawnGraphical;
            pawn.Image = pawn.PawnColor == PawnColor.Dark ? Resources.darkKing : Resources.lightKing;
        }

        public void RemovePawn(Pawn pawn)
        {
            Extension.BeginControlUpdate(this);
            Position position = pawn.Position;
            Controls.Remove(GetControl(position));
            Field field = SourceBoard.GetControlInPosition(position) as Field;
            FieldGraphical fieldGraphical = new FieldGraphical(field, BoardForm.DarkFieldsColor);
            fieldGraphical.Click += new EventHandler(FieldClicked);
            SetCellPosition(fieldGraphical, new TableLayoutPanelCellPosition(position.Column, position.Row));
            this.Controls.Add(fieldGraphical);
            Extension.EndControlUpdate(this);
        }

        public void ResetBoardState(PlayerGraphical p1, PlayerGraphical p2)
        {
            SourceBoard.SetUpBoardWithFields();
            SourceBoard.SetUpPlayerPawns(p1.Player);
            SourceBoard.SetUpPlayerPawns(p2.Player);
            RefreshBoardState(p1, p2);
        }

        public void RefreshBoardState(PlayerGraphical p1, PlayerGraphical p2)
        {
            Extension.BeginControlUpdate(this);
            Controls.Clear();

            TableLayoutPanel tlp = new TableLayoutPanel();
            TableLayoutControlCollection newControls = new TableLayoutControlCollection(tlp);


            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    Pawn pawn = SourceBoard.GetAllShapes()[i, j] as Pawn;
                    Field field = SourceBoard.GetAllShapes()[i, j] as Field;

                    if (pawn != null)
                    {
                        PawnColor color = p1.Player == pawn.Player ? p1.PawnsColor : p2.PawnsColor;
                        PawnGraphical pawnGraphical = new PawnGraphical(pawn, color);
                        pawnGraphical.Click += new EventHandler(PawnClicked);
                        newControls.Add(pawnGraphical);
                    }

                    else
                    {
                        Color color = (i + j) % 2 == 0 ? BoardForm.LightFieldsColor : BoardForm.DarkFieldsColor;
                        FieldGraphical fieldGraphical = new FieldGraphical(field, color);
                        fieldGraphical.Click += new EventHandler(FieldClicked);
                        newControls.Add(fieldGraphical);
                    }
                }
            }

            foreach (var control in newControls)
            {
                this.Controls.Add((Control)(control));
            }

            Extension.EndControlUpdate(this);
        }

        void FieldClicked(object sender, EventArgs e)
        {
            FieldGraphical fg = sender as FieldGraphical;
            MoveManager.SelectField(fg.GetField());
        }

        void PawnClicked(object sender, EventArgs e)
        {
            PawnGraphical pg = sender as PawnGraphical;
            MoveManager.SelectPawn(pg.Pawn);
        }
    }
}
