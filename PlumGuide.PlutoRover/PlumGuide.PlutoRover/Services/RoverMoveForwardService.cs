using System;
using PlumGuide.PlutoRover.Models;

namespace PlumGuide.PlutoRover.Services
{
    public class RoverMoveForwardService : IRoverMoveService
    {
        public RoverPosition Move(RoverPosition roverCurrentLocation)
        {
            var newPointX = roverCurrentLocation.PointX;
            var newPointY = roverCurrentLocation.PointY;

            if (string.Equals(roverCurrentLocation.Direction, Constants.Direction.North, StringComparison.OrdinalIgnoreCase))
            {
                newPointY++;
            }

            if (string.Equals(roverCurrentLocation.Direction, Constants.Direction.East, StringComparison.OrdinalIgnoreCase))
            {
                newPointX++;
            }

            if (string.Equals(roverCurrentLocation.Direction, Constants.Direction.South, StringComparison.OrdinalIgnoreCase))
            {
                newPointY--;
            }

            if (string.Equals(roverCurrentLocation.Direction, Constants.Direction.West, StringComparison.OrdinalIgnoreCase))
            {
                newPointX--;
            }

            return new RoverPosition
            {
                Direction = roverCurrentLocation.Direction,
                PointX = newPointX,
                PointY = newPointY
            };
        }
    }
}