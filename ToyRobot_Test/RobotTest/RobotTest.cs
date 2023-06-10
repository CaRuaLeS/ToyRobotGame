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
            testRobot.PlaceRobot(testRow, testColumn, testFacing);

            // Assert
            Assert.Equal(testFacing, testRobot.Facing);
            Assert.Equal(testRow, testRobot.Position.Row);
            Assert.Equal(testColumn, testRobot.Position.Column);
        }
        [Fact]
        public void Robot_PlaceRobotFunction_CallTwiceCorrectCoordinates()
        {
            // Arrange
            int testRow = 3;
            int testColumn = 2;
            var testFacing = Direction.SOUTH;
            Robot testRobot = new Robot();

            // Act
            testRobot.PlaceRobot(1, 1, Direction.NORTH);
            testRobot.PlaceRobot(testRow, testColumn, testFacing);

            // Assert
            Assert.Equal(testFacing, testRobot.Facing);
            Assert.Equal(testRow, testRobot.Position.Row);
            Assert.Equal(testColumn, testRobot.Position.Column);
        }
        [Fact]
        public void Robot_PlaceInvalidRobotFunction_FinalShouldBeFirstCoordinates()
        {
            // Arrange
            int testRow = 1;
            int testColumn = 1;
            var testFacing = Direction.SOUTH;
            int testInvalidRow = 8;
            int testInvalidColumn = 9;
            Robot testRobot = new Robot();

            // Act
            testRobot.PlaceRobot(testRow, testColumn, testFacing);
            testRobot.PlaceRobot(testInvalidRow, testInvalidColumn, testFacing);

            // Assert
            Assert.Equal(testFacing, testRobot.Facing);
            Assert.Equal(testRow, testRobot.Position.Row);
            Assert.Equal(testColumn, testRobot.Position.Column);
        }

        [Fact]
        public void Move_ToPosition_21()
        {
            // Arrange
            Robot testRobot = new Robot();
            int testFinalRow = 2;
            int testFinalColumn = 1;
            testRobot.PlaceRobot(1, 1, Direction.NORTH);

            // Act
            testRobot.Move();

            // Assert
            Assert.Equal(testFinalRow, testRobot.Position.Row);
            Assert.Equal(testFinalColumn, testRobot.Position.Column);
        }
        [Fact]
        public void Move_FromTopPositionToOtherSide_ToPosition11()
        {
            // Arrange
            Robot testRobot = new Robot();
            int testFinalRow = 1;
            int testFinalColumn = 1;
            testRobot.PlaceRobot(5, 1, Direction.NORTH);

            // Act
            testRobot.Move();

            // Assert
            Assert.Equal(testFinalRow, testRobot.Position.Row);
            Assert.Equal(testFinalColumn, testRobot.Position.Column);
        }
        [Fact]
        public void Move_FromLeftPositionToOtherSide_ToPosition35()
        {
            // Arrange
            Robot testRobot = new Robot();
            int testFinalRow = 3;
            int testFinalColumn = 5;
            testRobot.PlaceRobot(3, 1, Direction.WEST);

            // Act
            testRobot.Move();

            // Assert
            Assert.Equal(testFinalRow, testRobot.Position.Row);
            Assert.Equal(testFinalColumn, testRobot.Position.Column);
        }
        [Fact]
        public void Move_FromRightPositionToOtherSide_ToPosition31()
        {
            // Arrange
            Robot testRobot = new Robot();
            int testFinalRow = 3;
            int testFinalColumn = 1;
            testRobot.PlaceRobot(3, 5, Direction.EAST);

            // Act
            testRobot.Move();

            // Assert
            Assert.Equal(testFinalRow, testRobot.Position.Row);
            Assert.Equal(testFinalColumn, testRobot.Position.Column);
        }
        [Fact]
        public void Move_FromBottomPositionToOtherSide_ToPosition53()
        {
            // Arrange
            Robot testRobot = new Robot();
            int testFinalRow = 5;
            int testFinalColumn = 3;
            testRobot.PlaceRobot(1, 3, Direction.SOUTH);

            // Act
            testRobot.Move();

            // Assert
            Assert.Equal(testFinalRow, testRobot.Position.Row);
            Assert.Equal(testFinalColumn, testRobot.Position.Column);
        }
    }
}
