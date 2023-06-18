using ToyRobotGame.src.Identities;

namespace ToyRobotGame.src.Interfaces
{
    public interface IRobotActions
    {
        void PlaceRobot(int row, int column, Direction facing);
        void Move();
        void LookLeft();
        void LookRight();
        void Report();
    }
}
