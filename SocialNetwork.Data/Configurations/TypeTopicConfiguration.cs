using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Core.Models;

namespace SocialNetwork.Data.Configurations
{
    public class TypeTopicConfiguration : IEntityTypeConfiguration<TypeTopic>
    {
        public void Configure(EntityTypeBuilder<TypeTopic> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(255)
                .IsRequired();

            builder.HasData(
                        new TypeTopic
                        {
                            Id = 1,
                            Description = "Office"
                        },
                        new TypeTopic
                        {
                            Id = 2,
                            Description = "Books"
                        },
                        new TypeTopic
                        {
                            Id = 3,
                            Description = "eLearning"
                        },
                        new TypeTopic
                        {
                            Id = 4,
                            Description = "Innovation"
                        },
                        new TypeTopic
                        {
                            Id = 5,
                            Description = "Others"
                        });

            builder
                .ToTable("TypeTopic");
        }
    }
}
