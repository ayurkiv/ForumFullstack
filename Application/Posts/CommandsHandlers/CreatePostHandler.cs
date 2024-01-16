using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;

namespace Application.Posts.CommandsHandlers;

public class CreatePostHandler : IRequestHandler<CreatePost, Post>
{
    private readonly IPostRepository _repository;

    public CreatePostHandler(IPostRepository repository)
    {
        _repository = repository;
    }

    public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
    {
        var post = new Post
        {
            Content = request.Content,
            Title = request.Title
        };
        return await _repository.Create(post);
    }
}