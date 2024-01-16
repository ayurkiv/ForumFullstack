using Domain.Models;
using MediatR;

namespace Application.Posts.Queries;

public class GetByIdPost : IRequest<Post>
{
    public int PostId { get; set; }
}