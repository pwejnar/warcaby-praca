﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers;
using NUnit.Framework.Internal.Execution;

namespace warcaby
{
    public class MovementManager
    {
        public Pawn SelectedPawn { get; set; }
        public Field SelectedField { get; set; }
        public Board Board { get; set; }

        public MovementManager(Board board)
        {
            this.Board = board;
            SelectedField = null;
            SelectedPawn = null;
        }

        public void SelectPawn(Pawn pawn)
        {
            PlayerGraphical actualPlayer = GameManager.ActualPlayer;

            if (pawn.GetOwner() == actualPlayer.Player)
            {
                this.SelectedPawn = pawn;
            }
            else
            {
                MessageBox.Show("It is not your turn");
            }
        }

        public void SelectField(Field field)
        {
            if (SelectedPawn != null)
            {
                this.SelectedField = field;
                //check if valid move 
                // make move 
                MakeMove();
                //change actual player
            }
        }

        private void MakeMove()
        {
            ClearMoveData();
        }

        private void ClearMoveData()
        {
            SelectedPawn = null;
            SelectedField = null;
        }

    }
}
