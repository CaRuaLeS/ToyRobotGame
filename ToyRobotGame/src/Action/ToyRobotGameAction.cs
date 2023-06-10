using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Interfaces;
using ToyRobotGame.src.Obstacles;
using ToyRobotGame.src.Robot;

namespace ToyRobotGame.src.Action
{
    public class ToyRobotGameAction: IGameActions
    {
        private const int XYBoardSize = 5;
        private List<Wall> walls;

        public ToyRobotGameAction()
        {
            walls = new List<Wall>();
        }

        public void PlaceWall(int row, int column, Robot.Robot robot) 
        {
            Coordinate wallCoordiante = new Coordinate(row, column);

            if (isValidCoordinate(wallCoordiante))
            {
                Wall newWall = new(wallCoordiante);
                if (!isOccupiedCoordinate(newWall.Position, robot))
                {
                    walls.Add(newWall);
                }
            }
        }

        private bool isValidCoordinate(Coordinate coordinate)
        {
            if (coordinate.Row >= 1 && coordinate.Row <= XYBoardSize && coordinate.Column >= 1 && coordinate.Column <= XYBoardSize)
            {
                return true;
            }
            return false;
        }

        private bool isOccupiedCoordinate(Coordinate position, Robot.Robot robot)
        {

            if (robot != null && robot.Position.Row == position.Row && robot.Position.Column == position.Column 
                || walls.Exists(wall => wall.Position.Row == position.Row && wall.Position.Column == position.Column))
            {
                return true;
            }
            return false;

        }
    }
}
