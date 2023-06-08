using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Robot;
using Xunit;

namespace ToyRobot_Test.RobotTest
{
    public class RobotTest
    {
        [Fact]
        public void RobotInitializeWithCorrectPositionAndFacing() 
        {
            // Arrange
            var testPosition = new Coordinate(0, 0);
            var testFacing = Direction.NORTH;

            // Act
            var robot = new Robot(testPosition, testFacing);

            // Assert
            Assert.Equal(testPosition, robot.Position);
            Assert.Equal(testFacing, robot.Facing);


        }
    }
}
