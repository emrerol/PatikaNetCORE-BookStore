using FluentValidation;

namespace WebApi.Application.AuthorOperarions.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQueryValidator:AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailQueryValidator()
        {
            RuleFor(a=>a.AuthorId).GreaterThan(0);
        }
    }
}