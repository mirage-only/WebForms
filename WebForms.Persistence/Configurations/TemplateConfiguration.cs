using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebForms.Core.Models;

namespace WebForms.Persistence.Configurations;

public class TemplateConfiguration : IEntityTypeConfiguration<Template> 
{
    public void Configure(EntityTypeBuilder<Template> builder)
    {
        builder
            .HasKey(template => template.Id);
        
        builder
            .Property(template => template.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasMany(template => template.Tags)
            .WithMany(tag => tag.Templates);

        builder
            .HasOne(template => template.Creator)
            .WithMany(creator => creator.OwnTemplates);
        
        builder
            .HasMany(template => template.SelectionQuestions)
            .WithOne(question => question.Template)
            .HasForeignKey(question => question.TemplateId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        /*builder
            .HasMany(t => t.AccessHolders)
            .WithOne()
            .HasForeignKey("AccessHolderId")
            .IsRequired(false)*/;
    }
}