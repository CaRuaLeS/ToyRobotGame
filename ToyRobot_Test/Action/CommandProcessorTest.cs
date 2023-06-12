using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Action;
using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Robot;
using Xunit;

namespace ToyRobot_Test.Action
{
    public class CommandProcessorTest
    {
        [Fact]
        public void Command_PlaceRobotAction_PLaceIs23WEST()
        {
            // Arrange
            Robot testRobot = new Robot();
            CommandProcessor testProcessor = new CommandProcessor(testRobot);
            string testCommand = "PLACE_ROBOT 3,2,WEST";

            // Act
            testProcessor.ProcessCommand(testCommand);

            // Assert
            Assert.Equal(2, testRobot.Position.Row);
            Assert.Equal(3, testRobot.Position.Column);
            Assert.Equal(Direction.WEST, testRobot.Facing);

        }
        [Fact]
        public void Command_PlaceRobotInvalidAction_NoChangePosition()
        {
            // Arrange
            Robot testRobot = new Robot();
            CommandProcessor testProcessor = new CommandProcessor(testRobot);
            string testValidCommand = "PLACE_ROBOT 3,2,WEST";
            string testInValidCommand = "PLACE_ROBOT 2,7,NORTH";

            // Act
            testProcessor.ProcessCommand(testValidCommand);
            testProcessor.ProcessCommand(testInValidCommand);

            // Assert
            Assert.Equal(2, testRobot.Position.Row);
            Assert.Equal(3, testRobot.Position.Column);
            Assert.Equal(Direction.WEST, testRobot.Facing);

        }
        [Fact]
        public void Command_PlaceWall_WallListShouldBe1()
        {
            // Arrange
            Robot testRobot = new Robot();
            CommandProcessor testProcessor = new CommandProcessor(testRobot);
            string testValidCommand = "PLACE_WALL 2,3";

            // Act
            testProcessor.ProcessCommand(testValidCommand);

            // Assert
            Assert.Equal(1, testRobot.walls.Count);

        }
        [Fact]
        public void Command_PlaceWallIvalid_WallListShouldBe0()
        {
            // Arrange
            Robot testRobot = new Robot();
            CommandProcessor testProcessor = new CommandProcessor(testRobot);
            string testValidCommand = "PLACE_WALL 2,9";

            // Act
            testProcessor.ProcessCommand(testValidCommand);

            // Assert
            Assert.Equal(0, testRobot.walls.Count);

        }
        [Fact]
        public void Command_Move_ToPosition21()
        {
            // Arrange
            Robot testRobot = new Robot();
            CommandProcessor testProcessor = new CommandProcessor(testRobot);
            int testFinalRow = 2;
            int testFinalColumn = 1;
            string testValidCommand = "MOVE";


            // Act
            testRobot.PlaceRobot(1, 1, Direction.NORTH);
            testProcessor.ProcessCommand(testValidCommand);

            // Assert
            Assert.Equal(testFinalRow, testRobot.Position.Row);
            Assert.Equal(testFinalColumn, testRobot.Position.Column);
        }
        [Fact]
        public void Command_PlaceWallBlockRobot_PLaceShouldBe22()
        {
            // Arrange
            Robot testRobot = new Robot();
            CommandProcessor testProcessor = new CommandProcessor(testRobot);
            string testValidCommand = "PLACE_WALL 2,3";

            // Act
            testProcessor.ProcessCommand("PLACE_ROBOT 2,2,NORTH");
            testProcessor.ProcessCommand(testValidCommand);
            testProcessor.ProcessCommand("MOVE");

            // Assert
            Assert.Equal(2, testRobot.Position.Row);
            Assert.Equal(2, testRobot.Position.Column);

        }
        [Fact]
        public void Command_Left_FacingShouldBeWest()
        {
            // Arrange
            Robot testRobot = new Robot();
            CommandProcessor testProcessor = new CommandProcessor(testRobot);
            string testValidCommand = "LEFT";

            // Act
            testProcessor.ProcessCommand("PLACE_ROBOT 2,2,NORTH");
            testProcessor.ProcessCommand(testValidCommand);

            // Assert
            Assert.Equal(Direction.WEST, testRobot.Facing);
        }
        [Fact]
        public void Command_Right_FacingShouldBeEast()
        {
            // Arrange
            Robot testRobot = new Robot();
            CommandProcessor testProcessor = new CommandProcessor(testRobot);
            string testValidCommand = "RIGHT";

            // Act
            testProcessor.ProcessCommand("PLACE_ROBOT 2,2,NORTH");
            testProcessor.ProcessCommand(testValidCommand);

            // Assert
            Assert.Equal(Direction.EAST, testRobot.Facing);
        }
        [Fact]
        public void Command_Report_Is32NORTH()
        {
            // Arrange
            Robot testRobot = new Robot();
            CommandProcessor testProcessor = new CommandProcessor(testRobot);

            testProcessor.ProcessCommand("PLACE_ROBOT 3,2,NORTH");
            // StringWriter stores the data
            var consoleOut = new StringWriter();
            // SetOut stores the data in consoleOut
            Console.SetOut(consoleOut);

            // Act
            testProcessor.ProcessCommand("REPORT");
            var actualTestOutput = consoleOut.ToString();
            string testReportResult = "3,2,NORTH" + Environment.NewLine;

            // Assert
            Assert.Equal(testReportResult, actualTestOutput);
        }
    }
}
