using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Identities;

namespace ToyRobotGame.src.Obstacles
{
    public class Wall
    {
        public Coordinate Position;
        public Wall(Coordinate position) 
        {
            Position = position;
        }
    }
}
