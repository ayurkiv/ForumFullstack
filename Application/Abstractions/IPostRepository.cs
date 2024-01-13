using Domain.Models;

namespace Application.Abstractions;

public interface IPostRepository
{
    Task<ICollection<Post>> GetAll();
    Task<Post> GetWithComments(int postId);
    Task<Post> Create(Post postData);
    Task<Post> Update(string updatedContent, int postId);
    Task<Post> Delete(int postId);
}