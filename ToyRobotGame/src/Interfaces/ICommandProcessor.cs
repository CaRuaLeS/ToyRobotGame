using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotGame.src.Interfaces
{
    public interface ICommandProcessor
    {
        void ProcessCommand(string command);
    }
}
