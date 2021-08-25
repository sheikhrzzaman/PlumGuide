using System.Collections.Generic;
using PlumGuide.PlutoRover.Models;

namespace PlumGuide.PlutoRover.Services
{
    public interface IPlutoObstableLocationService
    {
        public List<RoverPosition> GetObstableLocations();
    }
}
