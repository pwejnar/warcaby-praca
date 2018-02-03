using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class Board
    {
        protected int horizontalCellCount;
        protected int verticalCellCount;
        protected Shape[,] shapes;

        public Board(int x) // 2x2 4x4 
        {
            horizontalCellCount = x;
            verticalCellCount = x;
            shapes = new Shape[x, x];
            SetUpBoardWithFields();
        }

        #region Getters

        public int GetSize()
        {
            return verticalCellCount;
        }

        public Shape[,] GetAllShapes()
        {
            return shapes;
        }

        public List<Pawn> GetPawns(Player player)
        {
            return GetPawns().Where(x => x.Player == player).ToList();
        }

        public List<Pawn> GetPawns()
        {

            List<Pawn> pawns = new List<Pawn>();

            foreach (Shape shape in shapes)
            {
                Pawn pawn = shape as Pawn;

                if (pawn != null)
                {
                    pawns.Add(pawn);
                }
            }
            return pawns;
        }

        #endregion

        public void PutOnBoard(Shape shape)
        {
            shapes[shape.Position.Row, shape.Position.Column] = shape;
        }

        public void PutOnBoard(params Shape[] shapesTab)
        {
            foreach (Shape shape in shapesTab)
            {
                shapes[shape.Position.Row, shape.Position.Column] = shape;
            }

        }

        public void Remove(Pawn pawn)
        {
            int row = pawn.Position.Row;
            int column = pawn.Position.Column;

            shapes[row, column] = new Field(new Position(row, column));
            //remove pawn? auto?
        }

        public void ClearPawns()
        {
            List<Pawn> allPawns = GetPawns();

            foreach (Pawn pawn in allPawns)
            {
                Remove(pawn);
            }
        }

        public void ChangePosition(Pawn pawn, Field field)
        {
            Position pawnPosition = pawn.Position;
            Position fieldPosition = field.Position;

            SetControlInPosition(pawn, fieldPosition);
            SetControlInPosition(field, pawnPosition);

            pawn.Position = fieldPosition;
            field.Position = pawnPosition;
        }

        public void CheckIfScoreKing(Pawn pawn)
        {
            if (!pawn.KingState)
            {
                Player player = pawn.Player;
                int pawnRow = pawn.Position.Row;

                if (player.Direction == GameDirection.Down && pawnRow == verticalCellCount - 1)
                    pawn.KingState = true;

                else if (player.Direction == GameDirection.Up && pawnRow == 0)
                    pawn.KingState = true;
            }
        }

        #region SetUp

        void SetUpBoardWithFields()
        {
            for (int i = 0; i < horizontalCellCount; i++)
            {
                for (int j = 0; j < horizontalCellCount; j++)
                {
                    shapes[j, i] = new Field(new Position(j, i));
                }
            }
        }

        public void SetUpPawns(Player _player)
        {
            int min = 0;
            int blockade = 0;
            int jump = 0;
            int pawnCreated = 0;

            if (_player == null)
                throw new Exception("Player not set");

            if (_player.Direction == GameDirection.Down)
            {
                min = 0;
                blockade = horizontalCellCount - 1;
                jump = 1;
            }

            else if (_player.Direction == GameDirection.Up)
            {
                min = horizontalCellCount - 1;
                blockade = 0;
                jump = -1;
            }


            for (int rowCount = min; ; rowCount += jump)
            {
                if (pawnCreated == 12)
                {
                    break;
                }

                for (int columnCount = min; ; columnCount += jump)
                {
                    if ((rowCount + columnCount) % 2 != 0)
                    {
                        shapes[rowCount, columnCount] = new Pawn(_player, new Position(rowCount, columnCount));
                        pawnCreated++;
                    }

                    if (columnCount == blockade)
                        break;
                }
            }
        }

        #endregion


        public Board Clone()
        {
            Board sourceBoard = this;
            Board cloneBoard = new Board(sourceBoard.GetSize());

            for (int i = 0; i < horizontalCellCount; i++)
            {
                for (int j = 0; j < horizontalCellCount; j++)
                {
                    cloneBoard.shapes[i, j] = sourceBoard.shapes[i, j].Clone();
                }
            }
            return cloneBoard;
        }

        public Shape GetControlInDirection(Position position, MoveDirection md)
        {

            if (md == MoveDirection.DownLeft)
            {
                return GetControlInPosition(position.GetNextPosition(+1, -1));
            }

            if (md == MoveDirection.DownRight)
            {
                return GetControlInPosition(position.GetNextPosition(+1, +1));
            }

            if (md == MoveDirection.UpperLeft)
            {
                return GetControlInPosition(position.GetNextPosition(-1, -1));
            }

            if (md == MoveDirection.UpperRight)
            {
                return GetControlInPosition(position.GetNextPosition(-1, +1));
            }

            throw new Exception();
        }



        public Shape GetControlInPosition(Position pos)
        {
            if (pos.Row >= verticalCellCount || pos.Column >= verticalCellCount)
                return null;

            if (pos.Row < 0 || pos.Column < 0)
                return null;

            return shapes[pos.Row, pos.Column];
        }

        public void SetControlInPosition(Shape shape, Position pos)
        {
            int row = pos.Row;
            int col = pos.Column;

            if (row >= verticalCellCount || col >= verticalCellCount)
                throw new Exception();

            if (row < 0 || col < 0)
                throw new Exception();

            shapes[pos.Row, pos.Column] = shape;
        }
    }
}

