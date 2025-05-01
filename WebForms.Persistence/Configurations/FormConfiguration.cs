using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebForms.Core.Models;

namespace WebForms.Persistence.Configurations;

public class FormConfiguration : IEntityTypeConfiguration<Form> 
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder
            .HasKey(f => f.Id);
        
        builder
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(form => form.Template)
            .WithMany()
            .HasForeignKey(form => form.TemplateId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder
            .HasOne(f => f.FormOwner)
            .WithMany(owner => owner.ReceivedAnswersForms);

        builder
            .HasOne(f => f.FormFiller)
            .WithMany(filler => filler.FilledForms);

        builder
            .HasMany(form => form.SelectionQuestionAnswers)
            .WithOne(answer => answer.Form)
            .HasForeignKey(answer => answer.FormId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
    }
}