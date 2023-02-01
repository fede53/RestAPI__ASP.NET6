using Cube.Api.Models.DTO;
using FluentValidation;

namespace NZWalks.API.Validators
{
    public class AddWalkRequestValidator : AbstractValidator<AddWalkDTO>
    {
        public AddWalkRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThan(0);
        }
    }
}