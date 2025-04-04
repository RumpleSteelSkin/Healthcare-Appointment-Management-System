using System.Transactions;
using MediatR;

namespace Core.Application.Pipelines.Transactional;

public class TransactionalPipeline<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ITransactional
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);
        TResponse response = await next();
        transaction.Complete();
        return response;
    }
}