using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotGame.src.Action;
using ToyRobotGame.src.Identities;
using ToyRobotGame.src.Robot;
using Xunit;

namespace ToyRobot_Test.ActionsTest
{
    public class GameActionTest
    {
        [Fact]
        public void PlaceRobot_IfNoRobotIsInTheField()
        {
            // Arrange

            GameAction testGameAction = new GameAction();
            int testRow = 2;
            int testColumn = 3;
            var testDirection = Direction.NORTH;

            // Act
            var testRobot = testGameAction.PlaceRobot(testRow, testColumn, testDirection);

            // Assert
            Assert.Equal(testRow, testRobot.Position.Row);
        }
    }
}
