﻿using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Obstacles;

namespace ToyRobotGame.src.Interfaces
{
    public interface IConditions
    {
        bool IsInsideBoardCoordinate(Coordinate position);
        bool IsOccupiedCoordinate (Coordinate position, Robot.Robot robot, List<Wall> walls);
    }
}
