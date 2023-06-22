using MemotecaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MemotecaApi.Data;

public class AppDbContext : DbContext
{
    public DbSet<Pensamento> Pensamentos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
    {
    }
}
