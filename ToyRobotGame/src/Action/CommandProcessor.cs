using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Interfaces;

namespace ToyRobotGame.src.Action
{
    public class CommandProcessor: ICommandProcessor
    {
        private Robot.Robot robot;   
        public CommandProcessor(Robot.Robot _robot)
        {
            this.robot = _robot;
        }

        public void ProcessCommand(string command) 
        {
            string[] parts = command.Split(' ');

            if (parts.Length == 0 ) 
                return;

            string action = parts[0];

            switch(action)
            {
                case "PLACE_ROBOT":
                    string[] robotPlace = parts[1].Split(',');
                    if (robotPlace.Length == 3)
                    {
                        int row, col;
                        Direction facing;
                        if (int.TryParse(robotPlace[0], out row) && int.TryParse(robotPlace[1], out col) &&
                        Enum.TryParse(robotPlace[2], out facing))
                        {
                            if (row <= robot.XYBoardSize && col <= robot.XYBoardSize)
                            robot.PlaceRobot(row, col, facing); 
                        }
                    }
                    break;
                case "PLACE_WALL":
                    string[] wallPlace = parts[1].Split(',');
                    if (wallPlace.Length == 2)
                    {
                        int row, col;
                        if (int.TryParse(wallPlace[0], out row) && int.TryParse(wallPlace[1], out col))
                        {
                            if (row <= robot.XYBoardSize && col <= robot.XYBoardSize)
                                robot.PlaceWall(row, col);
                        }
                    }
                    break;
                case "MOVE":
                    robot.Move();
                    break;
                case "LEFT":
                    robot.LookLeft();
                    break;
                case "RIGHT":
                    robot.LookRight();
                    break;
                case "REPORT":
                    robot.Report();
                    break;
                default:
                    break;
            }
        }
    }
}
