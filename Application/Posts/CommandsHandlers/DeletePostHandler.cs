using Application.Abstractions;
using Application.Posts.Commands;
using MediatR;

namespace Application.Posts.CommandsHandlers;

public class DeletePostHandler : IRequestHandler<DeletePost>
{
    private readonly IPostRepository _repository;

    public DeletePostHandler(IPostRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeletePost request, CancellationToken cancellationToken)
    {
        await _repository.Delete(request.PostId);
        return Unit.Value;
    }
}