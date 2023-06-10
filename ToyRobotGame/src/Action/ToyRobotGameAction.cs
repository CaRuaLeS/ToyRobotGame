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
    public class ToyRobotGameAction: IGameActions
    {
        private const int XYBoardSize = 5;
        private List<Wall> walls;

        public ToyRobotGameAction()
        {
            walls = new List<Wall>();
        }

        public void PlaceWall(int row, int column) 
        {
            
        }




    }
}
