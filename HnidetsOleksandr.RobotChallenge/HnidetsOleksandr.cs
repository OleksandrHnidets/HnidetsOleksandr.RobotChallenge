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
        public const int MinEnergyToCreateRobot = 250;

        public string Author
        {
            get { return "Hnidets Oleksandr"; }
        }

        public RobotCommand DoStep(IList<Robot.Common.Robot> robots, int robotToMoveIndex, Map map)
        {
            Robot.Common.Robot movingRobot = robots[robotToMoveIndex];
            Position stationPosition = FindNearestStation(robots[robotToMoveIndex], map, robots);

            if (DistanceHelper.IsInRadius(movingRobot, stationPosition))
            {
                return new CollectEnergyCommand();
            }
            else
            if ((stationPosition.X == movingRobot.Position.X) || (stationPosition.Y== movingRobot.Position.Y))
            {
                return new MoveCommand() { NewPosition = MoveLinear(movingRobot.Position, stationPosition) };
            }
            else
            if((stationPosition.X!= movingRobot.Position.X) && (stationPosition.Y!=movingRobot.Position.Y))
            {
                return new MoveCommand() { NewPosition = MoveDiagonal(movingRobot, stationPosition) };
            }
            else
            {
                return new CollectEnergyCommand();
            }
        }

        public Position FindNearestStation(Robot.Common.Robot movingrobot, Map map, IList<Robot.Common.Robot> robots)
        {
            EnergyStation nearest = null;
            int minDistance = int.MaxValue;
            
            foreach(var station in map.Stations)
            {
                if(IsStationFree(station,movingrobot,robots))
                {
                    int d = DistanceHelper.FindDistance(station.Position, movingrobot.Position);
                    if (d < minDistance)
                    {
                        minDistance = d;
                        nearest = station;
                    }
                }
            }
            return nearest == null ? null : nearest.Position;
        }

        public bool IsCellFree(Position cell, Robot.Common.Robot movingRobot, IList<Robot.Common.Robot> robots)
        {
            foreach(var robot in robots)
            {
                if(robot!=movingRobot)
                {
                    if (robot.Position == cell)
                        return false;
                }
            }
            return true;
        }

        public bool IsStationFree(EnergyStation station, Robot.Common.Robot movingRobot, IList<Robot.Common.Robot> robots)
        => IsCellFree(station.Position, movingRobot, robots);

        public Position MoveDiagonal(Robot.Common.Robot movingRobot, Position stationPos)
        {
            if (movingRobot.Position.X < stationPos.X && movingRobot.Position.Y < stationPos.Y)
            {
                return new Position() { X = movingRobot.Position.X + 1, Y = movingRobot.Position.Y + 1 };
            }
            else if (movingRobot.Position.X < stationPos.X && movingRobot.Position.Y > stationPos.Y)
            {
                return new Position() { X = movingRobot.Position.X + 1, Y = movingRobot.Position.Y - 1 };
            }
            else if (movingRobot.Position.X > stationPos.X && movingRobot.Position.Y < stationPos.Y)
            {
                return new Position() { X = movingRobot.Position.X - 1, Y = movingRobot.Position.Y + 1 };
            }
            else if (movingRobot.Position.X > stationPos.X && movingRobot.Position.Y > stationPos.Y)
            {
                return new Position() { X = movingRobot.Position.X - 1, Y = movingRobot.Position.Y - 1 };
            }
            else return new Position() { X = movingRobot.Position.X, Y = movingRobot.Position.Y };
        }

        public Position MoveLinear(Position movingRobotPos, Position stationPos)
        {
            if (movingRobotPos.X == stationPos.X)
            {
                Position pos = (movingRobotPos.Y < stationPos.Y) ? (new Position() { X = movingRobotPos.X, Y = movingRobotPos.Y + 1 }) : (new Position() { X = movingRobotPos.X, Y = movingRobotPos.Y - 1 });
                return pos;
            }
            else if (movingRobotPos.Y == stationPos.Y)
            {
                Position pos = (movingRobotPos.X < stationPos.X) ? (new Position() { X = movingRobotPos.X + 1, Y = movingRobotPos.Y }) : (new Position() { X = movingRobotPos.X - 1, Y = movingRobotPos.Y });
                return pos;
            }
            else return movingRobotPos;
        }
    }

}
