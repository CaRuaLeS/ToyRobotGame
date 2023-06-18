using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Interfaces;
using ToyRobotGame.src.Obstacles;
using ToyRobotGame.src.Robot;

namespace ToyRobotGame.src.Helpers
{
    public class Conditions: IConditions
    {
        private readonly int XYBoardSize;
        private readonly List<Wall> walls;

        public Conditions(int boardSize, List<Wall> instanceWalls) 
        { 
            XYBoardSize = boardSize;
            walls = instanceWalls;
        }

        public bool IsValidCoordinate(Coordinate position)
        {
            if (position.Row >= 1 && position.Row <= XYBoardSize && position.Column >= 1 && position.Column <= XYBoardSize)
            {
                return true;
            }
            return false;
        }
        public bool IsOccupiedCoordinate(Coordinate position, Robot.Robot robot)
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
