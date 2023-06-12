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
    }
}
