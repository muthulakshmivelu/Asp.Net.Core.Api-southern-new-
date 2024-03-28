using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Behaviours
{
    public class ValidationBehaviour<TRequest, TRespone> : IPipelineBehavior<TRequest, TRespone> where TRequest : IRequest<TRespone>
    {
        private readonly IValidator<TRequest> validator;

        public ValidationBehaviour(IValidator<TRequest> validator)
        {
            this.validator = validator;
        }

        public async Task<TRespone> Handle(TRequest request, RequestHandlerDelegate<TRespone> next, CancellationToken cancellationToken)
        {
            var result = await validator.ValidateAsync(request);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            return await next();
        }
    }
}
