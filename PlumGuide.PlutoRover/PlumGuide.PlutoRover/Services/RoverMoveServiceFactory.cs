using System;
using System.Collections.Generic;

namespace PlumGuide.PlutoRover.Services
{
    public class RoverMoveServiceFactory : IRoverMoveServiceFactory
    {
        private readonly IDictionary<string, IRoverMoveService> _dictionaryMoveServices;

        public RoverMoveServiceFactory(IDictionary<string, IRoverMoveService> dictionaryMoveServices)
        {
            _dictionaryMoveServices = dictionaryMoveServices;
        }

        public IRoverMoveService GetRoverMoveService(string moveKey)
        {
            if (_dictionaryMoveServices.ContainsKey(moveKey.ToUpper()))
            {
                return _dictionaryMoveServices[moveKey.ToUpper()];
            }

            throw new NotSupportedException($"Move:{moveKey} not supported");
        }
    }
}
