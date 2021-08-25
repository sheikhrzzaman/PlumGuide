namespace PlumGuide.PlutoRover.Services
{
    public interface IRoverRotationFactoryService
    {
        IRoverRotationService GetRoverRotationService(string rotationKey);
    }
}
