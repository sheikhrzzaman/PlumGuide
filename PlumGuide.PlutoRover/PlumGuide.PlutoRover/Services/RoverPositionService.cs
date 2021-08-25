using PlumGuide.PlutoRover.Models;

namespace PlumGuide.PlutoRover.Services
{
    public class RoverPositionService : IRoverPositionService
    {
        private RoverPosition _roverCurrentPosition;

        public RoverPositionService()
        {
            _roverCurrentPosition = new RoverPosition { PointX = 0, PointY = 0, Direction = "N" };
        }

        public RoverPosition GetRoverCurrentPosition()
        {
            return _roverCurrentPosition;
        }

        public void SaveRoverCurrentPosition(RoverPosition roverPosition)
        {
            _roverCurrentPosition = roverPosition;
        }
    }
}
