using ToyRobotGame.src.Identities;

namespace ToyRobotGame.src.Interfaces
{
    public interface IRobot
    {
        Coordinate Position { get; set; }
        Direction Facing { get; set; }
    }
}
