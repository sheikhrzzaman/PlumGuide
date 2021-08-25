using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using PlumGuide.PlutoRover;

namespace Calculator.Validations
{
    public class InstructionValidator : AbstractValidator<char[]>
    {
        private readonly HashSet<string> _validInstructions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            Constants.Move.Backward,
            Constants.Move.Forward,
            Constants.Move.Left,
            Constants.Move.Right
        };

        public InstructionValidator()
        {
            RuleFor(x => x).NotEmpty();

            RuleFor(x => x)
                .Must(x => x.All(s => _validInstructions.Contains(s.ToString())))
                .WithMessage(y => $"Instructions must be one of these values-{Constants.Move.Backward},{Constants.Move.Forward},{Constants.Move.Left},{Constants.Move.Right}");
        }
    }
}
