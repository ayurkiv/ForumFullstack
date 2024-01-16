using Application.Abstractions;
using Application.Posts.Commands;
using Application.Posts.Queries;
using Domain.Models;
using Infrastructure;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
        .EnableSensitiveDataLogging()
);
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddMediatR(typeof(CreatePost));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/post/{id:int}", async (IMediator mediator, int id) =>
    {
        var getPost = new GetByIdPost { PostId = id };
        var post = await mediator.Send(getPost);
        return Results.Ok(post);
    })
    .WithName("GetPostById");

app.MapGet("/api/posts", async (IMediator mediator) =>
    {
        var getPosts = new GetAllPosts();
        var posts = await mediator.Send(getPosts);
        return Results.Ok(posts);
    })
    .WithName("GetPosts");

app.MapPost("/api/posts", async (IMediator mediator, [FromBody] Post post) =>
{
    var createPost = new CreatePost
    {
        Content = post.Content,
        Title = post.Title
    };
    var createdPost = await mediator.Send(createPost);
    return Results.CreatedAtRoute("GetById", new {createdPost.Id}, createdPost);
});


app.Run();
