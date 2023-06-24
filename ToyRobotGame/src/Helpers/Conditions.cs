using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Interfaces;
using ToyRobotGame.src.Obstacles;

namespace ToyRobotGame.src.Helpers
{
    public class Conditions: IConditions
    {
        private readonly int XYBoardSize;

        public Conditions(int boardSize) 
        { 
            XYBoardSize = boardSize;
        }

        public bool IsInsideBoardCoordinate(Coordinate position)
        {
            if (position.Row >= 1 && position.Row <= XYBoardSize && position.Column >= 1 && position.Column <= XYBoardSize)
            {
                return true;
            }
            return false;
        }
        public bool IsOccupiedCoordinate(Coordinate position, Robot.Robot robot, List<Wall> walls)
        {
            if (robot.Position != null && robot.Position.Row == position.Row && robot.Position.Column == position.Column
                || walls.Exists(wall => wall.Position.Row == position.Row && wall.Position.Column == position.Column))
            {
                return true;
            }
            return false;
        }
    }
}
