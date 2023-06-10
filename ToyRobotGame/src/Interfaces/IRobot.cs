using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Identities;

namespace ToyRobotGame.src.Interfaces
{
    public interface IRobot
    {
        Coordinate Position { get; set; }
        Direction Facing { get; set; }
    }
}
