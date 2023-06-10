using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Interfaces;

namespace ToyRobotGame.src.Robot
{
    public class Robot: IRobot, IRobotActions
    {
        public Coordinate Position { get; set; }
        public Direction Facing { get; set; }
        IGameActions game;

        public Robot (IGameActions _game)
        {
            this.game = _game;
        }

        public void PlaceRobot(int row, int column, Direction facing) { }
        public void Move() { }
        public void LookLeft() { }
        public void LookRight() { }
    }
}
