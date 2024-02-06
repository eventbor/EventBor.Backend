using EventBor.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventBor.Backend.Infrastructure.Database.EntityConfigurations;

internal class EventEntityConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        // Set the table name to "Events"
        builder.ToTable("Events");

        // Configure properties specific to the Event entity
        builder
            .Property(e => e.Title)
            .IsRequired(true)
            .HasMaxLength(255);

        builder
            .Property(e => e.StartedAt)
            .IsRequired(true);

        builder
            .Property(e => e.Duration)
            .IsRequired(true)
            .HasMaxLength(50);

        builder
            .Property(e => e.Format)
            .IsRequired(true)
            .HasConversion<short>(); // Convert enum to string for storage

        builder
            .Property(e => e.Platform)
            .IsRequired(true)
            .HasMaxLength(100);

        builder
            .Property(e => e.Banner)
            .IsRequired(true)
            .HasMaxLength(255);

        builder
            .Property(e => e.Status)
            .IsRequired(true)
            .HasConversion<short>(); // Convert enum to string for storage

        builder
            .Property(e => e.Orginizer)
            .IsRequired(true)
            .HasMaxLength(100);

        builder
            .Property(e => e.Description)
            .IsRequired (true)
            .HasMaxLength(1000);

        builder
            .Property(e => e.Location)
            .IsRequired(true)
            .HasMaxLength(255);

        builder
            .Property(e => e.Address)
            .IsRequired(true)
            .HasMaxLength(255);

        builder
            .Property(e => e.IsPaid)
            .IsRequired(true)
            .IsRequired();

        builder
            .Property(e => e.Price)
            .IsRequired(true)
            .HasColumnType("decimal(18,2)");

        builder
            .Property(e => e.RegistrationLink)
            .IsRequired(true)
            .HasMaxLength(255);

        builder
            .Property(e => e.Capacity)
            .IsRequired(true);

        builder
            .Property(e => e.Contact)
            .IsRequired(true)
            .HasMaxLength(100);

        builder
            .Property(e => e.OfficialPage)
            .IsRequired(true)
            .HasMaxLength(255);
    }
}
