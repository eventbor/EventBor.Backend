using EventBor.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventBor.Backend.Infrastructure.Database.EntityConfigurations;

internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.FirstName)
            .IsRequired(true)
            .HasMaxLength(50);

        builder
            .Property(p => p.LastName)
            .IsRequired(true)
            .HasMaxLength(50);

        builder
            .Property(p => p.UserName)
            .IsRequired(true)
            .HasMaxLength(100);

        builder
            .HasIndex(p => p.UserName)
            .IsUnique(true);

        builder
            .Property(p => p.PasswordHash)
            .IsRequired(false);

        builder
            .Property(p => p.IsVerified)
            .IsRequired(true);

        builder
            .Property(p => p.IsActive)
            .IsRequired(true);

        builder
            .Property(p => p.PhoneNumber)
            .HasMaxLength(20)
            .IsRequired(false);
    }
}
