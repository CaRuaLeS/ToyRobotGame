using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Identities;

namespace ToyRobotGame.src.Interfaces
{
    public interface IGameActions
    {
        void PlaceRobot(int row, int column, Direction facing);
        void PlaceWall(int row, int column);
        void Report();
    }
}
