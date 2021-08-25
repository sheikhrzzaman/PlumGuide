namespace PlumGuide.PlutoRover.Services
{
    public interface IRoverMoveServiceFactory
    {
        IRoverMoveService GetRoverMoveService(string moveKey);
    }
}
