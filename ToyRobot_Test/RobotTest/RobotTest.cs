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
        public void Robot_PlaceRobotFunction_CorrectCoordinatesAndFacing()
        {
            // Arrange
            int testRow = 1;
            int testColumn = 1;
            var testFacing = Direction.NORTH;
            Robot testRobot = new Robot();

            // Act
            testRobot.PlaceRobot(1, 1, Direction.NORTH);

            // Assert
            Assert.Equal(testFacing, testRobot.Facing);
            Assert.Equal(testRow, testRobot.Position.Row);
            Assert.Equal(testColumn, testRobot.Position.Column);


        }
    }
}
