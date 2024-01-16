using Application.Abstractions;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;

namespace Application.Posts.QueryHandlers;

public class GetByIdPostHandler : IRequestHandler<GetByIdPost, Post>
{
    private readonly IPostRepository _repository;

    public GetByIdPostHandler(IPostRepository repository)
    {
        _repository = repository;
    }

    public async Task<Post> Handle(GetByIdPost request, CancellationToken cancellationToken)
    {
        return await _repository.GetById(request.PostId);
    }
}