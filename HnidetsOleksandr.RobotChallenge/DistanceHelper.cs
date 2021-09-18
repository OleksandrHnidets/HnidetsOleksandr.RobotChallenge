using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot.Common;

namespace HnidetsOleksandr.RobotChallenge
{
    class DistanceHelper
    {
        public const int MinLinearDistance = 9;
        public const int MinDiagonalDistance = 18;
        
        public static int FindDistance(Position a, Position b)
            => (int)(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));

        public static bool IsInRadius(Robot.Common.Robot movingRobot, Position stationPos)
        {
            List<Position> radiusCells = new List<Position>()
            {
                new Position(){ X=stationPos.X+1, Y=stationPos.Y+1},
                new Position(){X=stationPos.X+2, Y=stationPos.Y+2},
                new Position(){X=stationPos.X+3, Y=stationPos.Y+3},
                new Position(){X=stationPos.X+1, Y=stationPos.Y+2},
                new Position(){X=stationPos.X+1, Y=stationPos.Y+3},
                new Position(){X=stationPos.X+2, Y=stationPos.Y+1},
                new Position(){X=stationPos.X+2, Y=stationPos.Y+3},
                new Position(){X=stationPos.X+3, Y=stationPos.Y+1},
                new Position(){X=stationPos.X+3, Y=stationPos.Y+2},

                new Position(){X=stationPos.X+1, Y=stationPos.Y-1},
                new Position(){X=stationPos.X+2, Y=stationPos.Y-2},
                new Position(){X=stationPos.X+3, Y=stationPos.Y-3},
                new Position(){X=stationPos.X+1, Y=stationPos.Y-2},
                new Position(){X=stationPos.X+1, Y=stationPos.Y-3},
                new Position(){X=stationPos.X+2, Y=stationPos.Y-1},
                new Position(){X=stationPos.X+2, Y=stationPos.Y-3},
                new Position(){X=stationPos.X+3, Y=stationPos.Y-1},
                new Position(){X=stationPos.X+3, Y=stationPos.Y-2},

                new Position(){ X=stationPos.X-1, Y=stationPos.Y+1},
                new Position(){X=stationPos.X-2, Y=stationPos.Y+2},
                new Position(){X=stationPos.X-3, Y=stationPos.Y+3},
                new Position(){X=stationPos.X-1, Y=stationPos.Y+2},
                new Position(){X=stationPos.X-1, Y=stationPos.Y+3},
                new Position(){X=stationPos.X-2, Y=stationPos.Y+1},
                new Position(){X=stationPos.X-2, Y=stationPos.Y+3},
                new Position(){X=stationPos.X-3, Y=stationPos.Y+1},
                new Position(){X=stationPos.X-3, Y=stationPos.Y+2},

                new Position(){ X=stationPos.X-1, Y=stationPos.Y-1},
                new Position(){X=stationPos.X-2, Y=stationPos.Y-2},
                new Position(){X=stationPos.X-3, Y=stationPos.Y-3},
                new Position(){X=stationPos.X-1, Y=stationPos.Y-2},
                new Position(){X=stationPos.X-1, Y=stationPos.Y-3},
                new Position(){X=stationPos.X-2, Y=stationPos.Y-1},
                new Position(){X=stationPos.X-2, Y=stationPos.Y-3},
                new Position(){X=stationPos.X-3, Y=stationPos.Y-1},
                new Position(){X=stationPos.X-3, Y=stationPos.Y-2},
            };
            if (movingRobot.Position.X == stationPos.X || movingRobot.Position.Y == stationPos.Y)
            {
                bool isTrue = (FindDistance(movingRobot.Position, stationPos) <= 9);
                return isTrue;
            }
            else
            {
                foreach(Position p in radiusCells)
                {
                    return (p == movingRobot.Position);
                }
            }

            return false;   
        }
    }
}
