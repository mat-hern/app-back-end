using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Test.Models;

namespace Test;

public class ApplicationContext: DbContext
{
    IConfiguration _configuration;
    public DbSet<Device> Devices { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Household> Households { get; set; }

    public ApplicationContext(IConfiguration config)
    {
        this._configuration = config;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(_configuration["ConnectionStrings:DefaultConnection"]);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.IpAddress).IsRequired();
        }
            );
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Username).IsRequired();
            entity.Property(e => e.Password).IsRequired();
        }
            );
        modelBuilder.Entity<Household>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.IpAddress).IsRequired();
            }
        );
    }
}