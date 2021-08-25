using System.Collections.Generic;
using PlumGuide.PlutoRover.Models;

namespace PlumGuide.PlutoRover.Services
{
    public class PlutoBoundaryService : IPlutoBoundaryService
    {
        public List<RoverPosition> GetBoundaries()
        {
            return new List<RoverPosition>
            {
                new RoverPosition { PointX = 100, PointY = 100, Direction = "N" },
                new RoverPosition { PointX = -100, PointY = 100, Direction = "N" },

                new RoverPosition { PointX = 100, PointY = -100, Direction = "E" },
                new RoverPosition { PointX = 100, PointY = -100, Direction = "N" },

                new RoverPosition { PointX = 100, PointY = -100, Direction = "S" },
                new RoverPosition { PointX = -100, PointY = -100, Direction = "S" },

                new RoverPosition { PointX = -100, PointY = 100, Direction = "N" },
                new RoverPosition { PointX = -100, PointY = -100, Direction = "N" },
            };
        }
    }
}
