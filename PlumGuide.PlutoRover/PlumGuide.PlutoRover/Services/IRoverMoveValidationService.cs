using PlumGuide.PlutoRover.Models;

namespace PlumGuide.PlutoRover.Services
{
    public interface IRoverMoveValidationService
    {
        (bool, string) IsValidMove(RoverPosition roverPostion);
    }
}
