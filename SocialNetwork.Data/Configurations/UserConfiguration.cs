using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Core.Models;

namespace SocialNetwork.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Login)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasIndex(x => x.Login)
                .IsUnique();

            builder
                .Property(m => m.Password)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.FirstName)
                .IsRequired(false)
                .HasMaxLength(50);

            builder
                .Property(m => m.LastName)
                .IsRequired(false)
                .HasMaxLength(255);

            builder
                .Property(m => m.Birthdate)
                .IsRequired(false)
                .HasColumnType("date");

            builder
                .Property(x => x.Phone)
                .IsRequired(false)
                .HasMaxLength(10);

            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .HasIndex(x => x.Email)
                .IsUnique();

            builder
                .HasOne(m => m.TypeGender)
                .WithMany(a => a.Users)
                .HasForeignKey(m => m.TypeGenderId)
                .IsRequired(false);

            builder
                .ToTable("Users");
        }
    }
}
