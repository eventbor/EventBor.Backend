using EventBor.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventBor.Backend.Infrastructure.Database.EntityConfigurations;

internal class UserTelegramInfoEntityConfiguration : IEntityTypeConfiguration<UserTelegramInfo>
{
    public void Configure(EntityTypeBuilder<UserTelegramInfo> builder)
    {
        builder.ToTable("UserTelegramInfos");

        builder.HasKey(p => new { p.UserId, p.TelegramId });

        builder
            .HasOne(p => p.User)
            .WithOne(u => u.UserTelegramInfo)
            .HasForeignKey<UserTelegramInfo>(p => p.UserId);
    }
}
