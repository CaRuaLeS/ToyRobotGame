using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Identities;

namespace ToyRobot_Test.IdentitiesTest
{
    public class DirectionTest
    {
        [Fact]
        public void DirectionNorthIs1()
        {
            Assert.Equal(1, (int)Direction.NORTH);
        }
        [Fact]
        public void DirectionSouthIs3()
        {
            Assert.Equal(3, (int)Direction.SOUTH);
        }
        [Fact]
        public void DirectionEastIs2()
        {
            Assert.Equal(2, (int)Direction.EAST);
        }
        [Fact]
        public void DirectionWestIs4()
        {
            Assert.Equal(4, (int)Direction.WEST);

        }

    }
}
