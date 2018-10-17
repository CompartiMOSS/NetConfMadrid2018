using IS4.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace IS4.Api.Data
{
  public class ModelContext: DbContext
  {
    public ModelContext(DbContextOptions<ModelContext> options) : base(options)
    {
      Database.EnsureCreated();
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Competition> Competitions { get; set; }
    public DbSet<Score> Score { get; set; }
    public DbSet<Team> Teams { get; set; }
  }
}
