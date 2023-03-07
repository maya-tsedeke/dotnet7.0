using FluentValidation;

namespace Kernel.ValidationBase.Contracts;

public interface IValidatableModel<TApplicationModel> where TApplicationModel : class
{
    IValidator<TApplicationModel> ValidateApplicationModel(ApplicationBaseValidationModel<TApplicationModel> validator);
}