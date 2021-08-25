using PlumGuide.PlutoRover.Models;

namespace PlumGuide.PlutoRover.Services
{
    public interface IRoverPositionService
    {
        RoverPosition GetRoverCurrentPosition();

        void SaveRoverCurrentPosition(RoverPosition roverPosition);
    }
}
