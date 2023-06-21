using ToyRobotGame.src.Helpers;
using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Obstacles;
using ToyRobotGame.src.Robot;

namespace ToyRobot_Test.HelpersTest
{
    public class ConditionsTest
    {
        [Fact]
        public void IsValidCoordinate_SetCorrectCoordinates_ResultTrue()
        {
            // Arrange
            int testBoardSize = 5;
            int testColumn = 4;
            int testRow = 5;
            Coordinate testCoordinate = new(testColumn, testRow);
            Conditions testCondition = new(testBoardSize);

            // Act
            bool testValid = testCondition.IsInsideBoardCoordinate(testCoordinate);

            // Assert
            Assert.True(testValid);
        }

        [Fact]
        public void IsValidCoordinate_SetInvalidCoordinate_ResultFalse()
        {
            // Arrange
            int testBoardSize = 5;
            int testColumn = 7;
            int testRow = 5;
            Coordinate testCoordinate = new(testColumn, testRow);
            Conditions testCondition = new(testBoardSize);

            // Act
            bool testValid = testCondition.IsInsideBoardCoordinate(testCoordinate);

            // Assert
            Assert.False(testValid);
        }

        [Fact]
        public void IsOccupiedCoordinate_RobotPosition_ResultTrue()
        {
            // Arrange
            int testBoardSize = 5;
            Robot testRobot = new();
            int testColumn = 3;
            int testRow = 3;
            Coordinate testCoordinate = new(testColumn, testRow);
            Conditions testCondition = new(testBoardSize);

            testRobot.PlaceRobot(testColumn, testRow, Direction.NORTH);

            // Act
            bool testValid = testCondition.IsOccupiedCoordinate(testCoordinate, testRobot, new List<Wall>());

            // Assert
            Assert.True(testValid);
        }

        [Fact]
        public void IsOccupiedCoordinate_WallPosition_ResultTrue()
        {
            // Arrange
            int testBoardSize = 5;
            Robot testRobot = new();
            int testColumn = 3;
            int testRow = 3;
            Coordinate testCoordinate = new(testColumn, testRow);
            Conditions testCondition = new(testBoardSize);
            testRobot.PlaceWall(testColumn, testRow);
            // Act
            bool testValid = testCondition.IsOccupiedCoordinate(testCoordinate, testRobot, testRobot.walls);

            // Assert
            Assert.True(testValid);
        }

        [Fact]
        public void IsOccupiedCoordinate_UnoccupiedPosition_ResultFalse()
        {
            // Arrange
            int testBoardSize = 5;
            Robot testRobot = new();
            int testColumn = 5;
            int testRow = 1;
            Coordinate testCoordinate = new(testColumn, testRow);
            Conditions testCondition = new(testBoardSize);

            // Act
            bool testValid = testCondition.IsOccupiedCoordinate(testCoordinate, testRobot, testRobot.walls);

            // Assert
            Assert.False(testValid);
        }
    }
}
