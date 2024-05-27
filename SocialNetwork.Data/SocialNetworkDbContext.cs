using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Models;
using SocialNetwork.Data.Configurations;

namespace SocialNetwork.Data;
public class SocialNetworkDbContext : DbContext
{
    public DbSet<Article> Articles { get; set; }
    public DbSet<TypeGender> TypeGenders { get; set; }
    public DbSet<TypeTopic> TypeTopics { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Commentary> Commentaries { get; set; }
    public DbSet<Recommendation> Recommendations { get; set; }


    public SocialNetworkDbContext(DbContextOptions<SocialNetworkDbContext> options)
        : base(options)
    {
        this.Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .ApplyConfiguration(new TypeGenderConfiguration());

        builder
            .ApplyConfiguration(new TypeTopicConfiguration());

        builder
            .ApplyConfiguration(new UserConfiguration());

        builder
            .ApplyConfiguration(new ArticleConfiguration());

        builder
            .ApplyConfiguration(new CommentaryConfiguration());
        builder
            .ApplyConfiguration(new RecommendationConfiguration());
        builder
            .ApplyConfiguration(new ArticleConfiguration());

        //Realizamos carga inicial en la BD
        Seed(builder);
    }

    public void Seed(ModelBuilder builder)
    {
        //Seed de Users
        var usuariosArray = new User[]
        {
            new User {Id = 1, Login = "Usuario1", Password = "Usuario1_pass", FirstName = "Usuario", LastName = "1", Phone= "123456789", Birthdate = new DateTime(1999, 01, 01), Email = "Usuario1@gmail.com", TypeGenderId = 1},
            new User {Id = 2, Login = "Usuario2", Password = "Usuario2_pass", FirstName = "Usuario", LastName = "2", Phone= "223456789", Birthdate = new DateTime(2002, 02, 01), Email = "Usuario2@gmail.com", TypeGenderId = 2},
            new User {Id = 3, Login = "Usuario3", Password = "Usuario3_pass", FirstName = "Usuario", LastName = "3", Phone= "323456789", Birthdate = new DateTime(1996, 03, 01), Email = "Usuario3@gmail.com", TypeGenderId = 1},
            new User {Id = 4, Login = "Usuario4", Password = "Usuario4_pass", FirstName = "Usuario", LastName = "4", Phone= "423456789", Birthdate = new DateTime(1995, 04, 01), Email = "Usuario4@gmail.com", TypeGenderId = 2},
            new User {Id = 5, Login = "Usuario5", Password = "Usuario5_pass", FirstName = "Usuario", LastName = "5", Phone= "523456789", Birthdate = new DateTime(1988, 05, 01), Email = "Usuario5@gmail.com", TypeGenderId = 3},
            new User {Id = 6, Login = "Usuario6", Password = "Usuario6_pass", FirstName = "Usuario", LastName = "6", Phone= "623456789", Birthdate = new DateTime(2005, 06, 01), Email = "Usuario6@gmail.com", TypeGenderId = 2},
            new User {Id = 7, Login = "Usuario7", Password = "Usuario7_pass", FirstName = "Usuario", LastName = "7", Phone= "723456789", Birthdate = new DateTime(2001, 07, 01), Email = "Usuario7@gmail.com", TypeGenderId = 2},
            new User {Id = 8, Login = "Usuario8", Password = "Usuario8_pass", FirstName = "Usuario", LastName = "8", Phone= "823456789", Birthdate = new DateTime(2000, 08, 01), Email = "Usuario8@gmail.com", TypeGenderId = 1},
            new User {Id = 9, Login = "Usuario9", Password = "Usuario9_pass", FirstName = "Usuario", LastName = "9", Phone= "923456789", Birthdate = new DateTime(1999, 09, 01), Email = "Usuario9@gmail.com", TypeGenderId = 3},
            new User {Id = 10, Login = "Usuario10", Password = "Usuario10_pass", FirstName = "Usuario", LastName = "10", Phone= "023456789", Birthdate = new DateTime(1991, 10, 01), Email = "Usuario10@gmail.com", TypeGenderId = 1}
        };

        foreach (User usuario in usuariosArray)
        {
            builder.Entity<User>().HasData(usuario);
        }

        //Seed de Articles
        var articulosArray = new Article[]
        {
            new Article {Id = 1, Title = "Titulo del primer artículo del Usuario 1", Content= "Este es el contenido del primer artículo del Usuario 1", CreationDate = DateTime.Now, TypeTopicId = 1, UserId = 1},
            new Article {Id = 2, Title = "Titulo del primer artículo del Usuario 2", Content= "Este es el contenido del primer artículo del Usuario 2", CreationDate = DateTime.Now, TypeTopicId = 2, UserId = 2},
            new Article {Id = 3, Title = "Titulo del primer artículo del Usuario 3", Content= "Este es el contenido del primer artículo del Usuario 3", CreationDate = DateTime.Now, TypeTopicId = 3, UserId = 3},
            new Article {Id = 4, Title = "Titulo del primer artículo del Usuario 6", Content= "Este es el contenido del primer artículo del Usuario 6", CreationDate = DateTime.Now, TypeTopicId = 4, UserId = 6},
            new Article {Id = 5, Title = "Titulo del segundo artículo del Usuario 6", Content= "Este es el contenido del segundo artículo del Usuario 6", CreationDate = DateTime.Now, TypeTopicId = 5, UserId = 6},
            new Article {Id = 6, Title = "Titulo del primer artículo del Usuario 8", Content= "Este es el contenido del primer artículo del Usuario 8", CreationDate = DateTime.Now, TypeTopicId = 3, UserId = 8}
        };

        foreach (Article articulo in articulosArray)
        {
            builder.Entity<Article>().HasData(articulo);
        }

        //Seed de Comments
        var comentariosArray = new Commentary[]
        {
            new Commentary {Id = 1, Title = "Titulo de comentario en articulo 1 de usuario 4", Description = "Descripcion de comentario en articulo 1 de usuario 4", Date = DateTime.Now, Rating = 4, UserId = 4, ArticleId = 1},
            new Commentary {Id = 2, Title = "Titulo de comentario en articulo 2 de usuario 3", Description = "Descripcion de comentario en articulo 2 de usuario 3", Date = DateTime.Now, Rating = 2, UserId = 3, ArticleId = 2},
            new Commentary {Id = 3, Title = "Titulo de comentario en articulo 2 de usuario 6", Description = "Descripcion de comentario en articulo 2 de usuario 6", Date = DateTime.Now, Rating = 5, UserId = 6, ArticleId = 2},
            new Commentary {Id = 4, Title = "Titulo de comentario en articulo 4 de usuario 1", Description = "Descripcion de comentario en articulo  4 de usuario 1", Date = DateTime.Now, Rating = 5, UserId = 1, ArticleId = 4},
            new Commentary {Id = 5, Title = "Titulo de comentario en articulo 6 de usuario 10", Description = "Descripcion de comentario en articulo 6 de usuario 10", Date = DateTime.Now, Rating = 2, UserId = 10, ArticleId = 6},
            new Commentary {Id = 6, Title = "Titulo de comentario en articulo 6 de usuario 7", Description = "Descripcion de comentario en articulo 6 de usuario 7", Date = DateTime.Now, Rating = 1, UserId = 7, ArticleId = 6}
        };

        foreach (var comentario in comentariosArray)
        {
            builder.Entity<Commentary>().HasData(comentario);
        }

        //Seed de Recommendations
        var recomendacionesArray = new Recommendation[]
        {
            new Recommendation {Id = 1, Date = DateTime.Now, UserId = 2, ArticleId = 2},
            new Recommendation {Id = 2, Date = DateTime.Now, UserId = 4, ArticleId = 4},
            new Recommendation {Id = 3, Date = DateTime.Now, UserId = 7, ArticleId = 2},
            new Recommendation {Id = 4, Date = DateTime.Now, UserId = 8, ArticleId = 6},
            new Recommendation {Id = 5, Date = DateTime.Now, UserId = 9, ArticleId = 1},
            new Recommendation {Id = 6, Date = DateTime.Now, UserId = 2, ArticleId = 2},
            new Recommendation {Id = 7, Date = DateTime.Now, UserId = 10, ArticleId = 4},
            new Recommendation {Id = 8, Date = DateTime.Now, UserId = 3, ArticleId = 4},
            new Recommendation {Id = 9, Date = DateTime.Now, UserId = 5, ArticleId = 2},
        };

        foreach (var recomendacion in recomendacionesArray)
        {
            builder.Entity<Recommendation>().HasData(recomendacion);
        }

        base.OnModelCreating(builder);
    }
}
