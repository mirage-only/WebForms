using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebForms.Core.Models;

namespace WebForms.Persistence.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder
            .HasKey(tag => tag.Id);

        builder
            .Property(tag => tag.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasMany(tag => tag.Templates)
            .WithMany(template => template.Tags);
    }
}