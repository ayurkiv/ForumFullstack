namespace Domain.Models;

public class Post
{
    public int Id { get; init; }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public DateTime AddedDate { get; set; } = DateTime.Now;
    public DateTime? LastEditDate { get; set; }
}