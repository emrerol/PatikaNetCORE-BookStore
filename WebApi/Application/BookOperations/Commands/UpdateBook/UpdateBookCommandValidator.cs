using System;
using FluentValidation;
using WebApi.BookOperations.Commands.UpdateBook;

namespace WebApi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidator:AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(c=>c.BookId).GreaterThan(0);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(c=>c.Model.PageCount).GreaterThan(0);
            RuleFor(C=>C.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now);
            RuleFor(c=>c.Model.Title).NotNull().MinimumLength(2);
        }
    }
}