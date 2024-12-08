using concerts.Models;

namespace concerts.Data;

using Microsoft.EntityFrameworkCore;

public class FestivalContext : DbContext
{
    public FestivalContext(DbContextOptions<FestivalContext> options) : base(options) { }

    public DbSet<Concert> Concerts { get; set; }
}

