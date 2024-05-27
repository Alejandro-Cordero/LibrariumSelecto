using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SocialNetwork.Core;
using SocialNetwork.Core.Services;
using SocialNetwork.Data;
using SocialNetwork.Services;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICommentaryService, CommentaryService>();
builder.Services.AddTransient<IRecommendationService, RecommendationService>();
builder.Services.AddTransient<IArticleService, ArticleService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//para sqlite
//builder.Services.AddDbContext<SocialNetworkDbContext>(opciones => opciones.UseSqlite(@"Data Source = C:\Users\RUTA\PROYECTO\SocialNetwork.db"));


//para sqlserver
builder.Services.AddDbContext<SocialNetworkDbContext>(opciones => opciones.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Social Network", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

