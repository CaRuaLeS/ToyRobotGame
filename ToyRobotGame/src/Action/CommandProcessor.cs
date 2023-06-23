using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Interfaces;

namespace ToyRobotGame.src.Action
{
    public class CommandProcessor: ICommandProcessor
    {
        private readonly Robot.Robot robot;   
        public CommandProcessor(Robot.Robot _robot)
        {
            this.robot = _robot;
        }

        public void ProcessCommand(string command) 
        {
            string[] parts = command.Split(' ');

            if (parts.Length == 0 || command == "PLACE_ROBOT" || command == "PLACE_WALL")
                throw new CustomException("Invalid command");

            string action = parts[0];
            switch (action)
            {
                case "PLACE_ROBOT":
                    string[] robotPlace = parts[1].Split(',');
                    if (robotPlace.Length == 3)
                    {
                        if (int.TryParse(robotPlace[0], out int col) && int.TryParse(robotPlace[1], out int row) &&
                        Enum.TryParse(robotPlace[2], out Direction facing))
                        {
                            robot.PlaceRobot(col, row, facing); 
                        }
                        else { throw new CustomException("Invalid command"); }
                        
                    }
                    else { throw new CustomException("Invalid command. Need to add paramenter (PLACE_ROBOT X,Y,Facing)"); }
                    break;
                case "PLACE_WALL":
                    string[] wallPlace = parts[1].Split(',');
                    if (wallPlace.Length == 2)
                    {
                        if (int.TryParse(wallPlace[0], out int col) && int.TryParse(wallPlace[1], out int row))
                        {
                            robot.PlaceWall(col, row);
                        }
                    }
                    else { throw new CustomException("Invalid command. Need to add coordinate (PLACE_WALL X,Y)"); }
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
                    throw new CustomException("Invalid command");
                    
            }
        }
    }
}
