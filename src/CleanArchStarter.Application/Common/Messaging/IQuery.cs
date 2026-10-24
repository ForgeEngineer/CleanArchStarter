namespace CleanArchStarter.Application.Common.Messaging;

using MediatR;

public interface IQuery<TResult> : IRequest<TResult> { }

public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{ }
