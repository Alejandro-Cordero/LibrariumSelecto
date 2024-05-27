using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Core.Models;

namespace SocialNetwork.Data.Configurations
{
    public class CommentaryConfiguration : IEntityTypeConfiguration<Commentary>
    {
        public void Configure(EntityTypeBuilder<Commentary> builder)
        {
            builder.ToTable("Commentary");


            builder.Property(p => p.Id)
                    .IsRequired();


            builder.Property(p => p.Title)
                    .IsRequired()
                    .HasMaxLength(50);


            builder.Property(p => p.Description)
                    .IsRequired()
                    .HasMaxLength(250);

            builder.Property(p => p.Date)
                    .IsRequired();

            builder.Property(p => p.Rating)
                    .IsRequired();

            builder.HasOne(p => p.Article)
                     .WithMany(p => p.Commentaries)
                     .HasForeignKey(p => p.ArticleId)
                     .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
