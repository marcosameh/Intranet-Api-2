using App.Application.Infrastructure;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.ValidationBehaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
     where TResponse : Result<TResponse>, new()
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }



        public async Task<TResponse> Handle(TRequest request,  RequestHandlerDelegate<TResponse> next ,CancellationToken cancellationToken)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                var result = new TResponse();
                result.IsSuccess = false;
                result.Error = string.Join(", ", failures.Select(x => x.ErrorMessage));
                return await Task.FromResult(result); // Wrap result with Task.FromResult()
            }

            return await next();
        }

       
    }

}
