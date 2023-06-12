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
            string testCommand = "PLACE_ROBOT 2,3,WEST";

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
            string testValidCommand = "PLACE_ROBOT 2,3,WEST";
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
        public void Command_PlaceWallBlockRobot_PLaceShouldBe22()
        {
            // Arrange
            Robot testRobot = new Robot();
            CommandProcessor testProcessor = new CommandProcessor(testRobot);
            string testValidCommand = "PLACE_WALL 2,3";

            // Act
            testProcessor.ProcessCommand(testValidCommand);
            testProcessor.ProcessCommand("PLACE_ROBOT 2,2,NORTH");

            // Assert
            Assert.Equal(1, testRobot.walls.Count);

        }
    }
}
