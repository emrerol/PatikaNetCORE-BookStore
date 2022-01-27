using System;
using FluentValidation;

namespace WebApi.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(c=>c.Model.PageCount).GreaterThan(0);
            RuleFor(C=>C.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now);
            RuleFor(c=>c.Model.Title).NotNull().MinimumLength(2);
        }
    }
}