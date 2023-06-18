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

            if (parts.Length == 0 || command == "PLACE_ROBOT" || command == "PLACE_WALL") 
                return;

            string action = parts[0];

            switch(action)
            {
                case "PLACE_ROBOT":
                    string[] robotPlace = parts[1]?.Split(',');
                    if (robotPlace.Length == 3)
                    {
                        int row, col;
                        Direction facing;
                        if (int.TryParse(robotPlace[0], out col) && int.TryParse(robotPlace[1], out row) &&
                        Enum.TryParse(robotPlace[2], out facing))
                        {
                            if (row <= robot.XYBoardSize && col <= robot.XYBoardSize)
                            robot.PlaceRobot(col, row, facing); 
                        }
                    }
                    break;
                case "PLACE_WALL":
                    string[] wallPlace = parts[1]?.Split(',');
                    if (wallPlace.Length == 2)
                    {
                        int row, col;
                        if (int.TryParse(wallPlace[0], out col) && int.TryParse(wallPlace[1], out row))
                        {
                            if (row <= robot.XYBoardSize && col <= robot.XYBoardSize)
                                robot.PlaceWall(col, row);
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
