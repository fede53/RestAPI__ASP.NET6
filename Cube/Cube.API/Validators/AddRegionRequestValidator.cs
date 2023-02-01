using Cube.Api.Models.DTO;
using FluentValidation;

namespace Cube.Api.Validators
{
    public class AddRegionRequestValidator : AbstractValidator<AddRegionDTO>
    {
        public AddRegionRequestValidator() 
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Area).GreaterThan(0);
            RuleFor(x => x.Population).GreaterThanOrEqualTo(0);
        }
    }
}
