using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Obstacles;
using ToyRobotGame.src.Robot;

namespace ToyRobot_Test.Obstacles
{
    public class WallTest
    {
        [Fact]
        public void Wall_CreateWithCoordinates()
        {
            // Arrange
            var testPosition = new Coordinate(0, 0);

            // Act
            var testWall = new Wall(testPosition);

            // Assert
            Assert.Equal(testPosition, testWall.Position);


        }
    }
}
