using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebForms.Core.Models;

namespace WebForms.Persistence.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(user => user.Id);
        
        builder
            .Property(user => user.Id)
            .ValueGeneratedOnAdd();
        
        builder
            .HasIndex(user => user.Email)
            .IsUnique();

        builder
            .HasMany(user => user.OwnTemplates)
            .WithOne(template => template.Creator)
            .HasForeignKey(template => template.CreatorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(user => user.ReceivedAnswersForms)
            .WithOne(form => form.FormOwner)
            .HasForeignKey(form => form.FormOwnerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(user => user.FilledForms)
            .WithOne(form => form.FormFiller)
            .HasForeignKey(form => form.FormFillerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}