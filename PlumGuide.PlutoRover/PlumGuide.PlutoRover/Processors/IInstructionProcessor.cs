using PlumGuide.PlutoRover.Models;

namespace PlumGuide.PlutoRover.Processors
{
    public interface IInstructionProcessor
    {
        (RoverPosition, string) Process(char[] instructions);
    }
}
