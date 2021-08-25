using PlumGuide.PlutoRover.Models;

namespace PlumGuide.PlutoRover.Services
{
    public class RoverMoveYCoordinateService : IRoverMoveService
    {
        public RoverPosition Move(RoverPosition roverCurrentLocation, string forwardBackward)
        {
            return new RoverPosition
            {
                Direction = roverCurrentLocation.Direction,
                PointX = roverCurrentLocation.PointX,
                PointY = roverCurrentLocation.PointY + 1
            };
        }
    }
}
