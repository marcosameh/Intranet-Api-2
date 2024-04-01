using FluentValidation;

namespace App.Application.Featured.News.GetAll.Query
{
    public class GetNewsQueryValidator : AbstractValidator<GetNewsQuery>
    {
        public GetNewsQueryValidator()
        {
            RuleFor(x=>x.pageNumber).NotEmpty();
            RuleFor(x=>x.pageSize).NotEmpty();

        }
    }
}
