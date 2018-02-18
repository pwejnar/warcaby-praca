using System;
using System.Collections.Generic;
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
        public List<IMoveable> AvailablePawnMoves { get; set; }
        public Field SelectedField { get; set; }
        public Board Board { get; set; }
        public GameManager GameManager { get; set; }

        public MovementManager(Board board, GameManager gameManager)
        {
            this.Board = board;
            this.GameManager = gameManager;
            SelectedField = null;
            SelectedPawn = null;
        }

        public async void SelectPawn(Pawn pawn)
        {
            PlayerGraphical actualPlayer = GameManager.ActualPlayer;

            if (pawn.Player != actualPlayer.Player)
            {
                MessageBox.Show("It is not your turn");
                return;
            }

            this.SelectedPawn = pawn;
            Scope scope = new Scope(Board);
            this.AvailablePawnMoves = await scope.FindMoves(pawn);
        }

        public void SelectField(Field field)
        {
            if (SelectedPawn != null)
            {
                this.SelectedField = field;
                if (CheckIfValidMove(SelectedPawn.Position, SelectedField.Position))
                    MakeMove();
            }
        }

        bool CheckIfValidMove(Position pos1, Position pos2)
        {
            MoveDirection direction = Movement.GetDirection(pos1, pos2);
            if (direction == MoveDirection.Undefined)
                return false;

            Move move = new Move(pos1, pos2, direction);
            List<IMoveable> x = AvailablePawnMoves.Where(obj => obj.IsMove(move)).ToList();
            return x.Count > 0;
        }

        private void MakeMove()
        {
            Board.ChangePosition(SelectedPawn, SelectedField);
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
