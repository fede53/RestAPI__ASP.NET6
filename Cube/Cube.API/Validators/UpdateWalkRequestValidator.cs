using Cube.Api.Models.DTO;
using FluentValidation;

namespace NZWalks.API.Validators
{
    public class UpdateWalkRequestValidator : AbstractValidator<UpdateWalkDTO>
    {
        public UpdateWalkRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThan(0);
        }
    }
}