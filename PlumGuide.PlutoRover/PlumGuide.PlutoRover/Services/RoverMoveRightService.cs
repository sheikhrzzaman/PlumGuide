using System;
using PlumGuide.PlutoRover.Models;

namespace PlumGuide.PlutoRover.Services
{
    public class RoverMoveRightService : IRoverMoveService
    {
        public RoverPosition Move(RoverPosition roverCurrentLocation)
        {
            var newDirection = roverCurrentLocation.Direction;
            if (string.Equals(roverCurrentLocation.Direction, Constants.Direction.North, StringComparison.OrdinalIgnoreCase))
            {
                newDirection = Constants.Direction.East;
            }

            if (string.Equals(roverCurrentLocation.Direction, Constants.Direction.East, StringComparison.OrdinalIgnoreCase))
            {
                newDirection = Constants.Direction.South;
            }

            if (string.Equals(roverCurrentLocation.Direction, Constants.Direction.South, StringComparison.OrdinalIgnoreCase))
            {
                newDirection = Constants.Direction.West;
            }

            if (string.Equals(roverCurrentLocation.Direction, Constants.Direction.West, StringComparison.OrdinalIgnoreCase))
            {
                newDirection = Constants.Direction.North;
            }

            return new RoverPosition
            {
                Direction = newDirection,
                PointX = roverCurrentLocation.PointX,
                PointY = roverCurrentLocation.PointY
            };
        }
    }
}