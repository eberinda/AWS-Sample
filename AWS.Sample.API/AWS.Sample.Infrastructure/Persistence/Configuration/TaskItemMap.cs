using AWS.Sample.Domain.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWS.Sample.Infrastructure.Persistence.Configuration;

public class TaskItemMap : AuditableTypeConfiguration<TaskItem>
{
    public override void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(e => e.IsComplete)
            .IsRequired()
            .HasDefaultValue(false);
        
        base.Configure(builder);
    }
}