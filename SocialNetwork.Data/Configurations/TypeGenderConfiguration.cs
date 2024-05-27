using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Core.Models;

namespace SocialNetwork.Data.Configurations
{
    public class TypeGenderConfiguration : IEntityTypeConfiguration<TypeGender>
    {
        public void Configure(EntityTypeBuilder<TypeGender> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(255)
                .IsRequired();

            builder.HasData(
                        new TypeGender
                        {
                            Id = 1,
                            Description = "Male"
                        },
                        new TypeGender
                        {
                            Id = 2,
                            Description = "Female"
                        },
                        new TypeGender
                        {
                            Id = 3,
                            Description = "Other"
                        });

            builder
                .ToTable("TypeGender");
        }
    }
}
