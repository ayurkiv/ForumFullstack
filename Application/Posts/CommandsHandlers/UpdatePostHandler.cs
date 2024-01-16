using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;

namespace Application.Posts.CommandsHandlers;

public class UpdatePostHandler : IRequestHandler<UpdatePost, Post>
{
    private readonly IPostRepository _repository;

    public UpdatePostHandler(IPostRepository repository)
    {
        _repository = repository;
    }

    public async Task<Post> Handle(UpdatePost request, CancellationToken cancellationToken)
    {
        var update = new Post();
        if (request.Content != null)
        {
            update.Content = request.Content;
        }
        var post = await _repository.Update(update, request.PostId);
        return post;
    }
}