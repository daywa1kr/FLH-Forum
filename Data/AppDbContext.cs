using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;

namespace FirstCoreSolution.Models;
public class AppDbContext:DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}

    public DbSet<Post> Posts {get; set;}=null!;
    public DbSet<Answer> Answers {get; set;}=null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){

        modelBuilder.Entity<Post>().HasMany(p=>p.Answers).WithOne(p=>p.Post);

        modelBuilder.Entity<Post>().HasData(
            new Post{
                Id=1,
                Heading="Welcome to FLH Forum",
                Body="This is our first thread",
                Date=DateTime.Now,
                Rating=0
            }
        );
        modelBuilder.Entity<Answer>().HasData(
            new Answer{
                Id=1,
                Body="This is our first answer",
                Date=DateTime.Now,
                Rating=0,
                PostId=1
            }
        );
    }

}