using PlumGuide.PlutoRover.Models;

namespace PlumGuide.PlutoRover.Services
{
    public interface IRoverMoveService
    {
        RoverPosition Move(RoverPosition roverCurrentLocation);
    }
}
