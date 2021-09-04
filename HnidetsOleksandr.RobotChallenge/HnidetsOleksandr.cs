using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot.Common;

namespace HnidetsOleksandr.RobotChallenge
{
    public class HnidetsOleksandr : IRobotAlgorithm
    {
        public string Author
        {
            get { return "Hnidets Oleksandr"; }
        }

        public RobotCommand DoStep(IList<Robot.Common.Robot> robots, int robotToMoveIndex, Map map)
        {
            var myRobot = robots[robotToMoveIndex];
            Position newposition = myRobot.Position;
            newposition.X++;
            newposition.Y++;
            return new MoveCommand() { NewPosition = newposition };
        }
    }
}
