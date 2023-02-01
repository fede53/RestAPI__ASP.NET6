using Cube.Api.Models.DTO;
using FluentValidation;

namespace NZWalks.API.Validators
{
    public class UpdateWalkDifficultyRequestValidator : AbstractValidator<UpdateWalkDifficultyDTO>
    {
        public UpdateWalkDifficultyRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}