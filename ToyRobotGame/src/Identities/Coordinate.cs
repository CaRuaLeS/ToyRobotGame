using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotGame.src.Identities
{
    public class Coordinate
    {
        public int Row;
        public int Column;

        public Coordinate(int column, int row)
        {
            Column = column;
            Row = row;
        }
    }
}
