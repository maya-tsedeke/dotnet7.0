using FluentValidation;
using Kernel.ValidationBase.Contracts;

namespace Kernel.ValidationBase;

public class ApplicationBaseValidationModel<TApplicationModel> : AbstractValidator<TApplicationModel>, IValidatableModel<TApplicationModel> where TApplicationModel : class
{

    public virtual IValidator<TApplicationModel> ValidateApplicationModel(ApplicationBaseValidationModel<TApplicationModel> validator)
    {
        throw new NotImplementedException();
    }
}