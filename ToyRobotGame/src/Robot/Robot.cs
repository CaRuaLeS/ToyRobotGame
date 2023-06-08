using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Identities;

namespace ToyRobotGame.src.Robot
{
    public class Robot
    {
        public Coordinate Position;
        public Direction Facing;

        public Robot (Coordinate position, Direction facing)
        {
            this.Position = position;
            this.Facing = facing;
        }
    }
}
