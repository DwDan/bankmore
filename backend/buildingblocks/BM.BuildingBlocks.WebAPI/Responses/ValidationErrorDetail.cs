using FluentValidation.Results;

namespace BM.BuildingBlocks.WebAPI.Responses
{
    public class ValidationErrorDetail
    {
        public string Error { get; init; } = string.Empty;
        public string Detail { get; init; } = string.Empty;

        public static explicit operator ValidationErrorDetail(ValidationFailure validationFailure)
        {
            return new ValidationErrorDetail
            {
                Detail = validationFailure.ErrorMessage,
                Error = validationFailure.ErrorCode
            };
        }
    }
}
