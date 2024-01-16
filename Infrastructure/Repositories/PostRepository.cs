using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly ApplicationDbContext _context;

    public PostRepository( ApplicationDbContext context)
    {
        this._context = context;
    }

    public async Task<ICollection<Post>> GetAll()
    {
        return await _context.Posts.ToListAsync();
    }
    public async Task<Post?> GetById(int postId)
    {
        return await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
    }

    public async Task<Post> Create(Post postData)
    {
        _context.Posts.Add(postData);
        await _context.SaveChangesAsync();
        return postData;
    }

    public async Task<Post?> Update(Post updateData, int postId)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        if (post != null)
        {
            post.Content = updateData.Content;
            post.Title = updateData.Title;
            post.LastEditDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return post;
        }
        return null;
    }

    public async Task Delete(int postId)
    {
        var post = _context.Posts.FirstOrDefault(p => p.Id == postId);
        if (post != null)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}