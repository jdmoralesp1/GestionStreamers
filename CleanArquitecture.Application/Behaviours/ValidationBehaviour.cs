using FluentValidation;
using MediatR;
using ValidationException = CleanArquitecture.Application.Exceptions.ValidationException;

namespace CleanArquitecture.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //Si tengo alguna validación voy a hacer su evaluación
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                //Busca las validaciones y las ejecuta en el Pipeline (tubo) de un request hacia mi API
                var validationResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));

                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count() != 0)
                {
                    throw new ValidationException(failures);
                }
            }

            return await next();
        }
    }
}
