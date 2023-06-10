using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Identities;

namespace ToyRobotGame.src.Interfaces
{
    public interface IRobotActions
    {
        void PlaceRobot(int row, int column, Direction facing);
        void Move();
        void LookLeft();
        void LookRight();
    }
}
