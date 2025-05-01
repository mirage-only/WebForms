using Microsoft.EntityFrameworkCore;
using WebForms.Core.Models;
using WebForms.Persistence.Configurations;

namespace WebForms.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User?> Users { get; set; }
    
    public DbSet<Template> Templates { get; set; }
    
    public DbSet<Form> Forms { get; set; }
    
    public DbSet<Tag> Tags { get; set; }

    public DbSet<SelectionQuestion> SelectionQuestions { get; set; }
    
    public DbSet<SelectionQuestionAnswer> SelectionQuestionAnswers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        
        modelBuilder.ApplyConfiguration(new TemplateConfiguration());
        
        modelBuilder.ApplyConfiguration(new FormConfiguration());
        
        modelBuilder.ApplyConfiguration(new TagConfiguration());

        modelBuilder.ApplyConfiguration(new SelectionQuestionConfiguration());

        modelBuilder.ApplyConfiguration(new SelectionQuestionAnswerConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}