using System.Linq;
using PlumGuide.PlutoRover.Models;

namespace PlumGuide.PlutoRover.Services
{
    public class RoverMoveValidationService : IRoverMoveValidationService
    {
        private readonly IPlutoBoundaryService _plutoBoundaryService;
        private readonly IPlutoObstableLocationService _plutoObstableLocationService;

        public RoverMoveValidationService(
            IPlutoBoundaryService plutoBoundaryService,
            IPlutoObstableLocationService plutoObstableLocationService)
        {
            _plutoBoundaryService = plutoBoundaryService;
            _plutoObstableLocationService = plutoObstableLocationService;
        }

        public (bool, string) IsValidMove(RoverPosition roverPostion)
        {
            if (_plutoObstableLocationService
                .GetObstableLocations().Any(x => x.PointX == roverPostion.PointX &&
                                                 x.PointY == roverPostion.PointY &&
                                                 x.Direction == roverPostion.Direction))
            {
                return (false, "Obstable");
            }

            if (_plutoBoundaryService
               .GetBoundaries().Any(x => x.PointX == roverPostion.PointX &&
                                                x.PointY == roverPostion.PointY &&
                                                x.Direction == roverPostion.Direction))
            {
                return (false, "Pluto boundary reached");
            }

            return (true, null);
        }
    }
}
