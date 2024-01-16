using Domain.Models;
using MediatR;

namespace Application.Posts.Commands;

public class CreatePost : IRequest<Post>
{
    public string Content { get; set; } = "";
    public string Title { get; set; } = "";
}