using System;

namespace PlumGuide.PlutoRover.Services
{
    public class RoverRotationRightService : IRoverRotationService
    {
        public string Rotate(string currentDirection)
        {
            if (string.Equals(currentDirection, Constants.Direction.North, StringComparison.OrdinalIgnoreCase))
            {
                return Constants.Direction.East;
            }

            if (string.Equals(currentDirection, Constants.Direction.East, StringComparison.OrdinalIgnoreCase))
            {
                return Constants.Direction.South;
            }

            if (string.Equals(currentDirection, Constants.Direction.South, StringComparison.OrdinalIgnoreCase))
            {
                return Constants.Direction.West;
            }

            if (string.Equals(currentDirection, Constants.Direction.West, StringComparison.OrdinalIgnoreCase))
            {
                return Constants.Direction.North;
            }

            return currentDirection;
        }
    }
}