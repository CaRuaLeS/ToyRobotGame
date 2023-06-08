using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Identities;

namespace ToyRobot_Test.IdentitiesTest
{
    public class CoordinateTest
    {
        [Fact]
        public void CoordinateSetRowAndColumn()
        {
            int testRow = 2;
            int testColumn = 3;

            Coordinate coordinate = new Coordinate(testRow, testColumn);

            Assert.Equal(testRow, coordinate.Row);
            Assert.Equal(testColumn, coordinate.Column);
        }
    }
}
