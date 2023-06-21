using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Robot;

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
            Robot testRobot = new();

            // Act
            testRobot.PlaceRobot(testColumn, testRow, testFacing);

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
            Robot testRobot = new();

            // Act
            testRobot.PlaceRobot(1, 1, Direction.NORTH);
            testRobot.PlaceRobot(testColumn, testRow, testFacing);

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
            Robot testRobot = new();

            // Act
            testRobot.PlaceRobot(testColumn, testRow, testFacing);
            testRobot.PlaceRobot(testInvalidRow, testInvalidColumn, testFacing);

            // Assert
            Assert.Equal(testFacing, testRobot.Facing);
            Assert.Equal(testRow, testRobot.Position.Row);
            Assert.Equal(testColumn, testRobot.Position.Column);
        }

        [Fact]
        public void Robot_PlaceRobotFunction_OnWallPosition_RobotStayInPosition()
        {
            // Arrange
            int testRow = 1;
            int testColumn = 1;
            var testFacing = Direction.SOUTH;
            int testWallRow = 8;
            int testWallColumn = 9;
            Robot testRobot = new();

            // Act
            testRobot.PlaceRobot(testColumn, testRow, testFacing);
            testRobot.PlaceWall(testWallColumn, testWallRow);
            testRobot.PlaceRobot(testWallColumn, testWallRow, testFacing);

            // Assert
            Assert.Equal(testFacing, testRobot.Facing);
            Assert.Equal(testRow, testRobot.Position.Row);
            Assert.Equal(testColumn, testRobot.Position.Column);
        }

        [Fact]
        public void Move_ToPosition_21()
        {
            // Arrange
            Robot testRobot = new();
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
            Robot testRobot = new();
            int testFinalRow = 1;
            int testFinalColumn = 1;
            testRobot.PlaceRobot(1, 5, Direction.NORTH);

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
            Robot testRobot = new();
            int testFinalColumn = 5;
            int testFinalRow = 3;
            testRobot.PlaceRobot(1, 3, Direction.WEST);

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
            Robot testRobot = new();
            int testFinalRow = 3;
            int testFinalColumn = 1;
            testRobot.PlaceRobot(5, 3, Direction.EAST);

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
            Robot testRobot = new();
            int testFinalRow = 5;
            int testFinalColumn = 3;
            testRobot.PlaceRobot(3, 1, Direction.SOUTH);

            // Act
            testRobot.Move();

            // Assert
            Assert.Equal(testFinalRow, testRobot.Position.Row);
            Assert.Equal(testFinalColumn, testRobot.Position.Column);
        }
        [Fact]
        public void Move_WithWallPlaced_StayInPosition11()
        {
            // Arrange
            Robot testRobot = new();
            int testRow = 1;
            int testColumn = 2;
            testRobot.PlaceRobot(testColumn, testRow, Direction.NORTH);

            // Act
            testRobot.PlaceWall(2, 2);
            testRobot.Move();

            // Assert
            Assert.Equal(testColumn, testRobot.Position.Column);
            Assert.Equal(testRow, testRobot.Position.Row);
        }

        [Fact]
        public void LookLeft_FacingMustBeSOUTH()
        {
            // Arrange
            Robot testRobot = new();
            Direction testingDirectionResult = Direction.EAST;
            testRobot.PlaceRobot(1, 3, Direction.SOUTH);

            // Act
            testRobot.LookLeft();

            // Assert
            Assert.Equal(testingDirectionResult, testRobot.Facing);
        }
        [Fact]
        public void LookLeft_FacingMustBeWEST()
        {
            // Arrange
            Robot testRobot = new();
            Direction testingDirectionResult = Direction.WEST;
            testRobot.PlaceRobot(1, 3, Direction.NORTH);

            // Act
            testRobot.LookLeft();

            // Assert
            Assert.Equal(testingDirectionResult, testRobot.Facing);
        }
        [Fact]
        public void LookRight_FacingMustBeWEST()
        {
            // Arrange
            Robot testRobot = new();
            Direction testingDirectionResult = Direction.WEST;
            testRobot.PlaceRobot(1, 3, Direction.SOUTH);

            // Act
            testRobot.LookRight();

            // Assert
            Assert.Equal(testingDirectionResult, testRobot.Facing);
        }
        [Fact]
        public void LookRight_FacingMustBeNORTH()
        {
            // Arrange
            Robot testRobot = new();
            Direction testingDirectionResult = Direction.NORTH;
            testRobot.PlaceRobot(1, 3, Direction.WEST);

            // Act
            testRobot.LookRight();

            // Assert
            Assert.Equal(testingDirectionResult, testRobot.Facing);
        }

        [Fact]
        public void Report_ResultMustBe_23NORTH()
        {
            // Arrange
            Robot testRobot = new();
            Direction testDirection = Direction.NORTH;
            int testRow = 2;
            int testCol = 3;
            testRobot.PlaceRobot(testCol, testRow, testDirection);
            // StringWriter stores the data
            var consoleOut = new StringWriter();
            // SetOut stores the data in consoleOut
            Console.SetOut(consoleOut);

            // Act
            testRobot.Report();
            var actualTestOutput = consoleOut.ToString();
            string testReportResult = $"{testCol},{testRow},{testDirection}" + Environment.NewLine;

            // Assert
            Assert.Equal(testReportResult, actualTestOutput);
        }
        [Fact]
        public void PlaceWall_ShouldBePlaced_InPosition22()
        {
            // Arrange
            Robot testRobot = new();
            int testWallRow = 2;
            int testWallColumn = 2;

            // Act
            testRobot.PlaceWall(testWallRow, testWallColumn);

            // Assert
            Assert.Single(testRobot.walls);
        }
        [Fact]
        public void PlaceWall_ShouldBlockRobotMovement_RobotInPosition21()
        {
            // Arrange
            Robot testRobot = new();
            int testRow = 2;
            int testColumn = 1;
            Direction testFacing = Direction.EAST;
            testRobot.PlaceRobot(testColumn, testRow, testFacing);

            // Act
            testRobot.PlaceWall(2, 2);
            testRobot.Move();

            // Assert
            Assert.Equal(testRow, testRobot.Position.Row);
            Assert.Equal(testColumn, testRobot.Position.Column);
        }
        [Fact]
        public void PlaceWall_ShouldBlockRobotMovementToOtherSideOfTheBoard_RobotInPosition51()
        {
            // Arrange
            Robot testRobot = new();
            int testRow = 5;
            int testColumn = 1;
            Direction testFacing = Direction.NORTH;
            testRobot.PlaceRobot(testColumn, testRow, testFacing);

            // Act
            testRobot.PlaceWall(1, 1);
            testRobot.Move();

            // Assert
            Assert.Equal(testRow, testRobot.Position.Row);
            Assert.Equal(testColumn, testRobot.Position.Column);
        }
    }
}
