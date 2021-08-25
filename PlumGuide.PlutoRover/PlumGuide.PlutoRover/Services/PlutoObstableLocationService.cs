using System.Collections.Generic;
using PlumGuide.PlutoRover.Models;

namespace PlumGuide.PlutoRover.Services
{
    public class PlutoObstableLocationService : IPlutoObstableLocationService
    {
        public List<RoverPosition> GetObstableLocations()
        {
            return new List<RoverPosition>
            {
                new RoverPosition { PointX = 10, PointY = 20, Direction = "N" },
                new RoverPosition { PointX = 23, PointY = -45, Direction = "E" },

                new RoverPosition { PointX = 45, PointY = 19, Direction = "S" },
                new RoverPosition { PointX = 11, PointY = 60, Direction = "W" },
            };
        }
    }
}
