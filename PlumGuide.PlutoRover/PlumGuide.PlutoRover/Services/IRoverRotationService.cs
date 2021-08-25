using PlumGuide.PlutoRover.Models;

namespace PlumGuide.PlutoRover.Services
{
    public interface IRoverRotationService
    {
        RoverPosition Rotate(RoverPosition roverCurrentLocation, string forwardBackward);
    }
}
