using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Robot;

namespace ToyRobotGame.src.Action
{
    public class RobotAction
    {
        private int XYBoardLimits = 4;

        public void Move(Robot.Robot robot) 
        {
            // Condition walls when it is implemented
            if (robot != null)
            {
                if (robot.Position != null)
                {
                    if (isValidCoordinate(robot.Position))
                    {
                        Coordinate newCoordinate = CalculateNewCoordinatePosition(robot);
                        robot.Position = newCoordinate;
                    }
                }
            }
        }

        public void LookLeft(Robot.Robot robot)
        {
            ChangeFacingDirection(robot, - 1);
        }

        public void LookRight(Robot.Robot robot)
        {
            ChangeFacingDirection(robot, + 1);

        }

        private void ChangeFacingDirection(Robot.Robot robot, int sideToLook) 
        {
            // SideToLook = -1 --> Look left
            // SideToLook = 1 --> Look right

            if (robot != null)
            {
                int newValue = ((int)robot.Facing + sideToLook) % 4;
                if (newValue < 1) { newValue = 4; }

                robot.Facing = (Direction)newValue;
            }
        }

        public bool isValidCoordinate(Coordinate coordinate)
        {
            if (coordinate.Row >= 1 && coordinate.Row <=XYBoardLimits && coordinate.Column >= 1 && coordinate.Column <= XYBoardLimits)
            {
                return true;
            }
            return false;
        }

        private Coordinate CalculateNewCoordinatePosition(Robot.Robot robot)
        {
            Coordinate newPosition = new(robot.Position.Row, robot.Position.Column);

            switch (robot.Facing)
            {
                case Direction.NORTH:
                    newPosition.Row++;
                    break;
                case Direction.SOUTH:
                    newPosition.Row--;
                    break;
                case Direction.EAST:
                    newPosition.Column++;
                    break;
                case Direction.WEST:
                    newPosition.Column--;
                    break;
            }

            if (newPosition.Row < 1)
            {
                newPosition.Row = XYBoardLimits;
            }
            else if (newPosition.Row > XYBoardLimits)
            {
                newPosition.Row = 1;
            }

            if (newPosition.Column < 1)
            {
                newPosition.Column = XYBoardLimits;
            }
            else if (newPosition.Column > XYBoardLimits)
            {
                newPosition.Column = 1;
            }

            return newPosition;
        }
    }
}
