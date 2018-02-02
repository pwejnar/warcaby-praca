using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers;

namespace Checkers
{
    public class BoardGraphical : TableLayoutPanel
    {
        public Board SourceBoard { get; set; }
        public MovementManager MoveManager { get; set; }

        public BoardGraphical(Board board, MovementManager moveManager)
        {
            this.MoveManager = moveManager;
            SourceBoard = board;
            Location = new Point(100, 60);
            ColumnCount = board.GetSize();
            RowCount = board.GetSize();
            BorderStyle = BorderStyle.FixedSingle;
            this.AutoSize = true;
        }


        public void SetUpPawns(PlayerGraphical p1, PlayerGraphical p2)
        {
            SourceBoard.SetUpPawns(p1.Player);
            SourceBoard.SetUpPawns(p2.Player);
        }

        public void UpdateBoardState(PlayerGraphical p1, PlayerGraphical p2)
        {
            Extension.BeginControlUpdate(this);
            ClearBoard();

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
                        Controls.Add(pawnGraphical);
                    }

                    else
                    {
                        Color color = (i + j) % 2 == 0 ? Form1.lightColor : Form1.darkColor;
                        FieldGraphical fieldGraphical = new FieldGraphical(field, color);
                        fieldGraphical.Click += new EventHandler(FieldClicked);
                        Controls.Add(fieldGraphical);
                    }
                }
            }

            Extension.EndControlUpdate(this);
        }

        public void ClearBoard()
        {
            Controls.Clear();
        }

        void FieldClicked(object sender, EventArgs e)
        {
            FieldGraphical fg = sender as FieldGraphical;
            MoveManager.SelectField(fg.GetField());
        }

        void PawnClicked(object sender, EventArgs e)
        {
            PawnGraphical pg = sender as PawnGraphical;
            MoveManager.SelectPawn(pg.GetPawn());
        }
    }
}
