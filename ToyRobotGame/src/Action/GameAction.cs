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
        // Made it public for testing
        public Robot.Robot robotInstance;
        private RobotAction robotAction = new RobotAction();

        public void PlaceRobot(int row, int column, Direction placeFacing)
        {
            Coordinate placeCoordinate = new(row, column);

            if (robotAction.isValidCoordinate(placeCoordinate))
            {                

                if (robotInstance == null)
                {
                    robotInstance = new Robot.Robot(placeCoordinate, placeFacing);
                }
                else
                {
                    robotInstance.Position = placeCoordinate;
                    robotInstance.Facing = placeFacing;
                }

            }
        }

        public void PlaceWall()
        {

        }
        public void Report (Robot.Robot robot)
        {

        }
    }
}
