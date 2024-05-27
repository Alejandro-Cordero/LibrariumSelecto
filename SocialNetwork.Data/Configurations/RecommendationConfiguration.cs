using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Core.Models;

namespace SocialNetwork.Data.Configurations
{
    public class RecommendationConfiguration : IEntityTypeConfiguration<Recommendation>
    {
        public void Configure(EntityTypeBuilder<Recommendation> builder)
        {
            builder
            .ToTable("Recommendations");
            builder
            .HasKey(m => m.Id);

            builder
                .Property(m => m.Date)
                .IsRequired();

            builder.HasOne(m => m.Article)
                     .WithMany(m => m.Recommendations)
                     .HasForeignKey(m => m.ArticleId)
                     .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
