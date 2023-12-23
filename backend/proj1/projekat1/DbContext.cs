using Microsoft.EntityFrameworkCore;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>options):base(options){}

    public DbSet<UserEntity> Users{get;set;}
    
    public DbSet<BorderCrossEntity> CrossBorders { get; set; }

    public DbSet<TermEntity> Terms {get; set;}

}