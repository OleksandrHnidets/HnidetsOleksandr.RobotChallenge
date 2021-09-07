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
            Robot.Common.Robot movingRobot = robots[robotToMoveIndex];
            if((movingRobot.Energy>500)&&(robots.Count<map.Stations.Count))
            {
                return new CreateNewRobotCommand();
            }

            Position stationPosition = FindNearestStation(robots[robotToMoveIndex], map, robots);

            if (stationPosition == null)
                return null;
            if (stationPosition == movingRobot.Position)
                return new CollectEnergyCommand();
            else 
            {
                return new MoveCommand() { NewPosition = stationPosition };
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
    }

}
