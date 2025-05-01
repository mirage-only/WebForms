using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebForms.Core.Models;

namespace WebForms.Persistence.Configurations;

public class SelectionQuestionConfiguration : IEntityTypeConfiguration<SelectionQuestion>
{
    public void Configure(EntityTypeBuilder<SelectionQuestion> builder)
    {
        builder
            .HasKey(question => question.Id);

        builder
            .Property(question => question.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(question => question.Template)
            .WithMany(template => template.SelectionQuestions);
        
        builder
            .HasMany(question => question.Answers)
            .WithOne(answer => answer.Question)
            .HasForeignKey(answer => answer.QuestionId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}