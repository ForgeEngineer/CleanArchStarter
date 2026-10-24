namespace CleanArchStarter.Application.Common.Messaging;

using MediatR;

public interface ICommand<TResult> : IRequest<TResult> { }

public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{ }
