using Cube.Api.Models.DTO;
using FluentValidation;

namespace NZWalks.API.Validators
{
    public class UpdateRegionRequestValidator : AbstractValidator<UpdateRegionDTO>
    {
        public UpdateRegionRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Area).GreaterThan(0);
            RuleFor(x => x.Population).GreaterThanOrEqualTo(0);
        }
    }
}
