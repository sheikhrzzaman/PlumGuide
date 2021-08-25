using PlumGuide.PlutoRover.Models;
using PlumGuide.PlutoRover.Services;

namespace PlumGuide.PlutoRover.Processors
{
    public class InstructionProcessor : IInstructionProcessor
    {
        private readonly IRoverMoveServiceFactory _roverMoveServiceFactory;
        private readonly IRoverPositionService _roverPositionService;
        private readonly IRoverMoveValidationService _roverMoveValidationService;

        public InstructionProcessor(
            IRoverMoveServiceFactory roverMoveServiceFactory,
            IRoverPositionService roverPositionService,
            IRoverMoveValidationService roverMoveValidationService)
        {
            _roverMoveServiceFactory = roverMoveServiceFactory;
            _roverPositionService = roverPositionService;
            _roverMoveValidationService = roverMoveValidationService;
        }

        public (RoverPosition, string) Process(char[] instructions)
        {
            var currentRoverPosition = _roverPositionService.GetRoverCurrentPosition();

            RoverPosition newPosition = currentRoverPosition;
            string message = null;

            foreach (var instruction in instructions)
            {
                newPosition = _roverMoveServiceFactory.GetRoverMoveService(instruction.ToString()).Move(currentRoverPosition);

                var (isValid, response) = _roverMoveValidationService.IsValidMove(newPosition);

                if (!isValid)
                {
                    message = response;
                    break;
                }

                currentRoverPosition = newPosition;
            }

            _roverPositionService.SaveRoverCurrentPosition(newPosition);
            return (currentRoverPosition, message);
        }
    }
}
