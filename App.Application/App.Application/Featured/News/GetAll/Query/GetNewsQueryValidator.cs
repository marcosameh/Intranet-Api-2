using FluentValidation;

namespace App.Application.Featured.News.GetAll.Query
{
    public class GetNewsQueryValidator : AbstractValidator<GetNewsQuery>
    {
        public GetNewsQueryValidator()
        {
            RuleFor(x=>x.pageNumber).NotEmpty().NotEqual(0);
            RuleFor(x=>x.pageSize).NotEmpty().NotEqual(0);

        }
    }
}
