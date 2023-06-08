using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Action;

namespace ToyRobotGame.src.Action
{
    public class GameAction
    {
        RobotAction robotAction = new RobotAction();

        public Robot.Robot PlaceRobot(int row, int column, Direction placeFacing)
        {
            Coordinate placeCoordinate = new(row, column);

            if (robotAction.isValidCoordinate(placeCoordinate))
            {                
                Robot.Robot robot = new(placeCoordinate, placeFacing);

                if (robot == null)
                {
                    robot = new Robot.Robot(placeCoordinate, placeFacing);
                }
                else
                {
                    robot.Position = placeCoordinate;
                    robot.Facing = placeFacing;
                }

                return robot;
            }
            return null;
        }

        public void PlaceWall()
        {

        }
        public void Report (Robot.Robot robot)
        {

        }
    }
}
