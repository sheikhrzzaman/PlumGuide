using System.Collections.Generic;
using Calculator.Validations;
using FluentValidation;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using PlumGuide.PlutoRover;
using PlumGuide.PlutoRover.Processors;
using PlumGuide.PlutoRover.Services;

[assembly: FunctionsStartup(typeof(Startup))]

namespace PlumGuide.PlutoRover
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter> { new StringEnumConverter() },
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };

            builder.Services.AddSingleton<RoverMoveForwardService>();
            builder.Services.AddSingleton<RoverMoveBackwardService>();
            builder.Services.AddSingleton<RoverMoveLeftService>();
            builder.Services.AddSingleton<RoverMoveRightService>();

            builder.Services.AddSingleton<IRoverMoveServiceFactory, RoverMoveServiceFactory>();

            builder.Services.AddSingleton<IDictionary<string, IRoverMoveService>>(sp =>
            {
                return new Dictionary<string, IRoverMoveService>
                {
                    { Constants.Move.Forward, sp.GetRequiredService<RoverMoveForwardService>() },
                    { Constants.Move.Backward, sp.GetRequiredService<RoverMoveBackwardService>() },
                    { Constants.Move.Left, sp.GetRequiredService<RoverMoveLeftService>() },
                    { Constants.Move.Right, sp.GetRequiredService<RoverMoveRightService>() }
                };
            });

            builder.Services.AddSingleton<IInstructionProcessor, InstructionProcessor>();

            builder.Services.AddSingleton<IValidator<char[]>, InstructionValidator>();
            builder.Services.AddSingleton<IRoverPositionService, RoverPositionService>();

            builder.Services.AddSingleton<IPlutoBoundaryService, PlutoBoundaryService>();
            builder.Services.AddSingleton<IPlutoObstableLocationService, PlutoObstableLocationService>();
            builder.Services.AddSingleton<IRoverMoveValidationService, RoverMoveValidationService>();
        }
    }
}
