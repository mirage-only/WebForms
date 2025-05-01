using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebForms.Core.Models;

namespace WebForms.Persistence.Configurations;

public class SelectionQuestionAnswerConfiguration : IEntityTypeConfiguration<SelectionQuestionAnswer>
{
    public void Configure(EntityTypeBuilder<SelectionQuestionAnswer> builder)
    {
        builder
            .HasKey(answer => answer.Id);

        builder
            .Property(answer => answer.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(answer => answer.Form)
            .WithMany(form => form.SelectionQuestionAnswers);

        builder
            .HasOne(answer => answer.Question)
            .WithMany(question => question.Answers);
    }
}