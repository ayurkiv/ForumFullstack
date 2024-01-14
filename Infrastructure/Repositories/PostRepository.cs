using Application.Abstractions;
using Domain.Models;

namespace Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    public readonly ApplicationDbContext _context;

    public PostRepository( ApplicationDbContext context)
    {
        this._context = context;
    }

    public Task<ICollection<Post>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Post> GetWithComments(int postId)
    {
        throw new NotImplementedException();
    }

    public Task<Post> Create(Post postData)
    {
        throw new NotImplementedException();
    }

    public Task<Post> Update(string updatedContent, int postId)
    {
        throw new NotImplementedException();
    }

    public Task<Post> Delete(int postId)
    {
        throw new NotImplementedException();
    }
}