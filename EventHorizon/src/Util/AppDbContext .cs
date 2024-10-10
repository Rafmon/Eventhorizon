using EventHorizon.src.Events;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<MemoryAddress> MemoryAddresses { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        TriggerWalCheckpoint();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<MemoryAddress>()
            .HasKey(ma => ma.Address); 

       
        builder.Entity<MemoryAddress>()
            .Property(ma => ma.Address)
            .ValueGeneratedNever(); // Prevent auto-increment for Address
    }

    private void TriggerWalCheckpoint()
    {
        // Use raw SQL to trigger the WAL checkpoint honestly proably not really necessary 
        this.Database.ExecuteSqlRaw("PRAGMA wal_checkpoint(FULL);");
    }
}
