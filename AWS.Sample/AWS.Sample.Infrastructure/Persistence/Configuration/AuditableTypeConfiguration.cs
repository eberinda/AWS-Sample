using AWS.Sample.Domain.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AWS.Sample.Infrastructure.Persistence.Configuration;

public class AuditableTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : class, IAuditableEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.ToTable(typeof(TEntity).Name);
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).UseIdentityColumn();
        
        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .IsRequired(false);
    }
}