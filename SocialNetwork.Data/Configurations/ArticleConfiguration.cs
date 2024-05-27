using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Core.Models;

namespace SocialNetwork.Data.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.Content)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .Property(m => m.CreationDate)
                .IsRequired();

            builder
                .HasOne(x => x.TypeTopic)
                .WithMany(a => a.Articles)
                .HasForeignKey(m => m.TypeTopicId)
                .IsRequired();

            builder
                .HasOne(x => x.User)
                .WithMany(a => a.Articles)
                .HasForeignKey(m => m.UserId)
                .IsRequired();

            builder
                .ToTable("Articles");
        }
    }
}
