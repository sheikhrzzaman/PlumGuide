using System.Collections.Generic;
using PlumGuide.PlutoRover.Models;

namespace PlumGuide.PlutoRover.Services
{
    public interface IPlutoBoundaryService
    {
        public List<RoverPosition> GetBoundaries();
    }
}
