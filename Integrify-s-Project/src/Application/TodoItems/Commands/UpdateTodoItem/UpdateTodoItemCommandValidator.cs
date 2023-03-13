using FluentValidation;

namespace Integrify_s_Project.Application.TodoItems.Commands.UpdateTodoItem;
public class UpdateTodoItemCommandValidator : AbstractValidator<UpdateTodoItemCommand>
{
    public UpdateTodoItemCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
