using ToyRobotGame.src.Robot;

namespace ToyRobotGame.src.Interfaces
{
    public interface ICommandProcessor
    {
        void ProcessCommand(string command);

        void Report(Robot.Robot element);
    }
}
