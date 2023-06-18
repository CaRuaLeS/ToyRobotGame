using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Obstacles;
using ToyRobotGame.src.Robot;

namespace ToyRobotGame.src.Interfaces
{
    public interface IConditions
    {
        bool IsValidCoordinate(Coordinate position);
        bool IsOccupiedCoordinate (Coordinate position, Robot.Robot robot);
    }
}
