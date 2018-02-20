using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers
{
    public enum GameDirection
    {
        Up, Down, All
    }
    public enum MoveDirection
    {
        DownRight,
        DownLeft,
        UpperRight,
        UpperLeft,
        Undefined
    }
    public static class Movement
    {
        public static List<MoveDirection> GetDirections(GameDirection gameDirection = GameDirection.All)
        {
            List<MoveDirection> directions = new List<MoveDirection>();

            if (gameDirection == GameDirection.All)
            {
                directions.Add(MoveDirection.UpperLeft);
                directions.Add(MoveDirection.UpperRight);
                directions.Add(MoveDirection.DownLeft);
                directions.Add(MoveDirection.DownRight);
            }

            else if (gameDirection == GameDirection.Up)
            {
                directions.Add(MoveDirection.UpperLeft);
                directions.Add(MoveDirection.UpperRight);
            }

            else if (gameDirection == GameDirection.Down)
            {
                directions.Add(MoveDirection.DownLeft);
                directions.Add(MoveDirection.DownRight);
            }

            return directions;
        }

        public static MoveDirection GetOpositteDirection(MoveDirection md)
        {

            if (md == MoveDirection.UpperLeft)
            {
                return MoveDirection.DownRight;
            }

            if (md == MoveDirection.UpperRight)
            {
                return MoveDirection.DownLeft;
            }

            if (md == MoveDirection.DownLeft)
            {
                return MoveDirection.UpperRight;
            }

            if (md == MoveDirection.DownRight)
            {
                return MoveDirection.UpperLeft;
            }

            throw new Exception("direction not supported.");
        }

        public static MoveDirection GetDirection(Position position1, Position position2)
        {

            if (position1.Row < position2.Row && position1.Column > position2.Column)
            {
                return MoveDirection.DownLeft;
            }

            if (position1.Row < position2.Row && position1.Column < position2.Column)
            {
                return MoveDirection.DownRight;
            }

            if (position1.Row > position2.Row && position1.Column > position2.Column)
            {
                return MoveDirection.UpperLeft;
            }

            if (position1.Row > position2.Row && position1.Column < position2.Column)
            {
                return MoveDirection.UpperRight;
            }

            return MoveDirection.Undefined;
        }
    }
}
