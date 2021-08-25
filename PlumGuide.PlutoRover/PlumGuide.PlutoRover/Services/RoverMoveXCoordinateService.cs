using PlumGuide.PlutoRover.Models;

namespace PlumGuide.PlutoRover.Services
{
    public class RoverMoveXCoordinateService : IRoverMoveService
    {
        public RoverPosition Move(RoverPosition roverCurrentLocation, string forwardBackward)
        {
            return new RoverPosition
            {
                Direction = roverCurrentLocation.Direction,
                PointX = roverCurrentLocation.PointX + 1,
                PointY = roverCurrentLocation.PointY
            };
        }
    }
}
