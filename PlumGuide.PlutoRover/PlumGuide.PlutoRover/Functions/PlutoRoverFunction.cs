using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using PlumGuide.PlutoRover.Processors;

namespace PlumGuide.PlutoRover.Functions
{
    public class PlutoRoverFunction
    {
        private readonly IInstructionProcessor _instructionProcessor;
        private readonly IValidator<char[]> _validator;

        public PlutoRoverFunction(IInstructionProcessor instructionProcessor, IValidator<char[]> validator)
        {
            _instructionProcessor = instructionProcessor;
            _validator = validator;
        }

        [FunctionName("PlutoRoverFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v1/plutorover/move")] HttpRequestMessage requestMessage)
        {
            var instructions = await requestMessage.Content.ReadAsStringAsync();

            var chars = instructions.ToCharArray();

            var validationResults = _validator.Validate(chars);

            if (!validationResults.IsValid)
            {
                string errorMessage = string.Join(
                                      Environment.NewLine,
                                      validationResults.Errors.Select(e => e.ErrorMessage).ToArray());

                return new BadRequestObjectResult($"{instructions} {Environment.NewLine} {errorMessage}");
            }

            var response = _instructionProcessor.Process(chars);

            return new OkObjectResult(response);
        }
    }
}
