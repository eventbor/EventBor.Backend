using EventBor.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventBor.Backend.Infrastructure.Database.EntityConfigurations;

internal class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.Name)
            .IsRequired(true)
            .HasMaxLength(100);
    }
}
