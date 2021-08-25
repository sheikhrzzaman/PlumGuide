using System;
using System.Collections.Generic;

namespace PlumGuide.PlutoRover.Services
{
    public class RoverRotationFactoryService : IRoverRotationFactoryService
    {
        private readonly IDictionary<string, IRoverRotationService> _dictionaryRoationServices;

        public RoverRotationFactoryService(IDictionary<string, IRoverRotationService> dictionaryRoationServices)
        {
            _dictionaryRoationServices = dictionaryRoationServices;
        }

        public IRoverRotationService GetRoverRotationService(string rotationKey)
        {
            if (_dictionaryRoationServices.ContainsKey(rotationKey))
            {
                return _dictionaryRoationServices[rotationKey];
            }

            throw new NotImplementedException();
        }
    }
}
