using Domain.Models;

namespace Application.Abstractions;

public interface IPostRepository
{
    Task<ICollection<Post>> GetAll();
    Task<Post?> GetById(int postId);
    Task<Post> Create(Post postData);
    Task<Post?> Update(Post updateData, int postId);
    Task Delete(int postId);
}