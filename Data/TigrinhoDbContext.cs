using Microsoft.EntityFrameworkCore;
using LittleTigerV2.Models;

namespace LittleTigerV2.Data
{
    public class TigrinhoDbContext : DbContext
    {
        public TigrinhoDbContext(DbContextOptions<TigrinhoDbContext> options) : base(options) { }
        public DbSet<Aposta> Apostas { get; set; }
    }
}