using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Interfaces;
using ToyRobotGame.src.Obstacles;
using ToyRobotGame.src.Robot;

namespace ToyRobotGame.src.Action
{
    public class ToyRobotGameAction: IRobotActions, IGameActions
    {
        int XYBoardSize = 5;
        private Robot.Robot robot;
        private List<Wall> walls;

        public void PlaceRobot(int row, int column, Direction facing) { }
        public void PlaceWall(int row, int column) { }
        public void Report() { }

        public void Move() { }
        public void LookLeft() { }
        public void LookRight() { }

    }
}
